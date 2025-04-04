﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherSphereV4.Models;
using Newtonsoft.Json;
using System.Net.Http;

namespace WeatherSphereV4.Processes
{
    public class ProcessWeatherData
    {
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

        public async Task<string> GetJsonString(string siteUrl, string final)
        {
            using (HttpClient client = new HttpClient())
            {
                string fullUrl = siteUrl + final;  // ✅ Ensure full URL is used
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
