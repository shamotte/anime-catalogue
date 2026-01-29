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
        [ObservableProperty]
        private ICharacter character;
        public CharacterViewModel(ICharacter character) {
        this.character = character;
        }

    }
}
