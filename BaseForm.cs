using System; // For EventArgs, Task, etc.
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using FontAwesome.Sharp;
using WeatherSphereV4.CustomControls;
using WeatherSphereV4.Utilities;
using System.Net.Http; // For HttpClient - reuse static instance if possible
using Newtonsoft.Json; // For JSON parsing
using WeatherSphereV4.Models; // IpApiLocationInfo
using WeatherSphereV4.Processes; // ProcessWeatherData
using System.Threading.Tasks;
using WeatherSphereV4.Services; // For Task

namespace WeatherSphereV4
{
    public partial class BaseForm : Form
    {
        private IconButton currentbutton;
        private Panel leftBorderButton;

        //Fields
        private int borderSize = 2;
        private Size formSize; //Keep form size when it is minimized and restored.Since the form is resized because it takes into account the size of the title bar and borders.

        public BaseForm()
        {
            InitializeComponent();

            this.Padding = new Padding(borderSize);//Border size
            this.BackColor = Color.FromArgb(25, 25, 50);//Border color

            leftBorderButton = new Panel();
            leftBorderButton.Size = new Size(9, 73);
            leftBorderButton.Visible = false;
            panelMenu.Controls.Add(leftBorderButton);
            pictureLogo.BringToFront();
            pictureLogo.BackColor = Color.Transparent;

            WeatherSharedData.UserLoggedOut += HandleUserLogout;
        }

