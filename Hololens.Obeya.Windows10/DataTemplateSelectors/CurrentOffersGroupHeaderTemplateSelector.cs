namespace Hololens.Obeya.Windows10.DataTemplateSelectors
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public class CurrentOffersGroupHeaderTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ContratSignedHeader { get; set; }
        public DataTemplate NegoationHeader { get; set; }
        public DataTemplate NoContractHeader { get; set; }
        
        protected override DataTemplate SelectTemplateCore(object item)
        {
            DataTemplate selectedDataTemplate = ContratSignedHeader;



            return selectedDataTemplate;
        }
    }
}
