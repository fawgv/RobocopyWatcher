using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace RobocopyWatcherService
{
    public enum ServiceState
    {
        SERVICE_STOPPED = 0x00000001,
        SERVICE_START_PENDING = 0x00000002,
        SERVICE_STOP_PENDING = 0x00000003,
        SERVICE_RUNNING = 0x00000004,
        SERVICE_CONTINUE_PENDING = 0x00000005,
        SERVICE_PAUSE_PENDING = 0x00000006,
        SERVICE_PAUSED = 0x00000007,
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ServiceStatus
    {
        public long dwServiceType;
        public ServiceState dwCurrentState;
        public long dwControlsAccepted;
        public long dwWin32ExitCode;
        public long dwServiceSpecificExitCode;
        public long dwCheckPoint;
        public long dwWaitHint;
    };

    public partial class RobocopyWatcherService : ServiceBase
    {
        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool SetServiceStatus(IntPtr handle, ref ServiceStatus serviceStatus);

        ProcessStartInfo runRobocopy;
        Process proc;

        public RobocopyWatcherService()
        {
            InitializeComponent();
        }


        protected override void OnStart(string[] args)
        {
            ////System.Windows.Forms.MessageBox.Show("Test");
            //// Update the service state to Start Pending.  
            //ServiceStatus serviceStatus = new ServiceStatus();
            //serviceStatus.dwCurrentState = ServiceState.SERVICE_START_PENDING;
            ////serviceStatus.dwWaitHint = 100000;
            //SetServiceStatus(this.ServiceHandle, ref serviceStatus);
            try
            {

                runRobocopy = new ProcessStartInfo();
                runRobocopy.FileName = "cmd.exe";
                //string fileName = System.IO.Path.Combine(System.IO.Directory..{ipaddr}List.txt");
                string pathVideoSource = Properties.Resources.watcherPath;
                //string nbtscan = System.IO.Path.Combine(Environment.CurrentDirectory, @"SupportTools\nbtscan.exe");
                //if (File.Exists(fileName))
                //    File.Delete(fileName);

                //runRobocopy.Arguments = $"/c start /b robocopy \"{Properties.Resources.watcherPath}\" {Properties.Resources.destinationFolder}%COMPUTERNAME% *.mp4 /MOT:1";

                runRobocopy.Arguments = $"/c start /b robocopy \"{Properties.Resources.watcherPath}\" C:\\nasdengisrazyru\\%COMPUTERNAME% *.mp4 /MOT:1";

                //Process.Start(runNBTScan);
                proc = new Process();
                proc.StartInfo = runRobocopy;
                //proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                proc.Start();
            }
            catch (Exception)
            {
                //Bindings.StatusBarText = ex.Message;
            }

            // Update the service state to Running.  
            //serviceStatus.dwCurrentState = ServiceState.SERVICE_RUNNING;
            //SetServiceStatus(this.ServiceHandle, ref serviceStatus);
        }

        protected override void OnStop()
        {
            try
            {
                proc.Dispose();
            }
            catch (Exception)
            {

            }
        }
    }
}
