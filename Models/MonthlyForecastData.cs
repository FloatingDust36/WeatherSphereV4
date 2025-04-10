using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherSphereV4.Models
{
    public class MonthlyForecastData
    {

        public DailyInfo daily { get; set; }
    }

    public class DailyInfo
    {
        public List<string> time { get; set; }
        public List<int> weather_code { get; set; }
        public List<double> temperature_2m_mean { get; set; }
    }
}
