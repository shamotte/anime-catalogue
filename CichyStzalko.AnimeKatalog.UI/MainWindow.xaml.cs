using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CichyStrzalko.AnimeKatalog.UI.ViewModels;
using CichyStrzalko.AnimeKatalog.UI.ViewModels.Lists;
using CichyStrzalko.AnimeKatalog.BL;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Windows.Xps;
using CommunityToolkit.Mvvm.Input;
namespace CichyStrzalko.AnimeKatalog.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public AnimeListViewModel AnimeList { get; set; } = new AnimeListViewModel();
        private ViewModels.AnimeViewModel? _selectedAnime = null;

        public ViewModels.AnimeViewModel? SelectedAnime
        {
            get => _selectedAnime;
            set
            {
                _selectedAnime = value;
                DeleteCommandAnime.NotifyCanExecuteChanged();
                EditCommandAnime.NotifyCanExecuteChanged();
            }
        }

        public CharacterListViewModel CharacterList { get; set; } = new CharacterListViewModel();
        private ViewModels.CharacterViewModel? _selectedCharacter = null;
        public ViewModels.CharacterViewModel? SelectedCharacter
        {
            get => _selectedCharacter;
            set
            {
                _selectedCharacter = value;
                DeleteCommandCharacter.NotifyCanExecuteChanged();
                EditCommandCharacter.NotifyCanExecuteChanged();
            }
        }
        public StudioListViewModel StudioList { get; set; } = new StudioListViewModel();
        private IConfiguration Configuration;
        private ViewModels.StudioVievModel? _selectedStudio = null;
        public ViewModels.StudioVievModel? SelectedStudio
        {
            get => _selectedStudio;
            set
            {
                _selectedStudio = value;
                DeleteCommandStudio.NotifyCanExecuteChanged();
                EditCommandStudio.NotifyCanExecuteChanged();
            }
        }


        private BL.BL _BL;

        public RelayCommand AddCommandStudio { get; }
        public RelayCommand EditCommandStudio { get; }
        public RelayCommand DeleteCommandStudio { get; }



        public RelayCommand AddCommandAnime { get; }
        public RelayCommand EditCommandAnime { get; }
        public RelayCommand DeleteCommandAnime { get; }


        public RelayCommand AddCommandCharacter { get; }
        public RelayCommand EditCommandCharacter { get; }
        public RelayCommand DeleteCommandCharacter { get; }

        //TODO: rzeczywiście jakieś funkcje do edycji czy coś
        public MainWindow()
        { 
            //TODO: real configuration here
            Configuration = new ConfigurationBuilder().Build();
            _BL = new BL.BL(Configuration);

            AnimeList.Refresh(_BL.GetAllAnime());
            CharacterList.Refresh(_BL.GetAllCharacters());
            StudioList.Refresh(_BL.GetAllStudios());
            DataContext = this;

            AddCommandStudio = new RelayCommand(AddStudio);
            EditCommandStudio = new RelayCommand(EditStudio, () => { return SelectedStudio != null; });
            DeleteCommandStudio = new RelayCommand(DeleteStudio, () => { return SelectedStudio != null; });
            
            AddCommandAnime = new RelayCommand(AddAnime);
            EditCommandAnime = new RelayCommand(EditAnime, () => { return SelectedAnime != null; });
            DeleteCommandAnime = new RelayCommand(DeleteAnime, () => { return SelectedAnime != null; });

            AddCommandCharacter = new RelayCommand(AddCharacter);
            EditCommandCharacter =  new RelayCommand(EditCharacter, () => { return SelectedCharacter != null; });
            DeleteCommandCharacter = new RelayCommand(DeleteCharacter, () => { return SelectedCharacter != null; });

            InitializeComponent();
        }

        private void AddStudio()
        {
        }

        private void EditStudio()
        {
            Console.WriteLine(SelectedStudio?.Name);
        }

        private void DeleteStudio()
        {
            Console.WriteLine(SelectedStudio?.Name);
        }
        private void AddAnime()
        {

        }

        private void EditAnime()
        {
            Console.WriteLine(SelectedAnime?.Name);
        }

        private void DeleteAnime()
        {
            Console.WriteLine(SelectedAnime?.Name);
        }
        private void AddCharacter()
        {

        }

        private void EditCharacter()
        {
            Console.WriteLine(SelectedCharacter?.Name);
        }

        private void DeleteCharacter()
        {
            Console.WriteLine(SelectedCharacter?.Name);
        }
    }
}