
using DevOps.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOps.Models
{
    public class MenuItem
    {
        public string MenuItemName { get; set; }
        public DelegateCommand Command { get; set; }
        public List<ChildItem> Childs { get; set; }
        public MenuItem(string menuName, DelegateCommand command)
        {
            MenuItemName = menuName;
            Command = command;
        }
        public MenuItem(string menuName)
        {
            MenuItemName = menuName;
        }
        public MenuItem() { }

    }
}
