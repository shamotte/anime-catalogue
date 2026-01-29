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
        //public AnimeListViewModel AnimeList { get; set; } = new AnimeListViewModel();

        //public ViewModels.AnimeViewModel? SelectedAnime { get; set; } = null;

        //public CharacterListViewModel CharacterList { get; set; } = new CharacterListViewModel();

        //public ViewModels.CharacterViewModel? SelectedCharacter { get; set; } = null;
        //public StudioListViewModel StudioList { get; set; } = new StudioListViewModel();
        //private IConfiguration Configuration;
        //public ViewModels.StudioViewModel? SelectedStudio { get; set; } = null;


        //private BL.BL _BL;

        //public RelayCommand AddCommandStudio { get; }
        //public RelayCommand EditCommandStudio { get; }
        //public RelayCommand DeleteCommandStudio { get; }



        //public RelayCommand AddCommandAnime { get; }
        //public RelayCommand EditCommandAnime { get; }
        //public RelayCommand DeleteCommandAnime { get; }


        //public RelayCommand AddCommandCharacter { get; }
        //public RelayCommand EditCommandCharacter { get; }
        //public RelayCommand DeleteCommandCharacter { get; }

        //TODO: rzeczywiście jakieś funkcje do edycji czy coś
        public MainWindow()
        {
            //TODO: real configuration here

            DataContext = new MainViewModel();
            //AnimeList.Refresh(_BL.GetAllAnime());
            //CharacterList.Refresh(_BL.GetAllCharacters());
            //StudioList.Refresh(_BL.GetAllStudios());
            //DataContext = this;

            //AddCommandStudio = new RelayCommand(AddStudio);
            //EditCommandStudio = new RelayCommand(EditStudio, () => { return SelectedStudio != null; });
            //DeleteCommandStudio = new RelayCommand(DeleteStudio, () => { return SelectedStudio != null; });

            //AddCommandAnime = new RelayCommand(AddAnime);
            //EditCommandAnime = new RelayCommand(EditAnime, () => { return SelectedAnime != null; });
            //DeleteCommandAnime = new RelayCommand(DeleteAnime, () => { return SelectedAnime != null; });

            //AddCommandCharacter = new RelayCommand(AddCharacter);
            //EditCommandCharacter =  new RelayCommand(EditCharacter, () => { return SelectedCharacter != null; });
            //DeleteCommandCharacter = new RelayCommand(DeleteCharacter, () => { return SelectedCharacter != null; });

            InitializeComponent();
        }

        //private void ListAnimeSelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    SelectedAnime = ListAnime.SelectedItem as AnimeViewModel;
        //    if (SelectedAnime != null)
        //    {
        //        DeleteCommandAnime.NotifyCanExecuteChanged();
        //        EditCommandAnime.NotifyCanExecuteChanged();
        //    }
        //}
        //private void ListStudioSelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    SelectedStudio = ListStudio.SelectedItem as StudioViewModel;
        //    if (SelectedStudio != null)
        //    {
        //        DeleteCommandStudio.NotifyCanExecuteChanged();
        //        EditCommandStudio.NotifyCanExecuteChanged();
        //    }
        //}
        //private void ListCharactersSelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    SelectedCharacter = ListCharacters.SelectedItem as CharacterViewModel;
        //    if (SelectedCharacter != null)
        //    {
        //        DeleteCommandCharacter.NotifyCanExecuteChanged();
        //        EditCommandCharacter.NotifyCanExecuteChanged();
        //    }

        //}
        //private void AddStudio()
        //{
        //}

        //private void EditStudio()
        //{
        //    //Console.WriteLine(SelectedStudio..Name);
        //}

        //private void DeleteStudio()
        //{
        //    //Console.WriteLine(SelectedStudio?.Name);
        //}
        //private void AddAnime()
        //{

        //}

        //private void EditAnime()
        //{
        //    //Console.WriteLine(SelectedAnime?.Name);
        //}

        //private void DeleteAnime()
        //{
        //    //Console.WriteLine(SelectedAnime?.Name);
        //}
        //private void AddCharacter()
        //{

        //}

        //private void EditCharacter()
        //{
        //    //Console.WriteLine(SelectedCharacter?.Name);
        //}

        //private void DeleteCharacter()
        //{
        //    //Console.WriteLine(SelectedCharacter?.Name);
        //}
    }
}