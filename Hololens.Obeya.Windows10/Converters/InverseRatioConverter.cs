using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Hololens.Obeya.Windows10.Converters
{
    public class InverseRatioConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            double inverse = 0;

            try
            {
                var real = (double)value;

                inverse = 1 - real;
            }
            finally
            { }

            return inverse;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
