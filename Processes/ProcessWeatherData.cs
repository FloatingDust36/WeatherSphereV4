using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherSphereV4.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Configuration;

namespace WeatherSphereV4.Processes
{
    public class ProcessWeatherData
    {
        private static readonly string ApiBaseUrl = ConfigurationManager.AppSettings["WeatherApiBaseUrl"] ?? "https://api.open-meteo.com/v1/forecast";

        public CurrentWeatherData DeserializeCurrentWeatherData(string json)
        {
            return JsonConvert.DeserializeObject<CurrentWeatherData>(json);
        }

        public Forecast7Days DeserializeForecast7Days(string json)
        {
            return JsonConvert.DeserializeObject<Forecast7Days>(json);
        }

        public HourlyForecastData DeserializeHourlyForecast(string json)
        {
            return JsonConvert.DeserializeObject<HourlyForecastData>(json);
        }
        public MonthlyForecastData DeserializeMonthlyForecast(string json)
        {
            return JsonConvert.DeserializeObject<MonthlyForecastData>(json);
        }

        public async Task<string> GetJsonString(string Url)
        {
            string fullUrl = ApiBaseUrl + Url;
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(fullUrl);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }

                string errorMessage = await response.Content.ReadAsStringAsync();
                return $"Error: {response.StatusCode} - {errorMessage}";
            }
        }
    }


}
