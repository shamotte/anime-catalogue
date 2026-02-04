using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CichyStrzalko.AnimeKatalog.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CichyStrzalko.AnimeKatalog.UI.ViewModels
{
    public partial class CharacterViewModel : ObservableValidator
    {
        [ObservableProperty]
        private int id;
        [Required]
        [ObservableProperty]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Name can't be empty")]
        private string name;

        [Required]
        [ObservableProperty]
        private IAnime anime;

        //[ObservableProperty]
        //private ICharacter character;
        public CharacterViewModel(ICharacter character) {

            //this.character = character;
        this.id = character.Id;
        this.name = character.Name;
        this.anime = character.Anime;
        }

    }
}
