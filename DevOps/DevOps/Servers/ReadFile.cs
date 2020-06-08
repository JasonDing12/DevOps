using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOps.Servers
{
    public class ReadFile
    {   
        /// <summary>
        /// 插件必须实现的接口
        /// </summary>
        /// <returns></returns>
        public static List<string> GetFileName(string rootPath)
        {
            //1.获取指定目录
            //string rootPath = Directory.GetCurrentDirectory();
            //rootPath += "\\DLL";
            //获取目录下的所有文件名
            List<string> fileNames = new List<string>();
            DirectoryInfo root = new DirectoryInfo(rootPath);
            foreach (FileInfo f in root.GetFiles())
            {
                var name = f.Name.Split('.');
                fileNames.Add(name[0]);
            }
            return fileNames;
        }
    }
}
