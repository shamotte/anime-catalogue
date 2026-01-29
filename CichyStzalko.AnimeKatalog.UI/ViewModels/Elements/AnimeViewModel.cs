
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
        public string Genres { get => _Anime.Genre.ToString(); }
        //public int Id
        //{
        //    get => _Anime.Id;
        //}

        //public string Name {
        //    get => _Anime.Name;
        //    set {
        //        _Anime.Name = value;
        //    //SendPropertyChanged(nameof(Name));
        //    }
        //}
        //public int Episodes {
        //    get => _Anime.Episodes;
        //    set
        //    {
        //        _Anime.Episodes = value;
        //        //SendPropertyChanged(nameof(Episodes));
        //    }
        //}
        //[ObservableProperty]
        //public string Premiere
        //{
        //    get => _Anime.Premiere;
        //    set {
        //        _Anime.Premiere = value;
        //        //SendPropertyChanged(nameof(Premiere));
        //    }
        //}
        //[ObservableProperty]
        //public Genre Genre{
        //    get => _Anime.Genre;
        //    set {
        //        _Anime.Genre = value;
        //    //SendPropertyChanged(nameof(Genre));
        //    }
        //}

        //public String Genres
        //{
        //    get { return _Anime.Genre.ToString(); }
        //}


        //public IStudio Studio
        //{
        //    get => _Anime.Studio;
        //    set
        //    {
        //        _Anime.Studio = value;
        //        //SendPropertyChanged(nameof(Studio));
        //    }
        //} 

        //public string ImageFile
        //{
        //    get => _Anime.ImageFile;
        //    set {
        //        _Anime.ImageFile = value;
        //        //SendPropertyChanged(nameof (ImageFile));    
        //    }
        //}
        // //private void SendPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
