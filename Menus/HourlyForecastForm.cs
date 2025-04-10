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

namespace WeatherSphereV4
{
    public partial class HourlyForecastForm : UserControl
    {
        private ProcessWeatherAPI weatherAPI = new ProcessWeatherAPI();
        private ProcessWeatherData processWeatherData = new ProcessWeatherData();
        private HourlyForecastData cachedWeatherData;

        public HourlyForecastForm()
        {
            InitializeComponent();
            LoadHourlyForecast();
        }

        private async void LoadHourlyForecast()
        {
            try
            {
                // Show loading indicator here.
                string coordinates = "latitude=" + WeatherSharedData.Latitude + "&longitude=" + WeatherSharedData.Longitude;
                string queriesDaily = "&daily=sunrise,sunset,weather_code";
                string queriesHourly = "&hourly=is_day,weather_code,apparent_temperature,relative_humidity_2m,wind_speed_10m,cloud_cover,uv_index,pressure_msl";
                string queriesFinal = coordinates + queriesDaily + queriesHourly + "&timezone=auto&forecast_days=7";

                string jsonString = await weatherAPI.GetWeatherDataAsync(queriesFinal);

                if (string.IsNullOrEmpty(jsonString))
                {
                    MessageBox.Show("Failed to load weather data.");
                    return;
                }

                cachedWeatherData = processWeatherData.DeserializeHourlyForecast(jsonString);
                InitializeControlDaily(cachedWeatherData.hourly, cachedWeatherData.daily);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            finally
            {
                // Hide loading indicator here.
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
                DisplayWeatherIcon(hourlyControl.pictureWeatherIcon, icon);

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
                MessageBox.Show(ex.Message);
            }
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
    }
}