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
using WeatherSphereV4.UserControls; // Assuming MonthlyControl is in this namespace

namespace WeatherSphereV4
{
    public partial class MonthlyForecastForm : UserControl
    {
        private const int CalendarRows = 7; // Including header
        private const int CalendarColumns = 7;
        private const int FutureForecastLimitDays = 15;
        private ProcessWeatherAPI weatherAPI = new ProcessWeatherAPI();
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

            try
            {
                string coordinates = $"latitude={WeatherSharedData.Latitude}&longitude={WeatherSharedData.Longitude}";
                string queriesDaily = "&daily=weather_code,temperature_2m_mean";
                string dateRange = $"&timezone=auto&start_date={apiStartDate:yyyy-MM-dd}&end_date={apiEndDate:yyyy-MM-dd}";
                string queryFinal = coordinates + queriesDaily + dateRange;

                string jsonString = await weatherAPI.GetWeatherDataAsync(queryFinal);
                if (string.IsNullOrEmpty(jsonString))
                {
                    MessageBox.Show("Failed to load monthly forecast data.");
                    return;
                }

                MonthlyForecastData weatherData = processWeatherData.DeserializeMonthlyForecast(jsonString);
                labelMonth.Text = new DateTime(year, month, 1).ToString("MMMM");
                MessageBox.Show($"Weather data loaded for {labelMonth.Text} {year}.");
                PopulateCalendarGrid(year, month, weatherData, calendarStartDate);
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
                                DisplayWeatherIcon(monthlyControl.pictureWeatherIcon, condition.DayIcon);
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
    }
}