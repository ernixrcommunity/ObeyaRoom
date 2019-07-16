namespace Hololens.Obeya.Windows10.Controls
{
    using Core.Models;
    using Core.ViewModels;
    using Core.ViewModels.Base;
    using System;
    using System.Collections.ObjectModel;
    using Windows.UI.Composition;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Hosting;

    public class BindableDragableCanvas : Canvas
    {
        private readonly DependencyProperty AttachedViewModelProperty = DependencyProperty.Register("AttachedViewModel", typeof(ViewModelBase), typeof(BindableDragableCanvas), new PropertyMetadata(null));
        private readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register("ItemsSource", typeof(ObservableCollection<TaskModel>), typeof(BindableDragableCanvas), new PropertyMetadata(new ObservableCollection<TaskModel>(), (d, e) =>
        {
            BindableDragableCanvas instance = (BindableDragableCanvas)d;
            if (e.NewValue != null && e.NewValue != e.OldValue)
            {
                
                ObservableCollection<TaskModel> items = (ObservableCollection<TaskModel>)e.NewValue;
                foreach (var item in instance.Children)
                {
                    
                    item.Tapped -= Item_Tapped;
                }
                instance.Children.Clear();
                instance.InvalidateMeasure();
                int top = 0;
                int left = 0;
                foreach(var item in items)
                {
                    StopAnimation(item);
                    item.DataContext = item;
                    item.Tapped += Item_Tapped;
                    instance.Children.Add(item);
                    Canvas.SetTop(item, top);
                    Canvas.SetLeft(item, left);
                    item.Width = instance.ActualWidth - 20;
                    top += 202;

                    var diffHours = (item.DueDate - DateTime.Now).TotalHours;
                    if ( diffHours <= 24 && item.Status != Core.Enums.StatusEnum.DONE)
                    {
                        item.IsNearToDueDate = true;
                        AnimateOpacityItem(item);
                    }
                        
                }

                instance.Height = top;
            }
            else if (e.NewValue == null)
            {
                foreach (var item in instance.Children)
                {
                    item.Tapped -= Item_Tapped;
                }
                instance.Children.Clear();
            }
        }));


        private static void AnimateOpacityItem(TaskModel item)
        {
            Visual controlToAnimate = ElementCompositionPreview.GetElementVisual(item);
            Compositor compositor = controlToAnimate.Compositor;

            var animation = compositor.CreateScalarKeyFrameAnimation();

            animation.InsertKeyFrame(0.0f, 1f);
            animation.InsertKeyFrame(0.1f, 0.9f);
            animation.InsertKeyFrame(0.2f, 0.8f);
            animation.InsertKeyFrame(0.3f, 0.7f);
            animation.InsertKeyFrame(0.4f, 0.6f);
            animation.InsertKeyFrame(0.5f, 0.5f);
            animation.InsertKeyFrame(0.6f, 0.6f);
            animation.InsertKeyFrame(0.7f, 0.7f);
            animation.InsertKeyFrame(0.8f, 0.8f);
            animation.InsertKeyFrame(0.9f, 0.9f);
            animation.InsertKeyFrame(1f, 1f);


            animation.Duration = TimeSpan.FromMilliseconds(600);
            animation.IterationBehavior = AnimationIterationBehavior.Forever;

            controlToAnimate.StartAnimation("Opacity", animation);
        }


        private static void StopAnimation(TaskModel item)
        {
            item.IsNearToDueDate = false;
            Visual controlToAnimate = ElementCompositionPreview.GetElementVisual(item);            
            controlToAnimate.StopAnimation("Opacity");
            controlToAnimate.Opacity = 1;
        }

        private static async void Item_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            var item = (sender as TaskModel);

            var contentDialog = new EditTaskContentDialog();

            contentDialog.DataContext = item;

            var result = await contentDialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                BindableDragableCanvas canvas = (BindableDragableCanvas)item.Parent;
                var vm = (TasksViewModel)canvas.AttachedViewModel;
                if (vm != null)
                {
                    vm.InitializeTasks();
                }
            }
        }

        public BindableDragableCanvas()
        {
            this.SizeChanged += BindableDragableCanvas_SizeChanged;
        }

        private void BindableDragableCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            foreach(var item in this.Children)
            {
                (item as TaskModel).Width = this.ActualWidth - 20;
            }
        }

        public ObservableCollection<TaskModel> ItemsSource
        {
            get { return (ObservableCollection<TaskModel>)this.GetValue(ItemsSourceProperty); }
            set { this.SetValue(ItemsSourceProperty, value); }
        }

        public ViewModelBase AttachedViewModel
        {
            get { return (ViewModelBase)this.GetValue(AttachedViewModelProperty); }
            set { this.SetValue(AttachedViewModelProperty, value); }
        }
    }
}
