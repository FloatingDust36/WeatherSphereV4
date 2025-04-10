using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherSphereV4.Models
{
    public class IpApiLocationInfo
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("regionName")]
        public string RegionName { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("lat")]
        public double? Lat { get; set; } // Use nullable double for safety

        [JsonProperty("lon")]
        public double? Lon { get; set; } // Use nullable double for safety

        [JsonProperty("message")]
        public string Message { get; set; } // For error messages from API
    }
}
