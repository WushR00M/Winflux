using DarkModeForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Winflux.Winflux.Main.Views.Appearance
{
    public partial class AltTabApp : Form
    {
        public AltTabApp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int parsedValue;
            if (int.TryParse(textBox1.Text, out parsedValue))
            {
                if (parsedValue < 0 || parsedValue > 100)
                {
                    Messenger.MessageBox("Value input is invalid, must be between 0 and 100.", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.None);
                    return;
                } else
                {
                    GlobalFunc.ExecuteCommand("reg.exe add \"HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MultitaskingView\\AltTabViewHost\" /v Grid_backgroundPercent /t REG_DWORD /d " + parsedValue.ToString() + " /f");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int parsedValue;
            if (int.TryParse(textBox2.Text, out parsedValue))
            {
                if (parsedValue < 0 || parsedValue > 100)
                {
                    Messenger.MessageBox("Value input is invalid, must be between 0 and 100.", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.None);
                    return;
                }
                else
                {
                    GlobalFunc.ExecuteCommand("reg.exe add \"HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MultitaskingView\\AltTabViewHost\" /v BackgroundDimmingLayer_percent /t REG_DWORD /d " + parsedValue.ToString() + " /f");
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                GlobalFunc.ExecuteCommand("reg.exe add \"HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\" /v AltTabSettings /t REG_DWORD /d 1 /f");
            }
            else
            {
                GlobalFunc.ExecuteCommand("reg.exe add \"HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\" /v AltTabSettings /t REG_DWORD /d 0 /f");
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                GlobalFunc.ExecuteCommand("reg.exe add \"HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MultitaskingView\\AltTabViewHost\" /v wallpaper /t REG_DWORD /d 1 /f");
            }
            else
            {
                GlobalFunc.ExecuteCommand("reg.exe add \"HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MultitaskingView\\AltTabViewHost\" /v wallpaper /t REG_DWORD /d 0 /f");
            }
        }
    }
}
