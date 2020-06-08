
using DevOps.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOps.Models
{
    public class ChildItem
    {

        public string ChildName { get; set; }
        public short Childlx { get; set; }
        public DelegateCommand Command { get; set; }
        public MenuItem MenuItem { get; set; }
        public ChildItem(MenuItem menuClass, string childName, short childlx, DelegateCommand command)
        {
            MenuItem = menuClass;
            ChildName = childName;
            Childlx = childlx;
            Command = command;
        }
        public ChildItem() { }

    }
}
