namespace Hololens.Obeya.Core.ViewModels.Base
{
    using Microsoft.Practices.Unity;
    using Services.DataService;

    /// <summary>
    /// View model locator and IoC control.
    /// </summary>
    public class ViewModelLocator
    {
        private readonly IUnityContainer container;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public ViewModelLocator()
        {
            container = new UnityContainer();

            container.RegisterType<IDataService, DataService>();
            container.RegisterType<WelcomeViewModel>();
            container.RegisterType<WelcomeNotHoloLensViewModel>();
            container.RegisterType<WorkforceViewModel>();
            container.RegisterType<StrategyViewModel>();
            container.RegisterType<TasksViewModel>();
            container.RegisterType<CustomerAcquisitionViewModel>();
        }

        /// <summary>
        /// Welcome viewmodel instance.
        /// </summary>
        public WelcomeViewModel WelcomeVM
        {
            get { return container.Resolve<WelcomeViewModel>(); }
        }

        public WelcomeNotHoloLensViewModel WelcomeNotHoloLensVM
        {
            get { return container.Resolve<WelcomeNotHoloLensViewModel>(); }
        }

        /// <summary>
        /// Workforce viewmodel instance.
        /// </summary>
        public WorkforceViewModel WorkforceVM
        {
            get { return container.Resolve<WorkforceViewModel>(); }
        }

        public StrategyViewModel StrategyVM
        {
            get { return container.Resolve<StrategyViewModel>(); }
        }

        /// <summary>
        /// TasksManagement viewmodel instance.
        /// </summary>
        public TasksViewModel TasksVM
        {
            get { return container.Resolve<TasksViewModel>(); }
        }

        /// <summary>
        /// Gets the customer acquisition vm.
        /// </summary>
        public CustomerAcquisitionViewModel CustomerAcquisitionVM
        {
            get { return container.Resolve<CustomerAcquisitionViewModel>(); }
        }

        /// <summary>
        /// Method to register services from the UI project
        /// </summary>
        /// <typeparam name="TFrom"></typeparam>
        /// <typeparam name="TTo"></typeparam>
        public void RegisterType<TFrom, TTo>() where TTo : TFrom
        {
            container.RegisterType<TFrom, TTo>();
        }

        /// <summary>
        /// Resolve instance by type
        /// </summary>
        /// <typeparam name="T">type to resolve</typeparam>
        /// <returns>resolved instance.</returns>
        public T ResolveType<T>()
        {
            return container.Resolve<T>();
        }
    }
}
