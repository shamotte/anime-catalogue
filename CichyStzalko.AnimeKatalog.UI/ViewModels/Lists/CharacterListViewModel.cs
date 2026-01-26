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
    public class CharacterListViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<CharacterViewModel> CharacterList { get; set; } = new ObservableCollection<CharacterViewModel>();

        public void Refresh(IEnumerable<ICharacter> characters) {
            CharacterList.Clear();

            foreach (var character in characters) { 
            var a = new CharacterViewModel(character);
                CharacterList.Add(a);
            }
            
            SendPropertyChanged(nameof(CharacterList));
        }


        private void SendPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
