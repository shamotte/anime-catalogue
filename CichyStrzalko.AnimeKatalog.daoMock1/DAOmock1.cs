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
                Genre = Genre.Horror
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


        public IAnime CreateNewCPU(IAnime anime)
        {
            throw new NotImplementedException();
        }

        public IStudio CreateNewStudio(IStudio studio)
        {
            throw new NotImplementedException();
        }

        public void DeleteAnime(int animeId)
        {
            throw new NotImplementedException();
        }

        public void DeleteStudio(int studioId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IAnime> GetAllAnimes()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ICharacter> GetAllCharacters()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IStudio> GetAllStudios()
        {
            throw new NotImplementedException();
        }

        public void UpdateCPU(IAnime anime)
        {
            throw new NotImplementedException();
        }

        public void UpdateStudio(IStudio studio)
        {
            throw new NotImplementedException();
        }
    }
}
