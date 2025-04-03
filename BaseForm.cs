using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using FontAwesome.Sharp;
using WeatherSphereV4.CustomControls;

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
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            buttonHome.PerformClick();
        }

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
        }

        private void buttonMaps_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            LoadUserControl("Settings", new MapsForm());
        }

        private void buttonHourlyForecast_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            LoadUserControl("HourlyForecast", new HourlyForecastForm());
        }

        private void buttonMonthlyForecast_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            LoadUserControl("MonthlyForecast", new MonthlyForecastForm());
        }

        private void buttonLife_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
            LoadUserControl("Life", new LifeForm());
        }

        private void buttonFavorites_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);
            LoadUserControl("Favorites", new FavoritesForm());
        }

        private void buttonAccount_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            LoadUserControl("Account", new AccountForm());
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            LoadUserControl("Settings", new SettingsForm());
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
        }

        private void buttonNightDayToggle_MouseHover(object sender, EventArgs e)
        {
            buttonNightDayToggle.IconSize = 70;
        }

        private void buttonNightDayToggle_MouseLeave(object sender, EventArgs e)
        {
            buttonNightDayToggle.IconSize = 55;
        }

        private void buttonAddRemoveFavorites_MouseHover(object sender, EventArgs e)
        {
            buttonAddRemoveFavorites.IconSize = 70;
        }

        private void buttonAddRemoveFavorites_MouseLeave(object sender, EventArgs e)
        {
            buttonAddRemoveFavorites.IconSize = 55;
        }

        private void buttonRefresh_MouseHover(object sender, EventArgs e)
        {
            buttonRefresh.IconSize = 70;
        }

        private void buttonRefresh_MouseLeave(object sender, EventArgs e)
        {
            buttonRefresh.IconSize = 55;
        }
    }
}
