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
                { 55, new WeatherCondition(55, "Dense drizzle", "drizzle-dense-day", "drizzle-dense-night") },
                { 56, new WeatherCondition(56, "Light freezing drizzle", "freezing-drizzle-light-day", "freezing-drizzle-light-night") },
                { 57, new WeatherCondition(57, "Dense freezing drizzle", "freezing-drizzle-dense-day", "freezing-drizzle-dense-night") },
                { 61, new WeatherCondition(61, "Slight rain", "rain-slight-day", "rain-slight-night") },
                { 63, new WeatherCondition(63, "Moderate rain", "rain-moderate-day", "rain-moderate-night") },
                { 65, new WeatherCondition(65, "Heavy rain", "rain-heavy-day", "rain-heavy-night") },
                { 66, new WeatherCondition(66, "Light freezing rain", "freezing-rain-light-day", "freezing-rain-light-night") },
                { 67, new WeatherCondition(67, "Heavy freezing rain", "freezing-rain-heavy-day", "freezing-rain-heavy-night") },
                { 71, new WeatherCondition(71, "Slight snow fall", "snow-fall-slight-day", "snow-fall-slight-night") },
                { 73, new WeatherCondition(73, "Moderate snow fall", "snow-fall-moderate-day", "snow-fall-moderate-night") },
                { 75, new WeatherCondition(75, "Heavy snow fall", "snow-fall-heavy-day", "snow-fall-heavy-night") },
                { 77, new WeatherCondition(77, "Snow grains", "snow-grains-day", "snow-grains-night") },
                { 80, new WeatherCondition(80, "Slight rain showers", "rain-showers-slight-day", "rain-showers-slight-night") },
                { 81, new WeatherCondition(81, "Moderate rain showers", "rain-showers-moderate-day", "rain-showers-moderate-night") },
                { 82, new WeatherCondition(82, "Violent rain showers", "rain-showers-violent-day", "rain-showers-violent-night") },
                { 85, new WeatherCondition(85, "Slight snow showers", "snow-showers-slight-day", "snow-showers-slight-night") },
                { 86, new WeatherCondition(86, "Heavy snow showers", "snow-showers-heavy-day", "snow-showers-heavy-night") },
                { 95, new WeatherCondition(95, "Thunderstorm: Slight or moderate", "thunderstorm-slight-day", "thunderstorm-slight-night") },
                { 96, new WeatherCondition(96, "Thunderstorm with slight hail", "thunderstorm-slight-hail-day", "thunderstorm-slight-hail-night") },
                { 99, new WeatherCondition(99, "Thunderstorm with heavy hail", "thunderstorm-heavy-hail-day", "thunderstorm-heavy-hail-night") }
            };

        public static string GetDescription(int code) =>
            WeatherData.TryGetValue(code, out var condition) ? condition.Description : "Unknown weather";

        public static string GetIcon(int code, bool isDay) =>
            WeatherData.TryGetValue(code, out var condition) ? (isDay ? condition.DayIcon : condition.NightIcon) : (isDay ? "unknown-day" : "unknown-night");

        public static WeatherCondition GetCondition(int code) =>
            WeatherData.TryGetValue(code, out var condition) ? condition : new WeatherCondition(code, "Unknown weather", "unknown-day", "unknown-night");
    }
}
