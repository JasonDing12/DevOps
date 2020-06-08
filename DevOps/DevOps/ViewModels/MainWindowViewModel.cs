using DevOps.Commands;
using DevOps.Models;
using DevOps.Servers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DevOps.ViewModels
{
    public class MainWindowViewModel:NotificationObject
    {
        private RootMenuViewModel theMenuA;
        public RootMenuViewModel TheMenuA
        {
            get { return theMenuA; }
            set
            {
                theMenuA = value;
                this.RaisePropertyChanged("TheMenuA");
            }
        }

        public MainWindowViewModel()
        {

            TheMenuA = GetMenusA();
        }

        private RootMenuViewModel GetMenusA()
        {
            RootMenu RootMenuA = new RootMenu("插件");
            //RootMenuA.MenuItems = new List<MenuItem>();
            //RootMenuA.MenuItems.Add(new MenuItem("例如", GetCommand()));
            //RootMenuA.MenuItems.Add(new MenuItem("例如1", GetCommand()));
            RootMenuA.MenuItems = GetMenu();

            RootMenuViewModel rootMenuViewModel = new RootMenuViewModel(RootMenuA);

            return rootMenuViewModel;
        }

        private DelegateCommand GetCommand()
        {
            DelegateCommand com = new DelegateCommand();
            com.ExecuteAtion = new Action<object>(mess);
            return com;
        }

        private void mess(object parameter)
        {
            MessageBox.Show("New");
        }

        private List<MenuItem> GetMenu()
        {
            string path = Directory.GetCurrentDirectory();
            path += "\\DLL";
            //获取指定目录下的所有文件的名称path+DLL
            List<string> fileNames = ReadFile.GetFileName(path);
            List<MenuItem> menu = new List<MenuItem>();
            if (fileNames.Count > 0)
            {
                foreach (string fileName in fileNames)
                {
                    string filePath = path + "\\" + fileName + ".dll";
                    Assembly assem = Assembly.LoadFile(filePath);
                    //得到所有的类型名
                    Type[] tys = assem.GetTypes();
                    foreach (Type ty in tys)
                    {
                        if (ty.Name == fileName)
                        {
                            ConstructorInfo magicConstructor = ty.GetConstructor(Type.EmptyTypes);//获取不带参数的构造函数
                            object magicClassObject = magicConstructor.Invoke(new object[] { });//这里是获取一个类似于类的实例的东东
                            //获取菜单名称
                            MethodInfo mi = ty.GetMethod("GetMenuName");
                            string Name = mi.Invoke(magicClassObject, null).ToString();
                            //获取菜单界面
                            MethodInfo mt = ty.GetMethod("GetForm");
                            Action<object> method = mt.Invoke(magicClassObject, null) as Action<object>;
                            DelegateCommand com = new DelegateCommand();
                            com.ExecuteAtion = method;
                            menu.Add(new MenuItem(Name, com));
                        }
                    }
                }
            }
            return menu;
        }


    }
}
