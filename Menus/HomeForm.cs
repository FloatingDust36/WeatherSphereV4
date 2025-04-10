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
using FontAwesome.Sharp;
using WeatherSphereV4.Utilities;
using WeatherSphereV4.Services;
using static GMap.NET.Entity.OpenStreetMapGeocodeEntity;

namespace WeatherSphereV4
{
    public partial class HomeForm : UserControl
    {
        private const string CurrentWeatherParameters = "is_day,weather_code,temperature_2m,apparent_temperature,relative_humidity_2m,wind_speed_10m,cloud_cover,pressure_msl";
        private const string DailyWeatherParameters = "sunrise,sunset,uv_index_max";
        private const string Forecast7DaysParameters = "weather_code,temperature_2m_mean,sunrise,sunset";
        private ProcessWeatherData processWeatherData;
        private ProcessGeocoding processGeocoding;
        bool isDay;

        public HomeForm()
        {
            InitializeComponent();
            processWeatherData = new ProcessWeatherData();
            processGeocoding = new ProcessGeocoding();
            CenterLoadingSpinner();

            WeatherSharedData.LocationChanged += HandleLocationChanged;
            this.Disposed += (s, e) => WeatherSharedData.LocationChanged -= HandleLocationChanged;
        }

        private async void HandleLocationChanged(object sender, EventArgs e)
        {
            // Use BeginInvoke/Invoke if mixing threads, but since event is static and UI updates happen,
            // it's safer, although async void handlers usually run on UI thread in WinForms unless awaited differently.
            // Using async void directly is often okay here, but check for cross-thread issues if they arise.

            Console.WriteLine("HomeForm Handling LocationChanged Event..."); // For Debugging

            // Get the latest location data
            string currentLat = WeatherSharedData.Latitude;
            string currentLon = WeatherSharedData.Longitude;
            string currentLoc = WeatherSharedData.Location;

            // Ensure we have valid data before trying to load
            if (!string.IsNullOrEmpty(currentLat) && !string.IsNullOrEmpty(currentLon))
            {
                // Update the location label immediately
                if (labelLocation.InvokeRequired)
                {
                    labelLocation.Invoke(new Action(() => labelLocation.Text = currentLoc));
                }
                else
                {
                    labelLocation.Text = currentLoc;
                }

                // Reload both current weather and forecast for the new location
                // Use Task.WhenAll to run them concurrently if they are independent
                try
                {
                    // Don't need Show/Hide overlay within the handler if the methods called already do it.
                    // If Load methods don't show overlay, add ShowLoadingOverlay() here and HideLoadingOverlay() in finally.
                    await Task.WhenAll(
                        LoadCurrentWeatherData(currentLat, currentLon),
                        LoadForecast7Days(currentLat, currentLon)
                    );
                }
                catch (Exception ex)
                {
                    // Handle or log potential errors from WhenAll, though individual methods have catches
                    Console.WriteLine($"Error during HomeForm coordinated data load: {ex.Message}");
                    // ShowInfoBar is likely called within the Load methods on error already.
                }
            }
            else
            {
                Console.WriteLine("HomeForm HandleLocationChanged skipped: Lat/Lon is null/empty.");
                // Optionally clear UI or show message if location becomes invalid
                // ClearHomeWeatherDataUI();
                // ShowInfoBar("Location data is missing.", InfoBarType.Warning);
            }
        }

        private void buttonHomeSearch_MouseEnter(object sender, EventArgs e)
        {
            UIHelper.SetIconButtonSize(sender, UIHelper.IconSizeSearchHover);
        }

        private void buttonHomeSearch_MouseLeave(object sender, EventArgs e)
        {
            UIHelper.SetIconButtonSize(sender, UIHelper.IconSizeSearchDefault);
        }

