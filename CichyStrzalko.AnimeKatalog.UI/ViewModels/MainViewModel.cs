using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CichyStrzalko.AnimeKatalog.BL;
using CichyStrzalko.AnimeKatalog.Core;
using CichyStrzalko.AnimeKatalog.Core.Project.Core.Configuration;
using CichyStrzalko.AnimeKatalog.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;



namespace CichyStrzalko.AnimeKatalog.UI.ViewModels
{
    public partial class MainViewModel: ObservableValidator
    {
        private IConfiguration _configuration;
        private BL.BL _BL;
        public MainViewModel()
        {
            _configuration = AppConfiguration.Configuration;
            _BL = new BL.BL(_configuration);

            RefreshStudios();
            RefreshAnimes();
            RefreshCharacters();

            newStudio = new StudioViewModel( _BL.CreateStudio());
            newAnime = new AnimeViewModel(_BL.CreateAnime());
            newCharacter = new CharacterViewModel(_BL.CreateCharacter());

            foreach (Genre g in Enum.GetValues<Genre>())
            {
                Addeddgenres.Add(new GenreViewModel(g, false));
                editedGenres.Add(new GenreViewModel(g, false));
            }
        }



        [ObservableProperty]
        private ObservableCollection<GenreViewModel> addeddgenres = new ObservableCollection<GenreViewModel>();
        [ObservableProperty]
        private ObservableCollection<GenreViewModel> editedGenres = new ObservableCollection<GenreViewModel>();
        //[ObservableProperty]
        //private ObservableCollection<CheckBox> genreCheckBoxes = new ObservableCollection<CheckBox>();

        #region Studio
        partial void OnSelectedstudioChanged(StudioViewModel? value)
        {
            if(value != null)
            {
                EditedStudio = new StudioViewModel(value.Studio);
            }
        }
        private void RefreshStudios()
        {
            Studios = new ObservableCollection<StudioViewModel>(
                _BL.GetAllStudios().Select(s => new StudioViewModel(s))
            );
            Studios.OrderBy(s => s.Id);
            OnStudioFilterTextChanged(StudioFilterText);
        }

        [ObservableProperty]
        private ObservableCollection<StudioViewModel> studios = new ObservableCollection<StudioViewModel>();

