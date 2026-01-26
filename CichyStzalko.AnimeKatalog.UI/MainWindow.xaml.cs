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
using CichyStrzalko.AnimeKatalog.UI.ViewModels.Lists;

namespace CichyStrzalko.AnimeKatalog.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AnimeListViewModel AnimeListViewModel = new AnimeListViewModel();
        private CharacterListViewModel CharacterListViewModel = new CharacterListViewModel();
        private StudioListViewModel StudioListViewModel = new StudioListViewModel();

        public MainWindow()
        {
            InitializeComponent();
        }
    }
}