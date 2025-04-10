using System;
using System.Drawing; // Required for PictureBox
using System.IO;      // Required for Path and File
using System.Windows.Forms;
using FontAwesome.Sharp;
using System.Configuration;

namespace WeatherSphereV4.Utilities // Or WeatherSphereV4.Utils if you prefer a sub-namespace
{
    public static class UIHelper
    {
        // Define Icon Folder Path (Consider making this configurable later in Step 6)
        private static readonly string IconsFolder = "Icons";
        private static readonly string UnknownIconFile = "unknown.gif";

        /// <summary>
        /// Loads the specified weather icon into the PictureBox.
        /// Handles missing icons gracefully by attempting to load 'unknown.gif'.
        /// </summary>
        /// <param name="pictureBox">The PictureBox control to display the icon in.</param>
        /// <param name="iconName">The name of the icon file (without extension).</param>
        public static void DisplayWeatherIcon(PictureBox pictureBox, string iconName)
        {
            if (pictureBox == null) return; // Safety check

            string iconsFolder = ConfigurationManager.AppSettings["IconsFolderPath"] ?? "Icons";
            string unknownIconFile = ConfigurationManager.AppSettings["UnknownIconFileName"] ?? "unknown.gif";

            string iconFilePath = null;
            bool iconFound = false;

            if (!string.IsNullOrEmpty(iconName))
            {
                try
                {
                    iconFilePath = Path.Combine(Application.StartupPath, iconsFolder, $"{iconName}.gif");

                    if (File.Exists(iconFilePath))
                    {
                        pictureBox.ImageLocation = iconFilePath;
                        pictureBox.Visible = true;
                        iconFound = true;
                    }
                    else
                    {
                        // Log that the specific icon was missing
                        Console.WriteLine($"Weather icon not found: {iconFilePath}");
                    }
                }
                catch (Exception ex)
                {
                    // Log issues accessing the primary icon file path
                    Console.WriteLine($"Error accessing icon file '{iconFilePath}': {ex.Message}");
                }
            }

            // If the specific icon wasn't found or iconName was null/empty, try loading unknown.gif
            if (!iconFound)
            {
                try
                {
                    string unknownIconPath = Path.Combine(Application.StartupPath, iconsFolder, unknownIconFile);
                    if (File.Exists(unknownIconPath))
                    {
                        pictureBox.ImageLocation = unknownIconPath;
                        pictureBox.Visible = true;
                    }
                    else
                    {
                        // If even unknown.gif is missing, hide the PictureBox or clear it
                        Console.WriteLine($"Fallback icon not found: {unknownIconPath}");
                        pictureBox.ImageLocation = null;
                        pictureBox.Image = null; // Clear any existing image
                        pictureBox.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    // Log issues accessing the fallback icon
                    Console.WriteLine($"Error accessing fallback icon file '{UnknownIconFile}': {ex.Message}");
                    pictureBox.ImageLocation = null;
                    pictureBox.Image = null;
                    pictureBox.Visible = false;
                }
            }
        }

        /// <summary>
        /// Sets the IconSize property for an IconButton.
        /// </summary>
        /// <param name="sender">The object that triggered the event (should be an IconButton).</param>
        /// <param name="iconSize">The desired icon size.</param>
        public static void SetIconButtonSize(object sender, int iconSize)
        {
            // Check if the sender is actually an IconButton
            if (sender is IconButton iconButton)
            {
                try
                {
                    iconButton.IconSize = iconSize;
                }
                catch (Exception ex)
                {
                    // Log potential errors if setting the size fails for some reason
                    Console.WriteLine($"Error setting IconSize for {iconButton.Name}: {ex.Message}");
                }
            }
        }

        // Optional: Define common sizes as constants for clarity
        public const int IconSizeLargeDefault = 55;
        public const int IconSizeLargeHover = 70;
        public const int IconSizeSearchDefault = 35;
        public const int IconSizeSearchHover = 45;
    }
}