        private async Task LoadCurrentWeatherData(string lat, string lon)
        {
            HideInfoBar();
            ShowLoadingOverlay();
            buttonHomeSearch.Enabled = false;

            try
            {
                string endpoint = $"?latitude={lat}&longitude={lon}&daily={DailyWeatherParameters}&current={CurrentWeatherParameters}";
                string final = $"{endpoint}&timezone=auto&forecast_days=1";

                string jsonString = await processWeatherData.GetJsonString(final);

                if (string.IsNullOrEmpty(jsonString))
                {
                    throw new Exception("Received empty response from weather API."); // Treat empty as error
                }

                // Deserialize weather data
                CurrentWeatherData weatherData = processWeatherData.DeserializeCurrentWeatherData(jsonString);
                CurrentWeather currentWeather = weatherData.currentWeather;
                DailyWeather dailyWeather = weatherData.dailyWeather;

                UpdateWeatherUI(currentWeather, dailyWeather);

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
                ClearHomeWeatherDataUI(); // Call the specific reset method for this form
            }
            finally
            {
                HideLoadingOverlay();
                buttonHomeSearch.Enabled = true;
            }
        }

        private async void UpdateWeatherUI(CurrentWeather current, DailyWeather daily)
        {
            labelTemperature.Text = $"{current.temperature_2m}°C";
            labelFeelsLike.Text = $"Feels like {current.apparent_temperature}°C";
            labelHumidity.Text = $"{current.relative_humidity_2m}%";
            labelWindSpeed.Text = $"{current.wind_speed_10m} m/s";
            labelCloudCover.Text = $"{current.cloud_cover}%";
            labelPressure.Text = $"{current.pressure_msl} hPa";

            try
            {
                if (daily?.sunrise?.Count > 0 && DateTime.TryParse(daily.sunrise[0], out DateTime sunriseTime))
                {
                    labelSunrise.Text = sunriseTime.ToString("hh:mm tt"); // Formats as "06:15 AM"
                }
                else
                {
                    labelSunrise.Text = "--:--"; // Default if data is missing/invalid
                }

                if (daily?.sunset?.Count > 0 && DateTime.TryParse(daily.sunset[0], out DateTime sunsetTime))
                {
                    labelSunset.Text = sunsetTime.ToString("hh:mm tt"); // Formats as "06:30 PM"
                }
                else
                {
                    labelSunset.Text = "--:--"; // Default if data is missing/invalid
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing sunrise/sunset times: {ex.Message}");
                labelSunrise.Text = "Error";
                labelSunset.Text = "Error";
            }

            labelUVIndex.Text = daily.uv_index_max[0].ToString();

            DateTime date = DateTime.Parse(current.time);
            labelCurrentDate.Text = date.ToString("dddd, MMMM dd, yyyy");

            var condition = WeatherCodeDescription.GetCondition(current.weather_code);
            labelDescription.Text = condition.Description;

            isDay = current.is_day == 1;
            string icon = isDay ? condition.DayIcon : condition.NightIcon;
            UIHelper.DisplayWeatherIcon(pictureWeatherIcon, icon);
        }

        private async Task LoadForecast7Days(string lat, string lon)
        {
            HideInfoBar();           // Clear previous info/error messages
            ShowLoadingOverlay();
            buttonHomeSearch.Enabled = false;

            try
            {
                string endpoint = $"?latitude={lat}&longitude={lon}&daily={Forecast7DaysParameters}";
                string final = $"{endpoint}&timezone=auto";

                string jsonString = await processWeatherData.GetJsonString(final);

                if (string.IsNullOrEmpty(jsonString))
                {
                    throw new Exception("Received empty response from weather API."); // Treat empty as error
                }

                Forecast7Days forecastData = processWeatherData.DeserializeForecast7Days(jsonString);
                DailyForecast dailyForecast = forecastData.dailyForecast;

                UpdateForecastUI(dailyForecast);

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
                ClearHomeWeatherDataUI(); // Call the specific reset method for this form
            }
            finally
            {
                HideLoadingOverlay();
                buttonHomeSearch.Enabled = true;
            }
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

            string icon1 = isDay ? condition1.DayIcon : condition1.NightIcon;
            string icon2 = isDay ? condition2.DayIcon : condition2.NightIcon;
            string icon3 = isDay ? condition3.DayIcon : condition3.NightIcon;
            string icon4 = isDay ? condition4.DayIcon : condition4.NightIcon;
            string icon5 = isDay ? condition5.DayIcon : condition5.NightIcon;
            string icon6 = isDay ? condition6.DayIcon : condition6.NightIcon;
            string icon7 = isDay ? condition7.DayIcon : condition7.NightIcon;

            UIHelper.DisplayWeatherIcon(picture1, icon1);
            UIHelper.DisplayWeatherIcon(picture2, icon2);
            UIHelper.DisplayWeatherIcon(picture3, icon3);
            UIHelper.DisplayWeatherIcon(picture4, icon4);
            UIHelper.DisplayWeatherIcon(picture5, icon5);
            UIHelper.DisplayWeatherIcon(picture6, icon6);
            UIHelper.DisplayWeatherIcon(picture7, icon7);
        }

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

                string address = await processGeocoding.GetCompleteAddressFromSearchTerm(location);
                WeatherSharedData.SetLocationData(lat, lon, address);

                labelLocation.Text = address;
                // Load data using shared coordinates
                await LoadCurrentWeatherData(lat, lon);
                await LoadForecast7Days(lat, lon);
            }
            else
            {
                MessageBox.Show("Location not found. Try being more specific.");
            }
        }

