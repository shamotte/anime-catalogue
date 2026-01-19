namespace CichyStrzalko.AnimeKatalog.Core
{
    [Flags]
    public enum Genre
    {
        Comedy = 1 << 0,
        Horror = 1 << 1,
        SliceOfLife = 1 << 2,
        Action = 1 << 3,
        Isekai = 1 << 4,
        Drama = 1 << 5,
        Cryminal = 1 << 6,
        ScienceFiction = 1 << 7,
        Fantasy = 1 << 8,


    }
}
