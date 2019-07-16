namespace Hololens.Obeya.Windows10.Controls
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public sealed partial class BusinessUnitButton : UserControl
    {
        public BusinessUnitButton()
        {
            this.InitializeComponent();

            this.Loaded += BusinessUnitButton_Loaded;
        }

        private void BusinessUnitButton_Loaded(object sender, RoutedEventArgs e)
        {
            this.Loaded -= BusinessUnitButton_Loaded;
            FillAnimation.Begin();
        }
    }
}
