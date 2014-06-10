using System;
using System.Windows.Input;

namespace wControls.WPF {
    
    public class Command<T> : ICommand {
        private readonly Action<T> command;
        private readonly Func<T, bool> canExecute;

        public Command(Action<T> command) : this(command, null){

        }

        public Command(Action<T> command, Func<T, bool> canExecute) {
            if (command == null)
                throw new ArgumentNullException();
            this.command = command;
            this.canExecute = canExecute;
        } 

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <returns>
        /// true if this command can be executed; otherwise, false.
        /// </returns>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        public bool CanExecute(object parameter) {
            return canExecute == null || canExecute((T)parameter);
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        public void Execute(object parameter) {
            command.Invoke((T)parameter);
        }

        public virtual void RaiseCanExecuteChanged() {
            CanExecuteChanged.Raise(this);
        }

        public event EventHandler CanExecuteChanged;
    }
}
