namespace Hololens.Obeya.Windows10.Converters
{
    using Core.Enums;
    using System;
    using Windows.UI;
    using Windows.UI.Xaml.Data;

    public class TaskStatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            StatusEnum currentValue = (StatusEnum)value;

            switch (currentValue)
            {
                case StatusEnum.TODO:
                    return (Color)App.Current.Resources["ERNIRed"];
                case StatusEnum.WIP:
                    return (Color)App.Current.Resources["ERNIOrange"];
                case StatusEnum.DONE:
                    return (Color)App.Current.Resources["ERNIGreen"];
                default:
                    return (Color)App.Current.Resources["ERNIBlue"];
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null;
        }
    }
}
