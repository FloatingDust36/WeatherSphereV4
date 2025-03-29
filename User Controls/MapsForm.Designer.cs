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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapsForm));
            guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            labelLocation = new Label();
            labelCurrentDateTime = new Label();
            labelDescription = new Label();
            labelFeelsLike = new Label();
            labelTemperature = new Label();
            pictureWeatherIcon = new PictureBox();
            panelSearch = new WeatherSphereV4.CustomControls.CustomPanel();
            buttonSearch = new FontAwesome.Sharp.IconButton();
            textboxSearch = new TextBox();
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            guna2CustomGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureWeatherIcon).BeginInit();
            panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            SuspendLayout();
            // 
            // guna2CustomGradientPanel1
            // 
            guna2CustomGradientPanel1.BackColor = Color.FromArgb(50, 50, 79);
            guna2CustomGradientPanel1.Controls.Add(labelLocation);
            guna2CustomGradientPanel1.Controls.Add(labelCurrentDateTime);
            guna2CustomGradientPanel1.Controls.Add(labelDescription);
            guna2CustomGradientPanel1.Controls.Add(labelFeelsLike);
            guna2CustomGradientPanel1.Controls.Add(labelTemperature);
            guna2CustomGradientPanel1.Controls.Add(pictureWeatherIcon);
            guna2CustomGradientPanel1.Controls.Add(panelSearch);
            guna2CustomGradientPanel1.CustomizableEdges = customizableEdges1;
            guna2CustomGradientPanel1.Dock = DockStyle.Left;
            guna2CustomGradientPanel1.FillColor = Color.FromArgb(50, 50, 79);
            guna2CustomGradientPanel1.FillColor2 = Color.FromArgb(50, 50, 79);
            guna2CustomGradientPanel1.FillColor3 = Color.FromArgb(50, 50, 79);
            guna2CustomGradientPanel1.FillColor4 = Color.FromArgb(50, 50, 79);
            guna2CustomGradientPanel1.Location = new Point(0, 0);
            guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            guna2CustomGradientPanel1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2CustomGradientPanel1.Size = new Size(335, 744);
            guna2CustomGradientPanel1.TabIndex = 2;
            // 
            // labelLocation
            // 
            labelLocation.AutoSize = true;
            labelLocation.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelLocation.ForeColor = Color.Gainsboro;
            labelLocation.Location = new Point(30, 568);
            labelLocation.Name = "labelLocation";
            labelLocation.Size = new Size(274, 25);
            labelLocation.TabIndex = 32;
            labelLocation.Text = "Cebu, Central Visayas, Philippines";
            // 
            // labelCurrentDateTime
            // 
            labelCurrentDateTime.AutoSize = true;
            labelCurrentDateTime.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCurrentDateTime.ForeColor = Color.Gainsboro;
            labelCurrentDateTime.Location = new Point(31, 525);
            labelCurrentDateTime.Name = "labelCurrentDateTime";
            labelCurrentDateTime.Size = new Size(258, 28);
            labelCurrentDateTime.TabIndex = 31;
            labelCurrentDateTime.Text = "Friday, March 21 of 7:28 AM";
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelDescription.ForeColor = Color.Gainsboro;
            labelDescription.Location = new Point(31, 483);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(146, 32);
            labelDescription.TabIndex = 30;
            labelDescription.Text = "Partly Sunny";
            // 
            // labelFeelsLike
            // 
            labelFeelsLike.AutoSize = true;
            labelFeelsLike.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelFeelsLike.ForeColor = Color.Gainsboro;
            labelFeelsLike.Location = new Point(31, 440);
            labelFeelsLike.Name = "labelFeelsLike";
            labelFeelsLike.Size = new Size(169, 32);
            labelFeelsLike.TabIndex = 29;
            labelFeelsLike.Text = "Feels like 82°C";
            // 
            // labelTemperature
            // 
            labelTemperature.AutoSize = true;
            labelTemperature.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTemperature.ForeColor = Color.Gainsboro;
            labelTemperature.Location = new Point(81, 318);
            labelTemperature.Name = "labelTemperature";
            labelTemperature.Size = new Size(136, 65);
            labelTemperature.TabIndex = 28;
            labelTemperature.Text = "78 °F";
            // 
            // pictureWeatherIcon
            // 
            pictureWeatherIcon.Image = (Image)resources.GetObject("pictureWeatherIcon.Image");
            pictureWeatherIcon.Location = new Point(57, 152);
            pictureWeatherIcon.Name = "pictureWeatherIcon";
            pictureWeatherIcon.Size = new Size(198, 147);
            pictureWeatherIcon.SizeMode = PictureBoxSizeMode.Zoom;
            pictureWeatherIcon.TabIndex = 27;
            pictureWeatherIcon.TabStop = false;
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
            panelSearch.Controls.Add(buttonSearch);
            panelSearch.Controls.Add(textboxSearch);
            panelSearch.Location = new Point(31, 20);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(273, 53);
            panelSearch.TabIndex = 26;
            // 
            // buttonSearch
            // 
            buttonSearch.BackColor = Color.White;
            buttonSearch.FlatStyle = FlatStyle.Flat;
            buttonSearch.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            buttonSearch.ForeColor = Color.White;
            buttonSearch.IconChar = FontAwesome.Sharp.IconChar.Search;
            buttonSearch.IconColor = Color.Black;
            buttonSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonSearch.IconSize = 35;
            buttonSearch.Location = new Point(210, 3);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(63, 47);
            buttonSearch.TabIndex = 5;
            buttonSearch.UseVisualStyleBackColor = false;
            buttonSearch.MouseEnter += buttonSearch_MouseEnter;
            buttonSearch.MouseLeave += buttonSearch_MouseLeave;
            // 
            // textboxSearch
            // 
            textboxSearch.BorderStyle = BorderStyle.None;
            textboxSearch.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textboxSearch.Location = new Point(12, 13);
            textboxSearch.Name = "textboxSearch";
            textboxSearch.PlaceholderText = "Search Location...";
            textboxSearch.Size = new Size(212, 24);
            textboxSearch.TabIndex = 1;
            // 
            // webView21
            // 
            webView21.AllowExternalDrop = true;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.White;
            webView21.Dock = DockStyle.Fill;
            webView21.Location = new Point(335, 0);
            webView21.Name = "webView21";
            webView21.Size = new Size(847, 744);
            webView21.TabIndex = 3;
            webView21.ZoomFactor = 1D;
            // 
            // MapsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(webView21);
            Controls.Add(guna2CustomGradientPanel1);
            Name = "MapsForm";
            Size = new Size(1182, 744);
            guna2CustomGradientPanel1.ResumeLayout(false);
            guna2CustomGradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureWeatherIcon).EndInit();
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private CustomControls.CustomPanel panelSearch;
        private TextBox textboxSearch;
        private Label labelLocation;
        private Label labelCurrentDateTime;
        private Label labelDescription;
        private Label labelFeelsLike;
        private Label labelTemperature;
        private PictureBox pictureWeatherIcon;
        private FontAwesome.Sharp.IconButton buttonSearch;
    }
}
