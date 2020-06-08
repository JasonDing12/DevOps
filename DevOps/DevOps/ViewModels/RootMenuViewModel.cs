using DevOps.Commands;
using DevOps.Models;
using System;
using System.Collections.Generic;
//using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOps.ViewModels
{
    public class RootMenuViewModel : MenuItemViewModel
    {
        private RootMenu _rootMenu;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuItemViewModel"></see> class.
        /// </summary>
        /// <param name="parentViewModel">The parent view model.</param>
        public RootMenuViewModel(RootMenu rootMenu)
            : base(null)
        {
            _rootMenu = rootMenu;
            base.Header = RootName;
            base.Command = RootCommand;
            if (_rootMenu.MenuItems != null)
            {
                LoadChildMenuItems();
            }
               
        }
        public string RootName
        {
            get
            {
                return _rootMenu.RootName;
            }
            set
            {
                _rootMenu.RootName = value;
                RaisePropertyChanged("RootName");
            }
        }
        public DelegateCommand RootCommand
        {
            get
            {
                return _rootMenu.Command;
            }
            set
            {
                _rootMenu.Command = value;
                RaisePropertyChanged("RootCommand");
            }
        }
        /// <summary>
        /// Loads the child menu items.
        /// </summary>
        public override void LoadChildMenuItems()
        {
            _rootMenu.MenuItems.ForEach
                (
                        MenuItem =>
                        {
                            if (MenuItem.MenuItemName == string.Empty || MenuItem.MenuItemName == "Separator")
                            {
                                SeparatorViewModel separatorViewModel = new SeparatorViewModel(this);
                                Children.Add(separatorViewModel);
                            }
                            else if (MenuItem.MenuItemName != null)
                            {
                                MenuClassViewModel childMenuViewModel = new MenuClassViewModel(this, MenuItem);
                                childMenuViewModel.Header = MenuItem.MenuItemName;
                                childMenuViewModel.Command = MenuItem.Command;
                                Children.Add(childMenuViewModel);
                            }
                        }
                );
        }
    }
}
