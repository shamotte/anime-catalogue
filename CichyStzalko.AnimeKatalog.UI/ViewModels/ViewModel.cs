using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CichyStrzalko.AnimeKatalog.UI.ViewModels.Lists;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CichyStrzalko.AnimeKatalog.UI.ViewModels
{
    public partial class ViewModel : ObservableValidator
    {
 
        [ObservableProperty]
        //[NotifyCanExecuteChangedFor(nameof(CanAddStudio))]
        private AnimeViewModel? selectedAnime;

        #region STUDIO
        [ObservableProperty]
        private ObservableCollection<StudioViewModel> studioList = new ObservableCollection<StudioViewModel>();

        private bool CanAddStudio(object parameter)
        {
            return true;
        }
        private bool CanEditStudio(object parameter)
        {
            return true;
        }

        private bool CanDeleteStudio(object parameter) {
            return true;
        }

        [RelayCommand(CanExecute = nameof(CanAddStudio))]
        private void AddStudio()
        {
        }
        [RelayCommand(CanExecute = nameof(CanEditStudio))]
        private void EditStudio()
        {
        }
        [RelayCommand(CanExecute = nameof(CanDeleteStudio))]
        private void DeleteStudio()
        { }
        #endregion
        #region Anime
        [ObservableProperty]
        private ObservableCollection<AnimeViewModel> animeList = new ObservableCollection<AnimeViewModel>();

        private bool CanAddAnime(object parameter)
        {
            return true;
        }
        private bool CanEditAnime(object parameter)
        {
            return true;
        }

        private bool CanDeleteAnime(object parameter)
        {
            return true;
        }

        [RelayCommand(CanExecute = nameof(CanAddAnime))]
        private void AddAnime()
        {

        }

        [RelayCommand(CanExecute = nameof(CanEditAnime))]
        private void EditAnime()
        {

        }

        [RelayCommand(CanExecute = nameof(CanDeleteAnime))]
        private void DeleteAnime() {
        }

        #endregion Anime
        #region Character
        [ObservableProperty]
        private ObservableCollection<CharacterViewModel> characterList = new ObservableCollection<CharacterViewModel>();

        private bool CanAddCharacter(object parameter)
        {
            return true;
        }
        private bool CanEditCharacter(object parameter)
        {
            return true;
        }

        private bool CanDeleteCharacter(object parameter)
        {
            return true;
        }

        [RelayCommand(CanExecute = nameof(CanAddCharacter))]
        private void AddCharacter()
        {

        }

        [RelayCommand(CanExecute = nameof(CanEditCharacter))]
        private void EditCharacter()
        {

        }

        [RelayCommand(CanExecute = nameof(CanDeleteCharacter))]
        private void DeleteCharacter()
        {
        }

        #endregion Character
    }
}