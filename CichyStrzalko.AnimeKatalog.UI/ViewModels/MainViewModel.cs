using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CichyStrzalko.AnimeKatalog.BL;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Configuration;

namespace CichyStrzalko.AnimeKatalog.UI.ViewModels
{
    public partial class MainViewModel: ObservableValidator
    {
        private IConfiguration _configuration;
        private BL.BL _BL;
        public MainViewModel()
        {
            _configuration = new ConfigurationBuilder().Build();
            _BL = new BL.BL(_configuration);

            studios = new ObservableCollection<StudioViewModel>(
                _BL.GetAllStudios().Select(s => new StudioViewModel(s))
            );
            animes = new ObservableCollection<AnimeViewModel>(
                _BL.GetAllAnime().Select(a => new AnimeViewModel(a))
            );
            characters = new ObservableCollection<CharacterViewModel>(
                _BL.GetAllCharacters().Select(c => new CharacterViewModel(c))
            );

        }

        #region Studio

        
        [ObservableProperty]
        private ObservableCollection<StudioViewModel> studios = new ObservableCollection<StudioViewModel>();

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(DeleteStudioCommand))]
        private StudioViewModel? selectedstudio;

        private bool CanAddStudio()
        {
            // Implementation for determining if a studio can be added
            return true;
        }

        private bool CanDeleteStudio()
        {
            return Selectedstudio != null;
        }

        private bool CanEditStudio()
        {
            return Selectedstudio != null;
        }
        [RelayCommand(CanExecute = nameof(CanAddStudio))]
        private void AddStudio()
        {
            // Implementation for adding a studio
        }
        [RelayCommand(CanExecute = nameof(CanDeleteStudio))]
        private void DeleteStudio()
        {
            if (Selectedstudio != null)
            {
                _BL.DeleteStudio(Selectedstudio.Studio.Id);
                Studios.Remove(Selectedstudio);
            }
        }

        [RelayCommand(CanExecute = nameof(CanEditStudio))]
        private void EditStudio()
        {
            // Implementation for editing a studio
        }
        #endregion

        #region Anime
        [ObservableProperty]
        private ObservableCollection<AnimeViewModel> animes = new ObservableCollection<AnimeViewModel>();
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(DeleteAnimeCommand))]
        private AnimeViewModel? selectedanime;

        private bool CanAddAnime()
        {
            // Implementation for determining if an anime can be added
            return true;
        }

        private bool CanDeleteAnime()
        {
            return Selectedanime != null;
        }

        private bool CanEditAnime()
        {
            return Selectedanime != null;
        }

        [RelayCommand(CanExecute = nameof(CanAddAnime))]
        private void AddAnime()
        {
            // Implementation for adding an anime
        }
        [RelayCommand(CanExecute = nameof(CanDeleteAnime))]
        private void DeleteAnime()
        {
            if(Selectedanime != null)
            {
                _BL.DeleteAnime(Selectedanime.Anime.Id);
                Animes.Remove(Selectedanime);
            }
        }
        [RelayCommand(CanExecute = nameof(CanEditAnime))]
        private void EditAnime()
        {
            // Implementation for editing an anime
        }
        #endregion

        #region Character
        [ObservableProperty]
        private ObservableCollection<CharacterViewModel> characters = new ObservableCollection<CharacterViewModel>();

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(DeleteCharacterCommand))]
        private CharacterViewModel? selectedcharacter;

        private bool CanAddCharacter()
        {
            // Implementation for determining if a character can be added
            return true;
        }
        private bool CanDeleteCharacter()
        {
            return Selectedcharacter != null;
        }
        private bool CanEditCharacter()
        {
            return Selectedcharacter != null;
        }
        [RelayCommand(CanExecute = nameof(CanAddCharacter))]
        private void AddCharacter()
        {
            // Implementation for adding a character
        }
        [RelayCommand(CanExecute = nameof(CanDeleteCharacter))]
        private void DeleteCharacter()
        {
            if (Selectedcharacter != null)
            {
                _BL.DeleteCharacter(Selectedcharacter.Character.Id);
                Characters.Remove(Selectedcharacter);
            }
        }
        [RelayCommand(CanExecute = nameof(CanEditCharacter))]
        private void EditCharacter()
        {
            // Implementation for editing a character
        }
        #endregion
    }
}
