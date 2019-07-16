namespace Hololens.Obeya.Windows10.Converters
{
    using Core.Enums;
    using System;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Data;

    public class OfferStatusToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Visibility valueToReturn = Visibility.Collapsed;
            if (parameter == null)
                valueToReturn = Visibility.Collapsed;

            if (value is OfferStatus)
            {
                OfferStatus offerStatus = (OfferStatus)value;

                if (string.Compare(offerStatus.ToString(), (string)parameter, true) == 0)
                    valueToReturn = Visibility.Visible;
                else
                    valueToReturn = Visibility.Collapsed;
            }

            return valueToReturn;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null;
        }
    }
}
