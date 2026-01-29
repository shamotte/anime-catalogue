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
using System.CodeDom.Compiler;
namespace CichyStrzalko.AnimeKatalog.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public AnimeListViewModel AnimeList { get; set; } = new AnimeListViewModel();

        public CharacterListViewModel CharacterList { get; set; } = new CharacterListViewModel();
        public StudioListViewModel StudioList { get; set; } = new StudioListViewModel();
        private IConfiguration Configuration;


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

        public MainWindow(ViewModel viewModel)
        {
            //TODO: real configuration here
            Configuration = new ConfigurationBuilder().Build();
            _BL = new BL.BL(Configuration);

            DataContext = viewModel;

            InitializeComponent();
        }
    }
}