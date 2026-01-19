using CichyStrzalko.AnimeKatalog.Core;
using CichyStrzalko.AnimeKatalog.Interfaces;
using CichyStrzalko.AnimeKatalog.INTERFACES;
using Microsoft.Extensions.Configuration;
using System.ComponentModel;
using System.Reflection;


namespace CichyStrzalko.AnimeKatalog.BL
{
    public class BL
    {
        private IDAO dao;
        

        public BL(IConfiguration configuration)
        {
            
            string libraryName = configuration["DAOLibraryName"] ?? "";

            if (string.IsNullOrEmpty(libraryName))
                throw new Exception("Brak klucza 'DAOLibraryName' w pliku konfiguracyjnym.");

            LoadLibrary(libraryName, configuration);
        }

        private void LoadLibrary(string libraryName, IConfiguration configuration)
        {
            try
            {
                
                string? dllPath = FindDllPath(libraryName);

                if (dllPath == null)
                    throw new FileNotFoundException($"Nie można odnaleźć pliku {libraryName}.");

                
                Assembly assembly = Assembly.UnsafeLoadFrom(dllPath);

                
                Type? daoType = assembly.GetTypes()
                    .FirstOrDefault(t => typeof(IDAO).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

                if (daoType == null)
                    throw new Exception($"W bibliotece {dllPath} nie znaleziono klasy implementującej IDAO");

                
                 dao = (IDAO)Activator.CreateInstance(daoType)!;
            }
            catch (Exception ex)
            {
                throw new Exception($"Błąd Late Binding (DAO) dla {libraryName}: {ex.Message}");
            }

        }

        private string? FindDllPath(string libraryName)
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string localPath = Path.Combine(baseDir, libraryName);
            if (File.Exists(localPath)) return localPath;

            
            return null;
        }


        
        public IEnumerable<IAnime> GetAllAnime() => dao.GetAllAnimes();

        public IEnumerable<IStudio> GetAllStudios() => dao.GetAllStudios();

        public IEnumerable<ICharacter> GetAllCharacters() => dao.GetAllCharacters();


}
}
