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

namespace Winflux.Winflux.Main.Views.Informative
{
    public partial class AboutWF_Tree : Form
    {
        public AboutWF_Tree()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("https://github.com/WushR00M/Winflux/");
            Process.Start(sInfo);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("https://www.patreon.com/wushroomnimbus");
            Process.Start(sInfo);
        }
    }
}
