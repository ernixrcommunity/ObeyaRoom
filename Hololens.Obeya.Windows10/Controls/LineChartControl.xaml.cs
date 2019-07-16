namespace Hololens.Obeya.Windows10.Controls
{
    using Core.Models;
    using OxyPlot;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Windows.UI;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public sealed partial class LineChartControl : UserControl
    {
        private readonly static DependencyProperty ItemsSourceProperty = DependencyProperty.RegisterAttached("ItemsSource", typeof(List<GenericDateValueModel>), typeof(LineChartControl), new PropertyMetadata(null, (d, e) =>
        {
            if (e.NewValue != e.OldValue && e.NewValue != null)
            {
                LineChartControl instance = (LineChartControl)d;
                instance.MainSerie.ItemsSource = (List<GenericDateValueModel>)e.NewValue;
                instance.CustomerPlot.InvalidatePlot(true);
            }

        }));

        private readonly static DependencyProperty LineColorProperty = DependencyProperty.RegisterAttached("LineColor", typeof(Color), typeof(LineChartControl), new PropertyMetadata(Colors.Black, (d, e) =>
        {
            if (e.NewValue != e.OldValue && e.NewValue != null)
            {
                Color color = (Color)e.NewValue;
                LineChartControl instance = (LineChartControl)d;
                instance.MainSerie.Color = OxyColor.FromArgb(color.A, color.R, color.G, color.B);
            }
        }));

        public LineChartControl()
        {
            this.InitializeComponent();

            CustomerPlot.DataContext = this;
        }

        public List<GenericDateValueModel> ItemsSource
        {
            get { return (List<GenericDateValueModel>)this.GetValue(ItemsSourceProperty); }
            set { this.SetValue(ItemsSourceProperty, value); }
        }

        public Color LineColor
        {
            get { return (Color)this.GetValue(LineColorProperty); }
            set { this.SetValue(LineColorProperty, value); }
        }
    }
}
