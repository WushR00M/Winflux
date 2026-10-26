using DarkModeForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Winflux.Winflux.Main.Forms;

namespace Winflux
{
    public partial class MainForm : Form
    {
        private DarkModeCS dm = null;

        public MainForm()
        {
            InitializeComponent();
            dm = new DarkModeCS(this)
            {
                ColorMode = DarkModeCS.DisplayMode.DarkMode
            };
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutWinflux aboutForm = new AboutWinflux();
            aboutForm.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void restartExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExecuteCommand("taskkill /f /im explorer.exe");
            ExecuteCommand("start explorer.exe");
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Messenger.MessageBox("Are you sure you want to log out of Windows? Save any and all unsaved work before proceeding.", "Log Out of Windows",
               MessageBoxButtons.YesNo, MessageBoxIcon.None) == DialogResult.Yes)
                    {
                ExecuteCommand("shutdown /l");
            }
        }

            private static void ExecuteCommand(string command)
            {
                var processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
                processInfo.CreateNoWindow = true;
                processInfo.UseShellExecute = false;
                processInfo.RedirectStandardError = true;
                processInfo.RedirectStandardOutput = true;

                var process = Process.Start(processInfo);

                process.OutputDataReceived += (object sender, DataReceivedEventArgs e) =>
                    Console.WriteLine("output>>" + e.Data);
                process.BeginOutputReadLine();

                process.ErrorDataReceived += (object sender, DataReceivedEventArgs e) =>
                    Console.WriteLine("error>>" + e.Data);
                process.BeginErrorReadLine();

                process.WaitForExit();

                Console.WriteLine("ExitCode: {0}", process.ExitCode);
                process.Close();
            }

        private void powerCycleRestartPCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Messenger.MessageBox("Are you sure you want to restart Windows? Save any and all unsaved work before proceeding.", "Restart Windows",
               MessageBoxButtons.YesNo, MessageBoxIcon.None) == DialogResult.Yes)
            {
                ExecuteCommand("shutdown /r /t 0");
            }
        }

        private void notMyFaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Messenger.MessageBox("Save any and all work before proceeding. All BSODs should have zero harmful effects on your PC.", "NotMyFault",
               MessageBoxButtons.YesNo, MessageBoxIcon.None) == DialogResult.Yes)
            {
                NotMyFault notMyFault = new NotMyFault();
                notMyFault.ShowDialog();
            }
        }
    }
}
