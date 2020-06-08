
using DevOps.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOps.Models
{
    public class RootMenu
    {
        public string RootName { get; set; }
        public DelegateCommand Command { get; set; }
        public List<MenuItem> MenuItems { get; set; }
        public RootMenu(string rootName)
        {
            RootName = rootName;
        }
    }
}
