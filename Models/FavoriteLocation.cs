using System;

namespace WeatherSphereV4.Models
{
    public class FavoriteLocation
    {
        public int FavoriteID { get; set; }
        public int UserID { get; set; }
        public string LocationName { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public DateTime DateAdded { get; set; }

        // Optional: Override ToString for easy display in lists/debug
        public override string ToString()
        {
            return LocationName ?? "Unknown Location";
        }
    }
}
