namespace Hololens.Obeya.Windows10.Controls
{
    using Core.ViewModels;
    using System;
    using Windows.UI.Xaml.Controls;

    public sealed partial class TasksControl : UserControl
    {
        public TasksControl()
        {
            this.InitializeComponent();

            this.Loaded += TasksControl_Loaded;
        }

        private void TasksControl_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.Loaded -= TasksControl_Loaded;
            var vm = DataContext as TasksViewModel;
            vm.InitializeTasks();
        }

        private async void Button_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            var vm = DataContext as TasksViewModel;

            var contentDialog = new NewTaskContentDialog();
            var result = await contentDialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                vm.AddNewTask(contentDialog.Description);
            }
        }
    }
}
