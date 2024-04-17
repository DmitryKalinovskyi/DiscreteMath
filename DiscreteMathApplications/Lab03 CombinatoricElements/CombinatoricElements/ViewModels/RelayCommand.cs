using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CombinatoricElements.ViewModels
{
    public class RelayCommand : ICommand
    {
        private Func<object?, bool>? _canExecute;
        private Action<object?>? _execute;

        public RelayCommand(Func<object?, bool>? canExecute, Action<object?>? execute)
        {
            _canExecute = canExecute;
            _execute = execute;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            // if we don't have any _canExecute delegate, then we just return true
            return _canExecute?.Invoke(parameter) ?? true;
        }

        public void Execute(object? parameter)
        {
            _execute?.Invoke(parameter);
        }
    }
}
