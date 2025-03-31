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
    public partial class HourlyForecastForm : UserControl
    {
        public HourlyForecastForm()
        {
            InitializeComponent();
        }

        private void cyberScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            // Adjust the panel's vertical scroll position based on the scrollbar's value
            flowLayoutPanel2.VerticalScroll.Value = e.NewValue;
            flowLayoutPanel2.PerformLayout();
        }
    }
}
