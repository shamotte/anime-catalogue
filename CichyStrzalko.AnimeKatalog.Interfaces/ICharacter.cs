using CichyStrzalko.AnimeKatalog.Core;

namespace CichyStrzalko.AnimeKatalog.Interfaces
{
    public interface ICharacter
    {
        int Id { get; }
        string Name { get; }
        IAnime Anime { get; }
    }
}
