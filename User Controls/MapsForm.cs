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
    public partial class MapsForm: UserControl
    {
        public MapsForm()
        {
            InitializeComponent();
            webView21.Source = new Uri("https://www.google.com/maps");
        }
    }
}
