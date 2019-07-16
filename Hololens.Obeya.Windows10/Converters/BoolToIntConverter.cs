namespace Hololens.Obeya.Windows10.Converters
{
    using System;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Data;

    public class BoolToIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool valueBool;

            bool.TryParse(value.ToString(), out valueBool);

            if (valueBool)
                return 50;

            return -10;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null;
        }
    }
}
