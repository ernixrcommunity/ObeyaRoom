namespace Hololens.Obeya.Windows10.Services.MultiWindowService
{
    using Core.Enums;
    using Core.Services.MultiWindowService;
    using System;
    using System.Threading.Tasks;
    using Views;
    using Windows.ApplicationModel.Core;
    using Windows.ApplicationModel.Resources;
    using Windows.UI.Core;
    using Windows.UI.ViewManagement;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// Contract implementation for multi window manager
    /// </summary>
    public class MultiWindowService : IMultiWindowService
    {
        /// <summary>
        /// <see cref="IMultiWindowService"/>
        /// </summary>
        /// <param name="screen"><see cref="IMultiWindowService"/></param>
        /// <returns><see cref="IMultiWindowService"/></returns>
        public async Task<bool> OpenNewWindowForScreen(ScreenTypes screen)
        {
            Page instance = GetPageInstance(screen);

            if (instance != null)
            {
                CoreWindow window = null;
                await CoreApplication.CreateNewView().Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    window = CoreWindow.GetForCurrentThread();
                    var frame = new Frame();
                    frame.Navigate(instance.GetType());
                    Window.Current.Content = frame;
                    Window.Current.Activate();
                    ApplicationView.GetForCurrentView().Title = GetPageTitleByScreen(screen);
                });

                var viewId = ApplicationView.GetApplicationViewIdForWindow(window);
                return await ApplicationViewSwitcher.TryShowAsStandaloneAsync(viewId);
            }

            return false;
        }

        /// <summary>
        /// <see cref="IMultiWindowService"/>
        /// </summary>
        /// <param name="screen"><see cref="IMultiWindowService"/></param>
        /// <returns><see cref="IMultiWindowService"/></returns>
        public string GetPageTitleByScreen(ScreenTypes screen)
        {
            ResourceLoader loader = new ResourceLoader();
            switch (screen)
            {
                case ScreenTypes.LANDING:
                    return loader.GetString("LandingScreenTitle");
                case ScreenTypes.WORKFORCE:
                    return loader.GetString("WorkforceScreenTitle");
                case ScreenTypes.STRATEGY:
                    return loader.GetString("StrategyScreenTitle");
                case ScreenTypes.TASKS:
                    return loader.GetString("TasksScreenTitle");
                case ScreenTypes.CUSTOMERS:
                    return loader.GetString("CustomersScreenTitle");
                default:
                    return string.Empty;
            }
        }

        private Page GetPageInstance(ScreenTypes screen)
        {
            switch (screen)
            {
                case ScreenTypes.WORKFORCE:
                    return new Workforce();
                case ScreenTypes.STRATEGY:
                    return new Strategy();
                case ScreenTypes.TASKS:
                    return new Tasks();
                case ScreenTypes.CUSTOMERS:
                    return new Customers();
                default:
                    return null;
            }
        }
    }
}
