namespace WeatherSphereV4
{
    partial class MapsForm
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapsForm));
            panelMain = new Panel();
            panelSearch = new WeatherSphereV4.CustomControls.CustomPanel();
            buttonHomeSearch = new FontAwesome.Sharp.IconButton();
            textboxHomeSearch = new TextBox();
            labelLocation = new Label();
            labelCurrentDate = new Label();
            labelDescription = new Label();
            labelFeelsLike = new Label();
            labelTemperature = new Label();
            pictureWeatherIcon = new PictureBox();
            panelMap = new Panel();
            gMapControl = new GMap.NET.WindowsForms.GMapControl();
            panelInfoBar = new Panel();
            labelInfoBarMessage = new Label();
            buttonCloseInfoBar = new FontAwesome.Sharp.IconButton();
            iconInfoBar = new FontAwesome.Sharp.IconButton();
            panelLoadingOverlay = new Panel();
            pictureLoadingSpinner = new PictureBox();
            panelMain.SuspendLayout();
            panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureWeatherIcon).BeginInit();
            panelMap.SuspendLayout();
            panelInfoBar.SuspendLayout();
            panelLoadingOverlay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureLoadingSpinner).BeginInit();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.FromArgb(50, 50, 79);
            panelMain.Controls.Add(panelSearch);
            panelMain.Controls.Add(labelLocation);
            panelMain.Controls.Add(labelCurrentDate);
            panelMain.Controls.Add(labelDescription);
            panelMain.Controls.Add(labelFeelsLike);
            panelMain.Controls.Add(labelTemperature);
            panelMain.Controls.Add(pictureWeatherIcon);
            panelMain.Dock = DockStyle.Left;
            panelMain.Location = new Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(335, 744);
            panelMain.TabIndex = 4;
            // 
            // panelSearch
            // 
            panelSearch.BackColor = Color.MediumSlateBlue;
            panelSearch.BorderColor = Color.PaleVioletRed;
            panelSearch.BorderRadius = 26;
            panelSearch.BorderSize = 0;
            panelSearch.Color1 = Color.White;
            panelSearch.Color2 = Color.White;
            panelSearch.ColorOrientation = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            panelSearch.Controls.Add(buttonHomeSearch);
            panelSearch.Controls.Add(textboxHomeSearch);
            panelSearch.Location = new Point(31, 90);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(273, 53);
            panelSearch.TabIndex = 48;
            // 
            // buttonHomeSearch
            // 
            buttonHomeSearch.BackColor = Color.White;
            buttonHomeSearch.FlatStyle = FlatStyle.Flat;
            buttonHomeSearch.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            buttonHomeSearch.ForeColor = Color.White;
            buttonHomeSearch.IconChar = FontAwesome.Sharp.IconChar.Search;
            buttonHomeSearch.IconColor = Color.Black;
            buttonHomeSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonHomeSearch.IconSize = 35;
            buttonHomeSearch.Location = new Point(210, 3);
            buttonHomeSearch.Name = "buttonHomeSearch";
            buttonHomeSearch.Size = new Size(63, 47);
            buttonHomeSearch.TabIndex = 5;
            buttonHomeSearch.UseVisualStyleBackColor = false;
            buttonHomeSearch.Click += buttonHomeSearch_Click;
            buttonHomeSearch.MouseEnter += buttonHomeSearch_MouseEnter;
            buttonHomeSearch.MouseLeave += buttonHomeSearch_MouseLeave;
            // 
            // textboxHomeSearch
            // 
            textboxHomeSearch.BorderStyle = BorderStyle.None;
            textboxHomeSearch.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textboxHomeSearch.Location = new Point(18, 13);
            textboxHomeSearch.Name = "textboxHomeSearch";
            textboxHomeSearch.PlaceholderText = "Search Location...";
            textboxHomeSearch.Size = new Size(206, 24);
            textboxHomeSearch.TabIndex = 1;
            // 
            // labelLocation
            // 
            labelLocation.AutoSize = true;
            labelLocation.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelLocation.ForeColor = Color.Gainsboro;
            labelLocation.Location = new Point(17, 627);
            labelLocation.Name = "labelLocation";
            labelLocation.Size = new Size(242, 21);
            labelLocation.TabIndex = 47;
            labelLocation.Text = "Cebu, Central Visayas, Philippines";
            // 
            // labelCurrentDate
            // 
            labelCurrentDate.AutoSize = true;
            labelCurrentDate.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCurrentDate.ForeColor = Color.Gainsboro;
            labelCurrentDate.Location = new Point(18, 584);
            labelCurrentDate.Name = "labelCurrentDate";
            labelCurrentDate.Size = new Size(210, 28);
            labelCurrentDate.TabIndex = 46;
            labelCurrentDate.Text = "Friday, March 21, 2021";
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelDescription.ForeColor = Color.Gainsboro;
            labelDescription.Location = new Point(18, 542);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(291, 28);
            labelDescription.TabIndex = 45;
            labelDescription.Text = "Freezing Drizzle: Dense intensity";
            // 
            // labelFeelsLike
            // 
            labelFeelsLike.AutoSize = true;
            labelFeelsLike.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelFeelsLike.ForeColor = Color.Gainsboro;
            labelFeelsLike.Location = new Point(18, 499);
            labelFeelsLike.Name = "labelFeelsLike";
            labelFeelsLike.Size = new Size(169, 32);
            labelFeelsLike.TabIndex = 44;
            labelFeelsLike.Text = "Feels like 82°C";
            // 
            // labelTemperature
            // 
            labelTemperature.AutoSize = true;
            labelTemperature.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTemperature.ForeColor = Color.Gainsboro;
            labelTemperature.Location = new Point(107, 393);
            labelTemperature.Name = "labelTemperature";
            labelTemperature.Size = new Size(123, 65);
            labelTemperature.TabIndex = 43;
            labelTemperature.Text = "78°F";
            // 
            // pictureWeatherIcon
            // 
            pictureWeatherIcon.Location = new Point(31, 242);
            pictureWeatherIcon.Name = "pictureWeatherIcon";
            pictureWeatherIcon.Size = new Size(273, 185);
            pictureWeatherIcon.SizeMode = PictureBoxSizeMode.Zoom;
            pictureWeatherIcon.TabIndex = 42;
            pictureWeatherIcon.TabStop = false;
            // 
            // panelMap
            // 
            panelMap.Controls.Add(gMapControl);
            panelMap.Dock = DockStyle.Fill;
            panelMap.Location = new Point(335, 35);
            panelMap.Name = "panelMap";
            panelMap.Size = new Size(847, 709);
            panelMap.TabIndex = 5;
            // 
            // gMapControl
            // 
            gMapControl.Bearing = 0F;
            gMapControl.CanDragMap = true;
            gMapControl.Dock = DockStyle.Fill;
            gMapControl.EmptyTileColor = Color.Navy;
            gMapControl.GrayScaleMode = false;
            gMapControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            gMapControl.LevelsKeepInMemory = 5;
            gMapControl.Location = new Point(0, 0);
            gMapControl.MarkersEnabled = true;
            gMapControl.MaxZoom = 20;
            gMapControl.MinZoom = 1;
            gMapControl.MouseWheelZoomEnabled = true;
            gMapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            gMapControl.Name = "gMapControl";
            gMapControl.NegativeMode = false;
            gMapControl.PolygonsEnabled = true;
            gMapControl.RetryLoadTile = 0;
            gMapControl.RoutesEnabled = true;
            gMapControl.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            gMapControl.SelectedAreaFillColor = Color.FromArgb(33, 65, 105, 225);
            gMapControl.ShowTileGridLines = false;
            gMapControl.Size = new Size(847, 709);
            gMapControl.TabIndex = 0;
            gMapControl.Zoom = 0D;
            gMapControl.MouseClick += gMapControl_MouseClick;
            gMapControl.MouseDown += gMapControl_MouseDown;
            gMapControl.MouseUp += gMapControl_MouseUp;
            // 
            // panelInfoBar
            // 
            panelInfoBar.BackColor = Color.CornflowerBlue;
            panelInfoBar.Controls.Add(labelInfoBarMessage);
            panelInfoBar.Controls.Add(buttonCloseInfoBar);
            panelInfoBar.Controls.Add(iconInfoBar);
            panelInfoBar.Dock = DockStyle.Top;
            panelInfoBar.Location = new Point(335, 0);
            panelInfoBar.Name = "panelInfoBar";
            panelInfoBar.Size = new Size(847, 35);
            panelInfoBar.TabIndex = 43;
            panelInfoBar.Visible = false;
            // 
            // labelInfoBarMessage
            // 
            labelInfoBarMessage.Dock = DockStyle.Fill;
            labelInfoBarMessage.Location = new Point(35, 0);
            labelInfoBarMessage.Name = "labelInfoBarMessage";
            labelInfoBarMessage.Padding = new Padding(5, 0, 0, 0);
            labelInfoBarMessage.Size = new Size(777, 35);
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
            buttonCloseInfoBar.Location = new Point(812, 0);
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
            // panelLoadingOverlay
            // 
            panelLoadingOverlay.Controls.Add(pictureLoadingSpinner);
            panelLoadingOverlay.Dock = DockStyle.Fill;
            panelLoadingOverlay.Location = new Point(0, 0);
            panelLoadingOverlay.Name = "panelLoadingOverlay";
            panelLoadingOverlay.Size = new Size(1182, 744);
            panelLoadingOverlay.TabIndex = 49;
            panelLoadingOverlay.Visible = false;
            // 
            // pictureLoadingSpinner
            // 
            pictureLoadingSpinner.Anchor = AnchorStyles.None;
            pictureLoadingSpinner.Image = (Image)resources.GetObject("pictureLoadingSpinner.Image");
            pictureLoadingSpinner.Location = new Point(335, 86);
            pictureLoadingSpinner.Name = "pictureLoadingSpinner";
            pictureLoadingSpinner.Size = new Size(498, 498);
            pictureLoadingSpinner.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureLoadingSpinner.TabIndex = 13;
            pictureLoadingSpinner.TabStop = false;
            // 
            // MapsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(50, 50, 79);
            Controls.Add(panelMap);
            Controls.Add(panelInfoBar);
            Controls.Add(panelMain);
            Controls.Add(panelLoadingOverlay);
            Name = "MapsForm";
            Size = new Size(1182, 744);
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureWeatherIcon).EndInit();
            panelMap.ResumeLayout(false);
            panelInfoBar.ResumeLayout(false);
            panelLoadingOverlay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureLoadingSpinner).EndInit();
            ResumeLayout(false);
        }

        private void buttonHomeSearch_Click(object sender, EventArgs e)
        {
            // Call the async method
            buttonHomeSearch_ClickAsync(sender, e).ConfigureAwait(false);
        }

        #endregion
        private Panel panelMain;
        private CustomControls.CustomPanel panelSearch;
        private FontAwesome.Sharp.IconButton buttonHomeSearch;
        private TextBox textboxHomeSearch;
        private Label labelLocation;
        private Label labelCurrentDate;
        private Label labelDescription;
        private Label labelFeelsLike;
        private Label labelTemperature;
        private PictureBox pictureWeatherIcon;
        private Panel panelMap;
        private GMap.NET.WindowsForms.GMapControl gMapControl;
        private Panel panelInfoBar;
        private Label labelInfoBarMessage;
        private FontAwesome.Sharp.IconButton buttonCloseInfoBar;
        private FontAwesome.Sharp.IconButton iconInfoBar;
        private Panel panelLoadingOverlay;
        private PictureBox pictureLoadingSpinner;
    }
}
