
using System.ComponentModel;


using CichyStrzalko.AnimeKatalog.Core;
using CichyStrzalko.AnimeKatalog.Interfaces;

namespace CichyStrzalko.AnimeKatalog.UI.ViewModels
{
    public class AnimeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private IAnime Anime;

        public AnimeViewModel(IAnime anime)
        {
            this.Anime = anime;
        }
        public int id
        {
            get => Anime.Id;
        }

        public string Name {
            get => Anime.Name;
            set {
            Anime.Name = value;
            SendPropertyChanged(nameof(Name));
            }
        }
        public int Episodes {
            get => Anime.Episodes;
            set
            {
                Anime.Episodes = value;
                SendPropertyChanged(nameof(Episodes));
            }
        }
        public string Premiere
        {
            get => Anime.Premiere;
            set { 
                Anime.Premiere = value;
                SendPropertyChanged(nameof(Premiere));
            }
        }

        public Genre Genre{
            get => Anime.Genre;
            set { Anime.Genre = value;
            SendPropertyChanged(nameof(Genre));}
        }

        public String Genres
        {
            get { return Anime.Genre.ToString(); }
        }


        public IStudio Studio
        {
            get => Anime.Studio;
            set
            {
                Anime.Studio = value;
                SendPropertyChanged(nameof(Studio));
            }
        } 

        public string ImageFile
        {
            get => Anime.ImageFile;
            set {
                Anime.ImageFile = value;
                SendPropertyChanged(nameof (ImageFile));    
            }
        }
         private void SendPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
