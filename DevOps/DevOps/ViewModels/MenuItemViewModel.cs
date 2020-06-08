
using DevOps.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOps.ViewModels
{
    public class MenuItemViewModel: NotificationObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MenuItemViewModel"/> class.
        /// </summary>
        /// <param name="parentViewModel">The parent view model.</param>
        public MenuItemViewModel(MenuItemViewModel parentViewModel)
        {
            ParentViewModel = parentViewModel;
            _childMenuItems = new ObservableCollection<MenuItemViewModel>();
        }

        private ObservableCollection<MenuItemViewModel> _childMenuItems;
        /// <summary>
        /// Gets the child menu items.
        /// </summary>
        /// <value>The child menu items.</value>
        public ObservableCollection<MenuItemViewModel> Children
        {
            get
            {
                return _childMenuItems;
            }
        }

        private string _header;
        /// <summary>
        /// Gets or sets the header.
        /// </summary>
        /// <value>The header.</value>
        public string Header
        {
            get
            {
                return _header;
            }
            set
            {
                _header = value;
                RaisePropertyChanged("Header");
            }
        }
        private short _childlx;
        /// <summary>
        /// Gets or sets the CommandParameter.
        /// </summary>
        /// <value>The CommandParameter.</value>
        public short Childlx
        {
            get
            {
                return _childlx;
            }
            set
            {
                _childlx = value;
                RaisePropertyChanged("Childlx");
            }
        }
        /// <summary>
        /// Gets or sets the Command.
        /// </summary>
        /// <value>The Command.</value>
        private DelegateCommand command;
        public DelegateCommand Command
        {
            get
            {
                return command;
            }
            set
            {
                command = value;
                RaisePropertyChanged("Command");
            }
        }

        /// <summary>
        /// Gets or sets the parent view model.
        /// </summary>
        /// <value>The parent view model.</value>
        public MenuItemViewModel ParentViewModel { get; set; }

        public virtual void LoadChildMenuItems()
        {

        }
    }
}
