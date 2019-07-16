using Hololens.Obeya.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Hololens.Obeya.Windows10.Controls
{
    public sealed partial class EditTaskContentDialog : ContentDialog
    {
        public EditTaskContentDialog()
        {
            this.InitializeComponent();

            this.Loaded += EditTaskContentDialog_Loaded;
        }

        private void EditTaskContentDialog_Loaded(object sender, RoutedEventArgs e)
        {
            this.Loaded -= EditTaskContentDialog_Loaded;

            var item = (TaskModel)this.DataContext;
            switch (item.Status)
            {
                case Core.Enums.StatusEnum.TODO:
                    TodoRadio.IsChecked = true;
                    break;
                case Core.Enums.StatusEnum.WIP:
                    WipRadio.IsChecked = true;
                    break;
                case Core.Enums.StatusEnum.DONE:
                    DoneRadio.IsChecked = true;
                    break;
                default:
                    break;
            }
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            var item = (TaskModel)this.DataContext;
            if (TodoRadio.IsChecked.Value)
                item.Status = Core.Enums.StatusEnum.TODO;
            else if (WipRadio.IsChecked.Value)
                item.Status = Core.Enums.StatusEnum.WIP;
            else
                item.Status = Core.Enums.StatusEnum.DONE;
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
