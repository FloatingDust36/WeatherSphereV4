using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherSphereV4
{
    public partial class HomeForm : UserControl
    {
        public HomeForm()
        {
            InitializeComponent();
        }

        private void buttonHomeSearch_MouseHover(object sender, EventArgs e)
        {
            buttonHomeSearch.IconSize = 45;
        }

        private void buttonHomeSearch_MouseEnter(object sender, EventArgs e)
        {
            buttonHomeSearch.IconSize = 45;
        }

        private void buttonHomeSearch_MouseLeave(object sender, EventArgs e)
        {
            buttonHomeSearch.IconSize = 35;
        }
    }
}
