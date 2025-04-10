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
        private static readonly HttpClient httpClient = new HttpClient();

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

        public async Task<string> GetJsonString(string relativeUrl)
        {
            string fullUrl = ApiBaseUrl + relativeUrl;

            HttpResponseMessage response = await httpClient.GetAsync(fullUrl);

            response.EnsureSuccessStatusCode(); // This will throw an HttpRequestException if the status code is not success (e.g., 404 Not Found, 500 Server Error)

            // If EnsureSuccessStatusCode doesn't throw, we have a successful response
            return await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// Performs a generic GET request to the specified URL using the shared HttpClient.
        /// Throws HttpRequestException on non-success status codes.
        /// </summary>
        /// <param name="url">The absolute URL to request.</param>
        /// <param name="timeoutSeconds">Optional timeout in seconds (default 10).</param>
        /// <returns>The response body as a string.</returns>
        public static async Task<string> GetGenericJsonAsync(string url, int timeoutSeconds = 10)
        {
            // Note: HttpClient timeout is typically set once on the static client,
            // but we can use a CancellationTokenSource for per-request timeout if needed.
            // For simplicity here, we rely on the default HttpClient timeout or assume short requests.
            // If you need strict per-request timeouts, CancellationTokenSource is better.

            try
            {
                // Use the existing static httpClient instance
                HttpResponseMessage response = await httpClient.GetAsync(url);

                // Check for HTTP errors (4xx, 5xx) and throw exception if found
                response.EnsureSuccessStatusCode();

                // Read the content if successful
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                // Log or handle specific HTTP request errors
                Console.WriteLine($"HTTP Request Error in GetGenericJsonAsync for {url}: {ex.Message}");
                // Re-throw the exception so the caller knows the request failed
                throw;
            }
            catch (Exception ex)
            {
                // Catch other potential exceptions (e.g., network issues)
                Console.WriteLine($"Generic Error in GetGenericJsonAsync for {url}: {ex.Message}");
                // Re-throw or handle as appropriate
                throw; // Re-throwing maintains the original exception stack trace
            }
        }
    }


}
