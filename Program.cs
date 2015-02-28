using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MarkEmptyDirs
{
    class Program
    {

        static void Recursion(DirectoryInfo di)
        {
           
            DirectoryInfo[] dirs = di.GetDirectories();
            foreach (var item in dirs)
            {
                Recursion(item);
            }
            if (di.GetFiles().Length == 0)
            {
                Console.WriteLine(di.FullName);
                FileInfo fi = new FileInfo(di.FullName+"/"+".gitignore");
                FileStream fs = fi.Create();
                fs.Close();
            }
        }
        static void Main(string[] args)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(".");
                Recursion(di);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
