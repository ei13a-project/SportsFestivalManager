using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace SportsFestivalManager.Wpf
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            canExecute = canExecute ?? new Func<bool>(() => true);

            _execute = _ => execute();
            _canExecute = _ => canExecute();
        }
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));

            _execute = execute;
            _canExecute = canExecute ?? new Func<object, bool>(_ => true);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
        public bool CanExecute(object parameter)
        {
            return _canExecute(parameter);
        }
    }
}
