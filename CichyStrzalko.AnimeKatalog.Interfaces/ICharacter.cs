using CichyStrzalko.AnimeKatalog.Core;

namespace CichyStrzalko.AnimeKatalog.Interfaces
{
    public interface ICharacter
    {
        int Id { get; set; }
        string Name { get; set; }
        IAnime Anime { get; set; }

        string ImageFile { get; set; }
    }
}
