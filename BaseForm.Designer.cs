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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panelTitleBar = new Panel();
            btnMinimize = new FontAwesome.Sharp.IconButton();
            btnMaximize = new FontAwesome.Sharp.IconButton();
            btnClose = new FontAwesome.Sharp.IconButton();
            panelTitle = new Panel();
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
            separator1 = new ReaLTaiizor.Controls.Separator();
            guna2ImageButton1 = new Guna.UI2.WinForms.Guna2ImageButton();
            guna2ImageButton2 = new Guna.UI2.WinForms.Guna2ImageButton();
            guna2ImageButton3 = new Guna.UI2.WinForms.Guna2ImageButton();
            panelTitleBar.SuspendLayout();
            panelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureLogo).BeginInit();
            panelMenu.SuspendLayout();
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
            panelTitle.Controls.Add(guna2ImageButton3);
            panelTitle.Controls.Add(guna2ImageButton2);
            panelTitle.Controls.Add(guna2ImageButton1);
            panelTitle.Controls.Add(pictureLogo);
            panelTitle.Controls.Add(buttonMenu);
            panelTitle.Dock = DockStyle.Top;
            panelTitle.Location = new Point(0, 48);
            panelTitle.Name = "panelTitle";
            panelTitle.Size = new Size(1282, 73);
            panelTitle.TabIndex = 1;
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
            panelContents.BackColor = Color.FromArgb(50, 50, 79);
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
            buttonFavorites.IconChar = FontAwesome.Sharp.IconChar.Star;
            buttonFavorites.IconColor = Color.Gainsboro;
            buttonFavorites.IconFont = FontAwesome.Sharp.IconFont.Auto;
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
            panelMenu.Controls.Add(separator1);
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
            // separator1
            // 
            separator1.Dock = DockStyle.Bottom;
            separator1.LineColor = Color.Gray;
            separator1.Location = new Point(0, 583);
            separator1.Name = "separator1";
            separator1.Size = new Size(100, 15);
            separator1.TabIndex = 8;
            separator1.Text = "separator1";
            // 
            // guna2ImageButton1
            // 
            guna2ImageButton1.CheckedState.ImageSize = new Size(64, 64);
            guna2ImageButton1.Dock = DockStyle.Right;
            guna2ImageButton1.HoverState.ImageSize = new Size(64, 64);
            guna2ImageButton1.Image = (Image)resources.GetObject("guna2ImageButton1.Image");
            guna2ImageButton1.ImageOffset = new Point(0, 0);
            guna2ImageButton1.ImageRotate = 0F;
            guna2ImageButton1.ImageSize = new Size(45, 45);
            guna2ImageButton1.Location = new Point(1186, 0);
            guna2ImageButton1.Name = "guna2ImageButton1";
            guna2ImageButton1.Padding = new Padding(0, 0, 100, 0);
            guna2ImageButton1.PressedState.ImageSize = new Size(64, 64);
            guna2ImageButton1.ShadowDecoration.CustomizableEdges = customizableEdges3;
            guna2ImageButton1.Size = new Size(96, 73);
            guna2ImageButton1.TabIndex = 2;
            // 
            // guna2ImageButton2
            // 
            guna2ImageButton2.CheckedState.ImageSize = new Size(64, 64);
            guna2ImageButton2.Dock = DockStyle.Right;
            guna2ImageButton2.HoverState.ImageSize = new Size(64, 64);
            guna2ImageButton2.Image = (Image)resources.GetObject("guna2ImageButton2.Image");
            guna2ImageButton2.ImageOffset = new Point(0, 0);
            guna2ImageButton2.ImageRotate = 0F;
            guna2ImageButton2.ImageSize = new Size(45, 45);
            guna2ImageButton2.Location = new Point(1090, 0);
            guna2ImageButton2.Name = "guna2ImageButton2";
            guna2ImageButton2.Padding = new Padding(0, 0, 100, 0);
            guna2ImageButton2.PressedState.ImageSize = new Size(64, 64);
            guna2ImageButton2.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2ImageButton2.Size = new Size(96, 73);
            guna2ImageButton2.TabIndex = 3;
            // 
            // guna2ImageButton3
            // 
            guna2ImageButton3.CheckedState.ImageSize = new Size(64, 64);
            guna2ImageButton3.Dock = DockStyle.Right;
            guna2ImageButton3.HoverState.ImageSize = new Size(64, 64);
            guna2ImageButton3.Image = (Image)resources.GetObject("guna2ImageButton3.Image");
            guna2ImageButton3.ImageOffset = new Point(0, 0);
            guna2ImageButton3.ImageRotate = 0F;
            guna2ImageButton3.ImageSize = new Size(50, 50);
            guna2ImageButton3.Location = new Point(994, 0);
            guna2ImageButton3.Name = "guna2ImageButton3";
            guna2ImageButton3.Padding = new Padding(0, 0, 100, 0);
            guna2ImageButton3.PressedState.ImageSize = new Size(64, 64);
            guna2ImageButton3.ShadowDecoration.CustomizableEdges = customizableEdges1;
            guna2ImageButton3.Size = new Size(96, 73);
            guna2ImageButton3.TabIndex = 4;
            // 
            // BaseForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(50, 50, 79);
            ClientSize = new Size(1282, 865);
            Controls.Add(panelContents);
            Controls.Add(panelMenu);
            Controls.Add(panelTitle);
            Controls.Add(panelTitleBar);
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
        private ReaLTaiizor.Controls.Separator separator1;
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButton3;
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButton2;
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButton1;
    }
}
