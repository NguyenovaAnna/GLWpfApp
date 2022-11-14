using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ClientApp.Commands
{
    internal class SubmitCommand : ICommand
    {

        private Action<object> _execute;
        private Func<object, bool> _canExecute;
 

        public event EventHandler? CanExecuteChanged;

        public SubmitCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
            {
                return true;
            }
            else
            {
                return _canExecute(parameter);
            }
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
