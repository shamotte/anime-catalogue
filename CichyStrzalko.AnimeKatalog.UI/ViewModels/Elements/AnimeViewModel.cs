
using System.ComponentModel;
using System.Windows.Navigation;
using CichyStrzalko.AnimeKatalog.Core;
using CichyStrzalko.AnimeKatalog.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CichyStrzalko.AnimeKatalog.UI.ViewModels
{
    public partial class AnimeViewModel : ObservableObject
    {
        [ObservableProperty]
        private IAnime _Anime;
        public AnimeViewModel(IAnime anime)
        {
            this._Anime = anime;
        }
        public string Genres { get => Anime.Genre.ToString(); }

    }
}
