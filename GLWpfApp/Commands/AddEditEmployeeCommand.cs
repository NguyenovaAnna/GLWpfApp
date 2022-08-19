using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GLWpfApp.Commands
{
    internal class AddEditEmployeeCommand : ICommand
    {

        private Action<object> _execute;
 

        public event EventHandler? CanExecuteChanged;

        public AddEditEmployeeCommand(Action<object> execute)
        {
            _execute = execute;
        }


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
