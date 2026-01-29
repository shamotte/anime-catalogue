using CichyStrzalko.AnimeKatalog.Core;
using CichyStrzalko.AnimeKatalog.Interfaces;

namespace CichyStrzalko.AnimeKatalog.Interfaces
{
    public interface IAnime
    {
        int Id { get; set; }

        string Name { get; set; }

        int Episodes {  get; set; }

        string Premiere { get; set; }

        Genre Genre { get; set; }

        IStudio Studio { get; set; }

        string ImageFile { get; set; }
    }
}