        private void ClearHomeWeatherDataUI()
        {
            // Reset labels to default state
            labelTemperature.Text = "--°C";
            labelFeelsLike.Text = "Feels like --°C";
            labelHumidity.Text = "--%";
            labelWindSpeed.Text = "-- m/s";
            labelCloudCover.Text = "--%";
            labelPressure.Text = "-- hPa";
            labelSunrise.Text = "--:-- AM";
            labelSunset.Text = "--:-- PM";
            labelUVIndex.Text = "--";
            labelCurrentDate.Text = "----, ---- --, ----";
            labelDescription.Text = "Weather description";
            labelLocation.Text = "Loading location..."; // Or keep previous location? Decide UX.

            // Reset forecast labels/icons
            label1Day.Text = "Day"; label1Date.Text = "Date"; label1Temperature.Text = "--°C"; label1Description.Text = "-"; UIHelper.DisplayWeatherIcon(picture1, null);
            label2Day.Text = "Day"; label2Date.Text = "Date"; label2Temperature.Text = "--°C"; label2Description.Text = "-"; UIHelper.DisplayWeatherIcon(picture2, null);
            // ... Repeat for labels 3-7 and pictures 3-7 ...
            label7Day.Text = "Day"; label7Date.Text = "Date"; label7Temperature.Text = "--°C"; label7Description.Text = "-"; UIHelper.DisplayWeatherIcon(picture7, null);

            // Hide main weather icon
            UIHelper.DisplayWeatherIcon(pictureWeatherIcon, null); // Will hide it if unknown.gif is missing, or show unknown.gif
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

        private void HomeForm_Resize(object sender, EventArgs e)
        {
            CenterLoadingSpinner();
        }

        private void buttonCloseInfoBar_Click(object sender, EventArgs e)
        {
            HideInfoBar();
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {
            // Check if location data is already available when the form loads
            // and trigger the handler to load the data.
            // This ensures data loads the first time the form is shown,
            // even though it missed the initial event from BaseForm.
            if (!string.IsNullOrEmpty(WeatherSharedData.Latitude) && !string.IsNullOrEmpty(WeatherSharedData.Longitude))
            {
                Console.WriteLine("HomeForm_Load triggering initial data load via HandleLocationChanged...");
                // Call the existing handler to load data using the current WeatherSharedData
                HandleLocationChanged(this, EventArgs.Empty);
            }
            else
            {
                Console.WriteLine("HomeForm_Load skipped initial load: Lat/Lon is null/empty.");
                // Optionally show a message asking user to search, or wait for BaseForm detection
                // ShowInfoBar("Please search for a location.", InfoBarType.Info);
                // Or rely on HandleLocationChanged to eventually get called if BaseForm is slow
            }
        }
    }
}

public enum InfoBarType
{
    Info,
    Success,
    Warning,
    Error
}

