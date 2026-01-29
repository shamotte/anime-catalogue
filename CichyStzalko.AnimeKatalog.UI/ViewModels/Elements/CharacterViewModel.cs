using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CichyStrzalko.AnimeKatalog.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CichyStrzalko.AnimeKatalog.UI.ViewModels
{
    public partial class CharacterViewModel : ObservableObject
    {
        //public event PropertyChangedEventHandler? PropertyChanged;
        [ObservableProperty]
        private ICharacter _Character;
        public CharacterViewModel(ICharacter character) {
        this._Character = character;
        }

        //public int Id { get => Character.Id;}
        
        //public string Name { get => Character.Name; set {
        //        Character.Name = value;
        //        SendPropertyChanged(nameof(Name));
        //    }
        //}
        //public IAnime Anime {  get => Character.Anime;
        //set {
        //    Character.Anime = value;
        //    SendPropertyChanged(nameof(Anime));
        //    }
        //}
        //private void SendPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
