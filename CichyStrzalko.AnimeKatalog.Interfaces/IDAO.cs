
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CichyStrzalko.AnimeKatalog.Interfaces
{
    public interface IDAO
    {
        //GETERS
        IEnumerable<IStudio> GetAllStudios();
        //IEnumerable<IProduct> GetAllProducts();
        IEnumerable<IAnime> GetAllAnimes();

        IEnumerable<ICharacter> GetAllCharacters();


        //CREATES
        IStudio CreateNewStudio(IStudio studio);
        IAnime CreateNewAnime(IAnime anime);
        ICharacter CreateNewCharacter(ICharacter character);

        //DELETES
        void DeleteStudio(int studioId);
        void DeleteCharacter(int characterId);
        void DeleteAnime(int animeId);

        //UPDATES
        void UpdateStudio(IStudio studio);
        void UpdateAnime(IAnime anime);
        void UpdateCharacter(ICharacter character);
    }
}
