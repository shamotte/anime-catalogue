using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using CichyStrzalko.AnimeKatalog.UI.ViewModels;

namespace CichyStrzalko.AnimeKatalog.UI.Converters
{
    public class StudioVMToIStudio: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if(value is StudioViewModel s)
            {
                return s;
            }
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is StudioViewModel s)
            {
                return s.Studio;
            }
            return null;
        }
    }
}
