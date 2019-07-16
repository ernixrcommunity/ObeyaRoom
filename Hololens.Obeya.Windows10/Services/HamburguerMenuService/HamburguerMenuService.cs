using Hololens.Obeya.Core.Services.HamburguerMenuService;
using Hololens.Obeya.Windows10.Controls;
using Hololens.Obeya.Windows10.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Hololens.Obeya.Windows10.Services.HamburguerMenuService
{
    public class HamburguerMenuService : IHamburguerMenuService
    {
        public void ShowCustomers()
        {
            ShowControlInSplitViewContentsGrid(new CustomersControl());
        }

        public void ShowStrategy()
        {
            ShowControlInSplitViewContentsGrid(new StrategyControl());
        }

        public void ShowTasks()
        {
            ShowControlInSplitViewContentsGrid(new TasksControl());
        }

        public void ShowWorkforce()
        {
            ShowControlInSplitViewContentsGrid(new WorkforceControl());
        }

        private static void ShowControlInSplitViewContentsGrid(UserControl control)
        {
            var mainFrame = Window.Current.Content as Frame;

            if (mainFrame == null)
                return;

            var welcomeView = mainFrame.Content as WelcomeNotHoloLens;

            if (welcomeView == null)
                return;

            welcomeView.ContentGrid.Children.Clear();
            welcomeView.ContentGrid.Children.Add(control);
        }
    }
}
