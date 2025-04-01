using System;
using System.Collections.Generic;

namespace WeatherSphereV4.Models
{
    public class WeatherCondition
    {
        public int Code { get; }
        public string Description { get; }
        public string DayIcon { get; }
        public string NightIcon { get; }

        public WeatherCondition(int code, string description, string dayIcon, string nightIcon)
        {
            Code = code;
            Description = description;
            DayIcon = dayIcon;
            NightIcon = nightIcon;
        }
    }

    public static class WeatherCodeDescription
    {
        private static readonly Dictionary<int, WeatherCondition> WeatherData = new()
        {
            { 0, new WeatherCondition(0, "Clear sky", "clear-day", "clear-night") },
            { 1, new WeatherCondition(1, "Mainly clear", "mainly-clear-day", "mainly-clear-night") },
            { 2, new WeatherCondition(2, "Partly cloudy", "partly-cloudy-day", "partly-cloudy-night") },
            { 3, new WeatherCondition(3, "Overcast", "overcast-day", "overcast-night") },
            { 45, new WeatherCondition(45, "Fog", "fog-day", "fog-night") },
            { 48, new WeatherCondition(48, "Rime fog", "rime-fog-day", "rime-fog-night") },
            { 51, new WeatherCondition(51, "Light drizzle", "drizzle-light-day", "drizzle-light-night") },
            { 53, new WeatherCondition(53, "Moderate drizzle", "drizzle-moderate-day", "drizzle-moderate-night") },
            { 65, new WeatherCondition(65, "Heavy rain", "rain-heavy-day", "rain-heavy-night") },
            { 95, new WeatherCondition(95, "Thunderstorm: Slight", "thunderstorm-slight-day", "thunderstorm-slight-night") },
            { 99, new WeatherCondition(99, "Thunderstorm: Heavy hail", "thunderstorm-heavy-hail-day", "thunderstorm-heavy-hail-night") }
        };

        public static string GetDescription(int code) =>
            WeatherData.TryGetValue(code, out var condition) ? condition.Description : "Unknown weather";

        public static string GetIcon(int code, bool isDay) =>
            WeatherData.TryGetValue(code, out var condition) ? (isDay ? condition.DayIcon : condition.NightIcon) : (isDay ? "unknown-day" : "unknown-night");

        public static WeatherCondition GetCondition(int code) =>
            WeatherData.TryGetValue(code, out var condition) ? condition : new WeatherCondition(code, "Unknown weather", "unknown-day", "unknown-night");
    }
}
