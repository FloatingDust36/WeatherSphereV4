using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeatherSphereV4.UserControls;
using WeatherSphereV4.Processes;
using Newtonsoft.Json;
using WeatherSphereV4.Models;
using WeatherSphereV4.Utilities;
using FontAwesome.Sharp;
using Microsoft.VisualBasic.Logging;

namespace WeatherSphereV4
{
    public partial class HourlyForecastForm : UserControl
    {
        private const string ApiBaseUrl = "https://api.open-meteo.com/v1/forecast";
        private const string DailyWeatherParameters = "sunrise,sunset,weather_code";
        private const string HourlyWeatherParameters = "is_day,weather_code,apparent_temperature,relative_humidity_2m,wind_speed_10m,cloud_cover,uv_index,pressure_msl";
        private ProcessWeatherData processWeatherData = new ProcessWeatherData();
        private HourlyForecastData cachedWeatherData;

        public HourlyForecastForm()
        {
            InitializeComponent();
            LoadHourlyForecast();
        }

        private async Task LoadHourlyForecast()
        {
            HideInfoBar();           // Clear previous info/error messages
            ShowLoadingOverlay();

            try
            {
                string endpoint = $"?latitude={WeatherSharedData.Latitude}&longitude={WeatherSharedData.Longitude}&daily={DailyWeatherParameters}&hourly={HourlyWeatherParameters}";
                string final = $"{ApiBaseUrl}{endpoint}&timezone=auto&forecast_days=7";

                string jsonString = await processWeatherData.GetJsonString(final);

                if (string.IsNullOrEmpty(jsonString))
                {
                    throw new Exception("Received empty response from weather API."); // Treat empty as error
                }

                cachedWeatherData = processWeatherData.DeserializeHourlyForecast(jsonString);
                InitializeControlDaily(cachedWeatherData.hourly, cachedWeatherData.daily);

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
                ClearHourlyWeatherDataUI(); // Call the specific reset method for this form
            }
            finally
            {
                HideLoadingOverlay();
            }
        }

        private void InitializeControlDaily(Hourly hourly, Daily daily)
        {
            labelLocation.Text = WeatherSharedData.Location;
            dropdownDaily.Items.Clear();
            for (int i = 0; i < daily.time.Count; i++)
            {
                DateTime dateTime = DateTime.Parse(daily.time[i]);
                dropdownDaily.Items.Add(dateTime.ToString("MMM d yyy, dddd"));
            }
            dropdownDaily.SelectedIndex = 0; // Select the first item by default.
            UpdateControlHourly(0, hourly, daily); // Load the first day's hourly data.
        }

        private void UpdateControlHourly(int dayIndex, Hourly hourly, Daily daily)
        {
            panelHourly.Controls.Clear();
            panelHourly.AutoScroll = true;

            int totalHeight = 0;  // Track total height for vertical scrolling
            int startHourIndex = (dayIndex * 24); // Each day has 24 hours

            for (int i = 0; i < 24; i++)
            {
                HourlyControl hourlyControl = new HourlyControl();
                DateTime hourTime = DateTime.Parse(hourly.time[startHourIndex]);

                string hourText = hourTime.ToString("hh:mm tt");
                hourlyControl.labelTime.Text = hourText;

                var condition = WeatherCodeDescription.GetCondition(hourly.weather_code[startHourIndex]);

                bool isDay = hourly.is_day[startHourIndex] == 1;
                string icon = isDay ? condition.DayIcon : condition.NightIcon;
                UIHelper.DisplayWeatherIcon(hourlyControl.pictureWeatherIcon, icon);

                hourlyControl.labelDescription.Text = condition.Description;
                hourlyControl.labelFeelsLike.Text = $"{hourly.apparent_temperature[startHourIndex]}°C";
                hourlyControl.labelHumidity.Text = $"{hourly.relative_humidity_2m[startHourIndex]}%";
                hourlyControl.labelWindSpeed.Text = $"{hourly.wind_speed_10m[startHourIndex]} km/h";
                hourlyControl.labelCloudCover.Text = $"{hourly.cloud_cover[startHourIndex]}%";
                hourlyControl.labelUVIndex.Text = $"{hourly.uv_index[startHourIndex]}";
                hourlyControl.labelPressure.Text = $"{hourly.pressure_msl[startHourIndex]} hPa";

                hourlyControl.Location = new Point(0, totalHeight); // Position vertically

                panelHourly.Controls.Add(hourlyControl);
                totalHeight += hourlyControl.Height + 7; // Add spacing

                startHourIndex++; // Move to the next hour
            }
            panelHourly.AutoScrollMinSize = new Size(0, totalHeight); // Prevent horizontal scrolling
        }

        private void dropdownDaily_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = dropdownDaily.SelectedIndex;
            if (selectedIndex >= 0)
            {
                UpdateHourlyForecastForDay(selectedIndex);
            }
        }

        private void UpdateHourlyForecastForDay(int dayIndex)
        {
            if (cachedWeatherData != null)
            {
                UpdateControlHourly(dayIndex, cachedWeatherData.hourly, cachedWeatherData.daily);
                labelDate.Text = DateTime.Parse(cachedWeatherData.daily.time[dayIndex]).ToString("MMMM d, dddd");
            }
        }

        private void ClearHourlyWeatherDataUI()
        {
            panelHourly.Controls.Clear(); // Remove dynamically added HourlyControls
            labelLocation.Text = "Loading location...";
            labelDate.Text = "Select a date";
            dropdownDaily.Items.Clear(); // Clear date dropdown
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