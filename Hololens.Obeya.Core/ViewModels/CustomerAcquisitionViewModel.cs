namespace Hololens.Obeya.Core.ViewModels
{
    using System.Linq;
    using Enums;
    using Hololens.Obeya.Core.ViewModels.Base;
    using Models;
    using Services.DataService;
    using System.Collections.ObjectModel;
    using System.Collections.Generic;

    public class CustomerAcquisitionViewModel : ViewModelBase
    {
        private readonly IDataService dataService;
        private IEnumerable<GroupedOffers> currentOffers;        
        private ObservableCollection<string> opportunities;
        private ObservableCollection<string> requests;
        private ObservableCollection<string> keyAccounts;


        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerAcquisitionViewModel"/> class.
        /// </summary>
        /// <param name="dataService">The data service.</param>
        public CustomerAcquisitionViewModel(IDataService dataService)
        {
            this.dataService = dataService;
            var customerAcquisitionData = dataService.GetCustomerAcquisitionData();
            Opportunities = new ObservableCollection<string>(customerAcquisitionData.Opportunities);
            Requests = new ObservableCollection<string>(customerAcquisitionData.Requests);
            KeyAccounts = new ObservableCollection<string>(customerAcquisitionData.KeyAccounts);

            currentOffers =
            from item in customerAcquisitionData.CurrentOffers
            group item by item.Status into countryGroup
            select new GroupedOffers(countryGroup)
            {
                Group = countryGroup.Key
            };

        }


        public IEnumerable<GroupedOffers> CurrentOffers
        {
            get { return this.currentOffers; }
            set
            {
                this.currentOffers = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<string> Opportunities
        {
            get { return this.opportunities; }
            set
            {
                opportunities = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<string> Requests
        {
            get { return this.requests; }
            set
            {
                requests = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<string> KeyAccounts
        {
            get { return this.keyAccounts; }
            set
            {
                keyAccounts = value;
                RaisePropertyChanged();
            }
        }
    }

    public class GroupedOffers : ObservableCollection<CurrentOfferModel>
    {
        public GroupedOffers(IEnumerable<CurrentOfferModel> items) :base(items)
        {
        }
        public OfferStatus Group { get; set; }
    }
}
