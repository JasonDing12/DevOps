using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInterface
{
    public interface IDllInterface
    {
        /// <summary>
        /// 获取菜单目录的名称
        /// </summary>
        /// <returns></returns>
        string GetMenuName();
        /// <summary>
        /// 获取子菜单的界面
        /// </summary>
        /// <returns></returns>
        Action<object> GetForm();
    }
}
