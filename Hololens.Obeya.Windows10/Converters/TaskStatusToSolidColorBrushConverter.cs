namespace Hololens.Obeya.Windows10.Converters
{
    using Core.Enums;
    using System;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Media;

    public class TaskStatusToSolidColorBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            StatusEnum currentValue = (StatusEnum)value;

            switch (currentValue)
            {
                case StatusEnum.TODO:
                    return (SolidColorBrush)App.Current.Resources["ERNIRedBrush"];
                case StatusEnum.WIP:
                    return (SolidColorBrush)App.Current.Resources["ERNIOrangeBrush"];
                case StatusEnum.DONE:
                    return (SolidColorBrush)App.Current.Resources["ERNIGreenBrush"];
                default:
                    return (SolidColorBrush)App.Current.Resources["ERNIBlueBrush"];
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null;
        }
    }
}
