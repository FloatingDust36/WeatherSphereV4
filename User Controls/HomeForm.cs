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

            if(string.IsNullOrEmpty(jsonString))
            {
                MessageBox.Show("Failed to load weather data.");
                return;
            }

            // 🌥️ Deserialize weather data
            CurrentWeatherData weatherData = processCurrentWeatherData.DeserializeCurrentWeatherData(jsonString);
            CurrentWeather currentWeather = weatherData.currentWeather;
            DailyWeather dailyWeather = weatherData.dailyWeather;

            // ✅ Update UI with weather data
            UpdateWeatherUI(currentWeather, dailyWeather, location);
        }

        private async void UpdateWeatherUI(CurrentWeather current, DailyWeather daily, string location)
        {
            labelTemperature.Text = $"{current.temperature_2m}°C";
            labelFeelsLike.Text = $"Feels like {current.apparent_temperature}°C";
            labelHumidity.Text = $"{current.relative_humidity_2m}%";
            labelWindSpeed.Text = $"{current.wind_speed_10m} m/s";
            labelCloudCover.Text = $"{current.cloud_cover}%";
            labelPressure.Text = $"{current.pressure_msl} hPa";

            labelSunrise.Text = daily.sunrise[0].Substring(11, 5) + " AM";
            labelSunset.Text = daily.sunset[0].Substring(11, 5) + " PM";
            labelUVIndex.Text = daily.uv_index_max[0].ToString();

            // 🕰️ Display the current date
            DateTime date = DateTime.Parse(current.time);
            labelCurrentDate.Text = date.ToString("dddd, MMMM dd, yyyy");

            // 🌤️ Display weather description and GIF icon
            bool isDay = date.Hour >= 6 && date.Hour <= 18;  // Daytime check
            var condition = WeatherCodeDescription.GetCondition(current.weather_code);

            labelDescription.Text = condition.Description;

            // 🌟 Display GIF icon dynamically
            string icon = isDay ? condition.DayIcon : condition.NightIcon;
            DisplayWeatherIcon(icon);

            // 📍 Display location
            string address = await processGeocoding.GetCompleteAddress(location);
            labelLocation.Text = address;
        }

        // 🌤️ Display weather icon GIF dynamically
        private void DisplayWeatherIcon(string icon)
        {
            try
            {
                string iconPath = $@"{Application.StartupPath}\Icons\{icon}.gif";
                if (System.IO.File.Exists(iconPath))
                {
                    pictureWeatherIcon.ImageLocation = iconPath;
                }
                else
                {
                    pictureWeatherIcon.ImageLocation = $@"{Application.StartupPath}\Icons\unknown.gif";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading icon: {ex.Message}");
            }
        }

        // 🔍 Search button click event
        private async void buttonHomeSearch_Click(object sender, EventArgs e)
        {
            string location = textboxHomeSearch.Text;

            if (string.IsNullOrEmpty(location))
            {
                MessageBox.Show("Please enter a location.");
                return;
            }

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

