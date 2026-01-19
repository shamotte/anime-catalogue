using CichyStrzalko.AnimeKatalog.Core;

namespace CichyStrzalko.AnimeKatalog.INTERFACES
{
    public interface IStudio
    {
        int Id { get; set; }
        string Name { get; set; }
        string Address { get; set; }

        string ImgageFile { get; set; }

    }
}
