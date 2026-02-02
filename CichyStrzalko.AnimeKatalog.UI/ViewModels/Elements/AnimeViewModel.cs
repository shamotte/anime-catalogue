
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Windows.Navigation;
using CichyStrzalko.AnimeKatalog.Core;
using CichyStrzalko.AnimeKatalog.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CichyStrzalko.AnimeKatalog.UI.ViewModels
{
    public partial class AnimeViewModel : ObservableValidator
    {
        //[ObservableProperty]
        //private IAnime _Anime;
        [ObservableProperty]
        private int id;
        [ObservableProperty]
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Title can't be empty")]
        private String name;

        [ObservableProperty]
        [Required]
        [StringLength(100, MinimumLength = 1)]
        private String premiere;


        [ObservableProperty]
        [Required]
        private Genre genre;

        [ObservableProperty]
        [Required]
        private IStudio studio;

        [ObservableProperty]
        private int episodes;

        //TODO: image file

        public AnimeViewModel(IAnime anime)
        {
            //this._Anime = anime;

            this.name = anime.Name;
            this.premiere = anime.Premiere;
            this.genre = anime.Genre;
            this.studio = anime.Studio;
            this.episodes = anime.Episodes;


        }
        public string Genres { get => Genre.ToString(); }

    }
}
