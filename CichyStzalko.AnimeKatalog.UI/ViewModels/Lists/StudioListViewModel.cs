using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CichyStrzalko.AnimeKatalog.Interfaces;

namespace CichyStrzalko.AnimeKatalog.UI.ViewModels.Lists
{
    internal class AnimeListViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<AnimeViewModel> AnimeList { get; set; } = new ObservableCollection<AnimeViewModel>();

        public void Refresh(IEnumerable<IAnime> animes) { 
        AnimeList.Clear();

            foreach (var anime in animes) { 
            var a = new AnimeViewModel(anime);
            AnimeList.Add(a);
            }
            
            SendPropertyChanged(nameof(AnimeList));
        }


        private void SendPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
