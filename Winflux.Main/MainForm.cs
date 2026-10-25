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
    }
}
