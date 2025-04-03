using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherSphereV4.Models
{
    public class HourlyForecastData
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public Hourly hourly { get; set; }

        public Daily daily { get; set; }
    }

    public class Hourly
    {
        public List<string> time { get; set; }
        public List<double> apparent_temperature { get; set; }
        public List<int> weather_code { get; set; }
        public List<int> relative_humidity_2m { get; set; }
        public List<double> wind_speed_10m { get; set; }
        public List<int> cloud_cover { get; set; }
        public List<double> uv_index { get; set; }
        public List<double> pressure_msl { get; set; }
        
    }

    public class Daily
    {
        public List<string> time { get; set; } 
        public List<string> sunrise { get; set; }
        public List<string> sunset { get; set; }
        public List<int> weather_code { get; set; }
    }
}
