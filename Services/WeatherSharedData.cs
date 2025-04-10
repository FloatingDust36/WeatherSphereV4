using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherSphereV4.Services
{
    public static class WeatherSharedData
    {
        // --- Existing Fields/Properties ---
        private static string _latitude;
        private static string _longitude;
        private static string _location;

        public static string Latitude { get => _latitude; private set => _latitude = value; }
        public static string Longitude { get => _longitude; private set => _longitude = value; }
        public static string Location { get => _location; private set => _location = value; }


        // --- Existing Event Logic ---
        public static event EventHandler LocationChanged;

        private static void OnLocationChanged()
        {
            // Ensure Lat/Lon/Location are consistent before raising
            Console.WriteLine($"Location Changed Event Raised. New Location: {Location} ({Latitude}, {Longitude})"); // For Debugging
            // Use null-conditional operator ?. to safely invoke the event if there are subscribers
            LocationChanged?.Invoke(null, EventArgs.Empty);
        }

        public static void SetLocationData(string lat, string lon, string locationName)
        {
            bool changed = false;
            // Check each piece of data for changes before assigning
            if (_latitude != lat) { _latitude = lat; changed = true; }
            if (_longitude != lon) { _longitude = lon; changed = true; }
            // Be careful comparing potentially null locationName
            if (_location != locationName) { _location = locationName; changed = true; }

            if (changed)
            {
                // Raise the event only if something actually changed
                OnLocationChanged();
            }
            else
            {
                Console.WriteLine($"SetLocationData called but no change detected for {locationName}"); // Debugging
            }
        }

        public static void InitializeLocation(string lat, string lon, string locationName)
        {
            // Directly assign values
            _latitude = lat;
            _longitude = lon;
            _location = locationName;
            Console.WriteLine($"InitializeLocation called for {locationName}"); // Debugging
            // Directly raise the event because this IS the initial change.
            OnLocationChanged();
        }

        /// <summary>
        /// Stores the UserID of the currently logged-in user. Null if no user is logged in.
        /// </summary>
        public static int? LoggedInUserID { get; private set; } = null; // Initialize as null

        /// <summary>
        /// Clears the logged-in user ID (used for logout).
        /// </summary>
        public static void ClearLoggedInUser()
        {
            LoggedInUserID = null;
            Console.WriteLine("Logged out user."); // Optional log
        }

        /// <summary>
        /// Sets the logged-in user ID. Should only be called on successful login.
        /// </summary>
        /// <param name="userId">The ID of the logged-in user.</param>
        internal static void SetLoggedInUser(int userId) // Internal prevents accidental setting from UI forms
        {
            LoggedInUserID = userId;
            Console.WriteLine($"User logged in with ID: {userId}"); // Optional log
        }
    }
}
