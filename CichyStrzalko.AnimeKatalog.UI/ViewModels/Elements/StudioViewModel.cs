using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CichyStrzalko.AnimeKatalog.Interfaces;

namespace CichyStrzalko.AnimeKatalog.UI.ViewModels.Elements
{
    public class StudioVievModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private IStudio Studio;
        public StudioVievModel(IStudio studio) { 
            this.Studio = studio;
        }

        public int Id { get => Studio.Id;}

        public string Name { get => Studio.Name;
            set { Studio.Name = value;
            SendPropertyChanged(nameof(Name));
            }
        }

        public string Address { 
            get => Studio.Address;
            set {
                Studio.Address = value;
                SendPropertyChanged(nameof(Address));
            }
        }
        private void SendPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
