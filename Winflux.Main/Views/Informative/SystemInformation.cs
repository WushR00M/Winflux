using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using Microsoft.Win32;
using DarkModeForms;

namespace Winflux.Winflux.Main.Views.Informative
{
    public partial class SystemInformation : Form
    {
        private DarkModeCS dm = null;
        public SystemInformation()
        {
            InitializeComponent();
            dm = new DarkModeCS(this)
            {
                ColorMode = DarkModeCS.DisplayMode.DarkMode
            };

            StringBuilder sb = new StringBuilder();

            label1.Text = "System Information";
            sb.AppendLine(GetManagementObject("Win32_OperatingSystem", "Caption", "Windows Version"));
            sb.AppendLine(GetManagementObject("Win32_OperatingSystem", "Version", "OS Build"));
            sb.AppendLine(GetManagementObject("Win32_OperatingSystem", "Manufacturer", "Manufacturer"));
            sb.AppendLine();

            sb.AppendLine(GetManagementObject("Win32_Processor", "Name", "Processor Name"));
            sb.AppendLine(GetManagementObject("Win32_Processor", "Manufacturer", "Processor Manufacturer"));
            sb.AppendLine(GetManagementObject("Win32_Processor", "Description", "Processor Description"));
            sb.AppendLine();

            sb.AppendLine(GetManagementObject("Win32_PhysicalMemory", "Capacity", "Memory Capacity"));
            sb.AppendLine(GetManagementObject("Win32_PhysicalMemory", "Speed", "Memory Speed"));
            sb.AppendLine();

            richTextBox1.Text = sb.ToString();
        }
        private string GetManagementObject(string query, string property, string label)
        {
            StringBuilder sb = new StringBuilder();
            ManagementObjectSearcher searcher = new ManagementObjectSearcher($"SELECT {property} FROM {query}");
            foreach (ManagementObject obj in searcher.Get())
            {
                sb.Append($"{label}: {obj[property]}");
            }
            return sb.ToString();
        }
    }
}
