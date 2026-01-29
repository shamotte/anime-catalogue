using CichyStrzalko.AnimeKatalog.Core;
using CichyStrzalko.AnimeKatalog.Interfaces;
using Microsoft.Extensions.Configuration;
using System.ComponentModel;
using System.Reflection;

using CichyStrzalko.AnimeKatalog.daoMock1;
namespace CichyStrzalko.AnimeKatalog.BL
{
    public class BL
    {
        private IDAO dao;
        

        public BL(IConfiguration configuration)
        {
            //TODO: change to correct form
            //dao = new 
            //string libraryName = configuration["DAOLibraryName"] ?? "";
            dao = new DAOmock1();
            //if (string.IsNullOrEmpty(libraryName))
            //    throw new Exception("Brak klucza 'DAOLibraryName' w pliku konfiguracyjnym.");

            //LoadLibrary(libraryName, configuration);
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


        #region ANIMES
        public IEnumerable<IAnime> GetAllAnime() => dao.GetAllAnimes();

        public IAnime GetAnimeByID(int id) => GetAllAnime().First(a => a.Id == id);

        public IEnumerable<IAnime> GetAnimesByStudioID(int studioId) => GetAllAnime().Where(a => a.Studio.Id == studioId);

        public OperationResponse<bool> DeleteAnime(int animeId)
        {
            if (GetAllCharacters().Any(c => c.Anime.Id == animeId))
            {
                return new OperationResponse<bool>
                {
                    value = false,
                    message = "Nie można usunąć anime, ponieważ istnieją postacie z nim powiązane.",
                    succesful = false
                };
            }

            dao.DeleteAnime(animeId);
            return new OperationResponse<bool>
            {
                value = true,
                message = "Anime zostało usunięte.",
                succesful = false
            };
        }


        public IEnumerable<IAnime> GetAnimesByTitle(string titlePart) =>
            GetAllAnime().Where(a => a.Name.Contains(titlePart));

        public IEnumerable<IAnime> GetAnimeByCategory(Genre genre) =>
            GetAllAnime().Where(a => (a.Genre & genre) == genre);



        #endregion

        #region STUDIOS
        public IEnumerable<IStudio> GetAllStudios() => dao.GetAllStudios();
        public IStudio GetStudioByID(int id) => GetAllStudios().First(a => a.Id == id);

        public OperationResponse<bool> DeleteStudio(int studioId)
        {
            if (GetAllAnime().Any(a => a.Studio.Id == studioId))
            {
                return new OperationResponse<bool>
                {
                    value = false,
                    message = "Nie można usunąć studia, ponieważ istnieją anime z nim powiązane.",
                    succesful = false
                };
            }
            dao.DeleteStudio(studioId);
            return new OperationResponse<bool>
            {
                value = true,
                message = "Studio zostało usunięte.",
                succesful = true
            };
        }





        #endregion

        #region Characters

        public IEnumerable<ICharacter> GetAllCharacters() => dao.GetAllCharacters();
        public ICharacter GetCharacterByID(int id) => GetAllCharacters().First(a => a.Id == id);

        public IEnumerable<ICharacter> GetCharactersByAnimeID(int animeId) => GetAllCharacters().Where(c => c.Anime.Id == animeId);
        public OperationResponse<bool> DeleteCharacter(int characterId)
        {
            dao.DeleteCharacter(characterId);

            return new OperationResponse<bool>
            {
                value = true,
                message = "Postać została usunięta.",
                succesful = true
            };


        }

        #endregion

    }
}
