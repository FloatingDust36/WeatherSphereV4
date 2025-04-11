namespace WeatherSphereV4
{
    partial class BaseForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));
            panelTitleBar = new Panel();
            btnMinimize = new FontAwesome.Sharp.IconButton();
            btnMaximize = new FontAwesome.Sharp.IconButton();
            btnClose = new FontAwesome.Sharp.IconButton();
            panelTitle = new Panel();
            buttonRefresh = new FontAwesome.Sharp.IconButton();
            buttonAddRemoveFavorites = new FontAwesome.Sharp.IconButton();
            buttonNightDayToggle = new FontAwesome.Sharp.IconButton();
            pictureLogo = new PictureBox();
            buttonMenu = new FontAwesome.Sharp.IconButton();
            panelContents = new Panel();
            buttonHome = new FontAwesome.Sharp.IconButton();
            buttonMaps = new FontAwesome.Sharp.IconButton();
            buttonHourlyForecast = new FontAwesome.Sharp.IconButton();
            buttonMonthlyForecast = new FontAwesome.Sharp.IconButton();
            buttonLife = new FontAwesome.Sharp.IconButton();
            buttonFavorites = new FontAwesome.Sharp.IconButton();
            buttonSettings = new FontAwesome.Sharp.IconButton();
            buttonAccount = new FontAwesome.Sharp.IconButton();
            panelMenu = new Panel();
            menuSeparator = new ReaLTaiizor.Controls.Separator();
            panelLoadingOverlay = new Panel();
            pictureLoadingSpinner = new PictureBox();
            panelInfoBar = new Panel();
            labelInfoBarMessage = new Label();
            buttonCloseInfoBar = new FontAwesome.Sharp.IconButton();
            iconInfoBar = new FontAwesome.Sharp.IconButton();
            toolTip = new ToolTip(components);
            panelTitleBar.SuspendLayout();
            panelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureLogo).BeginInit();
            panelMenu.SuspendLayout();
            panelLoadingOverlay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureLoadingSpinner).BeginInit();
            panelInfoBar.SuspendLayout();
            SuspendLayout();
            // 
            // panelTitleBar
            // 
            panelTitleBar.BackColor = Color.FromArgb(113, 26, 188);
            panelTitleBar.Controls.Add(btnMinimize);
            panelTitleBar.Controls.Add(btnMaximize);
            panelTitleBar.Controls.Add(btnClose);
            panelTitleBar.Dock = DockStyle.Top;
            panelTitleBar.Location = new Point(0, 0);
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.Size = new Size(1282, 48);
            panelTitleBar.TabIndex = 0;
            panelTitleBar.MouseDown += panelTitleBar_MouseDown_1;
            // 
            // btnMinimize
            // 
            btnMinimize.BackColor = Color.FromArgb(113, 26, 188);
            btnMinimize.Dock = DockStyle.Right;
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            btnMinimize.IconColor = Color.Gainsboro;
            btnMinimize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMinimize.IconSize = 30;
            btnMinimize.Location = new Point(1102, 0);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(60, 48);
            btnMinimize.TabIndex = 6;
            btnMinimize.UseVisualStyleBackColor = false;
            btnMinimize.Click += btnMinimize_Click;
            // 
            // btnMaximize
            // 
            btnMaximize.BackColor = Color.FromArgb(113, 26, 188);
            btnMaximize.Dock = DockStyle.Right;
            btnMaximize.FlatAppearance.BorderSize = 0;
            btnMaximize.FlatStyle = FlatStyle.Flat;
            btnMaximize.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            btnMaximize.IconColor = Color.Gainsboro;
            btnMaximize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMaximize.IconSize = 30;
            btnMaximize.Location = new Point(1162, 0);
            btnMaximize.Name = "btnMaximize";
            btnMaximize.Size = new Size(60, 48);
            btnMaximize.TabIndex = 5;
            btnMaximize.UseVisualStyleBackColor = false;
            btnMaximize.Click += btnMaximize_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(184, 104, 150);
            btnClose.Dock = DockStyle.Right;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.IconChar = FontAwesome.Sharp.IconChar.XmarkCircle;
            btnClose.IconColor = Color.Gainsboro;
            btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnClose.IconSize = 35;
            btnClose.Location = new Point(1222, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(60, 48);
            btnClose.TabIndex = 4;
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // panelTitle
            // 
            panelTitle.BackColor = Color.FromArgb(49, 56, 100);
            panelTitle.Controls.Add(buttonRefresh);
            panelTitle.Controls.Add(buttonAddRemoveFavorites);
            panelTitle.Controls.Add(buttonNightDayToggle);
            panelTitle.Controls.Add(pictureLogo);
            panelTitle.Controls.Add(buttonMenu);
            panelTitle.Dock = DockStyle.Top;
            panelTitle.Location = new Point(0, 48);
            panelTitle.Name = "panelTitle";
            panelTitle.Size = new Size(1282, 73);
            panelTitle.TabIndex = 1;
            // 
            // buttonRefresh
            // 
            buttonRefresh.BackColor = Color.FromArgb(49, 56, 100);
            buttonRefresh.Dock = DockStyle.Right;
            buttonRefresh.FlatStyle = FlatStyle.Flat;
            buttonRefresh.ForeColor = Color.FromArgb(49, 56, 100);
            buttonRefresh.IconChar = FontAwesome.Sharp.IconChar.Refresh;
            buttonRefresh.IconColor = Color.Gainsboro;
            buttonRefresh.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonRefresh.IconSize = 55;
            buttonRefresh.Location = new Point(982, 0);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(100, 73);
            buttonRefresh.TabIndex = 4;
            buttonRefresh.UseVisualStyleBackColor = false;
            buttonRefresh.Click += buttonRefresh_Click;
            buttonRefresh.MouseLeave += buttonRefresh_MouseLeave;
            buttonRefresh.MouseHover += buttonRefresh_MouseHover;
            // 
            // buttonAddRemoveFavorites
            // 
            buttonAddRemoveFavorites.BackColor = Color.FromArgb(49, 56, 100);
            buttonAddRemoveFavorites.Dock = DockStyle.Right;
            buttonAddRemoveFavorites.FlatStyle = FlatStyle.Flat;
            buttonAddRemoveFavorites.ForeColor = Color.FromArgb(49, 56, 100);
            buttonAddRemoveFavorites.IconChar = FontAwesome.Sharp.IconChar.Star;
            buttonAddRemoveFavorites.IconColor = Color.Gainsboro;
            buttonAddRemoveFavorites.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonAddRemoveFavorites.IconSize = 55;
            buttonAddRemoveFavorites.Location = new Point(1082, 0);
            buttonAddRemoveFavorites.Name = "buttonAddRemoveFavorites";
            buttonAddRemoveFavorites.Size = new Size(100, 73);
            buttonAddRemoveFavorites.TabIndex = 3;
            buttonAddRemoveFavorites.UseVisualStyleBackColor = false;
            buttonAddRemoveFavorites.Click += buttonAddRemoveFavorites_Click;
            buttonAddRemoveFavorites.MouseLeave += buttonAddRemoveFavorites_MouseLeave;
            buttonAddRemoveFavorites.MouseHover += buttonAddRemoveFavorites_MouseHover;
            // 
            // buttonNightDayToggle
            // 
            buttonNightDayToggle.BackColor = Color.FromArgb(49, 56, 100);
            buttonNightDayToggle.Dock = DockStyle.Right;
            buttonNightDayToggle.FlatStyle = FlatStyle.Flat;
            buttonNightDayToggle.ForeColor = Color.FromArgb(49, 56, 100);
            buttonNightDayToggle.IconChar = FontAwesome.Sharp.IconChar.Moon;
            buttonNightDayToggle.IconColor = Color.Gainsboro;
            buttonNightDayToggle.IconFont = FontAwesome.Sharp.IconFont.Solid;
            buttonNightDayToggle.IconSize = 55;
            buttonNightDayToggle.Location = new Point(1182, 0);
            buttonNightDayToggle.Name = "buttonNightDayToggle";
            buttonNightDayToggle.Size = new Size(100, 73);
            buttonNightDayToggle.TabIndex = 2;
            buttonNightDayToggle.UseVisualStyleBackColor = false;
            buttonNightDayToggle.MouseLeave += buttonNightDayToggle_MouseLeave;
            buttonNightDayToggle.MouseHover += buttonNightDayToggle_MouseHover;
            // 
            // pictureLogo
            // 
            pictureLogo.BackColor = Color.Transparent;
            pictureLogo.Dock = DockStyle.Left;
            pictureLogo.Image = (Image)resources.GetObject("pictureLogo.Image");
            pictureLogo.Location = new Point(100, 0);
            pictureLogo.Name = "pictureLogo";
            pictureLogo.Padding = new Padding(35, 0, 0, 0);
            pictureLogo.Size = new Size(248, 73);
            pictureLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureLogo.TabIndex = 1;
            pictureLogo.TabStop = false;
            // 
            // buttonMenu
            // 
            buttonMenu.BackColor = Color.FromArgb(25, 25, 50);
            buttonMenu.Dock = DockStyle.Left;
            buttonMenu.FlatAppearance.BorderSize = 0;
            buttonMenu.FlatStyle = FlatStyle.Flat;
            buttonMenu.IconChar = FontAwesome.Sharp.IconChar.Bars;
            buttonMenu.IconColor = Color.Gainsboro;
            buttonMenu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonMenu.Location = new Point(0, 0);
            buttonMenu.Name = "buttonMenu";
            buttonMenu.Size = new Size(100, 73);
            buttonMenu.TabIndex = 0;
            buttonMenu.UseVisualStyleBackColor = false;
            buttonMenu.Click += buttonMenu_Click;
            // 
            // panelContents
            // 
            panelContents.BackColor = Color.White;
            panelContents.Dock = DockStyle.Fill;
            panelContents.Location = new Point(100, 121);
            panelContents.Name = "panelContents";
            panelContents.Size = new Size(1182, 744);
            panelContents.TabIndex = 3;
            // 
            // buttonHome
            // 
            buttonHome.Dock = DockStyle.Top;
            buttonHome.FlatAppearance.BorderSize = 0;
            buttonHome.FlatStyle = FlatStyle.Flat;
            buttonHome.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonHome.ForeColor = Color.Gainsboro;
            buttonHome.IconChar = FontAwesome.Sharp.IconChar.HomeLg;
            buttonHome.IconColor = Color.Gainsboro;
            buttonHome.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonHome.Location = new Point(0, 0);
            buttonHome.Margin = new Padding(0);
            buttonHome.Name = "buttonHome";
            buttonHome.Size = new Size(100, 73);
            buttonHome.TabIndex = 0;
            buttonHome.Tag = "Home";
            buttonHome.TextAlign = ContentAlignment.MiddleLeft;
            buttonHome.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonHome.UseVisualStyleBackColor = true;
            buttonHome.Click += buttonHome_Click;
            // 
            // buttonMaps
            // 
            buttonMaps.Dock = DockStyle.Top;
            buttonMaps.FlatAppearance.BorderSize = 0;
            buttonMaps.FlatStyle = FlatStyle.Flat;
            buttonMaps.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonMaps.ForeColor = Color.Gainsboro;
            buttonMaps.IconChar = FontAwesome.Sharp.IconChar.MapLocationDot;
            buttonMaps.IconColor = Color.Gainsboro;
            buttonMaps.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonMaps.Location = new Point(0, 73);
            buttonMaps.Name = "buttonMaps";
            buttonMaps.Size = new Size(100, 73);
            buttonMaps.TabIndex = 1;
            buttonMaps.Tag = "Maps";
            buttonMaps.TextAlign = ContentAlignment.MiddleLeft;
            buttonMaps.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonMaps.UseVisualStyleBackColor = true;
            buttonMaps.Click += buttonMaps_Click;
            // 
            // buttonHourlyForecast
            // 
            buttonHourlyForecast.Dock = DockStyle.Top;
            buttonHourlyForecast.FlatAppearance.BorderSize = 0;
            buttonHourlyForecast.FlatStyle = FlatStyle.Flat;
            buttonHourlyForecast.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonHourlyForecast.ForeColor = Color.Gainsboro;
            buttonHourlyForecast.IconChar = FontAwesome.Sharp.IconChar.ClockFour;
            buttonHourlyForecast.IconColor = Color.Gainsboro;
            buttonHourlyForecast.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonHourlyForecast.Location = new Point(0, 146);
            buttonHourlyForecast.Name = "buttonHourlyForecast";
            buttonHourlyForecast.Size = new Size(100, 73);
            buttonHourlyForecast.TabIndex = 2;
            buttonHourlyForecast.Tag = "Hourly Forecast";
            buttonHourlyForecast.TextAlign = ContentAlignment.MiddleLeft;
            buttonHourlyForecast.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonHourlyForecast.UseVisualStyleBackColor = true;
            buttonHourlyForecast.Click += buttonHourlyForecast_Click;
            // 
            // buttonMonthlyForecast
            // 
            buttonMonthlyForecast.Dock = DockStyle.Top;
            buttonMonthlyForecast.FlatAppearance.BorderSize = 0;
            buttonMonthlyForecast.FlatStyle = FlatStyle.Flat;
            buttonMonthlyForecast.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonMonthlyForecast.ForeColor = Color.Gainsboro;
            buttonMonthlyForecast.IconChar = FontAwesome.Sharp.IconChar.CalendarDays;
            buttonMonthlyForecast.IconColor = Color.Gainsboro;
            buttonMonthlyForecast.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonMonthlyForecast.Location = new Point(0, 219);
            buttonMonthlyForecast.Name = "buttonMonthlyForecast";
            buttonMonthlyForecast.Size = new Size(100, 73);
            buttonMonthlyForecast.TabIndex = 3;
            buttonMonthlyForecast.Tag = "Monthly Forecast";
            buttonMonthlyForecast.TextAlign = ContentAlignment.MiddleLeft;
            buttonMonthlyForecast.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonMonthlyForecast.UseVisualStyleBackColor = true;
            buttonMonthlyForecast.Click += buttonMonthlyForecast_Click;
            // 
            // buttonLife
            // 
            buttonLife.Dock = DockStyle.Top;
            buttonLife.FlatAppearance.BorderSize = 0;
            buttonLife.FlatStyle = FlatStyle.Flat;
            buttonLife.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonLife.ForeColor = Color.Gainsboro;
            buttonLife.IconChar = FontAwesome.Sharp.IconChar.Pagelines;
            buttonLife.IconColor = Color.Gainsboro;
            buttonLife.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonLife.Location = new Point(0, 292);
            buttonLife.Name = "buttonLife";
            buttonLife.Size = new Size(100, 73);
            buttonLife.TabIndex = 4;
            buttonLife.Tag = "Life";
            buttonLife.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonLife.UseVisualStyleBackColor = true;
            buttonLife.Click += buttonLife_Click;
            // 
            // buttonFavorites
            // 
            buttonFavorites.Dock = DockStyle.Top;
            buttonFavorites.FlatAppearance.BorderSize = 0;
            buttonFavorites.FlatStyle = FlatStyle.Flat;
            buttonFavorites.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonFavorites.ForeColor = Color.Gainsboro;
            buttonFavorites.IconChar = FontAwesome.Sharp.IconChar.BookBookmark;
            buttonFavorites.IconColor = Color.Gainsboro;
            buttonFavorites.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonFavorites.IconSize = 43;
            buttonFavorites.Location = new Point(0, 365);
            buttonFavorites.Name = "buttonFavorites";
            buttonFavorites.Size = new Size(100, 73);
            buttonFavorites.TabIndex = 5;
            buttonFavorites.Tag = "Favorites";
            buttonFavorites.TextAlign = ContentAlignment.MiddleLeft;
            buttonFavorites.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonFavorites.UseVisualStyleBackColor = true;
            buttonFavorites.Click += buttonFavorites_Click;
            // 
            // buttonSettings
            // 
            buttonSettings.Dock = DockStyle.Bottom;
            buttonSettings.FlatAppearance.BorderSize = 0;
            buttonSettings.FlatStyle = FlatStyle.Flat;
            buttonSettings.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonSettings.ForeColor = Color.Gainsboro;
            buttonSettings.IconChar = FontAwesome.Sharp.IconChar.Cog;
            buttonSettings.IconColor = Color.Gainsboro;
            buttonSettings.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonSettings.Location = new Point(0, 671);
            buttonSettings.Name = "buttonSettings";
            buttonSettings.Size = new Size(100, 73);
            buttonSettings.TabIndex = 6;
            buttonSettings.Tag = "Settings";
            buttonSettings.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonSettings.UseVisualStyleBackColor = true;
            buttonSettings.Click += buttonSettings_Click;
            // 
            // buttonAccount
            // 
            buttonAccount.Dock = DockStyle.Bottom;
            buttonAccount.FlatAppearance.BorderSize = 0;
            buttonAccount.FlatStyle = FlatStyle.Flat;
            buttonAccount.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonAccount.ForeColor = Color.Gainsboro;
            buttonAccount.IconChar = FontAwesome.Sharp.IconChar.User;
            buttonAccount.IconColor = Color.Gainsboro;
            buttonAccount.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonAccount.Location = new Point(0, 598);
            buttonAccount.Name = "buttonAccount";
            buttonAccount.Size = new Size(100, 73);
            buttonAccount.TabIndex = 7;
            buttonAccount.Tag = "Account";
            buttonAccount.TextAlign = ContentAlignment.MiddleLeft;
            buttonAccount.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonAccount.UseVisualStyleBackColor = true;
            buttonAccount.Click += buttonAccount_Click;
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(25, 25, 50);
            panelMenu.Controls.Add(menuSeparator);
            panelMenu.Controls.Add(buttonAccount);
            panelMenu.Controls.Add(buttonSettings);
            panelMenu.Controls.Add(buttonFavorites);
            panelMenu.Controls.Add(buttonLife);
            panelMenu.Controls.Add(buttonMonthlyForecast);
            panelMenu.Controls.Add(buttonHourlyForecast);
            panelMenu.Controls.Add(buttonMaps);
            panelMenu.Controls.Add(buttonHome);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 121);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(100, 744);
            panelMenu.TabIndex = 2;
            // 
            // menuSeparator
            // 
            menuSeparator.Dock = DockStyle.Bottom;
            menuSeparator.LineColor = Color.Gray;
            menuSeparator.Location = new Point(0, 583);
            menuSeparator.Name = "menuSeparator";
            menuSeparator.Size = new Size(100, 15);
            menuSeparator.TabIndex = 8;
            menuSeparator.Text = "separator1";
            // 
            // panelLoadingOverlay
            // 
            panelLoadingOverlay.Controls.Add(pictureLoadingSpinner);
            panelLoadingOverlay.Dock = DockStyle.Fill;
            panelLoadingOverlay.Location = new Point(0, 0);
            panelLoadingOverlay.Name = "panelLoadingOverlay";
            panelLoadingOverlay.Size = new Size(1282, 865);
            panelLoadingOverlay.TabIndex = 13;
            panelLoadingOverlay.Visible = false;
            // 
            // pictureLoadingSpinner
            // 
            pictureLoadingSpinner.Anchor = AnchorStyles.None;
            pictureLoadingSpinner.Image = (Image)resources.GetObject("pictureLoadingSpinner.Image");
            pictureLoadingSpinner.Location = new Point(866, 400);
            pictureLoadingSpinner.Name = "pictureLoadingSpinner";
            pictureLoadingSpinner.Size = new Size(498, 498);
            pictureLoadingSpinner.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureLoadingSpinner.TabIndex = 13;
            pictureLoadingSpinner.TabStop = false;
            // 
            // panelInfoBar
            // 
            panelInfoBar.BackColor = Color.CornflowerBlue;
            panelInfoBar.Controls.Add(labelInfoBarMessage);
            panelInfoBar.Controls.Add(buttonCloseInfoBar);
            panelInfoBar.Controls.Add(iconInfoBar);
            panelInfoBar.Dock = DockStyle.Top;
            panelInfoBar.Location = new Point(100, 121);
            panelInfoBar.Name = "panelInfoBar";
            panelInfoBar.Size = new Size(1182, 35);
            panelInfoBar.TabIndex = 43;
            panelInfoBar.Visible = false;
            // 
            // labelInfoBarMessage
            // 
            labelInfoBarMessage.Dock = DockStyle.Fill;
            labelInfoBarMessage.Location = new Point(35, 0);
            labelInfoBarMessage.Name = "labelInfoBarMessage";
            labelInfoBarMessage.Padding = new Padding(5, 0, 0, 0);
            labelInfoBarMessage.Size = new Size(1112, 35);
            labelInfoBarMessage.TabIndex = 2;
            labelInfoBarMessage.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // buttonCloseInfoBar
            // 
            buttonCloseInfoBar.Dock = DockStyle.Right;
            buttonCloseInfoBar.Enabled = false;
            buttonCloseInfoBar.FlatAppearance.BorderSize = 0;
            buttonCloseInfoBar.FlatStyle = FlatStyle.Flat;
            buttonCloseInfoBar.IconChar = FontAwesome.Sharp.IconChar.XmarkCircle;
            buttonCloseInfoBar.IconColor = Color.White;
            buttonCloseInfoBar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonCloseInfoBar.IconSize = 27;
            buttonCloseInfoBar.Location = new Point(1147, 0);
            buttonCloseInfoBar.Name = "buttonCloseInfoBar";
            buttonCloseInfoBar.Size = new Size(35, 35);
            buttonCloseInfoBar.TabIndex = 1;
            buttonCloseInfoBar.UseVisualStyleBackColor = true;
            buttonCloseInfoBar.Click += buttonCloseInfoBar_Click;
            // 
            // iconInfoBar
            // 
            iconInfoBar.Dock = DockStyle.Left;
            iconInfoBar.Enabled = false;
            iconInfoBar.FlatAppearance.BorderSize = 0;
            iconInfoBar.FlatStyle = FlatStyle.Flat;
            iconInfoBar.IconChar = FontAwesome.Sharp.IconChar.Info;
            iconInfoBar.IconColor = Color.White;
            iconInfoBar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconInfoBar.IconSize = 27;
            iconInfoBar.Location = new Point(0, 0);
            iconInfoBar.Name = "iconInfoBar";
            iconInfoBar.Size = new Size(35, 35);
            iconInfoBar.TabIndex = 0;
            iconInfoBar.UseVisualStyleBackColor = true;
            // 
            // BaseForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(50, 50, 79);
            ClientSize = new Size(1282, 865);
            Controls.Add(panelInfoBar);
            Controls.Add(panelContents);
            Controls.Add(panelMenu);
            Controls.Add(panelTitle);
            Controls.Add(panelTitleBar);
            Controls.Add(panelLoadingOverlay);
            MinimumSize = new Size(500, 768);
            Name = "BaseForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            TransparencyKey = Color.Fuchsia;
            Resize += Form1_Resize;
            panelTitleBar.ResumeLayout(false);
            panelTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureLogo).EndInit();
            panelMenu.ResumeLayout(false);
            panelLoadingOverlay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureLoadingSpinner).EndInit();
            panelInfoBar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelContents;
        private Panel panelTitleBar;
        private Panel panelTitle;
        private FontAwesome.Sharp.IconButton buttonMenu;
        private PictureBox pictureLogo;
        private FontAwesome.Sharp.IconButton btnMaximize;
        private FontAwesome.Sharp.IconButton btnClose;
        private FontAwesome.Sharp.IconButton btnMinimize;
        private FontAwesome.Sharp.IconButton buttonHome;
        private FontAwesome.Sharp.IconButton buttonMaps;
        private FontAwesome.Sharp.IconButton buttonHourlyForecast;
        private FontAwesome.Sharp.IconButton buttonMonthlyForecast;
        private FontAwesome.Sharp.IconButton buttonLife;
        private FontAwesome.Sharp.IconButton buttonFavorites;
        private FontAwesome.Sharp.IconButton buttonSettings;
        private FontAwesome.Sharp.IconButton buttonAccount;
        private Panel panelMenu;
        private ReaLTaiizor.Controls.Separator menuSeparator;
        private FontAwesome.Sharp.IconButton buttonNightDayToggle;
        private FontAwesome.Sharp.IconButton buttonAddRemoveFavorites;
        private FontAwesome.Sharp.IconButton buttonRefresh;
        private Panel panelLoadingOverlay;
        private PictureBox pictureLoadingSpinner;
        private Panel panelInfoBar;
        private Label labelInfoBarMessage;
        private FontAwesome.Sharp.IconButton buttonCloseInfoBar;
        private FontAwesome.Sharp.IconButton iconInfoBar;
        private ToolTip toolTip;
    }
}
