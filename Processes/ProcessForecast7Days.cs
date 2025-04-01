using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherSphereV4.Models;

namespace WeatherSphereV4.Processes
{
    public class ProcessForecast7Days
    {
        public Forecast7Days DeserializeForecast7Days(string json)
        {
            return JsonConvert.DeserializeObject<Forecast7Days>(json);
        }
        public async Task<string> GetJsonString(string siteUrl, string final)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(siteUrl);

                HttpResponseMessage response = await client.GetAsync(final);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }

                return "Could not retrieve JSON Object";
            }
        }
    }
}
