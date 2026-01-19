using CichyStrzalko.AnimeKatalog.Core;
using CichyStrzalko.AnimeKatalog.INTERFACES;

namespace CichyStrzalko.AnimeKatalog.Interfaces
{
    public interface IAnime
    {
        int Id { get; set; }

        string Name { get; set; }

        int Episodes {  get; set; }

        string Premiere { get; set; }

        Genre Genre { get; set; }

<<<<<<<< HEAD:CichyStrzalko.AnimeKatalog.Interfaces/Anime.cs
========
        IStudio Studio { get; set; }


>>>>>>>> 9d588629a4ccb68f9cdf8c070c3b1afdeec75c00:CichyStrzalko.AnimeKatalog.Interfaces/IAnime.cs
    }
}
