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
using GMap.NET;

namespace WeatherSphereV4
{
    public partial class MapsForm : UserControl
    {
        private string siteUrl = "https://api.open-meteo.com/v1/forecast";
        private ProcessWeatherData processWeatherData;
        private ProcessGeocoding processGeocoding;

        string lat = WeatherSharedData.Latitude;
        string lon = WeatherSharedData.Longitude;
        string location = WeatherSharedData.Location;

        private Point mouseDownPosition;
        private double lastZoomLevel;

        private bool isDragging = false;

        public MapsForm()
        {
            InitializeComponent();
            processWeatherData = new ProcessWeatherData();
            processGeocoding = new ProcessGeocoding();

            gMapControl.MapProvider = GMap.NET.MapProviders.GMapProviders.GoogleMap;
            gMapControl.Dock = DockStyle.Fill;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            gMapControl.ShowCenter = false;
            // allows dragging the map with the left mouse button
            gMapControl.DragButton = MouseButtons.Left;

            gMapControl.Position = new PointLatLng(Convert.ToDouble(lat), Convert.ToDouble(lon));
            gMapControl.Zoom = 12;
            AddMarker();
            LoadCurrentWeatherData(lat, lon, location);
        }

        private void gMapControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                mouseDownPosition = e.Location; // Store the initial position
            }
        }

        private void gMapControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        private void gMapControl_MouseClick(object sender, MouseEventArgs e)
        {
            // Check if the mouse moved significantly before releasing (indicating a drag)
            if (Math.Abs(e.X - mouseDownPosition.X) > 5 || Math.Abs(e.Y - mouseDownPosition.Y) > 5)
            {
                return; // Ignore click, as it's actually a drag
            }

            // Store the current zoom level before updating the position
            lastZoomLevel = gMapControl.Zoom;

            lat = gMapControl.FromLocalToLatLng(e.X, e.Y).Lat.ToString();
            lon = gMapControl.FromLocalToLatLng(e.X, e.Y).Lng.ToString();

            GoToCoordinate();
        }

        private async void GoToCoordinate()
        {
            gMapControl.Position = new PointLatLng(Convert.ToDouble(lat), Convert.ToDouble(lon));

            // Restore the previous zoom level instead of resetting
            gMapControl.Zoom = lastZoomLevel;
            gMapControl.Update();

            AddMarker();

            // Reverse geocode asynchronously
            location = await processGeocoding.GetCompleteAddressFromLatLon(lat, lon);
            await LoadCurrentWeatherData(lat, lon, location);
        }

        private void AddMarker()
        {
            gMapControl.Overlays.Clear();

            //Layer count is just a variable to add new OverLays with different names
            var markersOverlay = new GMap.NET.WindowsForms.GMapOverlay("marker1");

            //Marker far away in Quebec, Canada just to check my point in discussion    
            var marker = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
              new PointLatLng(Convert.ToDouble(lat), Convert.ToDouble(lon)),
              GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red_small);

            markersOverlay.Markers.Add(marker);
            gMapControl.Overlays.Add(markersOverlay);
        }

        private async Task LoadCurrentWeatherData(string lat, string lon, string location)
        {
            string current = "weather_code,temperature_2m,apparent_temperature";
            string endpoint = $"?latitude={lat}&longitude={lon}&current={current}";
            string final = $"{endpoint}&timezone=auto&forecast_days=1";

            string jsonString = await processWeatherData.GetJsonString(siteUrl, final);

            if (string.IsNullOrEmpty(jsonString))
            {
                MessageBox.Show("Failed to load weather data.");
                return;
            }

            // 🌥️ Deserialize weather data
            CurrentWeatherData weatherData = processWeatherData.DeserializeCurrentWeatherData(jsonString);
            CurrentWeather currentWeather = weatherData.currentWeather;
            DailyWeather dailyWeather = weatherData.dailyWeather;

            // ✅ Update UI with weather data
            UpdateWeatherUI(currentWeather, dailyWeather, location);
        }

        private async void UpdateWeatherUI(CurrentWeather current, DailyWeather daily, string location)
        {
            labelTemperature.Text = $"{current.temperature_2m}°C";
            labelFeelsLike.Text = $"Feels like {current.apparent_temperature}°C";

            // 🕰️ Display the current date
            DateTime date = DateTime.Parse(current.time);
            labelCurrentDate.Text = date.ToString("dddd, MMMM dd, yyyy");

            // 🌤️ Display weather description and GIF icon
            bool isDay = date.Hour >= 6 && date.Hour <= 18;  // Daytime check
            var condition = WeatherCodeDescription.GetCondition(current.weather_code);

            labelDescription.Text = condition.Description;

            // 🌟 Display GIF icon dynamically
            string icon = isDay ? condition.DayIcon : condition.NightIcon;
            DisplayWeatherIcon(pictureWeatherIcon, icon);

            // 📍 Display location
            labelLocation.Text = location;
        }

        private void DisplayWeatherIcon(PictureBox pictureBox, string icon)
        {
            try
            {
                string iconPath = $@"{Application.StartupPath}\Icons\{icon}.gif";
                if (System.IO.File.Exists(iconPath))
                {
                    pictureBox.ImageLocation = iconPath;
                }
                else
                {
                    pictureBox.ImageLocation = $@"{Application.StartupPath}\Icons\unknown.gif";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading icon: {ex.Message}");
            }
        }

        private void buttonHomeSearch_MouseEnter(object sender, EventArgs e)
        {
            buttonHomeSearch.IconSize = 45;
        }

        private void buttonHomeSearch_MouseLeave(object sender, EventArgs e)
        {
            buttonHomeSearch.IconSize = 35;
        }

        private async Task buttonHomeSearch_ClickAsync(object sender, EventArgs e)
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
                // 📍 Display location
                string address = await processGeocoding.GetCompleteAddressFromSearchTerm(location);

                gMapControl.Position = new PointLatLng(Convert.ToDouble(lat), Convert.ToDouble(lon));
                gMapControl.Zoom = 12;
                gMapControl.Update();
                AddMarker();
                await LoadCurrentWeatherData(lat, lon, address);
            }
            else
            {
                MessageBox.Show("Location not found. Try being more specific.");
            }
        }
    }

}
