namespace Hololens.Obeya.Windows10.Converters
{
    using System;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Media;

    public class DoubleToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var doubleValue = 0.0;

            Double.TryParse(value.ToString(), out doubleValue);

            if (doubleValue < 0.31)
                return (SolidColorBrush)App.Current.Resources["ERNIRedBrush"];
            else if (doubleValue < 0.61)
                return (SolidColorBrush)App.Current.Resources["ERNIOrangeBrush"];
            else
                return (SolidColorBrush)App.Current.Resources["ERNIGreenBrush"];
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null;
        }
    }
}
