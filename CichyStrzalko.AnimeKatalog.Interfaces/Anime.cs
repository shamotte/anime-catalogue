using CichyStrzalko.AnimeKatalog.Core;


namespace CichyStrzalko.AnimeKatalog.Interfaces
{
    public interface Anime
    {
        int Id { get; set; }

        string Name { get; set; }

        string Studio { get; set; }

        int Episodes {  get; set; }

        string Premiere { get; set; }

        Genre Genre { get; set; }

    }
}
