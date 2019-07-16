using Hololens.Obeya.Core.Models;
using Hololens.Obeya.Windows10.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Hololens.Obeya.Windows10.Controls
{
    public sealed partial class StrategyControl : UserControl
    {
        public StrategyControl()
        {
            this.InitializeComponent();
        }

        private void itemsListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var item = e.ClickedItem as StrategyItemModel;
            var dialog = new MessageDialog(
                $"{item.LongStatusDescription}\n\n" +
                $"Includes: {item.WhatIncludes}\n\n" +
                $"People: {item.People.Aggregate((current, next) => current + ", " + next )}\n",
                $"{item.Title} ({new DoubleToPercentageConverter().Convert(item.Status, null, null, null)})");

            dialog.ShowAsync().AsTask().ConfigureAwait(false);
        }
    }
}
