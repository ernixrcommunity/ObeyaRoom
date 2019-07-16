namespace Hololens.Obeya.Core.ViewModels.Base
{
    using System;
    using System.Windows.Input;

    /// <summary>
    /// Delegate command implementation
    /// </summary>
    public class DelegateCommand : ICommand
    {
        private readonly Action executeAction;
        private readonly Func<bool> canExecuteFunction;

        /// <summary>
        /// One parameter with default canExecute action constructor
        /// </summary>
        /// <param name="execute">Code to execute on command raised</param>
        public DelegateCommand(Action execute) : this(execute, null)
        {
        }

        /// <summary>
        /// Main constructor with execute and canExecute parameters
        /// </summary>
        /// <param name="execute">Code to execute on command raised</param>
        /// <param name="canExecute">Code to check if command can be executed</param>
        public DelegateCommand(Action execute, Func<bool> canExecute)
        {
            this.executeAction = execute;
            this.canExecuteFunction = canExecute;
        }

        /// <summary>
        /// Event raised to notify UI of execution possibility changes.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Method executed by the UI to check if command can be executed.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            if (canExecuteFunction != null)
                return canExecuteFunction();

            return true;
        }

        /// <summary>
        /// Method executed by the UI on command execution.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            executeAction?.Invoke();
        }

        /// <summary>
        /// Method executed by the ViewModel to notify can execute changes.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
