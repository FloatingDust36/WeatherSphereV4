using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherSphereV4.Processes
{
    public class ProcessGeocoding
    {
        private static readonly HttpClient client = new HttpClient();

        // 🌍 Geocoding method to get coordinates
        public async Task<(string latitude, string longitude)> GetCoordinates(string location)
        {
            var result = await GetGeocodingData(location);
            if (result != null)
            {
                string lat = result["latitude"].ToString();
                string lon = result["longitude"].ToString();
                return (lat, lon);
            }
            return (null, null);  // No result found
        }

        // 🌍 Geocoding method to get complete address
        public async Task<string> GetCompleteAddress(string location)
        {
            var result = await GetGeocodingData(location);
            if (result != null)
            {
                string name = result["name"]?.ToString() ?? "Unknown";
                string admin3 = result["admin3"]?.ToString();
                if (name == admin3)
                {
                    admin3 = "";
                }
                string admin2 = result["admin2"]?.ToString() ?? "";
                string admin1 = result["admin1"]?.ToString() ?? "";
                string country = result["country"]?.ToString() ?? "Unknown";

                var addressComponents = new List<string> { name, admin3, admin2, admin1, country };
                var nonEmptyComponents = addressComponents.Where(component => !string.IsNullOrWhiteSpace(component));

                return string.Join(", ", nonEmptyComponents);
            }
            return "No result found";  // No result found
        }

        // 🌍 Private method to get geocoding data
        private async Task<JToken> GetGeocodingData(string location)
        {
            try
            {
                // 🌐 OpenStreetMap Nominatim API
                string url = $"https://geocoding-api.open-meteo.com/v1/search?name={location}&count=1&language=en&format=json";

                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var json = JObject.Parse(jsonResponse);

                    var results = json["results"] as JArray;
                    if (results != null && results.Count > 0)
                    {
                        return results[0];
                    }
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            return null;
        }
    }
}
