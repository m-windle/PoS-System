using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SofkhaPOSLib
{
    public abstract class SofkhaPOS
    {
        public static string LogFilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
            "\\SofkhaPOS\\sofkha_log.txt";
        public static string DatabasePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
            "\\SofkhaPOS\\SofkhaDatabase.mdf";

        static SofkhaPOS()
        {
            if(!File.Exists(DatabasePath))
            {
                if(!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\SofkhaPOS"))
                {
                    Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\SofkhaPOS");
                }
                File.Copy(AppDomain.CurrentDomain.BaseDirectory + "SofkhaTemplate.mdf", DatabasePath);
            }
        }
    }
}
