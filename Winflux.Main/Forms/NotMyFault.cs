using DarkModeForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winflux.Winflux.Main.Forms
{
    public partial class NotMyFault : Form
    {
        private DarkModeCS dm = null;
        [DllImport("ntdll.dll")]
        private static extern uint RtlAdjustPrivilege(int privilege, bool bEnablePrivilege, bool isThreadPrivilege, out bool previousValue);

        [DllImport("ntdll.dll")]
        private static extern uint NtRaiseHardError(uint errorStatus, uint numberOfParameters, uint unicodeStringParameterMask, IntPtr parameters, uint validResponseOption, out uint response);

        private const int Privilege = 19;

        private const uint ErrorStatus = 0xc0000022;

        private const uint ValidResponseOption = 6;
        public NotMyFault()
        {
            InitializeComponent();
            dm = new DarkModeCS(this)
            {
                ColorMode = DarkModeCS.DisplayMode.DarkMode
            };
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                button1.Enabled = true;
                button1.Cursor = Cursors.Default;
            }
            else
            {
                button1.Enabled = false;
                button1.Cursor = Cursors.No;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NtRaiseHardError();
        }

        public static void NtRaiseHardError()
        {
            try
            {
                _ = RtlAdjustPrivilege(Privilege, true, false, out _);

                NtRaiseHardError(ErrorStatus, 0, 0, IntPtr.Zero, ValidResponseOption, out _);
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}
