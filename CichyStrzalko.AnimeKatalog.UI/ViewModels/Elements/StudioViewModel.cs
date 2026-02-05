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

        //[NotifyDataErrorInfo]
        //[ObservableProperty]
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Name can't be empty")]
        public string Name {
            get => studio.Name;
            set
            {
                if (value != studio.Name)
                {
                studio.Name = value;
                ValidateProperty(value, nameof(Name));
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(DisplayName));
                }
            }


        }



        //[NotifyDataErrorInfo]
        //[ObservableProperty]
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Address can't be empty")]
        public string Address {
            get => studio.Address;
            set
            {
                studio.Address = value;
                ValidateProperty(value, nameof(Address));
                OnPropertyChanged(nameof(Address));
            }
        }


        private IStudio studio;
        public IStudio Studio => studio;
        public StudioViewModel(IStudio studio) {
            this.studio = studio;
            if(studio != null) {
                this.id = studio.Id;
                this.Name = studio.Name;
                this.Address = studio.Address;
                ValidateAllProperties();
            }
        }
        public string DisplayName { get => $"{Id}: {Name}, {Address}"; }

        public IStudio ToModel()
        {
            studio.Id = Id;
            studio.Name = Name;
            studio.Address = Address;
            return studio;
        }

        public void copyFrom(StudioViewModel s)
        {
            Id = s.Id;
            Name = s.Name;
            Address = s.Address;
            //studio = ToModel();
        }
        public void CheckValidity()
        {
            ValidateAllProperties();
        }
    }
}
