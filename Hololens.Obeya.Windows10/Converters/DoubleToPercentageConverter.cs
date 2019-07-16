using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Hololens.Obeya.Windows10.Converters
{
    public class DoubleToPercentageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var percentage = "-";

            try
            {
                var real = (double)value;
                var normalized = (int)(real * 100);
                percentage = $"{normalized}%";
            }
            finally
            { }

            return percentage;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
