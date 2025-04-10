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
using WeatherSphereV4.Utilities;
using FontAwesome.Sharp;

namespace WeatherSphereV4
{
    public partial class MapsForm : UserControl
    {
        private const string ApiBaseUrl = "https://api.open-meteo.com/v1/forecast";
        private const string CurrentWeatherParameters = "is_day,weather_code,temperature_2m,apparent_temperature";
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

        private void buttonHomeSearch_MouseEnter(object sender, EventArgs e)
        {
            UIHelper.SetIconButtonSize(sender, UIHelper.IconSizeSearchHover); // Use 45 directly if you prefer
        }

        private void buttonHomeSearch_MouseLeave(object sender, EventArgs e)
        {
            UIHelper.SetIconButtonSize(sender, UIHelper.IconSizeSearchDefault); // Use 35 directly if you prefer
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
            location = await processGeocoding.GetCompleteAddressFromCoordinates(lat, lon);
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
            HideInfoBar();           // Clear previous info/error messages
            ShowLoadingOverlay();
            buttonHomeSearch.Enabled = false;

            try
            {
                string endpoint = $"?latitude={lat}&longitude={lon}&current={CurrentWeatherParameters}";
                string final = $"{ApiBaseUrl}{endpoint}&timezone=auto&forecast_days=1";

                string jsonString = await processWeatherData.GetJsonString(final);

                if (string.IsNullOrEmpty(jsonString))
                {
                    throw new Exception("Received empty response from weather API."); // Treat empty as error
                }

                CurrentWeatherData weatherData = processWeatherData.DeserializeCurrentWeatherData(jsonString);
                CurrentWeather currentWeather = weatherData.currentWeather;
                DailyWeather dailyWeather = weatherData.dailyWeather;

                UpdateWeatherUI(currentWeather, dailyWeather, location);

                // Optionally show success message briefly:
                // ShowInfoBar("Current weather updated.", InfoBarType.Success);
                // Consider using a Timer to hide success message after a few seconds
            }
            catch (Exception ex)
            {
                // Log the full error details for debugging
                Console.WriteLine($"ERROR loading current weather data: {ex.ToString()}");

                // Show user-friendly error message in the Info Bar
                ShowInfoBar($"Error loading current weather: {ex.Message}", InfoBarType.Error); // Show specific ex.Message

                // Reset the UI elements to a default/empty state
                ClearMapWeatherDataUI(); // Call the specific reset method for this form
            }
            finally
            {
                HideLoadingOverlay();
                buttonHomeSearch.Enabled = true;
            }
        }

