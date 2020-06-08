using DevOps.Commands;
using DevOps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DevOps.ViewModels
{
    public class MenuClassViewModel : MenuItemViewModel
    {
        private MenuItem _menuClass;
        /// <summary>
        /// Initializes a new instance of the <see cref="MenuItemViewModel"></see> class.
        /// </summary>
        /// <param name="parentViewModel">The parent view model.</param>
        public MenuClassViewModel(RootMenuViewModel parentViewModel, MenuItem menuClass)
            : base(parentViewModel)
        {
            _menuClass = menuClass;
            //if (_menuClass.Childs != null)
            //    LoadChildMenuItems();
        }

        //private string _menuName;
        /// <summary>
        /// Gets or sets the name of the team.
        /// </summary>
        /// <value>The name of the team.</value>
        public string MenuName
        {
            get
            {
                return _menuClass.MenuItemName;
            }
            set
            {
                _menuClass.MenuItemName = value;
                RaisePropertyChanged("MenuName");
            }
        }
        public DelegateCommand ItemCommand
        {
            get
            {
                return _menuClass.Command;
            }
            set
            {
                _menuClass.Command = value;
                RaisePropertyChanged("ItemCommand");
            }
        }


        public override void LoadChildMenuItems()
        {
            _menuClass.Childs.ForEach(child =>
            {
                if (child.ChildName == string.Empty)
                {
                    SeparatorViewModel separatorViewModel = new SeparatorViewModel(this);
                    Children.Add(separatorViewModel);
                }
                else
                {
                    ChildMenuViewModel childViewModel = new ChildMenuViewModel(this, child);
                    childViewModel.Header = child.ChildName;
                    childViewModel.Childlx = child.Childlx;
                    childViewModel.Command = child.Command;
                    Children.Add(childViewModel);
                }
            });
        }
    }
}