        //Filtratrion
        [ObservableProperty]
        private ObservableCollection<StudioViewModel> filteredStudios = new ObservableCollection<StudioViewModel>();
        [ObservableProperty]
        private string studioFilterText = string.Empty;
        partial void OnStudioFilterTextChanged(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                FilteredStudios = new ObservableCollection<StudioViewModel>(Studios);
            }
            else
            {
                FilteredStudios = new ObservableCollection<StudioViewModel>(
                    Studios.Where(s => s.Name.Contains(value, StringComparison.OrdinalIgnoreCase) ||
                                      s.Address.Contains(value, StringComparison.OrdinalIgnoreCase))
                );

            }
        }



        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(DeleteStudioCommand), nameof(EditStudioCommand))]
        private StudioViewModel? selectedstudio;


        private bool CanDeleteStudio()
        {
            return Selectedstudio != null;
        }
        [RelayCommand(CanExecute = nameof(CanDeleteStudio))]
        private void DeleteStudio()
        {
            if (Selectedstudio != null)
            {
                if (_BL.DeleteStudio(Selectedstudio.Id).succesful)
                {
                    RefreshStudios();
                }
            }
        }

        [ObservableProperty]
        private StudioViewModel? editedStudio;
        private bool CanEditStudio()
        {
            return Selectedstudio != null;
        }

        [ObservableProperty]
        private StudioViewModel? newStudio;
        
        private void ResetNewStudio()
        {
            NewStudio = new StudioViewModel( _BL.CreateStudio());
        }

        private bool CanAddStudio()
        {
            // TODO: Add erros
            return NewStudio != null && NewStudio.HasErrors == false;
        }
        [RelayCommand(CanExecute = nameof(CanAddStudio))]
        private void AddStudio()
        {
            if(NewStudio != null) {
                _BL.UpdateStudio(NewStudio.ToModel());
                NewStudio = new StudioViewModel(_BL.CreateStudio());
                RefreshStudios();
            }
        }

        [RelayCommand(CanExecute = nameof(CanEditStudio))]
        private void EditStudio()
        {
            if(EditedStudio != null)
                _BL.UpdateStudio(EditedStudio.ToModel());
            RefreshStudios();
        }
        #endregion

        #region Anime
        [ObservableProperty]
        private AnimeViewModel? editedAnime;
        partial void OnSelectedanimeChanged(AnimeViewModel? value)
        {
            if(value != null)
            {
                EditedAnime = new AnimeViewModel(value.Anime);
                foreach(GenreViewModel g in EditedGenres)
                {
                    if (EditedAnime.Genre.HasFlag(g.SelectedGenre))
                    {
                        g.IsSelected = true;
                    }
                    else
                    {
                        g.IsSelected = false;
                    }
                }
            }
        }
        private void RefreshAnimes()
        {
            foreach(var g in Addeddgenres)
            {
                g.IsSelected = false;
            }
            foreach (var g in EditedGenres)
            {
                g.IsSelected = false;
            }
            Animes = new ObservableCollection<AnimeViewModel>(
                _BL.GetAllAnime().Select(a => new AnimeViewModel(a))
            );
            Animes.OrderBy(a => a.Id);
            OnAnimeFilterTextChanged(AnimeFilterText);
        }

        [ObservableProperty]
        private ObservableCollection<AnimeViewModel> animes = new ObservableCollection<AnimeViewModel>();

        //Filtratrion
        [ObservableProperty]
        private ObservableCollection<AnimeViewModel> filteredAnimes = new ObservableCollection<AnimeViewModel>();
        [ObservableProperty]
        private string animeFilterText = string.Empty;
        partial void OnAnimeFilterTextChanged(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                FilteredAnimes = new ObservableCollection<AnimeViewModel>(Animes);
            }
            else
            {
                FilteredAnimes = new ObservableCollection<AnimeViewModel>(
                    Animes.Where(a => a.Name.Contains(value, StringComparison.OrdinalIgnoreCase) || a.Genres.Contains(value, StringComparison.OrdinalIgnoreCase) || a.Studio.Name.Contains(value, StringComparison.OrdinalIgnoreCase))
                );
            }
        }


        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(DeleteAnimeCommand), nameof(EditAnimeCommand))]
        private AnimeViewModel? selectedanime;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddAnimeCommand))]
        private AnimeViewModel? newAnime;
        private bool CanAddAnime()
        {
            //return NewAnime != null && !NewAnime.HasErrors;
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
            _BL.UpdateAnime(NewAnime.ToModel());
            NewAnime = new AnimeViewModel(_BL.CreateAnime());
            RefreshAnimes();
        }
        [RelayCommand(CanExecute = nameof(CanDeleteAnime))]
        private void DeleteAnime()
        {
            if(Selectedanime != null)
            {
                if (_BL.DeleteAnime(Selectedanime.Id).succesful)
                {
                    RefreshAnimes();
                }
              
            }
        }
        [RelayCommand(CanExecute = nameof(CanEditAnime))]
        private void EditAnime()
        {
            if (EditedAnime != null)
                foreach(GenreViewModel g in EditedGenres)
                {
                    if (g.IsSelected)
                    {
                        EditedAnime.Genre |= g.SelectedGenre;

                    }
                }
                _BL.UpdateAnime(EditedAnime.ToModel());
                RefreshAnimes();
        }
        #endregion

        #region Character
        [ObservableProperty]
        private CharacterViewModel? editedCharacter;
        partial void OnSelectedcharacterChanged(CharacterViewModel? value)
        {
            if (value != null)
            {
                EditedCharacter = new CharacterViewModel(value.Character);
            }
        }

        private void RefreshCharacters()
        {
            Characters = new ObservableCollection<CharacterViewModel>(
                _BL.GetAllCharacters().Select(c => new CharacterViewModel(c))
            );
            Characters.OrderBy(c => c.Id);
            OnCharactersFilterTextChanged(CharactersFilterText);
        }

        [ObservableProperty]
        private ObservableCollection<CharacterViewModel> characters = new ObservableCollection<CharacterViewModel>();

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(DeleteCharacterCommand), nameof(EditCharacterCommand))]
        private CharacterViewModel? selectedcharacter;

        //Filtratrion
        [ObservableProperty]
        private ObservableCollection<CharacterViewModel> filteredCharacters = new ObservableCollection<CharacterViewModel>();
        [ObservableProperty]
        private string charactersFilterText = string.Empty;
        partial void OnCharactersFilterTextChanged(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                FilteredCharacters = new ObservableCollection<CharacterViewModel>(Characters);
            }
            else
            {
                FilteredCharacters = new ObservableCollection<CharacterViewModel>(
                    Characters.Where(c => c.Name.Contains(value, StringComparison.OrdinalIgnoreCase) ||
                                      c.Anime.Name.Contains(value, StringComparison.OrdinalIgnoreCase))
                );
            }
        }

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddCharacterCommand), nameof(EditCharacterCommand))]
        private CharacterViewModel? newCharacter;
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
            _BL.UpdateCharacter(NewCharacter.ToModel());
            NewCharacter = new CharacterViewModel(_BL.CreateCharacter());
            RefreshCharacters();

        }
        [RelayCommand(CanExecute = nameof(CanDeleteCharacter))]
        private void DeleteCharacter()
        {
            if (Selectedcharacter != null)
            {
                if (_BL.DeleteCharacter(Selectedcharacter.Id).succesful)
                {
                    RefreshCharacters();
                }
            }
        }
        [RelayCommand(CanExecute = nameof(CanEditCharacter))]
        private void EditCharacter()
        {
            if (EditedCharacter != null)
            {
                _BL.UpdateCharacter(EditedCharacter.ToModel());
                RefreshCharacters();
            }
        }
        #endregion
    }
}
