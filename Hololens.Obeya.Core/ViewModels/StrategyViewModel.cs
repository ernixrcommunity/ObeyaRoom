namespace Hololens.Obeya.Core.ViewModels
{
    using Base;
    using Models;
    using Services.DataService;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class StrategyViewModel : ViewModelBase
    {
        private readonly IDataService dataService;

        private DelegateCommand orderCommand;

        private bool numericOrderOn = true;

        public StrategyViewModel(IDataService dataService) : base()
        {
            this.dataService = dataService;

            Initialize();
        }

        private async void Initialize()
        {
            LoadData();

            // This simulates a tutorial on how to use the order button
            await Task.Delay(1000);
            ExecuteOrderCommand();
            await Task.Delay(1000);
            ExecuteOrderCommand();
        }

        public DelegateCommand OrderCommand
        {
            get { return orderCommand ?? (orderCommand = new DelegateCommand(ExecuteOrderCommand)); }
        }

        public IEnumerable<StrategyItemModel> OverviewItems { get; set; }

        public IEnumerable<StrategyItemModel> CriticalItems { get; set; }

        public IEnumerable<StrategyItemModel> AccomplishedItems { get; set; }

        public string OrderTitle => numericOrderOn ? "123..." : "abc...";

        private void LoadData()
        {
            OverviewItems = this.dataService.GetStrategyItemsData();
            CriticalItems = this.dataService.GetStrategyItemsData();
            AccomplishedItems = this.dataService.GetStrategyItemsData(accomplished: true);
        }

        private void ExecuteOrderCommand()
        {
            if (numericOrderOn)
                OrderNumerically();
            else
                OrderAlphabetically();

            RaisePropertyChanged(nameof(OverviewItems));
            RaisePropertyChanged(nameof(CriticalItems));
            RaisePropertyChanged(nameof(AccomplishedItems));
            
            numericOrderOn = !numericOrderOn;

            RaisePropertyChanged(nameof(OrderTitle));
        }

        private void OrderNumerically()
        {
            OverviewItems = OverviewItems.OrderBy(m => m.Status);
            CriticalItems = CriticalItems.OrderBy(m => m.Status);
            AccomplishedItems = AccomplishedItems.OrderBy(m => m.Status);
        }

        private void OrderAlphabetically()
        {
            OverviewItems = OverviewItems.OrderBy(m => m.Title);
            CriticalItems = CriticalItems.OrderBy(m => m.Title);
            AccomplishedItems = AccomplishedItems.OrderBy(m => m.Title);
        }
    }
}
