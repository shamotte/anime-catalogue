using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CichyStrzalko.AnimeKatalog.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CichyStrzalko.AnimeKatalog.UI.ViewModels
{
    public partial class CharacterViewModel : ObservableValidator
    {
        [ObservableProperty]
        private ICharacter character;
        [ObservableProperty]
        private int id;
        [Required]
        [ObservableProperty]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Name can't be empty")]
        private string name;

        [Required]
        [ObservableProperty]
        private AnimeViewModel anime;

        [ObservableProperty]
        private Byte[] imageData;
        public CharacterViewModel(ICharacter character) {
            this.character = character;
            this.id = character.Id;
            this.name = character.Name;
            this.anime = new AnimeViewModel(character.Anime);
            this.imageData = character.ImageData;
        }

        public string DisplayName { get => $"{Id}: {Name}"; }
        public string DisplayAnime { get => $"{Anime.Id}: {Anime.Name} ({Anime.Premiere})"; }

        [RelayCommand]
        private void SetImage(object parameter)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                ImageData = File.ReadAllBytes(dialog.FileName);
            }
        }
    }
}
