using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeatherSphereV4.Processes;
using WeatherSphereV4.Models;
using GMap.NET.WindowsForms;

namespace WeatherSphereV4
{
    public partial class MapsForm : UserControl
    {
        private string siteUrl = "https://api.open-meteo.com/v1/forecast";
        private ProcessCurrentWeatherData processCurrentWeatherData;
        private ProcessGeocoding processGeocoding;

        string latitude = WeatherSharedData.Latitude;
        string longitude = WeatherSharedData.Longitude;
        string location = WeatherSharedData.Location;

        public MapsForm()
        {
            InitializeComponent();
            processCurrentWeatherData = new ProcessCurrentWeatherData();
            processGeocoding = new ProcessGeocoding();

            // Configure GMapControl
            gMapControl.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gMapControl.Zoom = 10;  // Set initial zoom level
            gMapControl.Position = new GMap.NET.PointLatLng(double.Parse(latitude), double.Parse(longitude));  // Set initial position (New York)
            gMapControl.MouseClick += GMapControl_MouseClick;
        }

        private void buttonHomeSearch_MouseEnter(object sender, EventArgs e)
        {
            buttonHomeSearch.IconSize = 45;
        }

        private void buttonHomeSearch_MouseLeave(object sender, EventArgs e)
        {
            buttonHomeSearch.IconSize = 35;
        }

        private async void GMapControl_MouseClick(object sender, MouseEventArgs e)
        {
            // Get the clicked latitude and longitude
            double lat = gMapControl.FromLocalToLatLng(e.X, e.Y).Lat;
            double lon = gMapControl.FromLocalToLatLng(e.X, e.Y).Lng;

            // Use the reverse geocoding method to get the address
            string location = await processGeocoding.GetCompleteAddressFromLatLon(lat.ToString(), lon.ToString());

            // Store the coordinates and location
            WeatherSharedData.Latitude = lat.ToString();
            WeatherSharedData.Longitude = lon.ToString();
            WeatherSharedData.Location = location;

            // Load the weather data for the clicked location
            await LoadCurrentWeatherData(lat.ToString(), lon.ToString(), location);
        }

        private async Task LoadCurrentWeatherData(string lat, string lon, string location)
        {
            string current = "weather_code,temperature_2m,apparent_temperature,relative_humidity_2m,wind_speed_10m,cloud_cover,pressure_msl";
            string daily = "sunrise,sunset,uv_index_max";
            string endpoint = $"?latitude={lat}&longitude={lon}&daily={daily}&current={current}";
            string final = $"{endpoint}&timezone=auto&forecast_days=1";

            string jsonString = await processCurrentWeatherData.GetJsonString(siteUrl, final);

            if (string.IsNullOrEmpty(jsonString))
            {
                MessageBox.Show("Failed to load weather data.");
                return;
            }

            // Deserialize weather data and update UI
            CurrentWeatherData weatherData = processCurrentWeatherData.DeserializeCurrentWeatherData(jsonString);
            CurrentWeather currentWeather = weatherData.currentWeather;
            DailyWeather dailyWeather = weatherData.dailyWeather;

            // Update UI with weather data
            UpdateWeatherUI(currentWeather, dailyWeather, location);
        }

        private async void UpdateWeatherUI(CurrentWeather current, DailyWeather daily, string location)
        {
            labelTemperature.Text = $"{current.temperature_2m}°C";
            labelFeelsLike.Text = $"Feels like {current.apparent_temperature}°C";

            DateTime date = DateTime.Parse(current.time);
            labelCurrentDate.Text = date.ToString("dddd, MMMM dd, yyyy");

            bool isDay = date.Hour >= 6 && date.Hour <= 18;  // Daytime check
            var condition = WeatherCodeDescription.GetCondition(current.weather_code);

            labelDescription.Text = condition.Description;

            string icon = isDay ? condition.DayIcon : condition.NightIcon;
            DisplayWeatherIcon(icon);

            // Display location
            labelLocation.Text = location;
        }

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

        // 🔍 Search button click event to search by location
        private async void buttonHomeSearch_Click(object sender, EventArgs e)
        {
            string location = textboxHomeSearch.Text;

            if (string.IsNullOrEmpty(location))
            {
                MessageBox.Show("Please enter a location.");
                return;
            }

            // Use your geocoding method to get coordinates
            var (lat, lon) = await processGeocoding.GetCoordinates(location);

            if (!string.IsNullOrEmpty(lat) && !string.IsNullOrEmpty(lon))
            {
                // Move map to searched location
                gMapControl.Position = new GMap.NET.PointLatLng(double.Parse(lat), double.Parse(lon));

                // Load weather data for searched location
                await LoadCurrentWeatherData(lat, lon, location);
            }
            else
            {
                MessageBox.Show("Location not found. Try being more specific.");
            }
        }
    }

}
