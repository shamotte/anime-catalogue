using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CichyStrzalko.AnimeKatalog.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CichyStrzalko.AnimeKatalog.UI.ViewModels
{
    public partial class StudioViewModel : ObservableValidator
    {
        [ObservableProperty]
        private int id;
        [Required]
        [ObservableProperty]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Name can't be empty")]
        private string name;

        [Required]
        [ObservableProperty]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Address can't be empty")]
        private string address;

        //[ObservableProperty]
        //private IStudio studio;
        public StudioViewModel(IStudio studio) {
            //this.studio = studio;
            this.id = studio.Id;
            this.name = studio.Name;
            this.address = studio.Address;
        }
        public string DisplayName { get => $"{Id}:{Name}, {Address}"; }
        //public string DisplayName { get => $"{Id}: {Name}, {Address}"; }
    }
}
