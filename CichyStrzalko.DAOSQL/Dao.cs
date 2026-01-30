using CichyStrzalko.DAOSQL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CichyStrzalko.AnimeKatalog.Interfaces;

namespace CichyStrzalko.DAOSQL
{
    public class Dao : IDAO
    {
        private readonly DataContext context;
        
        public Dao()
        {
            context = new DataContext();
            context.Database.Migrate();
        }

        public IAnime CreateNewAnime(IAnime anime)
        {
            return new Anime();
        }

        public ICharacter CreateNewCharacter(ICharacter character)
        {
            return new Character();
        }

        public IStudio CreateNewStudio(IStudio studio)
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
                .Include(a => a.Studio)
                .ToList();
            x.ForEach(a => a.Studio = context.Studios.FirstOrDefault(s => s.Id == a.StudioId)!);
            return x;
        }

        public IEnumerable<ICharacter> GetAllCharacters()
        {
            var x = context.Characters
                .Include(c => c.Anime)
                .ToList();
            x.ForEach(c => c.Anime = context.Animes.FirstOrDefault(a => a.Id == c.AnimeId)!);
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
                    context.SaveChanges();
                }
                a.StudioId = a.Studio.Id;

                context.Animes.Add(a);
            }
            context.SaveChanges();
        }

        public void UpdateCharacter(ICharacter character)
        {
            if (character is Character c)
            {
                var remove = context.Characters.FirstOrDefault(ch => ch.Id == c.Id);
                if (remove != null)
                {
                    context.Characters.Remove(remove);
                    context.SaveChanges();
                }
                c.AnimeId = c.Anime.Id;
                context.Characters.Add(c);
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
                    context.SaveChanges();
                }
                context.Studios.Add(s);
            }
        }
    }
}
