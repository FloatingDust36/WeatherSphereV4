using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WeatherSphereV4.Models
{
    public class CurrentWeatherData
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string timezone { get; set; }
        public string timezone_abbreviation { get; set; }
        public double elevation { get; set; }

        [JsonProperty("current")]
        public CurrentWeather currentWeather { get; set; }

        [JsonProperty("daily")]
        public DailyWeather dailyWeather { get; set; }
    }

    public class CurrentWeather
    {
        public string time { get; set; }
        public int weather_code { get; set; }
        public double temperature_2m { get; set; }
        public double apparent_temperature { get; set; }
        public int relative_humidity_2m { get; set; }
        public double wind_speed_10m { get; set; }
        public int cloud_cover { get; set; }
        public double pressure_msl { get; set; }
    }

    public class DailyWeather
    {
        public List<string> sunrise { get; set; }
        public List<string> sunset { get; set; }
        public List<double> uv_index_max { get; set; }
}
}
