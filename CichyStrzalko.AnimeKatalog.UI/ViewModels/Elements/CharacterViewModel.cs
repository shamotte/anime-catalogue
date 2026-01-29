using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CichyStrzalko.AnimeKatalog.Interfaces;

namespace CichyStrzalko.AnimeKatalog.UI.ViewModels
{
    public class CharacterViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private ICharacter Character;
        public CharacterViewModel(ICharacter character) {
        this.Character = character;
        }
        public int Id { get => Character.Id;}
        
        public string Name { get => Character.Name; set {
                Character.Name = value;
                SendPropertyChanged(nameof(Name));
            }
        }
        public IAnime Anime {  get => Character.Anime;
        set {
            Character.Anime = value;
            SendPropertyChanged(nameof(Anime));
            }
        }
        private void SendPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
