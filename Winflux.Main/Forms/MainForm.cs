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
using Winflux.Winflux.Main.Views;
using Winflux.Winflux.Main.Views.Appearance;
using Winflux.Winflux.Main.Views.Informative;

namespace Winflux
{
    public partial class MainForm : Form
    {
        private DarkModeCS dm = null;
        private Form dispForm = null;

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
            GlobalFunc.ExecuteCommand("taskkill /f /im explorer.exe");
            GlobalFunc.ExecuteCommand("start explorer.exe");
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Messenger.MessageBox("Are you sure you want to log out of Windows? Save any and all unsaved work before proceeding.", "Log Out of Windows",
               MessageBoxButtons.YesNo, MessageBoxIcon.None) == DialogResult.Yes)
                    {
                GlobalFunc.ExecuteCommand("shutdown /l");
            }
        }

        private void powerCycleRestartPCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Messenger.MessageBox("Are you sure you want to restart Windows? Save any and all unsaved work before proceeding.", "Restart Windows",
               MessageBoxButtons.YesNo, MessageBoxIcon.None) == DialogResult.Yes)
            {
                GlobalFunc.ExecuteCommand("shutdown /r /t 0");
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

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode tn = treeView1.SelectedNode;
            splitContainer1.Panel2.Controls.Clear();

            if (tn == null) { return; }
            else if (tn.Text == "System Information") {
                Winflux.Main.Views.Informative.SystemInformation dispForm = new Winflux.Main.Views.Informative.SystemInformation();

                dispForm.TopLevel = false;
                dispForm.FormBorderStyle = FormBorderStyle.None;

                splitContainer1.Panel2.Controls.Add(dispForm);
                dispForm.Show();
            }
            else if (tn.Text == "About Winflux")
            {
                AboutWF_Tree dispForm = new AboutWF_Tree();

                dispForm.TopLevel = false;
                dispForm.FormBorderStyle = FormBorderStyle.None;

                splitContainer1.Panel2.Controls.Add(dispForm);
                dispForm.Show();
            }
            else if (tn.Text == "View Source Page")
            {
                ProcessStartInfo sInfo = new ProcessStartInfo("https://github.com/WushR00M/Winflux/");
                Process.Start(sInfo);
            }
            else if (tn.Text == "Check Windows Activation Status")
            {
                WindowsActivStats dispForm = new WindowsActivStats();

                dispForm.TopLevel = false;
                dispForm.FormBorderStyle = FormBorderStyle.None;

                splitContainer1.Panel2.Controls.Add(dispForm);
                dispForm.Show();
            }
            else if (tn.Text == "Enable Better Context Menus")
            {
                BetterContext dispForm = new BetterContext();

                dispForm.TopLevel = false;
                dispForm.FormBorderStyle = FormBorderStyle.None;

                splitContainer1.Panel2.Controls.Add(dispForm);
                dispForm.Show();
            }
            else if (tn.Text == "Activate \'Aero Lite\'")
            {
                AeroLite dispForm = new AeroLite();

                dispForm.TopLevel = false;
                dispForm.FormBorderStyle = FormBorderStyle.None;

                splitContainer1.Panel2.Controls.Add(dispForm);
                dispForm.Show();
            }
        }
    }
}
