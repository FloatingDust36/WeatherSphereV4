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
using System.Windows.Data;

namespace WeatherSphereV4
{
    public partial class HomeForm : UserControl
    {
        private string siteUrl = "https://api.open-meteo.com/v1/forecast";
        private ProcessWeatherData processWeatherData;
        private ProcessGeocoding processGeocoding;
        bool isDay;

        public HomeForm()
        {
            InitializeComponent();
            processWeatherData = new ProcessWeatherData();
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

        private async Task LoadCurrentWeatherData(string lat, string lon)
        {
            string current = "weather_code,temperature_2m,apparent_temperature,relative_humidity_2m,wind_speed_10m,cloud_cover,pressure_msl";
            string daily = "sunrise,sunset,uv_index_max";
            string endpoint = $"?latitude={lat}&longitude={lon}&daily={daily}&current={current}";
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
            UpdateWeatherUI(currentWeather, dailyWeather);
        }

        private async Task LoadForecast7Days(string lat, string lon)
        {
            string parameters = "weather_code,temperature_2m_mean,sunrise,sunset";
            string endpoint = $"?latitude={lat}&longitude={lon}&daily={parameters}";
            string final = $"{endpoint}&timezone=auto";

            string jsonString = await processWeatherData.GetJsonString(siteUrl, final);

            if (string.IsNullOrEmpty(jsonString))
            {
                MessageBox.Show("Failed to load forecast data.");
                return;
            }

            // 🌥️ Deserialize forecast data
            Forecast7Days forecastData = processWeatherData.DeserializeForecast7Days(jsonString);
            DailyForecast dailyForecast = forecastData.dailyForecast;

            UpdateForecastUI(dailyForecast);
        }

        private async void UpdateForecastUI(DailyForecast dailyForecast)
        {
            DateTime date1 = DateTime.Parse(dailyForecast.time[0]);
            label1Day.Text = date1.ToString("dddd");
            label1Date.Text = date1.ToString("MMM dd");

            DateTime date2 = DateTime.Parse(dailyForecast.time[1]);
            label2Day.Text = date2.ToString("dddd");
            label2Date.Text = date2.ToString("MMM dd");

            DateTime date3 = DateTime.Parse(dailyForecast.time[2]);
            label3Day.Text = date3.ToString("dddd");
            label3Date.Text = date3.ToString("MMM dd");

            DateTime date4 = DateTime.Parse(dailyForecast.time[3]);
            label4Day.Text = date4.ToString("dddd");
            label4Date.Text = date4.ToString("MMM dd");

            DateTime date5 = DateTime.Parse(dailyForecast.time[4]);
            label5Day.Text = date5.ToString("dddd");
            label5Date.Text = date5.ToString("MMM dd");

            DateTime date6 = DateTime.Parse(dailyForecast.time[5]);
            label6Day.Text = date6.ToString("dddd");
            label6Date.Text = date6.ToString("MMM dd");

            DateTime date7 = DateTime.Parse(dailyForecast.time[6]);
            label7Day.Text = date7.ToString("dddd");
            label7Date.Text = date7.ToString("MMM dd");

            // 🌤️ Display temperature
            label1Temperature.Text = $"{dailyForecast.temperature_2m_mean[0]}°C";
            label2Temperature.Text = $"{dailyForecast.temperature_2m_mean[1]}°C";
            label3Temperature.Text = $"{dailyForecast.temperature_2m_mean[2]}°C";
            label4Temperature.Text = $"{dailyForecast.temperature_2m_mean[3]}°C";
            label5Temperature.Text = $"{dailyForecast.temperature_2m_mean[4]}°C";
            label6Temperature.Text = $"{dailyForecast.temperature_2m_mean[5]}°C";
            label7Temperature.Text = $"{dailyForecast.temperature_2m_mean[6]}°C";

            var condition1 = WeatherCodeDescription.GetCondition(dailyForecast.weather_code[0]);
            var condition2 = WeatherCodeDescription.GetCondition(dailyForecast.weather_code[1]);
            var condition3 = WeatherCodeDescription.GetCondition(dailyForecast.weather_code[2]);
            var condition4 = WeatherCodeDescription.GetCondition(dailyForecast.weather_code[3]);
            var condition5 = WeatherCodeDescription.GetCondition(dailyForecast.weather_code[4]);
            var condition6 = WeatherCodeDescription.GetCondition(dailyForecast.weather_code[5]);
            var condition7 = WeatherCodeDescription.GetCondition(dailyForecast.weather_code[6]);

            label1Description.Text = condition1.Description;
            label2Description.Text = condition2.Description;
            label3Description.Text = condition3.Description;
            label4Description.Text = condition4.Description;
            label5Description.Text = condition5.Description;
            label6Description.Text = condition6.Description;
            label7Description.Text = condition7.Description;

            // 🌟 Display GIF icon dynamically
            string icon1 = isDay ? condition1.DayIcon : condition1.NightIcon;
            string icon2 = isDay ? condition2.DayIcon : condition2.NightIcon;
            string icon3 = isDay ? condition3.DayIcon : condition3.NightIcon;
            string icon4 = isDay ? condition4.DayIcon : condition4.NightIcon;
            string icon5 = isDay ? condition5.DayIcon : condition5.NightIcon;
            string icon6 = isDay ? condition6.DayIcon : condition6.NightIcon;
            string icon7 = isDay ? condition7.DayIcon : condition7.NightIcon;

            DisplayWeatherIcon(picture1, icon1);
            DisplayWeatherIcon(picture2, icon2);
            DisplayWeatherIcon(picture3, icon3);
            DisplayWeatherIcon(picture4, icon4);
            DisplayWeatherIcon(picture5, icon5);
            DisplayWeatherIcon(picture6, icon6);
            DisplayWeatherIcon(picture7, icon7);
        }

        private async void UpdateWeatherUI(CurrentWeather current, DailyWeather daily)
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
            DateTime sunrise = DateTime.Parse(daily.sunrise[0]);
            DateTime sunset = DateTime.Parse(daily.sunset[0]);
            isDay = date >= sunrise && date <= sunset;  // Daytime check based on sunrise and sunset times
            var condition = WeatherCodeDescription.GetCondition(current.weather_code);

            labelDescription.Text = condition.Description;

            // 🌟 Display GIF icon dynamically
            string icon = isDay ? condition.DayIcon : condition.NightIcon;
            DisplayWeatherIcon(pictureWeatherIcon, icon);
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
                // ✅ Store the searched location in shared data
                WeatherSharedData.Latitude = lat;
                WeatherSharedData.Longitude = lon;

                // 📍 Display location
                string address = await processGeocoding.GetCompleteAddressFromSearchTerm(location);
                labelLocation.Text = address;
                WeatherSharedData.Location = address;

                // ✅ Load data using shared coordinates
                await LoadCurrentWeatherData(lat, lon);
                await LoadForecast7Days(lat, lon);
            }
            else
            {
                MessageBox.Show("Location not found. Try being more specific.");
            }
        }

    }
}

