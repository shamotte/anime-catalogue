using CichyStrzalko.AnimeKatalog.Core;

namespace CichyStrzalko.AnimeKatalog.Interfaces
{
    public interface ICharacter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IAnime Anime { get; set; }
    }
}
