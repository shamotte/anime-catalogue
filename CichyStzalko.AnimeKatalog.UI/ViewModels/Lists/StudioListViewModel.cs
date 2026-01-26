using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CichyStrzalko.AnimeKatalog.Interfaces;
using CichyStrzalko.AnimeKatalog.UI.ViewModels.Elements;

namespace CichyStrzalko.AnimeKatalog.UI.ViewModels.Lists
{
    public class StudioListViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<StudioVievModel> StudioList { get; set; } = new ObservableCollection<StudioVievModel>();

        public void Refresh(IEnumerable<IStudio> studios) {
            StudioList.Clear();

            foreach (var studio in studios) { 
            var a = new StudioVievModel(studio);
                StudioList.Add(a);
            }
            
            SendPropertyChanged(nameof(StudioList));
        }


        private void SendPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
