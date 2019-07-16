namespace Hololens.Obeya.Core.ViewModels
{
    using Base;
    using Models;
    using Services.DataService;
    using Services.MultiWindowService;
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    /// <summary>
    /// Workforce viewmodel
    /// </summary>
    public class WorkforceViewModel : ViewModelBase
    {
        private readonly IDataService dataService;

        private DelegateCommand goBackCommand;

        private BusinessUnitModel businessUnits = new BusinessUnitModel();
        private BusinessUnitModel selectedBusinessUnits = new BusinessUnitModel();

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="multiWindowService">Service to control other windows in app</param>
        /// <param name="dataService">Service for getting fake data</param>
        public WorkforceViewModel(IDataService dataService) : base()
        {
            this.dataService = dataService;

            BusinessUnits = this.dataService.GetWorkforceData();
            SelectedBusinessUnit = BusinessUnits;

            goBackCommand = new DelegateCommand(ExecuteGoBack, CanGoBack);
        }

        public DelegateCommand GoBackCommand
        {
            get { return this.goBackCommand; }
        }

        public BusinessUnitModel BusinessUnits
        {
            get { return businessUnits; }
            set
            {
                businessUnits = value;
                RaisePropertyChanged();
            }
        }

        public BusinessUnitModel SelectedBusinessUnit
        {
            get { return selectedBusinessUnits; }
            set
            {
                selectedBusinessUnits = value;
                RaisePropertyChanged();
                if (GoBackCommand != null)
                    GoBackCommand.RaiseCanExecuteChanged();
            }
        }
        
        private bool CanGoBack()
        {
            return SelectedBusinessUnit != BusinessUnits;
        }

        private void ExecuteGoBack()
        {
            SelectedBusinessUnit = BusinessUnits;
        }
    }
}
