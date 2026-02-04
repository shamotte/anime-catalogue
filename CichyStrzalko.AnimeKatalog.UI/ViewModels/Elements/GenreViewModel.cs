using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CichyStrzalko.AnimeKatalog.Core;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CichyStrzalko.AnimeKatalog.UI.ViewModels
{
    public partial class GenreViewModel: ObservableObject
    {
        public GenreViewModel(Genre g, bool selected)
        {  
            selectedGenre = g;
            isSelected = selected;

        }

       
        [ObservableProperty]
        private Genre selectedGenre;
        [ObservableProperty]
        private bool isSelected;
    }
}