        private async void UpdateWeatherUI(CurrentWeather current, DailyWeather daily, string location)
        {
            labelTemperature.Text = $"{current.temperature_2m}°C";
            labelFeelsLike.Text = $"Feels like {current.apparent_temperature}°C";

            // 🕰️ Display the current date
            DateTime date = DateTime.Parse(current.time);
            labelCurrentDate.Text = date.ToString("dddd, MMMM dd, yyyy");

            // 🌤️ Display weather description and GIF icon
            var condition = WeatherCodeDescription.GetCondition(current.weather_code);
            labelDescription.Text = condition.Description;

            // 🌟 Display GIF icon dynamically
            bool isDay = current.is_day == 1;
            string icon = isDay ? condition.DayIcon : condition.NightIcon;
            UIHelper.DisplayWeatherIcon(pictureWeatherIcon, icon);

            // 📍 Display location
            labelLocation.Text = location;
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

        private void ClearMapWeatherDataUI()
        {
            labelTemperature.Text = "--°C";
            labelFeelsLike.Text = "Feels like --°C";
            labelCurrentDate.Text = "----, ---- --, ----";
            labelDescription.Text = "Weather description";
            labelLocation.Text = "Select location";
            UIHelper.DisplayWeatherIcon(pictureWeatherIcon, null);
        }

        #region Loading Overlay & Info Bar Helpers

        /// <summary>
        /// Centers the loading spinner PictureBox within the overlay panel.
        /// Call this from constructor/Load and form's Resize event.
        /// </summary>
        private void CenterLoadingSpinner()
        {
            if (pictureLoadingSpinner != null && panelLoadingOverlay != null)
            {
                // Ensure calculations happen on the UI thread if needed, though Resize/Load usually are.
                int x = (panelLoadingOverlay.ClientSize.Width - pictureLoadingSpinner.Width) / 2;
                int y = (panelLoadingOverlay.ClientSize.Height - pictureLoadingSpinner.Height) / 2;
                // Prevent negative coordinates if spinner is larger than panel
                pictureLoadingSpinner.Location = new Point(Math.Max(0, x), Math.Max(0, y));
            }
        }

        /// <summary>
        /// Shows the loading overlay.
        /// </summary>
        private void ShowLoadingOverlay()
        {
            if (panelLoadingOverlay.InvokeRequired)
            {
                panelLoadingOverlay.Invoke(new Action(ShowLoadingOverlay));
                return;
            }
            CenterLoadingSpinner(); // Recenter before showing
            panelLoadingOverlay.Visible = true;
            panelLoadingOverlay.BringToFront();
        }

        /// <summary>
        /// Hides the loading overlay.
        /// </summary>
        private void HideLoadingOverlay()
        {
            if (panelLoadingOverlay.InvokeRequired)
            {
                panelLoadingOverlay.Invoke(new Action(HideLoadingOverlay));
                return;
            }
            panelLoadingOverlay.Visible = false;
        }

        /// <summary>
        /// Shows the Info Bar panel with a message and appropriate styling.
        /// </summary>
        /// <param name="message">The message to display.</param>
        /// <param name="messageType">Type of message (Info, Success, Warning, Error).</param>
        private void ShowInfoBar(string message, InfoBarType messageType = InfoBarType.Info)
        {
            if (panelInfoBar.InvokeRequired)
            {
                panelInfoBar.Invoke(new Action(() => ShowInfoBar(message, messageType)));
                return;
            }

            labelInfoBarMessage.Text = message;
            Color backColor = Color.CornflowerBlue; // Default
            Color foreColor = Color.White;
            IconChar icon = IconChar.InfoCircle;

            switch (messageType)
            {
                case InfoBarType.Error:
                    backColor = Color.FromArgb(217, 83, 79); // Red
                    icon = IconChar.TimesCircle; // Use TimesCircle for error
                    foreColor = Color.White;
                    break;
                case InfoBarType.Warning:
                    backColor = Color.FromArgb(240, 173, 78); // Yellow
                    icon = IconChar.Warning;
                    foreColor = Color.Black; // Dark text on yellow
                    break;
                case InfoBarType.Success:
                    backColor = Color.FromArgb(92, 184, 92); // Green
                    icon = IconChar.CheckCircle;
                    foreColor = Color.White;
                    break;
                case InfoBarType.Info:
                default:
                    backColor = Color.FromArgb(91, 192, 222); // Blue
                    icon = IconChar.InfoCircle;
                    foreColor = Color.White;
                    break;
            }

            panelInfoBar.BackColor = backColor;
            iconInfoBar.IconChar = icon;
            iconInfoBar.IconColor = foreColor; // Match icon color to text for consistency
            buttonCloseInfoBar.IconColor = foreColor; // Match close button icon color too
            labelInfoBarMessage.ForeColor = foreColor;


            panelInfoBar.Visible = true;
            panelInfoBar.BringToFront(); // Ensure it's visible
        }

        /// <summary>
        /// Hides the Info Bar panel.
        /// </summary>
        private void HideInfoBar()
        {
            if (panelInfoBar.InvokeRequired)
            {
                panelInfoBar.Invoke(new Action(HideInfoBar));
                return;
            }
            panelInfoBar.Visible = false;
        }

        #endregion

        private void buttonCloseInfoBar_Click(object sender, EventArgs e)
        {
            HideInfoBar();
        }
    }
}
