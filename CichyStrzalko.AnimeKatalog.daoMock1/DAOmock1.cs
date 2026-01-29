using System.Data;
using CichyStrzalko.AnimeKatalog.Interfaces;
using CichyStrzalko.AnimeKatalog.Core;


namespace CichyStrzalko.AnimeKatalog.daoMock1
{
    public class DAOmock1 : IDAO
    {
        private List<IAnime> animes;
        private List<ICharacter> characters;
        private List<IStudio> studios;

        public DAOmock1() {

            var studioCout = 5;



            var rand = new Random();


            studios = Enumerable.Range(0, studioCout).Select(x =>
            new Studio
            {
                
                Name = $"studio no {x}",
                Id = x,
                Address = "Your Moter"
                
            })
            .Cast<IStudio>()
            .ToList();

            var animeCount = 10;
            animes = Enumerable.Range(0, animeCount).Select(x =>
            new Anime {
                Episodes = rand.Next(1, 1000),
                Name = $"anime no {x}",
                Id = x,
                Premiere = "11.9.2001",
                Genre = Genre.Horror | Genre.SliceOfLife,
                Studio = studios[rand.Next(0, studioCout)],
                ImageFile = ""
            })
            .Cast<IAnime>()
            .ToList();


            characters = Enumerable.Range(0, 10).Select(x =>
            new Character
            {
                
                Name = $"character no {x}",
                Id = x,   
                Anime = animes[rand.Next(0, animeCount)],
            })
            .Cast<ICharacter>()
            .ToList();


        }

        

        public IAnime CreateNewAnime(IAnime anime)
        {
            animes.Add(anime);
            return anime;
        }

        public ICharacter CreateNewCharacter(ICharacter character)
        {
            characters.Add(character);
            return character;
        }

        public IStudio CreateNewStudio(IStudio studio)
        {
            studios.Add(studio);
            return studio;
        }

        public void DeleteAnime(int animeId)
        {
            animes.RemoveAll(a => a.Id == animeId);
        }

        public void DeleteCharacter(int characterId)
        {
            characters.RemoveAll(c => c.Id == characterId);
        }

        public void DeleteStudio(int studioId)
        {
            studios.RemoveAll(s => s.Id == studioId);
        }

        public IEnumerable<IAnime> GetAllAnimes()
        {
            return animes;
        }

        public IEnumerable<ICharacter> GetAllCharacters()
        {
            return characters;
        }

        public IEnumerable<IStudio> GetAllStudios()
        {
            return studios;
        }

        public void UpdateAnime(IAnime anime)
        {
            animes.Where(a => a.Id == anime.Id).ToList().ForEach(a =>
            {
                a.Name = anime.Name;
                a.Episodes = anime.Episodes;
                a.Genre = anime.Genre;
                a.Premiere = anime.Premiere;
                a.Studio = anime.Studio;
                a.ImageFile = anime.ImageFile;
            });
        }

        public void UpdateCharacter(ICharacter character)
        {
            characters.Where(c => c.Id == character.Id).ToList().ForEach(c =>
            {
                c.Name = character.Name;
                c.Anime = character.Anime;
            });
        }

        public void UpdateStudio(IStudio studio)
        {
            studios.Where(s => s.Id == studio.Id).ToList().ForEach(s =>
            {
                s.Name = studio.Name;
                s.Address = studio.Address;
            });
        }
    }
}
