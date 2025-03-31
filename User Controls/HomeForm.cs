using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeatherSphereV4.Models;
using WeatherSphereV4.Processes;

namespace WeatherSphereV4
{
    public partial class HomeForm : UserControl
    {
        private string siteUrl = "https://api.open-meteo.com/v1/forecast";

        private ProcessCurrentWeatherData processCurrentWeatherData;
        private ProcessGeocoding processGeocoding;
        public HomeForm()
        {
            InitializeComponent();
            processCurrentWeatherData = new ProcessCurrentWeatherData();
            processGeocoding = new ProcessGeocoding();
        }

        private void buttonHomeSearch_MouseEnter(object sender, EventArgs e)
        {
            buttonHomeSearch.IconSize = 45;
        }

        private void buttonHomeSearch_MouseLeave(object sender, EventArgs e)
        {
            buttonHomeSearch.IconSize = 35;
        }

        private async Task LoadWeatherData(string lat, string lon, string location)
        {
            string current = "weather_code,temperature_2m,apparent_temperature,relative_humidity_2m,wind_speed_10m,cloud_cover,pressure_msl";
            string daily = "sunrise,sunset,uv_index_max";
            string endpoint = $"?latitude={lat}&longitude={lon}&daily={daily}&current={current}";
            string final = $"{endpoint}&timezone=auto&forecast_days=1";

            string jsonString = await processCurrentWeatherData.GetJsonString(siteUrl, final);

            if (!string.IsNullOrEmpty(jsonString))
            {
                CurrentWeatherData currentWeatherData = processCurrentWeatherData.DeserializeCurrentWeatherData(jsonString);
                CurrentWeather currentWeather = currentWeatherData.currentWeather;
                DailyWeather dailyWeather = currentWeatherData.dailyWeather;

                // 🌡️ Display weather data
                labelTemperature.Text = $"{currentWeather.temperature_2m}°C";
                labelFeelsLike.Text = $"Feels like {currentWeather.apparent_temperature}°C";
                labelHumidity.Text = $"{currentWeather.relative_humidity_2m}%";
                labelWindSpeed.Text = $"{currentWeather.wind_speed_10m} m/s";
                labelCloudCover.Text = $"{currentWeather.cloud_cover}%";
                labelPressure.Text = $"{currentWeather.pressure_msl} hPa";

                labelSunrise.Text = dailyWeather.sunrise[0].Substring(11, 5) + " AM";
                labelSunset.Text = dailyWeather.sunset[0].Substring(11, 5) + " PM";
                labelUVIndex.Text = dailyWeather.uv_index_max[0].ToString();

                // 📅 Display formatted date
                DateTime date = DateTime.Parse(currentWeather.time);
                labelCurrentDate.Text = date.ToString("dddd, MMMM dd, yyyy");

                // 🌦️ Weather description
                labelDescription.Text = WeatherCodeDescription.GetDescription(currentWeather.weather_code);

                // 🌍 Get complete address using reverse geocoding
                string address = await processGeocoding.GetCompleteAddress(location);
                labelLocation.Text = address;
            }
            else
            {
                MessageBox.Show("Failed to load weather data.");
            }
        }

        private async void buttonHomeSearch_Click(object sender, EventArgs e)
        {
            string location = textboxHomeSearch.Text;

            if (string.IsNullOrEmpty(location))
            {
                MessageBox.Show("Please enter a location.");
                return;
            }

            // 🌍 Get latitude and longitude using geocoding
            var (lat, lon) = await processGeocoding.GetCoordinates(location);

            if (!string.IsNullOrEmpty(lat) && !string.IsNullOrEmpty(lon))
            {
                await LoadWeatherData(lat, lon, location);
            }
            else
            {
                MessageBox.Show("Location not found. Try being more specific.");
            }
        }
    }
}
