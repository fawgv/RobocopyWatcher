using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        private static Process proc;
        private static ProcessStartInfo runRobocopy;

        static void Main(string[] args)
        {
            
            try
            {
                #region MyRegion

                runRobocopy = new ProcessStartInfo();
                runRobocopy.FileName = "cmd.exe";
                //string fileName = System.IO.Path.Combine(System.IO.Directory..{ipaddr}List.txt");
                string pathVideoSource = Properties.Resources.watcherPath;
                //string nbtscan = System.IO.Path.Combine(Environment.CurrentDirectory, @"SupportTools\nbtscan.exe");
                //if (File.Exists(fileName))
                //    File.Delete(fileName);

                runRobocopy.Arguments = $"/c start /b robocopy \"{Properties.Resources.watcherPath}\" {Properties.Resources.destinationFolder}%COMPUTERNAME% *.mp4 /MOT:1";
                proc = new Process();
                proc.StartInfo = runRobocopy;
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                proc.Start();

                #endregion

            }
            catch (Exception)
            {
            }

            Console.ReadLine();  
        }


    }
}
