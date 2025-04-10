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
using WeatherSphereV4.UserControls; //MonthlyControl is in this namespace
using WeatherSphereV4.Utilities;
using FontAwesome.Sharp;

namespace WeatherSphereV4
{
    public partial class MonthlyForecastForm : UserControl
    {

        private const string DailyWeatherParameters = "weather_code,temperature_2m_mean";

        private const int CalendarRows = 7; // Including header
        private const int CalendarColumns = 7;
        private const int FutureForecastLimitDays = 15;
        private ProcessWeatherData processWeatherData = new ProcessWeatherData();
        private int currentYear;
        private int currentMonth;

        public MonthlyForecastForm()
        {
            InitializeComponent();
            DateTime now = DateTime.Now;
            currentYear = now.Year;
            currentMonth = now.Month;
        }

        private async Task LoadAndPopulateCalendar(int year, int month)
        {
            DateTime firstDayOfMonth = new DateTime(year, month, 1);
            int dayOfWeekOfFirst = (int)firstDayOfMonth.DayOfWeek;
            int daysFromPreviousMonth = dayOfWeekOfFirst % 7;
            DateTime calendarStartDate = firstDayOfMonth.AddDays(-daysFromPreviousMonth);
            DateTime calendarEndDate = calendarStartDate.AddDays(41); // Calculate based on 7 rows

            DateTime apiStartDate = calendarStartDate;
            DateTime apiEndDate = calendarEndDate;
            DateTime now = DateTime.Now;

            if (year == now.Year && month == now.Month)
            {
                DateTime futureLimit = now.AddDays(FutureForecastLimitDays);
                if (apiEndDate > futureLimit)
                {
                    apiEndDate = futureLimit;
                }
            }

            HideInfoBar();           // Clear previous info/error messages
            ShowLoadingOverlay();

            try
            {
                string endpoint = $"?latitude={WeatherSharedData.Latitude}&longitude={WeatherSharedData.Longitude}&daily={DailyWeatherParameters}";
                string final = $"{endpoint}&timezone=auto&start_date={apiStartDate:yyyy-MM-dd}&end_date={apiEndDate:yyyy-MM-dd}";

                string jsonString = await processWeatherData.GetJsonString(final);
                if (string.IsNullOrEmpty(jsonString))
                {
                    throw new Exception("Received empty response from weather API."); // Treat empty as error
                }

                MonthlyForecastData weatherData = processWeatherData.DeserializeMonthlyForecast(jsonString);
                labelMonth.Text = new DateTime(year, month, 1).ToString("MMMM");
                MessageBox.Show($"Weather data loaded for {labelMonth.Text} {year}.");
                PopulateCalendarGrid(year, month, weatherData, calendarStartDate);
            }
            catch (Exception ex)
            {
                // Log the full error details for debugging
                Console.WriteLine($"ERROR loading current weather data: {ex.ToString()}");

                // Show user-friendly error message in the Info Bar
                ShowInfoBar($"Error loading current weather: {ex.Message}", InfoBarType.Error); // Show specific ex.Message

                // Reset the UI elements to a default/empty state
                ClearMonthlyWeatherDataUI(); // Call the specific reset method for this form
            }
            finally
            {
                HideLoadingOverlay();
            }
        }

        private void PopulateCalendarGrid(int year, int month, MonthlyForecastData forecastData, DateTime calendarStartDate)
        {
            // Clear existing controls (starting from the second row)
            for (int i = tableLayoutPanelCalendar.RowCount - 1; i >= 1; i--)
            {
                for (int j = 0; j < tableLayoutPanelCalendar.ColumnCount; j++)
                {
                    Control controlToRemove = tableLayoutPanelCalendar.GetControlFromPosition(j, i);
                    if (controlToRemove != null)
                    {
                        tableLayoutPanelCalendar.Controls.Remove(controlToRemove);
                        controlToRemove.Dispose();
                    }
                }
            }
            tableLayoutPanelCalendar.RowCount = CalendarRows; // Reset row count

            DateTime currentDate = calendarStartDate;
            if (forecastData?.daily?.time == null) return; // Avoid null reference

            for (int row = 1; row < CalendarRows; row++)
            {
                for (int col = 0; col < CalendarColumns; col++)
                {
                    MonthlyControl monthlyControl = new MonthlyControl();
                    monthlyControl.labelDay.Text = currentDate.Day.ToString();
                    monthlyControl.labelDay.ForeColor = currentDate.Month == month ? Color.Gainsboro : Color.Gray;

                    if (currentDate.Month != month)
                    {
                        monthlyControl.panelMonthly.BackColor = Color.FromArgb(30, 0, 0, 64);
                    }
                    else if (currentDate.Date == DateTime.Now.Date && currentDate.Month == DateTime.Now.Month)
                    {
                        monthlyControl.panelMonthly.BackColor = Color.LightSteelBlue;
                    }
                    else
                    {
                        monthlyControl.panelMonthly.BackColor = Color.FromArgb(50, 0, 0, 128);
                    }

                    // Find corresponding forecast data
                    for (int i = 0; i < forecastData.daily.time.Count; i++)
                    {
                        if (DateTime.TryParse(forecastData.daily.time[i].ToString().Substring(0, 10), out DateTime apiDate) && apiDate.Date == currentDate.Date)
                        {
                            if (forecastData.daily.weather_code != null && i < forecastData.daily.weather_code.Count)
                            {
                                var condition = WeatherCodeDescription.GetCondition(forecastData.daily.weather_code[i]);
                                UIHelper.DisplayWeatherIcon(monthlyControl.pictureWeatherIcon, condition.DayIcon);
                            }
                            if (forecastData.daily.temperature_2m_mean != null && i < forecastData.daily.temperature_2m_mean.Count)
                            {
                                monthlyControl.labelTemperature.Text = $"{forecastData.daily.temperature_2m_mean[i]}°C";
                            }
                            break;
                        }
                    }

                    tableLayoutPanelCalendar.Controls.Add(monthlyControl, col, row);
                    currentDate = currentDate.AddDays(1);
                }
            }
        }

        private async void btnPreviousMonth_Click(object sender, EventArgs e)
        {
            currentMonth--;
            if (currentMonth < 1)
            {
                currentMonth = 12;
                currentYear--;
            }
            await LoadAndPopulateCalendar(currentYear, currentMonth);
        }

        private async void btnNextMonth_Click(object sender, EventArgs e)
        {
            currentMonth++;
            if (currentMonth > 12)
            {
                currentMonth = 1;
                currentYear++;
            }
            await LoadAndPopulateCalendar(currentYear, currentMonth);
        }

        private async void MonthlyForecastForm_Load(object sender, EventArgs e)
        {
            await LoadAndPopulateCalendar(currentYear, currentMonth);
        }

        private void ClearMonthlyWeatherDataUI()
        {
            labelMonth.Text = "Loading...";
            // Clear existing controls from TableLayoutPanel (excluding header row 0)
            for (int i = tableLayoutPanelCalendar.RowCount - 1; i >= 1; i--)
            {
                for (int j = 0; j < tableLayoutPanelCalendar.ColumnCount; j++)
                {
                    Control controlToRemove = tableLayoutPanelCalendar.GetControlFromPosition(j, i);
                    if (controlToRemove != null)
                    {
                        tableLayoutPanelCalendar.Controls.Remove(controlToRemove);
                        controlToRemove.Dispose();
                    }
                }
            }
        }

        private void buttonCloseInfoBar_Click(object sender, EventArgs e)
        {
            HideInfoBar();
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
    }
}