using WeatherSphereV4.Services;
using WeatherSphereV4.Models;
using System.Collections.Generic; // For List<>
using System.Windows.Forms;     // For MessageBox, etc
using System.Threading.Tasks;  // For Task
using System;                  // For EventArgs etc.
using FontAwesome.Sharp; // For FontAwesome icons

namespace WeatherSphereV4
{
    public partial class FavoritesForm : UserControl
    {
        public FavoritesForm()
        {
            InitializeComponent();
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

        private void buttonCloseInfoBar_Click(object sender, EventArgs e)
        {
            HideInfoBar();
        }

        private async void FavoritesForm_Load(object sender, EventArgs e)
        {
            await LoadFavoritesListAsync();
        }

        private async Task LoadFavoritesListAsync()
        {
            HideInfoBar();
            ShowLoadingOverlay();
            // Disable buttons while loading
            buttonGoToFavorite.Enabled = false;
            buttonRemoveFavorite.Enabled = false;
            listBoxFavorites.DataSource = null; // Clear previous data source
            listBoxFavorites.Items.Clear();     // Clear items directly too

            try
            {
                // Check if user is logged in
                if (!WeatherSharedData.LoggedInUserID.HasValue)
                {
                    ShowInfoBar("Please log in to view favorites.", InfoBarType.Warning);
                    return; // Exit if no user logged in
                }
                int userID = WeatherSharedData.LoggedInUserID.Value;

                // Get favorites from database
                List<FavoriteLocation> favoritesList = await DatabaseManager.GetFavoritesAsync(userID);

                if (favoritesList.Count > 0)
                {
                    // Bind the list to the ListBox
                    listBoxFavorites.DataSource = favoritesList;
                    listBoxFavorites.DisplayMember = "LocationName"; // Show this property in the list
                    listBoxFavorites.ValueMember = "FavoriteID";    // Use this property behind the scenes
                }
                else
                {
                    // No favorites found
                    ShowInfoBar("You haven't added any favorite locations yet.", InfoBarType.Info);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading favorites list: {ex.ToString()}");
                ShowInfoBar($"Error loading favorites: {ex.Message}", InfoBarType.Error);
                listBoxFavorites.DataSource = null; // Clear list on error
                listBoxFavorites.Items.Clear();
            }
            finally
            {
                HideLoadingOverlay();
                // Keep GoTo/Remove disabled until an item is selected
                buttonGoToFavorite.Enabled = false;
                buttonRemoveFavorite.Enabled = false;
            }
        }

        private void listBoxFavorites_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Enable GoTo and Remove buttons only if an item is actually selected
            bool isItemSelected = (listBoxFavorites.SelectedItem != null);
            buttonGoToFavorite.Enabled = isItemSelected;
            buttonRemoveFavorite.Enabled = isItemSelected;
        }

        private void buttonGoToFavorite_Click(object sender, EventArgs e)
        {
            // Get the selected favorite object
            if (listBoxFavorites.SelectedItem is FavoriteLocation selectedFav)
            {
                Console.WriteLine($"Navigating to favorite: {selectedFav.LocationName}");
                WeatherSharedData.SetLocationData(selectedFav.Latitude, selectedFav.Longitude, selectedFav.LocationName);

                // Optional: Show feedback
                ShowInfoBar($"Showing weather for '{selectedFav.LocationName}'.", InfoBarType.Info);

                var baseForm = this.ParentForm as BaseForm;
                if (baseForm != null)
                {
                    // 3. Tell BaseForm to switch to the "Home" view
                    baseForm.ShowView("Home");
                }
                else
                {
                    Console.WriteLine("Could not find BaseForm parent to switch view.");
                    // Handle error? Or maybe just setting shared data is enough?
                }
            }
        }

        private async void buttonRemoveFavorite_Click(object sender, EventArgs e)
        {
            // Get selected item and logged in user ID
            if (!(listBoxFavorites.SelectedItem is FavoriteLocation selectedFav)) return;
            if (!WeatherSharedData.LoggedInUserID.HasValue) return; // Should not happen if button is enabled

            int favId = selectedFav.FavoriteID;
            int userId = WeatherSharedData.LoggedInUserID.Value;
            string locName = selectedFav.LocationName;

            // Confirm deletion
            DialogResult confirm = MessageBox.Show($"Are you sure you want to remove '{locName}' from your favorites?",
                                                 "Confirm Removal",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                ShowLoadingOverlay(); // Show busy indicator
                buttonRemoveFavorite.Enabled = false;
                buttonGoToFavorite.Enabled = false;
                bool success = false;
                try
                {
                    success = await DatabaseManager.RemoveFavoriteAsync(favId, userId);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error removing favorite ID {favId}: {ex.ToString()}");
                    ShowInfoBar($"Error removing favorite: {ex.Message}", InfoBarType.Error);
                }
                finally
                {
                    HideLoadingOverlay();
                }

                if (success)
                {
                    ShowInfoBar($"Removed '{locName}' from favorites.", InfoBarType.Success);
                    // Refresh the list to show the item is gone
                    await LoadFavoritesListAsync();
                }
                else
                {
                    // ShowInfoBar already called on error, or RemoveFavoriteAsync returned false
                    // Re-enable buttons if needed, although list refresh handles it
                    buttonRemoveFavorite.Enabled = listBoxFavorites.SelectedItem != null;
                    buttonGoToFavorite.Enabled = listBoxFavorites.SelectedItem != null;
                }
            }
        }

        public async Task RefreshDataAsync()
        {
            Console.WriteLine("FavoritesForm RefreshDataAsync called.");
            // This is the method we already created to load the list
            await LoadFavoritesListAsync();
        }
    }
}
