using CichyStrzalko.AnimeKatalog.Interfaces;
using CichyStrzalko.DAOSQL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Graph.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CichyStrzalko.DAOSQL
{
    public class Dao : IDAO
    {
        private readonly DataContext context;

        private const string DatabaseName = "catalog.db";

        public Dao()
        {
            var options = CreateOptions();
            context = new DataContext(options);
            context.Database.Migrate();
        }
        private static string GetConnectionString()
        {
            var appDataPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Catalog");

            Directory.CreateDirectory(appDataPath);

            var dbPath = Path.Combine(appDataPath, DatabaseName);
            return $"Data Source={dbPath}";
        }

        private static DbContextOptions<DataContext> CreateOptions()
        {
            var builder = new DbContextOptionsBuilder<DataContext>();
            builder.UseSqlite(GetConnectionString());
            return builder.Options;
        }

        public IAnime CreateNewAnime()
        {
            return new Anime();
        }

        public ICharacter CreateNewCharacter()  
        {
            return new Character();
        }

        public IStudio CreateNewStudio()
        {
            return new Studio();
        }

        public void DeleteAnime(int animeId)
        {
            var remove = context.Animes.FirstOrDefault(a => a.Id == animeId);
            if (remove != null)
            {
                context.Animes.Remove(remove);
                context.SaveChanges();
            }

        }

        public void DeleteCharacter(int characterId)
        {
            var remove = context.Characters.FirstOrDefault(c => c.Id == characterId);
            if (remove != null)
            {
                context.Characters.Remove(remove);
                context.SaveChanges();
            }
        }

        public void DeleteStudio(int studioId)
        {
            var remove = context.Studios.FirstOrDefault(s => s.Id == studioId);
            if (remove != null)
            {
                context.Studios.Remove(remove);
                context.SaveChanges();
            }
        }

        public IEnumerable<IAnime> GetAllAnimes()
        {
            var x = context.Animes
                .ToList();
            
            return x;
        }

        public IEnumerable<ICharacter> GetAllCharacters()
        {
            var x = context.Characters
                .ToList();
            
            return x;
        }

        public IEnumerable<IStudio> GetAllStudios()
        {
            return context.Studios.ToList();
        }

        public void UpdateAnime(IAnime anime)
        {
            if (anime is Anime a)
            {

                var remove = context.Animes.FirstOrDefault(an => an.Id == a.Id);
                if (remove != null)
                {
                    context.Animes.Remove(remove);
                    
                }
                if(a.ImageData == null)
                {
                    a.ImageData = Array.Empty<byte>();
                }


                context.Animes.Add(a);
                context.SaveChanges();
            }
        }

        public void UpdateCharacter(ICharacter character)
        {
            if (character is Character c)
            {
                var remove = context.Characters.FirstOrDefault(ch => ch.Id == c.Id);
                if (remove != null)
                {
                    context.Characters.Remove(remove);
                }

                if(c.ImageData == null)
                {
                    c.ImageData = Array.Empty<byte>();
                }

                context.Characters.Add(c);
                context.SaveChanges();
            }
        }

        public void UpdateStudio(IStudio studio)
        {
            if (studio is Studio s)
            {
                var remove = context.Studios.FirstOrDefault(st => st.Id == s.Id);
                if (remove != null)
                {
                    context.Studios.Remove(remove);
                }
                context.Studios.Add(s);
                context.SaveChanges();
            }
        }
    }
}
