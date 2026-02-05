using CichyStrzalko.AnimeKatalog.Core;

namespace CichyStrzalko.AnimeKatalog.Interfaces
{
    public interface ICharacter
    {
        int Id { get; set; }
        string Name { get; set; }
        int AnimeId { get; set; }

        public byte[] ImageData { get; set; }
    }
}
