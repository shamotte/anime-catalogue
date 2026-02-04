
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
        [ObservableProperty]
        private IAnime anime;
        [ObservableProperty]
        private int id;
        [ObservableProperty]
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Title can't be empty")]
        private String name;

        [ObservableProperty]
        [Required]
        [StringLength(100, MinimumLength = 1)]
        private DateTime premiere;


        [ObservableProperty]
        [Required]
        private Genre genre;

        [ObservableProperty]
        [Required]
        private StudioViewModel studio;

        [ObservableProperty]
        private int episodes;

        //TODO: image file
        [ObservableProperty]
        private byte[] imageData;

        public AnimeViewModel(IAnime anime)
        {
            this.anime = anime;
            if (anime != null)
            {

                this.id = anime.Id;
                this.name = anime.Name;
                this.premiere = anime.Premiere;
                this.genre = anime.Genre;
                this.studio = new StudioViewModel(anime.Studio);
                this.episodes = anime.Episodes;
                this.imageData = anime.ImageData;
            }


        }
        public string Genres { get => Genre.ToString(); }

        public string DisplayName { get => $"{Id}: {Name} ({Premiere})"; }
        public string DisplayStudio { get => $"{Studio.Id}: {Studio.Name}, {Studio.Address}"; }
    }
}
