using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CichyStrzalko.AnimeKatalog.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CichyStrzalko.AnimeKatalog.UI.ViewModels
{
    public partial class StudioViewModel : ObservableObject
    {

        [ObservableProperty]
        private IStudio studio;
        public StudioViewModel(IStudio studio) { 
            this.studio = studio;
        }
    }
}
