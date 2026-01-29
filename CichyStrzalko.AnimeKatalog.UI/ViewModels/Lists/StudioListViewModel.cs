using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CichyStrzalko.AnimeKatalog.Interfaces;
using CichyStrzalko.AnimeKatalog.UI.ViewModels;

namespace CichyStrzalko.AnimeKatalog.UI.ViewModels.Lists
{
    public class StudioListViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<StudioViewModel> StudioList { get; set; } = new ObservableCollection<StudioViewModel>();

        public void Refresh(IEnumerable<IStudio> studios) {
            StudioList.Clear();

            foreach (var studio in studios) { 
            var a = new StudioViewModel(studio);
                StudioList.Add(a);
            }
            
            SendPropertyChanged(nameof(StudioList));
        }


        private void SendPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