        private void HandleUserLogout(object sender, EventArgs e)
        {
            // Ensure execution on the UI thread
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => HandleUserLogout(sender, e)));
                return;
            }

            Console.WriteLine("BaseForm Handling UserLogout Event...");

            // 1. Clear cached UserControls to ensure fresh state on next login
            foreach (UserControl uc in userControls.Values)
            {
                uc.Dispose(); // Dispose the cached controls
            }
            userControls.Clear(); // Clear the dictionary
            currentControl = null;

            // 2. Hide this main form
            this.Hide();

            // 3. Show the login form again
            // Create a NEW instance of the login form
            CreateAccountForm loginForm = new CreateAccountForm();

            // 4. Ensure application exits when the login form is closed
            loginForm.FormClosed += (s, args) => this.Close(); // Add FormClosed handler

            loginForm.Show();
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            ShowLoadingOverlay();

            await TrySetInitialLocationAsync();
            if (buttonHome != null) // Check if button exists
            {
                buttonHome.PerformClick();
            }
            else
            {
                // Fallback if buttonHome isn't available - manually load HomeForm
                LoadUserControl("Home", new HomeForm());
                // Ensure the home button in the menu *looks* activated
                ActivateButton(buttonHome, RGBColors.color1); // Assuming buttonHome is the sender object
            }

            HideLoadingOverlay(); // Hide BaseForm loading indicator
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

        #region Menu Movement and Design
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }

        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentbutton = (IconButton)senderBtn;
                currentbutton.BackColor = Color.FromArgb(37, 36, 81);
                currentbutton.ForeColor = color;
                currentbutton.TextAlign = ContentAlignment.MiddleCenter;
                currentbutton.IconColor = color;
                currentbutton.TextImageRelation = TextImageRelation.TextBeforeImage;
                if (this.panelMenu.Width > 100)
                {
                    currentbutton.ImageAlign = ContentAlignment.MiddleRight;
                }

                //Left Border Button
                leftBorderButton.BackColor = color;
                leftBorderButton.Location = new Point(0, currentbutton.Location.Y);
                leftBorderButton.Visible = true;
                leftBorderButton.BringToFront();
            }
        }

        private void DisableButton()
        {
            if (currentbutton != null)
            {
                currentbutton.BackColor = Color.FromArgb(25, 25, 50);
                currentbutton.ForeColor = Color.Gainsboro;
                currentbutton.TextAlign = ContentAlignment.MiddleLeft;
                currentbutton.IconColor = Color.Gainsboro;
                currentbutton.TextImageRelation = TextImageRelation.ImageBeforeText;
                if (this.panelMenu.Width > 100)
                    currentbutton.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            LoadUserControl("Home", new HomeForm());
            buttonAddRemoveFavorites.Visible = true; // Show the button when Home is active
        }

        private void buttonMaps_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            LoadUserControl("Maps", new MapsForm());
            buttonAddRemoveFavorites.Visible = true; // Show the button when Maps is active
        }

        private void buttonHourlyForecast_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            LoadUserControl("HourlyForecast", new HourlyForecastForm());
            buttonAddRemoveFavorites.Visible = false; // Hide the button when HourlyForecast is active
        }

        private void buttonMonthlyForecast_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            LoadUserControl("MonthlyForecast", new MonthlyForecastForm());
            buttonAddRemoveFavorites.Visible = false; // Hide the button when MonthlyForecast is active
        }

        private void buttonLife_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
            LoadUserControl("Life", new LifeForm());
            buttonAddRemoveFavorites.Visible = false; // Hide the button when Life is active
        }

        private void buttonFavorites_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);
            LoadUserControl("Favorites", new FavoritesForm());
            buttonAddRemoveFavorites.Visible = false; // Hide the button when Favorites is active
        }

        private void buttonAccount_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            LoadUserControl("Account", new AccountForm());
            buttonAddRemoveFavorites.Visible = false; // Hide the button when Account is active
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            LoadUserControl("Settings", new SettingsForm());
            buttonAddRemoveFavorites.Visible = false; // Hide the button when Settings is active
        }
        #endregion

        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panelTitleBar_MouseDown_1(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //Overridden methods
        protected override void WndProc(ref Message m)
        {
            const int WM_NCCALCSIZE = 0x0083;//Standar Title Bar - Snap Window
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MINIMIZE = 0xF020; //Minimize form (Before)
            const int SC_RESTORE = 0xF120; //Restore form (Before)
            const int WM_NCHITTEST = 0x0084;//Win32, Mouse Input Notification: Determine what part of the window corresponds to a point, allows to resize the form.
            const int resizeAreaSize = 10;
            #region Form Resize
            // Resize/WM_NCHITTEST values
            const int HTCLIENT = 1; //Represents the client area of the window
            const int HTLEFT = 10;  //Left border of a window, allows resize horizontally to the left
            const int HTRIGHT = 11; //Right border of a window, allows resize horizontally to the right
            const int HTTOP = 12;   //Upper-horizontal border of a window, allows resize vertically up
            const int HTTOPLEFT = 13;//Upper-left corner of a window border, allows resize diagonally to the left
            const int HTTOPRIGHT = 14;//Upper-right corner of a window border, allows resize diagonally to the right
            const int HTBOTTOM = 15; //Lower-horizontal border of a window, allows resize vertically down
            const int HTBOTTOMLEFT = 16;//Lower-left corner of a window border, allows resize diagonally to the left
            const int HTBOTTOMRIGHT = 17;//Lower-right corner of a window border, allows resize diagonally to the right
            ///<Doc> More Information: https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-nchittest </Doc>
            if (m.Msg == WM_NCHITTEST)
            { //If the windows m is WM_NCHITTEST
                base.WndProc(ref m);
                if (this.WindowState == FormWindowState.Normal)//Resize the form if it is in normal state
                {
                    if ((int)m.Result == HTCLIENT)//If the result of the m (mouse pointer) is in the client area of the window
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32()); //Gets screen point coordinates(X and Y coordinate of the pointer)                           
                        Point clientPoint = this.PointToClient(screenPoint); //Computes the location of the screen point into client coordinates                          
                        if (clientPoint.Y <= resizeAreaSize)//If the pointer is at the top of the form (within the resize area- X coordinate)
                        {
                            if (clientPoint.X <= resizeAreaSize) //If the pointer is at the coordinate X=0 or less than the resizing area(X=10) in 
                                m.Result = (IntPtr)HTTOPLEFT; //Resize diagonally to the left
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize))//If the pointer is at the coordinate X=11 or less than the width of the form(X=Form.Width-resizeArea)
                                m.Result = (IntPtr)HTTOP; //Resize vertically up
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)HTTOPRIGHT;
                        }
                        else if (clientPoint.Y <= (this.Size.Height - resizeAreaSize)) //If the pointer is inside the form at the Y coordinate(discounting the resize area size)
                        {
                            if (clientPoint.X <= resizeAreaSize)//Resize horizontally to the left
                                m.Result = (IntPtr)HTLEFT;
                            else if (clientPoint.X > (this.Width - resizeAreaSize))//Resize horizontally to the right
                                m.Result = (IntPtr)HTRIGHT;
                        }
                        else
                        {
                            if (clientPoint.X <= resizeAreaSize)//Resize diagonally to the left
                                m.Result = (IntPtr)HTBOTTOMLEFT;
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize)) //Resize vertically down
                                m.Result = (IntPtr)HTBOTTOM;
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)HTBOTTOMRIGHT;
                        }
                    }
                }
                return;
            }
            #endregion
            //Remove border and keep snap window
            if (m.Msg == WM_NCCALCSIZE && m.WParam.ToInt32() == 1)
            {
                return;
            }
            //Keep form size when it is minimized and restored. Since the form is resized because it takes into account the size of the title bar and borders.
            if (m.Msg == WM_SYSCOMMAND)
            {
                /// <see cref="https://docs.microsoft.com/en-us/windows/win32/menurc/wm-syscommand"/>
                /// Quote:
                /// In WM_SYSCOMMAND messages, the four low - order bits of the wParam parameter 
                /// are used internally by the system.To obtain the correct result when testing 
                /// the value of wParam, an application must combine the value 0xFFF0 with the 
                /// wParam value by using the bitwise AND operator.
                int wParam = (m.WParam.ToInt32() & 0xFFF0);
                if (wParam == SC_MINIMIZE)  //Before
                    formSize = this.ClientSize;
                if (wParam == SC_RESTORE)// Restored form(Before)
                    this.Size = formSize;
            }
            base.WndProc(ref m);
        }

        //Event methods
        private void Form1_Resize(object sender, EventArgs e)
        {
            AdjustForm();
        }

        //private methods
        private void AdjustForm()
        {
            switch (this.WindowState)
            {
                case FormWindowState.Maximized:
                    this.Padding = new Padding(0, 8, 8, 0);
                    break;
                case FormWindowState.Normal:
                    if (this.Padding.Top != borderSize)
                        this.Padding = new Padding(borderSize);
                    break;
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            formSize = this.ClientSize;
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                formSize = this.ClientSize;
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.Size = formSize;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonMenu_Click(object sender, EventArgs e)
        {
            MenuAnimation();
        }

        private void MenuAnimation()
        {
            if (this.panelMenu.Width > 100) //Collapse menu
            {
                panelMenu.Width = 100;
                foreach (Button menuButton in panelMenu.Controls.OfType<Button>())
                {
                    menuButton.Text = "";
                    menuButton.ImageAlign = ContentAlignment.MiddleCenter;
                    menuButton.Padding = new Padding(0);
                }
            }
            else
            { //Expand menu
                panelMenu.Width = 380;
                foreach (Button menuButton in panelMenu.Controls.OfType<Button>())
                {
                    menuButton.Text = "   " + menuButton.Tag.ToString();
                    menuButton.ImageAlign = ContentAlignment.MiddleLeft;
                    menuButton.TextAlign = ContentAlignment.MiddleLeft;
                    menuButton.TextImageRelation = TextImageRelation.ImageBeforeText;
                    menuButton.Padding = new Padding(20, 0, 0, 0);
                }
                //Activate the last selected button
                if (currentbutton != null)
                    ActivateButton(currentbutton, currentbutton.ForeColor);
            }
        }

        private Dictionary<string, UserControl> userControls = new Dictionary<string, UserControl>();
        private UserControl currentControl = null; // Keep track of active control

        private void LoadUserControl(string key, UserControl control)
        {
            if (currentControl != null)
            {
                currentControl.Hide(); // Hide previous control instead of clearing
            }
            if (!userControls.ContainsKey(key))
            {
                control.Dock = DockStyle.Fill;
                userControls[key] = control;
                panelContents.Controls.Add(control);
            }

            currentControl = userControls[key]; // Update active control
            currentControl.Show(); // Ensure the control is visible
            currentControl.BringToFront();

            UpdateFavoriteButtonState();
        }

        public async void UpdateFavoriteButtonState()
        {
            // Check if the *newly shown* control is Home or Maps
            bool showButton = (currentControl is HomeForm || currentControl is MapsForm);
            buttonAddRemoveFavorites.Visible = showButton;

            if (showButton && WeatherSharedData.LoggedInUserID.HasValue)
            {
                // If button is visible and user logged in, check current fav status
                string currentLat = WeatherSharedData.Latitude;
                string currentLon = WeatherSharedData.Longitude;
                int currentUserID = WeatherSharedData.LoggedInUserID.Value;

                if (!string.IsNullOrEmpty(currentLat) && !string.IsNullOrEmpty(currentLon))
                {
                    this.Cursor = Cursors.WaitCursor; // Indicate check
                    buttonAddRemoveFavorites.Enabled = false;
                    try
                    {
                        FavoriteLocation fav = await DatabaseManager.FindFavoriteAsync(currentUserID, currentLat, currentLon);
                        if (fav != null)
                        {
                            // Already a favorite
                            buttonAddRemoveFavorites.IconChar = IconChar.HeartCircleMinus; // Remove icon
                            toolTip.SetToolTip(buttonAddRemoveFavorites, "Remove from Favorites");
                        }
                        else
                        {
                            // Not a favorite
                            buttonAddRemoveFavorites.IconChar = IconChar.HeartCirclePlus; // Add icon
                            toolTip.SetToolTip(buttonAddRemoveFavorites, "Add to Favorites");
                        }
                    }
                    catch (Exception ex) { Console.WriteLine($"Error checking favorite status on view change: {ex.Message}"); }
                    finally
                    {
                        buttonAddRemoveFavorites.Enabled = true;
                        this.Cursor = Cursors.Default;
                    }
                }
                else // No valid location data, maybe default to "Add" state or disable?
                {
                    buttonAddRemoveFavorites.IconChar = IconChar.HeartCirclePlus;
                    toolTip.SetToolTip(buttonAddRemoveFavorites, "Add to Favorites");
                    buttonAddRemoveFavorites.Enabled = false; // Disable if no location data
                }
            }
            else if (showButton) // Button should be visible but user not logged in
            {
                buttonAddRemoveFavorites.IconChar = IconChar.HeartCirclePlus; // Default to Add icon
                toolTip.SetToolTip(buttonAddRemoveFavorites, "Log in to add favorites");
                buttonAddRemoveFavorites.Enabled = false; // Disable if not logged in
            }
        }

        private void buttonNightDayToggle_MouseHover(object sender, EventArgs e)
        {
            UIHelper.SetIconButtonSize(sender, UIHelper.IconSizeLargeHover);
        }

        private void buttonNightDayToggle_MouseLeave(object sender, EventArgs e)
        {
            UIHelper.SetIconButtonSize(sender, UIHelper.IconSizeLargeDefault);
        }

        private void buttonAddRemoveFavorites_MouseHover(object sender, EventArgs e)
        {
            UIHelper.SetIconButtonSize(sender, UIHelper.IconSizeLargeHover);
        }

        private void buttonAddRemoveFavorites_MouseLeave(object sender, EventArgs e)
        {
            UIHelper.SetIconButtonSize(sender, UIHelper.IconSizeLargeDefault);
        }

        private void buttonRefresh_MouseHover(object sender, EventArgs e)
        {
            UIHelper.SetIconButtonSize(sender, UIHelper.IconSizeLargeHover);
        }

        private void buttonRefresh_MouseLeave(object sender, EventArgs e)
        {
            UIHelper.SetIconButtonSize(sender, UIHelper.IconSizeLargeDefault);
        }

        private async Task TrySetInitialLocationAsync()
        {
            string ipApiUrl = "http://ip-api.com/json"; // URL for the IP API
            string defaultLat = "10.3157";
            string defaultLon = "123.8854";
            string defaultLocation = "Cebu City, Central Visayas, Philippines";

            try
            {
                Console.WriteLine("Attempting IP Geolocation using ProcessWeatherData...");

                // --- REPLACE THE using(var tempClient...) block ---
                // --- WITH a call to the new static method ---

                // Set a short timeout specifically for the IP lookup (e.g., 5 seconds)
                string jsonResponse = await ProcessWeatherData.GetGenericJsonAsync(ipApiUrl, 5);

                // --- The code below assumes GetGenericJsonAsync succeeded (didn't throw) ---

                IpApiLocationInfo locationInfo = JsonConvert.DeserializeObject<IpApiLocationInfo>(jsonResponse);

                if (locationInfo?.Status?.ToLower() == "success" && locationInfo.Lat.HasValue && locationInfo.Lon.HasValue)
                {
                    string detectedLocation = $"{locationInfo.City}, {locationInfo.RegionName}, {locationInfo.Country}";
                    Console.WriteLine($"IP Geolocation Success: {detectedLocation}");
                    // Use InitializeLocation to ensure event fires for first location
                    WeatherSharedData.InitializeLocation(locationInfo.Lat.Value.ToString(), locationInfo.Lon.Value.ToString(), detectedLocation);
                    return; // Success, exit method
                }
                else
                {
                    // This else block might be reached if status wasn't "success" or lat/lon were null
                    Console.WriteLine($"IP Geolocation API returned non-success or invalid data. Status: {locationInfo?.Status}, Message: {locationInfo?.Message}");
                }

                // --- REMOVE the old http response handling logic (IsSuccessStatusCode etc.) ---
                // --- It's now handled by GetGenericJsonAsync throwing an exception on failure ---

            }
            // --- The existing catch block will now catch exceptions from GetGenericJsonAsync ---
            catch (HttpRequestException httpEx) // Catch specific HTTP errors
            {
                Console.WriteLine($"Error during IP Geolocation HTTP request: {httpEx.Message}");
            }
            catch (JsonException jsonEx) // Catch errors during JSON parsing
            {
                Console.WriteLine($"Error parsing IP Geolocation response: {jsonEx.Message}");
            }
            catch (Exception ex) // Catch any other general errors
            {
                Console.WriteLine($"Generic error during IP Geolocation: {ex.Message}");
            }

            // If we reached here, detection failed (due to exception or non-success status), use default
            Console.WriteLine("IP Geolocation failed or unavailable, using default location (Cebu City).");
            // Use InitializeLocation to ensure event fires for first location
            WeatherSharedData.InitializeLocation(defaultLat, defaultLon, defaultLocation);
        }

        private async void buttonAddRemoveFavorites_Click(object sender, EventArgs e)
        {
            if (!WeatherSharedData.LoggedInUserID.HasValue)
            {
                // Optional: Show InfoBar or MessageBox asking user to log in first
                ShowInfoBar("Please log in to manage favorites.", InfoBarType.Warning);
                // Or: MessageBox.Show("Please log in to manage favorites.", "Login Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int currentUserID = WeatherSharedData.LoggedInUserID.Value;

            // 2. Get current location details from shared data
            string currentLat = WeatherSharedData.Latitude;
            string currentLon = WeatherSharedData.Longitude;
            string currentLocName = WeatherSharedData.Location;

            if (string.IsNullOrEmpty(currentLat) || string.IsNullOrEmpty(currentLon) || string.IsNullOrEmpty(currentLocName))
            {
                ShowInfoBar("Current location data is unavailable.", InfoBarType.Warning);
                return;
            }

            // 3. Check if this location is already a favorite
            this.Cursor = Cursors.WaitCursor;
            buttonAddRemoveFavorites.Enabled = false;
            FavoriteLocation existingFavorite = null;
            try
            {
                existingFavorite = await DatabaseManager.FindFavoriteAsync(currentUserID, currentLat, currentLon);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking for existing favorite: {ex.ToString()}");
                ShowInfoBar("Error checking favorites database.", InfoBarType.Error);
                this.Cursor = Cursors.Default;
                buttonAddRemoveFavorites.Enabled = true;
                return;
            }

            // 4. Add or Remove based on whether it was found
            try
            {
                bool success = false;
                if (existingFavorite != null)
                {
                    // --- Location IS a favorite, so REMOVE it ---
                    Console.WriteLine($"Attempting to remove favorite ID: {existingFavorite.FavoriteID}");
                    success = await DatabaseManager.RemoveFavoriteAsync(existingFavorite.FavoriteID, currentUserID);
                    if (success)
                    {
                        ShowInfoBar($"Removed '{currentLocName}' from favorites.", InfoBarType.Success);
                        // Update button appearance (example using IconChar)
                        buttonAddRemoveFavorites.IconChar = IconChar.HeartCirclePlus; // Or regular HeartCrack, Heart, etc.
                        toolTip.SetToolTip(buttonAddRemoveFavorites, "Add to Favorites"); // Assuming you have a ToolTip component named toolTip
                    }
                    else
                    {
                        ShowInfoBar($"Failed to remove '{currentLocName}' from favorites.", InfoBarType.Warning);
                    }
                }
                else
                {
                    // --- Location IS NOT a favorite, so ADD it ---
                    Console.WriteLine($"Attempting to add favorite: {currentLocName}");
                    success = await DatabaseManager.AddFavoriteAsync(currentUserID, currentLocName, currentLat, currentLon);
                    if (success)
                    {
                        ShowInfoBar($"Added '{currentLocName}' to favorites.", InfoBarType.Success);
                        // Update button appearance
                        buttonAddRemoveFavorites.IconChar = IconChar.HeartCircleMinus; // Or HeartCircleCheck, Solid Heart, etc.
                        toolTip.SetToolTip(buttonAddRemoveFavorites, "Remove from Favorites");
                    }
                    else
                    {
                        ShowInfoBar($"Failed to add '{currentLocName}' to favorites.", InfoBarType.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding/removing favorite: {ex.ToString()}");
                ShowInfoBar("Error updating favorites database.", InfoBarType.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                buttonAddRemoveFavorites.Enabled = true;
            }
        }

        private void buttonCloseInfoBar_Click(object sender, EventArgs e)
        {
            HideInfoBar();
        }

        private async void buttonRefresh_Click(object sender, EventArgs e)
        {
            // Check which control is currently active
            if (currentControl != null)
            {
                Console.WriteLine($"Refresh requested for: {currentControl.GetType().Name}");
                this.Cursor = Cursors.WaitCursor;
                buttonRefresh.Enabled = false; // Disable while refreshing

                // Use pattern matching (C# 7+) or if/else if (as BaseForm doesn't know RefreshDataAsync exists)
                // This calls the specific RefreshDataAsync method on the active control
                Task refreshTask = null;
                if (currentControl is HomeForm hf) { refreshTask = hf.RefreshDataAsync(); }
                else if (currentControl is MapsForm mf) { refreshTask = mf.RefreshDataAsync(); }
                else if (currentControl is HourlyForecastForm hff) { refreshTask = hff.RefreshDataAsync(); }
                else if (currentControl is MonthlyForecastForm mff) { refreshTask = mff.RefreshDataAsync(); }
                else if (currentControl is FavoritesForm ff) { refreshTask = ff.RefreshDataAsync(); }
                // Add other refreshable forms here if needed
                // else if (currentControl is SomeOtherForm sof) { refreshTask = sof.RefreshDataAsync(); }

                if (refreshTask != null)
                {
                    try
                    {
                        await refreshTask; // Wait for the refresh operation to complete
                        ShowInfoBar("Data refreshed.", InfoBarType.Success); // Optional success feedback
                                                                             // Use a timer to hide the success message after a few seconds?
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error during refresh: {ex.ToString()}");
                        // ShowInfoBar should be called by the specific form's load method on error
                    }
                }
                else
                {
                    Console.WriteLine("Current control does not support refreshing.");
                    // Maybe show info: ShowInfoBar("Refresh not applicable for this view.", InfoBarType.Info);
                }

                buttonRefresh.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Activates and loads the UserControl associated with the specified key.
        /// Simulates clicking the corresponding menu button.
        /// </summary>
        /// <param name="viewKey">The key (usually the Tag) associated with the view/button (e.g., "Home", "Maps").</param>
        public void ShowView(string viewKey)
        {
            // Find the button in the menu panel whose Tag matches the viewKey
            // This assumes you have set the 'Tag' property of your menu IconButtons
            // in the designer (e.g., buttonHome.Tag = "Home"; buttonMaps.Tag = "Maps"; etc.)
            IconButton targetButton = panelMenu.Controls.OfType<IconButton>()
                                          .FirstOrDefault(btn => btn.Tag?.ToString() == viewKey);

            if (targetButton != null)
            {
                Console.WriteLine($"BaseForm.ShowView: Found button for key '{viewKey}', performing click.");
                // Programmatically click the button.
                // The button's existing Click event handler will call ActivateButton and LoadUserControl.
                targetButton.PerformClick();
            }
            else
            {
                Console.WriteLine($"BaseForm.ShowView: Could not find button with Tag '{viewKey}'.");
                // Optionally show an error or just do nothing
            }
        }
    }
}
