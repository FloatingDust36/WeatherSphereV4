using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using WeatherSphereV4.Services;

namespace WeatherSphereV4
{
    public partial class AccountForm : UserControl
    {
        public AccountForm()
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

        private void AccountForm_Resize(object sender, EventArgs e)
        {
            CenterLoadingSpinner();
        }

        private async void AccountForm_Load(object sender, EventArgs e)
        {
            await LoadAccountDetailsAsync();
        }

        private async Task LoadAccountDetailsAsync()
        {
            HideInfoBar();
            ShowLoadingOverlay();
            ClearAccountUIAndDisableActions(); // Reset UI first

            try
            {
                if (!WeatherSharedData.LoggedInUserID.HasValue)
                {
                    ShowInfoBar("No user is currently logged in.", InfoBarType.Warning);
                    return; // Nothing to load
                }

                int userID = WeatherSharedData.LoggedInUserID.Value;

                // Get details from DB
                var (username, dateCreated, lastLogin) = await DatabaseManager.GetUserDetailsAsync(userID);

                if (username != null) // Check if user details were found
                {
                    // Populate Labels
                    labelUsernameDisplay.Text = username;
                    labelDateCreatedDisplay.Text = dateCreated.ToString("yyyy-MM-dd HH:mm"); // Or your preferred format
                    labelLastLoginDisplay.Text = lastLogin.HasValue ? lastLogin.Value.ToString("yyyy-MM-dd HH:mm") : "Never";

                    // Enable actions now that we know the user
                    buttonChangePassword.Enabled = true;
                    buttonLogout.Enabled = true;
                    buttonDeleteAccount.Enabled = true; // Enable delete button
                }
                else
                {
                    // User ID was set, but user not found in DB? Should not happen normally.
                    ShowInfoBar("Could not retrieve account details.", InfoBarType.Error);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading account details: {ex.ToString()}");
                ShowInfoBar($"Error loading details: {ex.Message}", InfoBarType.Error);
                ClearAccountUIAndDisableActions(); // Clear UI on error
            }
            finally
            {
                HideLoadingOverlay();
            }
        }

        private void ClearAccountUIAndDisableActions()
        {
            labelUsernameDisplay.Text = "...";
            labelDateCreatedDisplay.Text = "...";
            labelLastLoginDisplay.Text = "...";

            textboxCurrentPassword.Clear();
            textboxNewPassword.Clear();
            textboxConfirmNewPassword.Clear();

            buttonChangePassword.Enabled = false;
            buttonLogout.Enabled = false;
            buttonDeleteAccount.Enabled = false;
        }

        private async void buttonChangePassword_Click(object sender, EventArgs e)
        {
            HideInfoBar(); // Clear previous messages

            // --- 1. Get Input ---
            string currentPassword = textboxCurrentPassword.Text; // No trim
            string newPassword = textboxNewPassword.Text;
            string confirmPassword = textboxConfirmNewPassword.Text;

            // --- 2. Validate Input ---
            if (string.IsNullOrEmpty(currentPassword) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                ShowInfoBar("Please fill in all password fields.", InfoBarType.Warning);
                return;
            }
            if (newPassword != confirmPassword)
            {
                ShowInfoBar("New password and confirmation password do not match.", InfoBarType.Warning);
                textboxConfirmNewPassword.Focus();
                textboxConfirmNewPassword.SelectAll();
                return;
            }
            if (currentPassword == newPassword)
            {
                ShowInfoBar("New password must be different from the current password.", InfoBarType.Warning);
                textboxNewPassword.Focus();
                return;
            }
            // Optional: Add new password complexity validation here (length, characters etc.)

            // --- 3. Verify Current Password and Update ---
            this.Cursor = Cursors.WaitCursor;
            buttonChangePassword.Enabled = false;

            try
            {
                // Check if user is logged in (should be if button is enabled, but double-check)
                if (!WeatherSharedData.LoggedInUserID.HasValue)
                {
                    ShowInfoBar("Not logged in.", InfoBarType.Error);
                    return;
                }
                int userID = WeatherSharedData.LoggedInUserID.Value;
                // Get username from the display label which should be loaded
                string username = labelUsernameDisplay.Text;
                if (string.IsNullOrEmpty(username) || username == "...")
                {
                    ShowInfoBar("Cannot verify current user.", InfoBarType.Error);
                    return;
                }

                // Get current hash from DB
                var (storedHash, _) = await DatabaseManager.GetUserLoginInfoAsync(username);

                if (storedHash == null)
                {
                    ShowInfoBar("Could not retrieve current user information.", InfoBarType.Error);
                    return;
                }

                // Verify the entered CURRENT password
                bool isCurrentValid = DatabaseManager.VerifyPassword(currentPassword, storedHash);

                if (!isCurrentValid)
                {
                    ShowInfoBar("Incorrect current password.", InfoBarType.Error);
                    textboxCurrentPassword.Focus();
                    textboxCurrentPassword.SelectAll();
                    return; // Stop if current password doesn't match
                }

                // --- Current password is valid, proceed to hash and update ---

                string newPasswordHash = DatabaseManager.HashPassword(newPassword);
                bool updateSuccess = await DatabaseManager.UpdatePasswordHashAsync(userID, newPasswordHash);

                if (updateSuccess)
                {
                    ShowInfoBar("Password updated successfully.", InfoBarType.Success);
                    // Clear password fields after success
                    textboxCurrentPassword.Clear();
                    textboxNewPassword.Clear();
                    textboxConfirmNewPassword.Clear();
                }
                else
                {
                    ShowInfoBar("Failed to update password in the database.", InfoBarType.Error);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error changing password for UserID {WeatherSharedData.LoggedInUserID}: {ex.ToString()}");
                ShowInfoBar($"An error occurred: {ex.Message}", InfoBarType.Error);
            }
            finally
            {
                buttonChangePassword.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Logout button clicked.");
            // Clear the session and raise the event. BaseForm will handle UI changes.
            WeatherSharedData.ClearLoggedInUser();
        }

        private async void buttonDeleteAccount_Click(object sender, EventArgs e)
        {
            HideInfoBar();

            // 1. Confirm User is Logged In
            if (!WeatherSharedData.LoggedInUserID.HasValue)
            {
                ShowInfoBar("Not logged in.", InfoBarType.Error);
                return;
            }
            int userID = WeatherSharedData.LoggedInUserID.Value;
            string username = labelUsernameDisplay.Text; // Get username for confirmation message

            // 2. STRONG Confirmation!
            string confirmMessage = $"Are you absolutely sure you want to delete your account '{username}'?\n\n" +
                                    "THIS ACTION IS PERMANENT AND CANNOT BE UNDONE.\n" +
                                    "All your saved favorite locations will also be deleted.";

            DialogResult confirmation = MessageBox.Show(confirmMessage,
                                                      "Confirm Account Deletion",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Warning,
                                                      MessageBoxDefaultButton.Button2); // Default to NO

            if (confirmation == DialogResult.No)
            {
                return; // User cancelled
            }

            // --- User confirmed YES ---

            // 3. Attempt Deletion
            this.Cursor = Cursors.WaitCursor;
            buttonDeleteAccount.Enabled = false;
            buttonChangePassword.Enabled = false; // Disable other actions too
            buttonLogout.Enabled = false;

            bool deleteSuccess = false;
            try
            {
                if (!DatabaseManager.IsInitialized)
                {
                    ShowInfoBar("Database connection error.", InfoBarType.Error);
                    return;
                }
                deleteSuccess = await DatabaseManager.DeleteUserAsync(userID);

                if (deleteSuccess)
                {
                    // Success! User is deleted. Now trigger the logout process.
                    MessageBox.Show("Account successfully deleted.", "Account Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    WeatherSharedData.ClearLoggedInUser(); // This will clear ID and raise UserLoggedOut event
                                                           // BaseForm will handle hiding this form and showing the login screen via the event
                }
                else
                {
                    // Deletion failed at the database level (error already logged by DAL)
                    ShowInfoBar("Failed to delete account due to a database error.", InfoBarType.Error);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CRITICAL ERROR during account deletion for UserID {userID}: {ex.ToString()}");
                ShowInfoBar($"An unexpected error occurred: {ex.Message}", InfoBarType.Error);
            }
            finally
            {
                // Only re-enable buttons if deletion FAILED, otherwise form will be hidden by logout
                if (!deleteSuccess)
                {
                    buttonDeleteAccount.Enabled = true;
                    buttonChangePassword.Enabled = true;
                    buttonLogout.Enabled = true;
                    this.Cursor = Cursors.Default;
                }
            }
        }
    }
}
