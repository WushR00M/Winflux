using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winflux.Winflux.Main.Views.Informative
{
    public partial class WindowsActivStats : Form
    {
        public WindowsActivStats()
        {
            InitializeComponent();
            // i'll figure out how to optimize this later lol

            if (GlobalFunc.checkedActivation == true)
            {
                if (IsWindowsActivated() == true)
                {
                    label1.Text = "Windows is activated!";
                } else {
                    label1.Text = "Windows is not activated! You can activate it using the module below.";
                }
            } else {
                while (GlobalFunc.checkedActivation == false)
                {
                    while (IsWindowsActivated() == false)
                    {
                        System.Threading.Thread.Sleep(1000); // Wait for 1 second before checking again
                    }
                }
            }
        }

        public static bool IsWindowsActivated()
        {
            ManagementScope scope = new ManagementScope(@"\\" + System.Environment.MachineName + @"\root\cimv2");
            scope.Connect();

            SelectQuery searchQuery = new SelectQuery("SELECT Id FROM SoftwareLicensingProduct WHERE ApplicationID = '55c92734-d682-4d71-983e-d6ec3f16059f' and LicenseStatus = 1");
            ManagementObjectSearcher searcherObj = new ManagementObjectSearcher(scope, searchQuery);

            if (searcherObj.Get().Count > 0)
            {
                GlobalFunc.checkedActivation = true; // Set the flag to true since Windows is activated
                return true; // Windows is activated
            }
            else
            {
                GlobalFunc.checkedActivation = true; // Set the flag to true since Windows is activated
                return false; // Windows is not activated
            }
        }
    }
}
