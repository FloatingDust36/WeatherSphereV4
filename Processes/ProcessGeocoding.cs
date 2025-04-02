using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace WeatherSphereV4.Processes
{
    public class ProcessGeocoding
    {
        private static readonly HttpClient client = new HttpClient();
        private const string API_KEY = "85e2944515b74cee9890ceb03f1a333c";

        // 🌍 Geocoding: Get coordinates from a search term
        public async Task<(string latitude, string longitude)> GetCoordinates(string location)
        {
            var result = await GetGeocodingData(location);
            if (result != null)
            {
                string lat = result["geometry"]["lat"].ToString();
                string lon = result["geometry"]["lng"].ToString();
                return (lat, lon);
            }
            return (null, null); // No result found
        }

        // 🌍 Geocoding: Get complete address from a search term
        public async Task<string> GetCompleteAddressFromSearchTerm(string location)
        {
            var result = await GetGeocodingData(location);
            if (result != null)
            {
                return result["formatted"].ToString();
            }
            return "No result found"; // No result found
        }

        // 🌍 Reverse Geocoding: Get complete address from latitude & longitude
        public async Task<string> GetCompleteAddressFromLatLon(string lat, string lon)
        {
            try
            {
                string url = $"https://api.opencagedata.com/geocode/v1/json?q={lat}+{lon}&key={API_KEY}&limit=1";
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var json = JObject.Parse(jsonResponse);
                    var results = json["results"] as JArray;

                    if (results != null && results.Count > 0)
                    {
                        return results[0]["formatted"].ToString();
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
            return "No result found";
        }

        // 🌍 Private method to get geocoding data (for search term-based geocoding)
        private async Task<JToken> GetGeocodingData(string location)
        {
            try
            {
                string url = $"https://api.opencagedata.com/geocode/v1/json?q={location}&key={API_KEY}&limit=1";
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
