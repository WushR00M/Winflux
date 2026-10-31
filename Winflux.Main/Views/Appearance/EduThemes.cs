using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winflux.Winflux.Main.Views.Appearance
{
    public partial class EduThemes : Form
    {
        public EduThemes()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                GlobalFunc.ExecuteCommand("reg.exe add \"HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\PolicyManager\\current\\device\\Education\" /v EnableEduThemes /t REG_DWORD /d 1 /f");
            }
            else
            {
                GlobalFunc.ExecuteCommand("reg.exe delete \"HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\PolicyManager\\current\\device\\Education\" /v EnableEduThemes /f");
            }
        }
    }
}
