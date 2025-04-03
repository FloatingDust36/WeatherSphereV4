using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherSphereV4.Models;
using Newtonsoft.Json;
using System.Net.Http;


namespace WeatherSphereV4.Processes
{
    public class ProcessWeatherAPI
    {
        private ProcessWeatherData processWeatherData = new ProcessWeatherData();
        private string url = "https://api.open-meteo.com/v1/forecast?";

        public async Task<string> GetWeatherDataAsync(string queriesFinal) 
        {
            string fullUrl = url + queriesFinal;
            //MessageBox.Show($"Requesting URL: {fullUrl}");  // ✅ Log full URL

            string jsonString = await processWeatherData.GetJsonString(url, queriesFinal);

            if (string.IsNullOrEmpty(jsonString) || jsonString.StartsWith("Error"))
            {
                MessageBox.Show($"Failed to load weather data. Response: {jsonString}");
            }
            return jsonString;
        }
    }
}
