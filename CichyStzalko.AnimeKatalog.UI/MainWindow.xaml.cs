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
        public MainWindow()
        { 
            //TODO: real configuration here
            Configuration = new ConfigurationBuilder().Build();
            _BL = new BL.BL(Configuration);

            AnimeList.Refresh(_BL.GetAllAnime());
            CharacterList.Refresh(_BL.GetAllCharacters());
            StudioList.Refresh(_BL.GetAllStudios());
            DataContext = this;
            InitializeComponent();
        }
    }
}