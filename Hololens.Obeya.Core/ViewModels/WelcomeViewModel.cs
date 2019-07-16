using Hololens.Obeya.Core.Enums;
using Hololens.Obeya.Core.Services.MultiWindowService;
using Hololens.Obeya.Core.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hololens.Obeya.Core.ViewModels
{
    public class WelcomeViewModel : ViewModelBase
    {
        private readonly IMultiWindowService multiWindowService;

        private DelegateCommand acceptHelpCommand;

        public WelcomeViewModel(IMultiWindowService multiWindowService) : base()
        {
            this.multiWindowService = multiWindowService;

            acceptHelpCommand = new DelegateCommand(OpenObeyaRoomWindowsAsync);
        }

        public DelegateCommand AcceptHelpCommand => acceptHelpCommand;

        private async void OpenObeyaRoomWindowsAsync()
        {
            var screenTypes = Enum.GetValues(typeof(ScreenTypes)).Cast<ScreenTypes>();

            foreach (var screenType in screenTypes)
            {
                await multiWindowService.OpenNewWindowForScreen(screenType);
                await Task.Delay(1800);
            }
        }
    }
}
