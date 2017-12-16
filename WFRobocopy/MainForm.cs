using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFRobocopy
{
    public partial class MainForm : Form
    {


        private System.Threading.Timer screenShotTimer;


        //RoboSharp.RoboCommand roboCommand;

        public MainForm()
        {
            InitializeComponent();
        }

        private void ScreenShotTimer_Tick(object state)
        {
            try
            {
                #region MyRegion

                Process proc;
                ProcessStartInfo runRobocopy;

                //runRobocopy = new ProcessStartInfo();
                //runRobocopy.FileName = "robocopy.exe";
                ////string fileName = System.IO.Path.Combine(System.IO.Directory..{ipaddr}List.txt");
                //string pathVideoSource = Properties.Resources.watcherPath;
                ////string nbtscan = System.IO.Path.Combine(Environment.CurrentDirectory, @"SupportTools\nbtscan.exe");
                ////if (File.Exists(fileName))
                ////    File.Delete(fileName);

                ////runRobocopy.Arguments = $"/c start /b robocopy \"{Properties.Resources.watcherPath}\" {Properties.Resources.destinationFolder}%COMPUTERNAME% *.mp4 /MOT:1";
                //runRobocopy.Arguments = $" \"{Properties.Resources.watcherPath}\" {Properties.Resources.destinationFolder1}%COMPUTERNAME% *.mp4 /MOT:1";
                //proc = new Process();
                //proc.StartInfo = runRobocopy;
                ////proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                //proc.Start();
                foreach (var process in Process.GetProcessesByName("robocopy"))
                {
                    process.Kill();
                }

                //robocopy "C:\Users\%UserName%\Pictures\Camera Roll" "\\nas.dengisrazy.ru\IT\VideoFromCVZ\%COMPUTERNAME%" *.mp4 / MOT:10

                //RoboSharp.CopyOptions copyOpt = new RoboSharp.CopyOptions();
                //copyOpt.Destination = System.IO.Path.Combine(Properties.Resources.destinationFolder1, $"ЦВЗ-{Environment.MachineName.Remove(0,5).Remove(3)}");
                ////copyOpt.Source = $"{Properties.Resources.watcherPath}";
                //copyOpt.Source = $"{System.IO.Path.Combine((System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile)), "Pictures\\Camera Roll")}";
                //copyOpt.MonitorSourceChangesLimit = 10;
                //copyOpt.MoveFiles = true;
                ////copyOpt.MonitorSourceTimeLimit = 1;
                //copyOpt.FileFilter = "*.mp4";


                ////RoboSharp.ProcessedFileInfo roboFI = new RoboSharp.ProcessedFileInfo();
                //roboCommand = new RoboSharp.RoboCommand();
                //roboCommand.CopyOptions = copyOpt;
                ////roboCommand.OnCommandCompleted += RoboCommand_OnCommandCompleted;
                ////roboCommand.OnCopyProgressChanged += RoboCommand_OnCopyProgressChanged;
                //roboCommand.Start();
                using (proc = new Process())
                {
                    runRobocopy = new ProcessStartInfo();
                    runRobocopy.FileName = "cmd.exe";
                    //string fileName = System.IO.Path.Combine(System.IO.Directory..{ipaddr}List.txt");
                    //string pathVideoSource = Properties.Resources.watcherPath;

                    runRobocopy.Arguments = $"/c robocopy C:\\UserData\\Video {System.IO.Path.Combine(Properties.Resources.destinationFolder1, $"ЦВЗ-{Environment.MachineName.Remove(0, 5).Remove(3)}")} *.* /MOVE /MOT:30 ";
                    //runRobocopy.Arguments = $" \"{Properties.Resources.watcherPath}\" {Properties.Resources.destinationFolder1}%COMPUTERNAME% *.mp4 /MOT:1 ";

                    proc.StartInfo = runRobocopy;
                    proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    proc.Start();
                }
                



                #endregion

            }
            catch (Exception)
            {
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            screenShotTimer = new System.Threading.Timer(new TimerCallback(ScreenShotTimer_Tick), null, 0, 7200000);
        }



        ~MainForm()
        {
            foreach (var process in Process.GetProcessesByName("robocopy"))
            {
                process.Kill();
            }
            try
            {
                //roboCommand.Dispose();
                //proc.Close();
                //proc.Dispose();

            }
            catch (Exception)
            {
            }

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var process in Process.GetProcessesByName("robocopy"))
            {
                process.Kill();
            }
            try
            {
                //proc.Close();
                //proc.Dispose();
                //roboCommand.Dispose();

            }
            catch (Exception)
            {
            }
            Application.Exit();
        }
    }
}
