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
        int clicked = 0;

        public HourlyForecastForm()
        {
            InitializeComponent();
            LoadHourlyForecast();
        }

        private async void LoadHourlyForecast()
        {
            string coordinates = "latitude=" + WeatherSharedData.Latitude + "&longitude=" + WeatherSharedData.Longitude;
            string queriesDaily = "&daily=sunrise,sunset,weather_code";
            string queriesHourly = "&hourly=weather_code,apparent_temperature,relative_humidity_2m,wind_speed_10m,cloud_cover,uv_index,pressure_msl";
            string queriesFinal = coordinates + queriesDaily + queriesHourly + "&timezone=auto&forecast_days=7";

            string jsonString = await weatherAPI.GetWeatherDataAsync(queriesFinal);

            if (string.IsNullOrEmpty(jsonString))
            {
                MessageBox.Show("Failed to load weather data.");
                return;
            }

            //MessageBox.Show(jsonString);

            HourlyForecastData weatherData = processWeatherData.DeserializeHourlyForecast(jsonString);
            Hourly hourly = weatherData.hourly;
            Daily daily = weatherData.daily;
            UpdateControlDaily(hourly, daily);
        }

        private void UpdateControlDaily(Hourly hourly, Daily daily)
        {
            panelDaily.Controls.Clear();
            panelDaily.AutoScroll = true; // Enable auto-scrolling
            panelDaily.HorizontalScroll.Visible = true; // Ensure horizontal scroll is visible
            panelDaily.VerticalScroll.Visible = false; // Hide vertical scroll

            int totalWidth = 0;  // Track total width for horizontal scrolling
            int dailyControlHeight = 0; // Variable to store the height of DailyControl

            for (int i = 0; i < 7; i++)
            {
                DailyControl dailyControl = new DailyControl();

                //make the first control a different color
                if (i == clicked)
                {
                    dailyControl.panelDailyControl.Color1 = Color.FromArgb(0, 0, 128);
                    dailyControl.panelDailyControl.Color2 = Color.FromArgb(25, 25, 50);
                }


                DateTime dateTime = DateTime.Parse(daily.time[i]);
                dailyControl.labelDay.Text = dateTime.ToString("dddd");

                var condition = WeatherCodeDescription.GetCondition(daily.weather_code[i]);
                DisplayWeatherIcon(dailyControl.pictureWeatherIcon, condition.DayIcon);

                dailyControl.Width = 260; // Ensure each item has a fixed width
                dailyControl.Height = 120; // Set a fixed height for DailyControl
                dailyControlHeight = dailyControl.Height; // Store the height of DailyControl
                dailyControl.Location = new Point(totalWidth, 0); // Position horizontally

                panelDaily.Controls.Add(dailyControl);
                totalWidth += dailyControl.Width + 7;  // Add spacing
            }
            UpdateControlHourly(clicked, hourly, daily);
            int horizontalScrollBarHeight = SystemInformation.HorizontalScrollBarHeight;
            panelDaily.Height = dailyControlHeight + horizontalScrollBarHeight + 6;
            panelDaily.AutoScrollMinSize = new Size(totalWidth, dailyControlHeight);
        }

        private void UpdateControlHourly(int dayIndex, Hourly hourly, Daily daily)
        {
            panelHourly.Controls.Clear();
            panelHourly.AutoScroll = true; // Re-enable it

            int totalHeight = 0;  // Track total height for vertical scrolling
            int startHourIndex = (dayIndex * 24); // Each day has 24 hours

            for (int i = 0; i < 24; i++)
            {
                HourlyControl hourlyControl = new HourlyControl();

                DateTime hourTime = DateTime.Parse(hourly.time[startHourIndex]);

                // ex, 23:00 AM
                string hourText = hourTime.ToString("hh:mm tt");
                hourlyControl.labelTime.Text = hourText;

                var condition = WeatherCodeDescription.GetCondition(hourly.weather_code[startHourIndex]);
                // Display the icon based on the hour and sunset/sunrise
                int sunriseHour = int.Parse(daily.sunrise[dayIndex].Substring(11, 2));
                int sunsetHour = int.Parse(daily.sunset[dayIndex].Substring(11, 2));
                bool isDay = hourTime.Hour >= sunriseHour && hourTime.Hour < sunsetHour;
                string icon = isDay ? condition.DayIcon : condition.NightIcon;
                DisplayWeatherIcon(hourlyControl.pictureWeatherIcon, icon);

                hourlyControl.labelFeelsLike.Text = $"{hourly.apparent_temperature[startHourIndex]}°C";
                hourlyControl.labelHumidity.Text = $"{hourly.relative_humidity_2m[startHourIndex]}%";
                hourlyControl.labelWindSpeed.Text = $"{hourly.wind_speed_10m[startHourIndex]} km/h";
                hourlyControl.labelCloudCover.Text = $"{hourly.cloud_cover[startHourIndex]}%";
                hourlyControl.labelUVIndex.Text = $"{hourly.uv_index[startHourIndex]}";
                hourlyControl.labelPressure.Text = $"{hourly.pressure_msl[startHourIndex]} hPa";

                hourlyControl.Width = 1118;
                hourlyControl.Height = 167; // Set a fixed height for HourlyControl
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

    }
}
