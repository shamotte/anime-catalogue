using CichyStrzalko.AnimeKatalog.Core;

namespace CichyStrzalko.AnimeKatalog.Interfaces
{
    public interface IStudio
    {
        int Id { get; set; }
        string Name { get; set; }
        string Address { get; set; }

    }
}
