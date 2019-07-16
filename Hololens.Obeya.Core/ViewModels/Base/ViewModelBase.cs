namespace Hololens.Obeya.Core.ViewModels.Base
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Base viewmodel with change notifications.
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public ViewModelBase()
        {

        }

        /// <summary>
        /// Event to notify UI of property changes
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Method to raise PropertyChanged event
        /// </summary>
        /// <param name="propertyName"></param>
        public void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
