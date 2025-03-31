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
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            panelMain = new Panel();
            panelSearch = new WeatherSphereV4.CustomControls.CustomPanel();
            buttonHomeSearch = new FontAwesome.Sharp.IconButton();
            textboxHomeSearch = new TextBox();
            labelLocation = new Label();
            labelCurrentDateTime = new Label();
            labelDescription = new Label();
            labelFeelsLike = new Label();
            labelTemperature = new Label();
            pictureWeatherIcon = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            panelMain.SuspendLayout();
            panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureWeatherIcon).BeginInit();
            SuspendLayout();
            // 
            // webView21
            // 
            webView21.AllowExternalDrop = true;
            webView21.BackColor = Color.White;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.White;
            webView21.Dock = DockStyle.Fill;
            webView21.Location = new Point(335, 0);
            webView21.Name = "webView21";
            webView21.Size = new Size(847, 744);
            webView21.TabIndex = 3;
            webView21.ZoomFactor = 1D;
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.FromArgb(50, 50, 79);
            panelMain.Controls.Add(panelSearch);
            panelMain.Controls.Add(labelLocation);
            panelMain.Controls.Add(labelCurrentDateTime);
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
            panelSearch.TabIndex = 34;
            panelSearch.MouseEnter += buttonHomeSearch_MouseEnter;
            panelSearch.MouseLeave += buttonHomeSearch_MouseLeave;
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
            // 
            // textboxHomeSearch
            // 
            textboxHomeSearch.BorderStyle = BorderStyle.None;
            textboxHomeSearch.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textboxHomeSearch.Location = new Point(12, 13);
            textboxHomeSearch.Name = "textboxHomeSearch";
            textboxHomeSearch.PlaceholderText = "Search Location...";
            textboxHomeSearch.Size = new Size(212, 24);
            textboxHomeSearch.TabIndex = 1;
            // 
            // labelLocation
            // 
            labelLocation.AutoSize = true;
            labelLocation.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelLocation.ForeColor = Color.Gainsboro;
            labelLocation.Location = new Point(30, 629);
            labelLocation.Name = "labelLocation";
            labelLocation.Size = new Size(274, 25);
            labelLocation.TabIndex = 33;
            labelLocation.Text = "Cebu, Central Visayas, Philippines";
            // 
            // labelCurrentDateTime
            // 
            labelCurrentDateTime.AutoSize = true;
            labelCurrentDateTime.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCurrentDateTime.ForeColor = Color.Gainsboro;
            labelCurrentDateTime.Location = new Point(31, 586);
            labelCurrentDateTime.Name = "labelCurrentDateTime";
            labelCurrentDateTime.Size = new Size(258, 28);
            labelCurrentDateTime.TabIndex = 32;
            labelCurrentDateTime.Text = "Friday, March 21 of 7:28 AM";
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelDescription.ForeColor = Color.Gainsboro;
            labelDescription.Location = new Point(31, 544);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(146, 32);
            labelDescription.TabIndex = 31;
            labelDescription.Text = "Partly Sunny";
            // 
            // labelFeelsLike
            // 
            labelFeelsLike.AutoSize = true;
            labelFeelsLike.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelFeelsLike.ForeColor = Color.Gainsboro;
            labelFeelsLike.Location = new Point(31, 501);
            labelFeelsLike.Name = "labelFeelsLike";
            labelFeelsLike.Size = new Size(169, 32);
            labelFeelsLike.TabIndex = 30;
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
            labelTemperature.TabIndex = 29;
            labelTemperature.Text = "78°F";
            // 
            // pictureWeatherIcon
            // 
            pictureWeatherIcon.Image = (Image)resources.GetObject("pictureWeatherIcon.Image");
            pictureWeatherIcon.Location = new Point(31, 242);
            pictureWeatherIcon.Name = "pictureWeatherIcon";
            pictureWeatherIcon.Size = new Size(273, 185);
            pictureWeatherIcon.SizeMode = PictureBoxSizeMode.Zoom;
            pictureWeatherIcon.TabIndex = 28;
            pictureWeatherIcon.TabStop = false;
            // 
            // MapsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(50, 50, 79);
            Controls.Add(webView21);
            Controls.Add(panelMain);
            Name = "MapsForm";
            Size = new Size(1182, 744);
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureWeatherIcon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        public Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private Panel panelMain;
        private CustomControls.CustomPanel panelSearch;
        private FontAwesome.Sharp.IconButton buttonHomeSearch;
        private TextBox textboxHomeSearch;
        private Label labelLocation;
        private Label labelCurrentDateTime;
        private Label labelDescription;
        private Label labelFeelsLike;
        private Label labelTemperature;
        private PictureBox pictureWeatherIcon;
    }
}
