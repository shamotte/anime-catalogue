using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CichyStrzalko.AnimeKatalog.BL;
using CommunityToolkit.Mvvm.ComponentModel;
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

        #endregion

        #region Anime
        [ObservableProperty]
        private ObservableCollection<AnimeViewModel> animes = new ObservableCollection<AnimeViewModel>();

        #endregion

        #region Character
        [ObservableProperty]
        private ObservableCollection<CharacterViewModel> characters = new ObservableCollection<CharacterViewModel>();

        #endregion
    }
}
