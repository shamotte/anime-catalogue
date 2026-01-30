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
                Address = "Your Moter",

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
                ImageFile = "\\Images\\DaoMock1\\power.jpg"
            })
            .Cast<IAnime>()
            .ToList();


            characters = Enumerable.Range(0, 10).Select(x =>
            new Character
            {
                
                Name = $"character no {x}",
                Id = x,   
                Anime = animes[rand.Next(0, animeCount)],
                ImageFile = "\\Images\\DaoMock1\\power.jpg"
            })
            .Cast<ICharacter>()
            .ToList();


        }

        

        public IAnime CreateNewAnime()
        {
            return new Anime() { Id = animes.Max(a => a.Id) + 1};
        }

        public ICharacter CreateNewCharacter()
        {
            return new Character() { Id = characters.Max(c => c.Id) + 1 };
        }

        public IStudio CreateNewStudio()
        {
            return new Studio() { Id = studios.Max(s => s.Id) + 1 };
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
            
            animes.RemoveAll(a => a.Id == anime.Id);
            animes.Add(anime);
        }

        public void UpdateCharacter(ICharacter character)
        {
            characters.RemoveAll(c => c.Id == character.Id);
            characters.Add(character);
        }

        public void UpdateStudio(IStudio studio)
        {
               studios.RemoveAll(s => s.Id == studio.Id);
                studios.Add(studio);
        }
    }
}
