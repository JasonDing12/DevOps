
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace DevOps.Commands
{
    public class DelegateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (this.CanExecuteFunc == null)
            {
                return true;
            }
            return this.CanExecuteFunc(parameter);
        }

        public void Execute(object parameter)
        {
            if (this.ExecuteAtion == null)
            {
                return;
            }
            this.ExecuteAtion(parameter);
        }

        public Action<object> ExecuteAtion { get; set; }

        public Func<object, bool> CanExecuteFunc { get; set; }
    }
}