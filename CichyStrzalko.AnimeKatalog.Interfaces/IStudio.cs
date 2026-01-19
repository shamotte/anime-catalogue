using CichyStrzalko.AnimeKatalog.Core;

namespace CichyStrzalko.AnimeKatalog.Interfaces
{
    public interface IStudio
    {
        int Id { get; }
        string Name { get; }
        string Address { get; }

    }
}
