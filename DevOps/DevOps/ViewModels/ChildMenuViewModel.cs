using DevOps.Commands;
using DevOps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOps.ViewModels
{
    public class ChildMenuViewModel : MenuItemViewModel
    {
        private ChildItem _child;
        /// <summary>
        /// Initializes a new instance of the <see cref="MenuItemViewModel"></see> class.
        /// </summary>
        /// <param name="parentViewModel">The parent view model.</param>
        public ChildMenuViewModel(MenuClassViewModel parentViewModel, ChildItem child)
            : base(parentViewModel)
        {
            _child = child;
        }


        public string ChildName
        {
            get
            {
                return _child.ChildName;
            }
            set
            {
                _child.ChildName = value;
                RaisePropertyChanged("ChildName");
            }
        }
        public short ChildLx
        {
            get
            {
                return _child.Childlx;
            }
            set
            {
                _child.Childlx = value;
                RaisePropertyChanged("ChildLx");
            }
        }
        public DelegateCommand ChildCommand
        {
            get
            {
                return _child.Command;
            }
            set
            {
                _child.Command = value;
                RaisePropertyChanged("ChildCommand");
            }
        }
    }
}
