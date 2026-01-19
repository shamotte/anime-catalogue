using CichyStrzalko.AnimeKatalog.INTERFACES;
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

        //CREATES
        IStudio CreateNewStudio(IStudio studio);
        //IProduct CreateNewProduct(IProduct product);
        IAnime CreateNewCPU(IAnime anime);

        //DELETES
        void DeleteStudio(int studioId);
        //void DeleteProduct(int productId);
        void DeleteAnime(int animeId);

        //UPDATES
        void UpdateStudio(IStudio studio);
        void UpdateCPU(IAnime anime);
    }
}
