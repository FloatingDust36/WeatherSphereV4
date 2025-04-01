using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeatherSphereV4.Models
{
    public class Forecast7Days
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string timezone { get; set; }
        public string timezone_abbreviation { get; set; }
        public double elevation { get; set; }

        [JsonProperty("daily")]
        public DailyForecast dailyForecast { get; set; }
    }

    public class DailyForecast
    {
        public List<string> time { get; set; }

        public List<int> weather_code { get; set; }

        public List<double> temperature_2m_mean { get; set; }
    }
}
