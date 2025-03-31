using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherSphereV4.Models
{
    public static class WeatherCodeDescription
    {
        private static readonly Dictionary<int, (string Description, string DayPicture, string NightPicture)> weatherCodeDescriptions = new Dictionary<int, (string, string, string)>
            {
                { 0, ("Clear sky", "clear_sky_day.png", "clear_sky_night.png") },
                { 1, ("Mainly clear", "mainly_clear_day.png", "mainly_clear_night.png") },
                { 2, ("Partly cloudy", "partly_cloudy_day.png", "partly_cloudy_night.png") },
                { 3, ("Overcast", "overcast_day.png", "overcast_night.png") },
                { 45, ("Fog", "fog_day.png", "fog_night.png") },
                { 48, ("Depositing rime fog", "depositing_rime_fog_day.png", "depositing_rime_fog_night.png") },
                { 51, ("Drizzle: Light intensity", "drizzle_light_day.png", "drizzle_light_night.png") },
                { 53, ("Drizzle: Moderate intensity", "drizzle_moderate_day.png", "drizzle_moderate_night.png") },
                { 55, ("Drizzle: Dense intensity", "drizzle_dense_day.png", "drizzle_dense_night.png") },
                { 56, ("Freezing Drizzle: Light intensity", "freezing_drizzle_light_day.png", "freezing_drizzle_light_night.png") },
                { 57, ("Freezing Drizzle: Dense intensity", "freezing_drizzle_dense_day.png", "freezing_drizzle_dense_night.png") },
                { 61, ("Rain: Slight intensity", "rain_slight_day.png", "rain_slight_night.png") },
                { 63, ("Rain: Moderate intensity", "rain_moderate_day.png", "rain_moderate_night.png") },
                { 65, ("Rain: Heavy intensity", "rain_heavy_day.png", "rain_heavy_night.png") },
                { 66, ("Freezing Rain: Light intensity", "freezing_rain_light_day.png", "freezing_rain_light_night.png") },
                { 67, ("Freezing Rain: Heavy intensity", "freezing_rain_heavy_day.png", "freezing_rain_heavy_night.png") },
                { 71, ("Snow fall: Slight intensity", "snow_slight_day.png", "snow_slight_night.png") },
                { 73, ("Snow fall: Moderate intensity", "snow_moderate_day.png", "snow_moderate_night.png") },
                { 75, ("Snow fall: Heavy intensity", "snow_heavy_day.png", "snow_heavy_night.png") },
                { 77, ("Snow grains", "snow_grains_day.png", "snow_grains_night.png") },
                { 80, ("Rain showers: Slight intensity", "rain_showers_slight_day.png", "rain_showers_slight_night.png") },
                { 81, ("Rain showers: Moderate intensity", "rain_showers_moderate_day.png", "rain_showers_moderate_night.png") },
                { 82, ("Rain showers: Violent intensity", "rain_showers_violent_day.png", "rain_showers_violent_night.png") },
                { 85, ("Snow showers: Slight intensity", "snow_showers_slight_day.png", "snow_showers_slight_night.png") },
                { 86, ("Snow showers: Heavy intensity", "snow_showers_heavy_day.png", "snow_showers_heavy_night.png") },
                { 95, ("Thunderstorm: Slight or moderate", "thunderstorm_slight_day.png", "thunderstorm_slight_night.png") },
                { 96, ("Thunderstorm with slight hail", "thunderstorm_slight_hail_day.png", "thunderstorm_slight_hail_night.png") },
                { 99, ("Thunderstorm with heavy hail", "thunderstorm_heavy_hail_day.png", "thunderstorm_heavy_hail_night.png") }
            };

        public static string GetDescription(int weatherCode)
        {
            return weatherCodeDescriptions.TryGetValue(weatherCode, out var description) ? description.Description : "Unknown weather code";
        }

        public static string GetPicture(int weatherCode, bool isDay)
        {
            if (weatherCodeDescriptions.TryGetValue(weatherCode, out var description))
            {
                return isDay ? description.DayPicture : description.NightPicture;
            }
            return isDay ? "unknown_day.png" : "unknown_night.png";
        }
    }
}
