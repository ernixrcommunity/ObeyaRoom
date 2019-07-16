using Hololens.Obeya.Core.Enums;
using Hololens.Obeya.Core.Models;
using Hololens.Obeya.Core.Services.HamburguerMenuService;
using Hololens.Obeya.Core.Services.MultiWindowService;
using Hololens.Obeya.Core.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace Hololens.Obeya.Core.ViewModels
{
    public class WelcomeNotHoloLensViewModel : ViewModelBase
    {
        private readonly IHamburguerMenuService hamburguerMenuService;

        private List<MenuItemModel> menuItems;

        private DelegateCommand<MenuItemModel> menuItemCommand;

        public WelcomeNotHoloLensViewModel(IHamburguerMenuService hamburguerMenuService) : base()
        {
            this.hamburguerMenuService = hamburguerMenuService;

            menuItems = new List<MenuItemModel>();
            menuItems.Add(new MenuItemModel { Icon = '\uE821', Title = "Workforce Availability",
                ScreenType = ScreenTypes.WORKFORCE });
            menuItems.Add(new MenuItemModel { Icon = '\uE8FD', Title = "Strategy Items",
                ScreenType = ScreenTypes.STRATEGY });
            menuItems.Add(new MenuItemModel { Icon = '\uE73A', Title = "Management Actions",
                ScreenType = ScreenTypes.TASKS });
            menuItems.Add(new MenuItemModel { Icon = '\uE716', Title = "Customer Acquisition",
                ScreenType = ScreenTypes.CUSTOMERS });

            menuItemCommand = new DelegateCommand<MenuItemModel>(ShowBoard);
        }

        public List<MenuItemModel> MenuItems => menuItems;

        public DelegateCommand<MenuItemModel> MenuItemCommand => menuItemCommand;

        private void ShowBoard(object parameter)
        {
            var args = parameter as ItemClickEventArgs;

            if (args == null)
                return;

            var item = args.ClickedItem as MenuItemModel;

            if (item == null)
                return;

            switch (item.ScreenType)
            {
                case ScreenTypes.WORKFORCE:
                    hamburguerMenuService.ShowWorkforce();
                    break;
                case ScreenTypes.STRATEGY:
                    hamburguerMenuService.ShowStrategy();
                    break;
                case ScreenTypes.TASKS:
                    hamburguerMenuService.ShowTasks();
                    break;
                case ScreenTypes.CUSTOMERS:
                    hamburguerMenuService.ShowCustomers();
                    break;
                default:
                    break;
            }
        }
    }
}
