namespace WeatherSphereV4
{
    partial class HomeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeForm));
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
            buttonSearch = new FontAwesome.Sharp.IconButton();
            textboxSearch = new TextBox();
            panelGeneralInfo = new Panel();
            panelForecast = new Panel();
            panelForecastTable = new TableLayoutPanel();
            panel7 = new WeatherSphereV4.CustomControls.CustomPanel();
            panel7Day = new Label();
            label7Date = new Label();
            label7Description = new Label();
            picture7 = new PictureBox();
            panel6 = new WeatherSphereV4.CustomControls.CustomPanel();
            label6Date = new Label();
            label6Day = new Label();
            label6Description = new Label();
            picture6 = new PictureBox();
            panel5 = new WeatherSphereV4.CustomControls.CustomPanel();
            label5Date = new Label();
            label5Day = new Label();
            label5Description = new Label();
            picture5 = new PictureBox();
            panel4 = new WeatherSphereV4.CustomControls.CustomPanel();
            label4Date = new Label();
            label4Day = new Label();
            label4Description = new Label();
            picture4 = new PictureBox();
            panel3 = new WeatherSphereV4.CustomControls.CustomPanel();
            label3Date = new Label();
            label3Day = new Label();
            label3Description = new Label();
            picture3 = new PictureBox();
            panel2 = new WeatherSphereV4.CustomControls.CustomPanel();
            label2Date = new Label();
            label2Day = new Label();
            label2Description = new Label();
            picture2 = new PictureBox();
            panel1 = new WeatherSphereV4.CustomControls.CustomPanel();
            label1Date = new Label();
            label1Day = new Label();
            label1Description = new Label();
            picture1 = new PictureBox();
            labelForecast = new Label();
            panelDetails = new Panel();
            panelDetailsTable = new TableLayoutPanel();
            panelClouds = new WeatherSphereV4.CustomControls.CustomPanel();
            labelClouds = new Label();
            labelCloudsTitle = new Label();
            pictureClouds = new PictureBox();
            panelUVIndex = new WeatherSphereV4.CustomControls.CustomPanel();
            labelUVIndex = new Label();
            labelUVIndexTitle = new Label();
            pictureUVIndex = new PictureBox();
            panelPressure = new WeatherSphereV4.CustomControls.CustomPanel();
            labelPressure = new Label();
            labelPressureTitle = new Label();
            picturePressure = new PictureBox();
            panelSunriseSunset = new WeatherSphereV4.CustomControls.CustomPanel();
            pictureSunset = new PictureBox();
            labelSunset = new Label();
            laeblSunsetTitle = new Label();
            pictureSunrise = new PictureBox();
            labelSunrise = new Label();
            labelSunriseTitle = new Label();
            panelWindSpeed = new WeatherSphereV4.CustomControls.CustomPanel();
            labelWindSpeed = new Label();
            labelWindSpeedTitle = new Label();
            pictureWindSpeed = new PictureBox();
            panelHumidity = new WeatherSphereV4.CustomControls.CustomPanel();
            labelHumidity = new Label();
            labelHumidityTitle = new Label();
            pictureHumidity = new PictureBox();
            labelDetails = new Label();
            panelMain.SuspendLayout();
            panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureWeatherIcon).BeginInit();
            panelGeneralInfo.SuspendLayout();
            panelForecast.SuspendLayout();
            panelForecastTable.SuspendLayout();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picture7).BeginInit();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picture6).BeginInit();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picture5).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picture4).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picture3).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picture2).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picture1).BeginInit();
            panelDetails.SuspendLayout();
            panelDetailsTable.SuspendLayout();
            panelClouds.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureClouds).BeginInit();
            panelUVIndex.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureUVIndex).BeginInit();
            panelPressure.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picturePressure).BeginInit();
            panelSunriseSunset.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureSunset).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureSunrise).BeginInit();
            panelWindSpeed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureWindSpeed).BeginInit();
            panelHumidity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureHumidity).BeginInit();
            SuspendLayout();
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
            panelMain.TabIndex = 0;
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
            panelSearch.Location = new Point(31, 22);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(273, 53);
            panelSearch.TabIndex = 27;
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
            buttonHomeSearch.MouseEnter += buttonHomeSearch_MouseEnter;
            buttonHomeSearch.MouseLeave += buttonHomeSearch_MouseLeave;
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
            labelLocation.Location = new Point(30, 517);
            labelLocation.Name = "labelLocation";
            labelLocation.Size = new Size(274, 25);
            labelLocation.TabIndex = 21;
            labelLocation.Text = "Cebu, Central Visayas, Philippines";
            // 
            // labelCurrentDateTime
            // 
            labelCurrentDateTime.AutoSize = true;
            labelCurrentDateTime.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCurrentDateTime.ForeColor = Color.Gainsboro;
            labelCurrentDateTime.Location = new Point(31, 474);
            labelCurrentDateTime.Name = "labelCurrentDateTime";
            labelCurrentDateTime.Size = new Size(258, 28);
            labelCurrentDateTime.TabIndex = 20;
            labelCurrentDateTime.Text = "Friday, March 21 of 7:28 AM";
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelDescription.ForeColor = Color.Gainsboro;
            labelDescription.Location = new Point(31, 432);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(146, 32);
            labelDescription.TabIndex = 19;
            labelDescription.Text = "Partly Sunny";
            // 
            // labelFeelsLike
            // 
            labelFeelsLike.AutoSize = true;
            labelFeelsLike.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelFeelsLike.ForeColor = Color.Gainsboro;
            labelFeelsLike.Location = new Point(31, 389);
            labelFeelsLike.Name = "labelFeelsLike";
            labelFeelsLike.Size = new Size(169, 32);
            labelFeelsLike.TabIndex = 18;
            labelFeelsLike.Text = "Feels like 82°C";
            // 
            // labelTemperature
            // 
            labelTemperature.AutoSize = true;
            labelTemperature.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTemperature.ForeColor = Color.Gainsboro;
            labelTemperature.Location = new Point(107, 281);
            labelTemperature.Name = "labelTemperature";
            labelTemperature.Size = new Size(123, 65);
            labelTemperature.TabIndex = 17;
            labelTemperature.Text = "78°F";
            // 
            // pictureWeatherIcon
            // 
            pictureWeatherIcon.Image = (Image)resources.GetObject("pictureWeatherIcon.Image");
            pictureWeatherIcon.Location = new Point(31, 130);
            pictureWeatherIcon.Name = "pictureWeatherIcon";
            pictureWeatherIcon.Size = new Size(273, 185);
            pictureWeatherIcon.SizeMode = PictureBoxSizeMode.Zoom;
            pictureWeatherIcon.TabIndex = 16;
            pictureWeatherIcon.TabStop = false;
            // 
            // buttonSearch
            // 
            buttonSearch.BackColor = Color.Navy;
            buttonSearch.Dock = DockStyle.Right;
            buttonSearch.FlatStyle = FlatStyle.Flat;
            buttonSearch.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            buttonSearch.ForeColor = Color.Navy;
            buttonSearch.IconChar = FontAwesome.Sharp.IconChar.Search;
            buttonSearch.IconColor = Color.Gainsboro;
            buttonSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonSearch.IconSize = 35;
            buttonSearch.Location = new Point(197, 0);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(62, 53);
            buttonSearch.TabIndex = 2;
            buttonSearch.UseVisualStyleBackColor = false;
            // 
            // textboxSearch
            // 
            textboxSearch.BorderStyle = BorderStyle.None;
            textboxSearch.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textboxSearch.Location = new Point(12, 14);
            textboxSearch.Name = "textboxSearch";
            textboxSearch.PlaceholderText = "Search Location...";
            textboxSearch.Size = new Size(194, 24);
            textboxSearch.TabIndex = 1;
            // 
            // panelGeneralInfo
            // 
            panelGeneralInfo.BackColor = Color.FromArgb(50, 50, 79);
            panelGeneralInfo.BackgroundImageLayout = ImageLayout.Stretch;
            panelGeneralInfo.Controls.Add(panelForecast);
            panelGeneralInfo.Controls.Add(panelDetails);
            panelGeneralInfo.Dock = DockStyle.Fill;
            panelGeneralInfo.Location = new Point(335, 0);
            panelGeneralInfo.Name = "panelGeneralInfo";
            panelGeneralInfo.Size = new Size(847, 744);
            panelGeneralInfo.TabIndex = 1;
            // 
            // panelForecast
            // 
            panelForecast.BackColor = Color.Transparent;
            panelForecast.Controls.Add(panelForecastTable);
            panelForecast.Controls.Add(labelForecast);
            panelForecast.Dock = DockStyle.Fill;
            panelForecast.Location = new Point(0, 375);
            panelForecast.Name = "panelForecast";
            panelForecast.Size = new Size(847, 369);
            panelForecast.TabIndex = 3;
            // 
            // panelForecastTable
            // 
            panelForecastTable.ColumnCount = 7;
            panelForecastTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            panelForecastTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            panelForecastTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            panelForecastTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            panelForecastTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            panelForecastTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            panelForecastTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            panelForecastTable.Controls.Add(panel7, 6, 0);
            panelForecastTable.Controls.Add(panel6, 5, 0);
            panelForecastTable.Controls.Add(panel5, 4, 0);
            panelForecastTable.Controls.Add(panel4, 3, 0);
            panelForecastTable.Controls.Add(panel3, 2, 0);
            panelForecastTable.Controls.Add(panel2, 1, 0);
            panelForecastTable.Controls.Add(panel1, 0, 0);
            panelForecastTable.Dock = DockStyle.Fill;
            panelForecastTable.Location = new Point(0, 58);
            panelForecastTable.Name = "panelForecastTable";
            panelForecastTable.RowCount = 1;
            panelForecastTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            panelForecastTable.Size = new Size(847, 311);
            panelForecastTable.TabIndex = 12;
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(18, 151, 244);
            panel7.BorderColor = Color.White;
            panel7.BorderRadius = 10;
            panel7.BorderSize = 2;
            panel7.Color1 = Color.FromArgb(18, 151, 244);
            panel7.Color2 = Color.FromArgb(37, 64, 129);
            panel7.ColorOrientation = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            panel7.Controls.Add(panel7Day);
            panel7.Controls.Add(label7Date);
            panel7.Controls.Add(label7Description);
            panel7.Controls.Add(picture7);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(729, 3);
            panel7.Name = "panel7";
            panel7.Size = new Size(115, 305);
            panel7.TabIndex = 2;
            // 
            // panel7Day
            // 
            panel7Day.Anchor = AnchorStyles.None;
            panel7Day.AutoSize = true;
            panel7Day.BackColor = Color.Transparent;
            panel7Day.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            panel7Day.ForeColor = Color.Gainsboro;
            panel7Day.Location = new Point(11, 69);
            panel7Day.Name = "panel7Day";
            panel7Day.Size = new Size(90, 28);
            panel7Day.TabIndex = 24;
            panel7Day.Text = "March 3";
            // 
            // label7Date
            // 
            label7Date.Anchor = AnchorStyles.None;
            label7Date.AutoSize = true;
            label7Date.BackColor = Color.Transparent;
            label7Date.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7Date.ForeColor = Color.Gainsboro;
            label7Date.Location = new Point(18, 40);
            label7Date.Name = "label7Date";
            label7Date.Size = new Size(70, 28);
            label7Date.TabIndex = 23;
            label7Date.Text = "Friday";
            // 
            // label7Description
            // 
            label7Description.Anchor = AnchorStyles.None;
            label7Description.AutoSize = true;
            label7Description.BackColor = Color.Transparent;
            label7Description.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7Description.ForeColor = Color.Gainsboro;
            label7Description.Location = new Point(5, 239);
            label7Description.Name = "label7Description";
            label7Description.Size = new Size(98, 25);
            label7Description.TabIndex = 22;
            label7Description.Text = "Light Rain";
            // 
            // picture7
            // 
            picture7.Anchor = AnchorStyles.None;
            picture7.BackColor = Color.Transparent;
            picture7.Image = (Image)resources.GetObject("picture7.Image");
            picture7.Location = new Point(1, 122);
            picture7.Name = "picture7";
            picture7.Size = new Size(112, 93);
            picture7.SizeMode = PictureBoxSizeMode.Zoom;
            picture7.TabIndex = 21;
            picture7.TabStop = false;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(18, 151, 244);
            panel6.BorderColor = Color.White;
            panel6.BorderRadius = 10;
            panel6.BorderSize = 2;
            panel6.Color1 = Color.FromArgb(18, 151, 244);
            panel6.Color2 = Color.FromArgb(37, 64, 129);
            panel6.ColorOrientation = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            panel6.Controls.Add(label6Date);
            panel6.Controls.Add(label6Day);
            panel6.Controls.Add(label6Description);
            panel6.Controls.Add(picture6);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(608, 3);
            panel6.Name = "panel6";
            panel6.Size = new Size(115, 305);
            panel6.TabIndex = 2;
            // 
            // label6Date
            // 
            label6Date.Anchor = AnchorStyles.None;
            label6Date.AutoSize = true;
            label6Date.BackColor = Color.Transparent;
            label6Date.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6Date.ForeColor = Color.Gainsboro;
            label6Date.Location = new Point(11, 69);
            label6Date.Name = "label6Date";
            label6Date.Size = new Size(90, 28);
            label6Date.TabIndex = 24;
            label6Date.Text = "March 3";
            // 
            // label6Day
            // 
            label6Day.Anchor = AnchorStyles.None;
            label6Day.AutoSize = true;
            label6Day.BackColor = Color.Transparent;
            label6Day.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6Day.ForeColor = Color.Gainsboro;
            label6Day.Location = new Point(18, 40);
            label6Day.Name = "label6Day";
            label6Day.Size = new Size(70, 28);
            label6Day.TabIndex = 23;
            label6Day.Text = "Friday";
            // 
            // label6Description
            // 
            label6Description.Anchor = AnchorStyles.None;
            label6Description.AutoSize = true;
            label6Description.BackColor = Color.Transparent;
            label6Description.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6Description.ForeColor = Color.Gainsboro;
            label6Description.Location = new Point(5, 239);
            label6Description.Name = "label6Description";
            label6Description.Size = new Size(98, 25);
            label6Description.TabIndex = 22;
            label6Description.Text = "Light Rain";
            // 
            // picture6
            // 
            picture6.Anchor = AnchorStyles.None;
            picture6.BackColor = Color.Transparent;
            picture6.Image = (Image)resources.GetObject("picture6.Image");
            picture6.Location = new Point(1, 122);
            picture6.Name = "picture6";
            picture6.Size = new Size(112, 93);
            picture6.SizeMode = PictureBoxSizeMode.Zoom;
            picture6.TabIndex = 21;
            picture6.TabStop = false;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(18, 151, 244);
            panel5.BorderColor = Color.White;
            panel5.BorderRadius = 10;
            panel5.BorderSize = 2;
            panel5.Color1 = Color.FromArgb(18, 151, 244);
            panel5.Color2 = Color.FromArgb(37, 64, 129);
            panel5.ColorOrientation = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            panel5.Controls.Add(label5Date);
            panel5.Controls.Add(label5Day);
            panel5.Controls.Add(label5Description);
            panel5.Controls.Add(picture5);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(487, 3);
            panel5.Name = "panel5";
            panel5.Size = new Size(115, 305);
            panel5.TabIndex = 2;
            // 
            // label5Date
            // 
            label5Date.Anchor = AnchorStyles.None;
            label5Date.AutoSize = true;
            label5Date.BackColor = Color.Transparent;
            label5Date.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5Date.ForeColor = Color.Gainsboro;
            label5Date.Location = new Point(11, 69);
            label5Date.Name = "label5Date";
            label5Date.Size = new Size(90, 28);
            label5Date.TabIndex = 24;
            label5Date.Text = "March 3";
            // 
            // label5Day
            // 
            label5Day.Anchor = AnchorStyles.None;
            label5Day.AutoSize = true;
            label5Day.BackColor = Color.Transparent;
            label5Day.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5Day.ForeColor = Color.Gainsboro;
            label5Day.Location = new Point(18, 40);
            label5Day.Name = "label5Day";
            label5Day.Size = new Size(70, 28);
            label5Day.TabIndex = 23;
            label5Day.Text = "Friday";
            // 
            // label5Description
            // 
            label5Description.Anchor = AnchorStyles.None;
            label5Description.AutoSize = true;
            label5Description.BackColor = Color.Transparent;
            label5Description.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5Description.ForeColor = Color.Gainsboro;
            label5Description.Location = new Point(5, 239);
            label5Description.Name = "label5Description";
            label5Description.Size = new Size(98, 25);
            label5Description.TabIndex = 22;
            label5Description.Text = "Light Rain";
            // 
            // picture5
            // 
            picture5.Anchor = AnchorStyles.None;
            picture5.BackColor = Color.Transparent;
            picture5.Image = (Image)resources.GetObject("picture5.Image");
            picture5.Location = new Point(1, 122);
            picture5.Name = "picture5";
            picture5.Size = new Size(112, 93);
            picture5.SizeMode = PictureBoxSizeMode.Zoom;
            picture5.TabIndex = 21;
            picture5.TabStop = false;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(18, 151, 244);
            panel4.BorderColor = Color.White;
            panel4.BorderRadius = 10;
            panel4.BorderSize = 2;
            panel4.Color1 = Color.FromArgb(18, 151, 244);
            panel4.Color2 = Color.FromArgb(37, 64, 129);
            panel4.ColorOrientation = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            panel4.Controls.Add(label4Date);
            panel4.Controls.Add(label4Day);
            panel4.Controls.Add(label4Description);
            panel4.Controls.Add(picture4);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(366, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(115, 305);
            panel4.TabIndex = 2;
            // 
            // label4Date
            // 
            label4Date.Anchor = AnchorStyles.None;
            label4Date.AutoSize = true;
            label4Date.BackColor = Color.Transparent;
            label4Date.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4Date.ForeColor = Color.Gainsboro;
            label4Date.Location = new Point(11, 69);
            label4Date.Name = "label4Date";
            label4Date.Size = new Size(90, 28);
            label4Date.TabIndex = 24;
            label4Date.Text = "March 3";
            // 
            // label4Day
            // 
            label4Day.Anchor = AnchorStyles.None;
            label4Day.AutoSize = true;
            label4Day.BackColor = Color.Transparent;
            label4Day.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4Day.ForeColor = Color.Gainsboro;
            label4Day.Location = new Point(18, 40);
            label4Day.Name = "label4Day";
            label4Day.Size = new Size(70, 28);
            label4Day.TabIndex = 23;
            label4Day.Text = "Friday";
            // 
            // label4Description
            // 
            label4Description.Anchor = AnchorStyles.None;
            label4Description.AutoSize = true;
            label4Description.BackColor = Color.Transparent;
            label4Description.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4Description.ForeColor = Color.Gainsboro;
            label4Description.Location = new Point(5, 239);
            label4Description.Name = "label4Description";
            label4Description.Size = new Size(98, 25);
            label4Description.TabIndex = 22;
            label4Description.Text = "Light Rain";
            // 
            // picture4
            // 
            picture4.Anchor = AnchorStyles.None;
            picture4.BackColor = Color.Transparent;
            picture4.Image = (Image)resources.GetObject("picture4.Image");
            picture4.Location = new Point(1, 122);
            picture4.Name = "picture4";
            picture4.Size = new Size(112, 93);
            picture4.SizeMode = PictureBoxSizeMode.Zoom;
            picture4.TabIndex = 21;
            picture4.TabStop = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(18, 151, 244);
            panel3.BorderColor = Color.White;
            panel3.BorderRadius = 10;
            panel3.BorderSize = 2;
            panel3.Color1 = Color.FromArgb(18, 151, 244);
            panel3.Color2 = Color.FromArgb(37, 64, 129);
            panel3.ColorOrientation = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            panel3.Controls.Add(label3Date);
            panel3.Controls.Add(label3Day);
            panel3.Controls.Add(label3Description);
            panel3.Controls.Add(picture3);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(245, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(115, 305);
            panel3.TabIndex = 2;
            // 
            // label3Date
            // 
            label3Date.Anchor = AnchorStyles.None;
            label3Date.AutoSize = true;
            label3Date.BackColor = Color.Transparent;
            label3Date.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3Date.ForeColor = Color.Gainsboro;
            label3Date.Location = new Point(11, 69);
            label3Date.Name = "label3Date";
            label3Date.Size = new Size(90, 28);
            label3Date.TabIndex = 24;
            label3Date.Text = "March 3";
            // 
            // label3Day
            // 
            label3Day.Anchor = AnchorStyles.None;
            label3Day.AutoSize = true;
            label3Day.BackColor = Color.Transparent;
            label3Day.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3Day.ForeColor = Color.Gainsboro;
            label3Day.Location = new Point(18, 40);
            label3Day.Name = "label3Day";
            label3Day.Size = new Size(70, 28);
            label3Day.TabIndex = 23;
            label3Day.Text = "Friday";
            // 
            // label3Description
            // 
            label3Description.Anchor = AnchorStyles.None;
            label3Description.AutoSize = true;
            label3Description.BackColor = Color.Transparent;
            label3Description.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3Description.ForeColor = Color.Gainsboro;
            label3Description.Location = new Point(5, 239);
            label3Description.Name = "label3Description";
            label3Description.Size = new Size(98, 25);
            label3Description.TabIndex = 22;
            label3Description.Text = "Light Rain";
            // 
            // picture3
            // 
            picture3.Anchor = AnchorStyles.None;
            picture3.BackColor = Color.Transparent;
            picture3.Image = (Image)resources.GetObject("picture3.Image");
            picture3.Location = new Point(1, 122);
            picture3.Name = "picture3";
            picture3.Size = new Size(112, 93);
            picture3.SizeMode = PictureBoxSizeMode.Zoom;
            picture3.TabIndex = 21;
            picture3.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(18, 151, 244);
            panel2.BorderColor = Color.White;
            panel2.BorderRadius = 10;
            panel2.BorderSize = 2;
            panel2.Color1 = Color.FromArgb(18, 151, 244);
            panel2.Color2 = Color.FromArgb(37, 64, 129);
            panel2.ColorOrientation = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            panel2.Controls.Add(label2Date);
            panel2.Controls.Add(label2Day);
            panel2.Controls.Add(label2Description);
            panel2.Controls.Add(picture2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(124, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(115, 305);
            panel2.TabIndex = 1;
            // 
            // label2Date
            // 
            label2Date.Anchor = AnchorStyles.None;
            label2Date.AutoSize = true;
            label2Date.BackColor = Color.Transparent;
            label2Date.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2Date.ForeColor = Color.Gainsboro;
            label2Date.Location = new Point(11, 69);
            label2Date.Name = "label2Date";
            label2Date.Size = new Size(90, 28);
            label2Date.TabIndex = 24;
            label2Date.Text = "March 3";
            // 
            // label2Day
            // 
            label2Day.Anchor = AnchorStyles.None;
            label2Day.AutoSize = true;
            label2Day.BackColor = Color.Transparent;
            label2Day.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2Day.ForeColor = Color.Gainsboro;
            label2Day.Location = new Point(18, 40);
            label2Day.Name = "label2Day";
            label2Day.Size = new Size(70, 28);
            label2Day.TabIndex = 23;
            label2Day.Text = "Friday";
            // 
            // label2Description
            // 
            label2Description.Anchor = AnchorStyles.None;
            label2Description.AutoSize = true;
            label2Description.BackColor = Color.Transparent;
            label2Description.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2Description.ForeColor = Color.Gainsboro;
            label2Description.Location = new Point(5, 239);
            label2Description.Name = "label2Description";
            label2Description.Size = new Size(98, 25);
            label2Description.TabIndex = 22;
            label2Description.Text = "Light Rain";
            // 
            // picture2
            // 
            picture2.Anchor = AnchorStyles.None;
            picture2.BackColor = Color.Transparent;
            picture2.Image = (Image)resources.GetObject("picture2.Image");
            picture2.Location = new Point(1, 122);
            picture2.Name = "picture2";
            picture2.Size = new Size(112, 93);
            picture2.SizeMode = PictureBoxSizeMode.Zoom;
            picture2.TabIndex = 21;
            picture2.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(18, 151, 244);
            panel1.BorderColor = Color.White;
            panel1.BorderRadius = 10;
            panel1.BorderSize = 2;
            panel1.Color1 = Color.FromArgb(18, 151, 244);
            panel1.Color2 = Color.FromArgb(37, 64, 129);
            panel1.ColorOrientation = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            panel1.Controls.Add(label1Date);
            panel1.Controls.Add(label1Day);
            panel1.Controls.Add(label1Description);
            panel1.Controls.Add(picture1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(115, 305);
            panel1.TabIndex = 1;
            // 
            // label1Date
            // 
            label1Date.Anchor = AnchorStyles.None;
            label1Date.AutoSize = true;
            label1Date.BackColor = Color.Transparent;
            label1Date.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1Date.ForeColor = Color.Gainsboro;
            label1Date.Location = new Point(12, 67);
            label1Date.Name = "label1Date";
            label1Date.Size = new Size(90, 28);
            label1Date.TabIndex = 20;
            label1Date.Text = "March 3";
            // 
            // label1Day
            // 
            label1Day.Anchor = AnchorStyles.None;
            label1Day.AutoSize = true;
            label1Day.BackColor = Color.Transparent;
            label1Day.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1Day.ForeColor = Color.Gainsboro;
            label1Day.Location = new Point(19, 38);
            label1Day.Name = "label1Day";
            label1Day.Size = new Size(70, 28);
            label1Day.TabIndex = 19;
            label1Day.Text = "Friday";
            // 
            // label1Description
            // 
            label1Description.Anchor = AnchorStyles.None;
            label1Description.AutoSize = true;
            label1Description.BackColor = Color.Transparent;
            label1Description.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1Description.ForeColor = Color.Gainsboro;
            label1Description.Location = new Point(6, 237);
            label1Description.Name = "label1Description";
            label1Description.Size = new Size(98, 25);
            label1Description.TabIndex = 18;
            label1Description.Text = "Light Rain";
            // 
            // picture1
            // 
            picture1.Anchor = AnchorStyles.None;
            picture1.BackColor = Color.Transparent;
            picture1.Image = (Image)resources.GetObject("picture1.Image");
            picture1.Location = new Point(2, 120);
            picture1.Name = "picture1";
            picture1.Size = new Size(112, 93);
            picture1.SizeMode = PictureBoxSizeMode.Zoom;
            picture1.TabIndex = 17;
            picture1.TabStop = false;
            // 
            // labelForecast
            // 
            labelForecast.AutoSize = true;
            labelForecast.Dock = DockStyle.Top;
            labelForecast.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelForecast.ForeColor = Color.Gainsboro;
            labelForecast.Location = new Point(0, 0);
            labelForecast.Name = "labelForecast";
            labelForecast.Padding = new Padding(10);
            labelForecast.Size = new Size(265, 58);
            labelForecast.TabIndex = 11;
            labelForecast.Text = "Weather Forecast";
            // 
            // panelDetails
            // 
            panelDetails.BackColor = Color.Transparent;
            panelDetails.Controls.Add(panelDetailsTable);
            panelDetails.Controls.Add(labelDetails);
            panelDetails.Dock = DockStyle.Top;
            panelDetails.Location = new Point(0, 0);
            panelDetails.Name = "panelDetails";
            panelDetails.Size = new Size(847, 375);
            panelDetails.TabIndex = 2;
            // 
            // panelDetailsTable
            // 
            panelDetailsTable.BackColor = Color.Transparent;
            panelDetailsTable.ColumnCount = 3;
            panelDetailsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            panelDetailsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            panelDetailsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            panelDetailsTable.Controls.Add(panelClouds, 0, 1);
            panelDetailsTable.Controls.Add(panelUVIndex, 1, 1);
            panelDetailsTable.Controls.Add(panelPressure, 2, 1);
            panelDetailsTable.Controls.Add(panelSunriseSunset, 2, 0);
            panelDetailsTable.Controls.Add(panelWindSpeed, 1, 0);
            panelDetailsTable.Controls.Add(panelHumidity, 0, 0);
            panelDetailsTable.Dock = DockStyle.Fill;
            panelDetailsTable.Location = new Point(0, 58);
            panelDetailsTable.Name = "panelDetailsTable";
            panelDetailsTable.RowCount = 2;
            panelDetailsTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            panelDetailsTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            panelDetailsTable.Size = new Size(847, 317);
            panelDetailsTable.TabIndex = 11;
            // 
            // panelClouds
            // 
            panelClouds.BackColor = Color.FromArgb(18, 151, 244);
            panelClouds.BorderColor = Color.White;
            panelClouds.BorderRadius = 10;
            panelClouds.BorderSize = 2;
            panelClouds.Color1 = Color.FromArgb(18, 151, 244);
            panelClouds.Color2 = Color.FromArgb(37, 64, 129);
            panelClouds.ColorOrientation = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            panelClouds.Controls.Add(labelClouds);
            panelClouds.Controls.Add(labelCloudsTitle);
            panelClouds.Controls.Add(pictureClouds);
            panelClouds.Dock = DockStyle.Fill;
            panelClouds.Location = new Point(3, 161);
            panelClouds.Name = "panelClouds";
            panelClouds.Size = new Size(276, 153);
            panelClouds.TabIndex = 1;
            // 
            // labelClouds
            // 
            labelClouds.Anchor = AnchorStyles.None;
            labelClouds.AutoSize = true;
            labelClouds.BackColor = Color.Transparent;
            labelClouds.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelClouds.ForeColor = Color.Gainsboro;
            labelClouds.Location = new Point(142, 81);
            labelClouds.Name = "labelClouds";
            labelClouds.Size = new Size(100, 32);
            labelClouds.TabIndex = 7;
            labelClouds.Text = "10 mph";
            // 
            // labelCloudsTitle
            // 
            labelCloudsTitle.Anchor = AnchorStyles.None;
            labelCloudsTitle.AutoSize = true;
            labelCloudsTitle.BackColor = Color.Transparent;
            labelCloudsTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelCloudsTitle.ForeColor = Color.Gainsboro;
            labelCloudsTitle.Location = new Point(150, 38);
            labelCloudsTitle.Name = "labelCloudsTitle";
            labelCloudsTitle.Size = new Size(92, 32);
            labelCloudsTitle.TabIndex = 6;
            labelCloudsTitle.Text = "Clouds";
            // 
            // pictureClouds
            // 
            pictureClouds.Anchor = AnchorStyles.None;
            pictureClouds.BackColor = Color.Transparent;
            pictureClouds.Image = (Image)resources.GetObject("pictureClouds.Image");
            pictureClouds.Location = new Point(7, 14);
            pictureClouds.Name = "pictureClouds";
            pictureClouds.Size = new Size(129, 126);
            pictureClouds.SizeMode = PictureBoxSizeMode.Zoom;
            pictureClouds.TabIndex = 8;
            pictureClouds.TabStop = false;
            // 
            // panelUVIndex
            // 
            panelUVIndex.BackColor = Color.FromArgb(18, 151, 244);
            panelUVIndex.BorderColor = Color.White;
            panelUVIndex.BorderRadius = 10;
            panelUVIndex.BorderSize = 2;
            panelUVIndex.Color1 = Color.FromArgb(18, 151, 244);
            panelUVIndex.Color2 = Color.FromArgb(37, 64, 129);
            panelUVIndex.ColorOrientation = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            panelUVIndex.Controls.Add(labelUVIndex);
            panelUVIndex.Controls.Add(labelUVIndexTitle);
            panelUVIndex.Controls.Add(pictureUVIndex);
            panelUVIndex.Dock = DockStyle.Fill;
            panelUVIndex.Location = new Point(285, 161);
            panelUVIndex.Name = "panelUVIndex";
            panelUVIndex.Size = new Size(276, 153);
            panelUVIndex.TabIndex = 1;
            // 
            // labelUVIndex
            // 
            labelUVIndex.Anchor = AnchorStyles.None;
            labelUVIndex.AutoSize = true;
            labelUVIndex.BackColor = Color.Transparent;
            labelUVIndex.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelUVIndex.ForeColor = Color.Gainsboro;
            labelUVIndex.Location = new Point(156, 81);
            labelUVIndex.Name = "labelUVIndex";
            labelUVIndex.Size = new Size(100, 32);
            labelUVIndex.TabIndex = 10;
            labelUVIndex.Text = "10 mph";
            // 
            // labelUVIndexTitle
            // 
            labelUVIndexTitle.Anchor = AnchorStyles.None;
            labelUVIndexTitle.AutoSize = true;
            labelUVIndexTitle.BackColor = Color.Transparent;
            labelUVIndexTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelUVIndexTitle.ForeColor = Color.Gainsboro;
            labelUVIndexTitle.Location = new Point(147, 38);
            labelUVIndexTitle.Name = "labelUVIndexTitle";
            labelUVIndexTitle.Size = new Size(118, 32);
            labelUVIndexTitle.TabIndex = 9;
            labelUVIndexTitle.Text = "UV Index";
            // 
            // pictureUVIndex
            // 
            pictureUVIndex.Anchor = AnchorStyles.None;
            pictureUVIndex.BackColor = Color.Transparent;
            pictureUVIndex.Image = (Image)resources.GetObject("pictureUVIndex.Image");
            pictureUVIndex.Location = new Point(21, 14);
            pictureUVIndex.Name = "pictureUVIndex";
            pictureUVIndex.Size = new Size(129, 126);
            pictureUVIndex.SizeMode = PictureBoxSizeMode.Zoom;
            pictureUVIndex.TabIndex = 11;
            pictureUVIndex.TabStop = false;
            // 
            // panelPressure
            // 
            panelPressure.BackColor = Color.FromArgb(18, 151, 244);
            panelPressure.BorderColor = Color.White;
            panelPressure.BorderRadius = 10;
            panelPressure.BorderSize = 2;
            panelPressure.Color1 = Color.FromArgb(18, 151, 244);
            panelPressure.Color2 = Color.FromArgb(37, 64, 129);
            panelPressure.ColorOrientation = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            panelPressure.Controls.Add(labelPressure);
            panelPressure.Controls.Add(labelPressureTitle);
            panelPressure.Controls.Add(picturePressure);
            panelPressure.Dock = DockStyle.Fill;
            panelPressure.Location = new Point(567, 161);
            panelPressure.Name = "panelPressure";
            panelPressure.Size = new Size(277, 153);
            panelPressure.TabIndex = 1;
            // 
            // labelPressure
            // 
            labelPressure.Anchor = AnchorStyles.None;
            labelPressure.AutoSize = true;
            labelPressure.BackColor = Color.Transparent;
            labelPressure.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPressure.ForeColor = Color.Gainsboro;
            labelPressure.Location = new Point(151, 81);
            labelPressure.Name = "labelPressure";
            labelPressure.Size = new Size(100, 32);
            labelPressure.TabIndex = 13;
            labelPressure.Text = "10 mph";
            // 
            // labelPressureTitle
            // 
            labelPressureTitle.Anchor = AnchorStyles.None;
            labelPressureTitle.AutoSize = true;
            labelPressureTitle.BackColor = Color.Transparent;
            labelPressureTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPressureTitle.ForeColor = Color.Gainsboro;
            labelPressureTitle.Location = new Point(142, 38);
            labelPressureTitle.Name = "labelPressureTitle";
            labelPressureTitle.Size = new Size(112, 32);
            labelPressureTitle.TabIndex = 12;
            labelPressureTitle.Text = "Pressure";
            // 
            // picturePressure
            // 
            picturePressure.Anchor = AnchorStyles.None;
            picturePressure.BackColor = Color.Transparent;
            picturePressure.Image = (Image)resources.GetObject("picturePressure.Image");
            picturePressure.Location = new Point(16, 14);
            picturePressure.Name = "picturePressure";
            picturePressure.Size = new Size(130, 126);
            picturePressure.SizeMode = PictureBoxSizeMode.Zoom;
            picturePressure.TabIndex = 14;
            picturePressure.TabStop = false;
            // 
            // panelSunriseSunset
            // 
            panelSunriseSunset.BackColor = Color.FromArgb(18, 151, 244);
            panelSunriseSunset.BorderColor = Color.White;
            panelSunriseSunset.BorderRadius = 10;
            panelSunriseSunset.BorderSize = 2;
            panelSunriseSunset.Color1 = Color.FromArgb(18, 151, 244);
            panelSunriseSunset.Color2 = Color.FromArgb(37, 64, 129);
            panelSunriseSunset.ColorOrientation = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            panelSunriseSunset.Controls.Add(pictureSunset);
            panelSunriseSunset.Controls.Add(labelSunset);
            panelSunriseSunset.Controls.Add(laeblSunsetTitle);
            panelSunriseSunset.Controls.Add(pictureSunrise);
            panelSunriseSunset.Controls.Add(labelSunrise);
            panelSunriseSunset.Controls.Add(labelSunriseTitle);
            panelSunriseSunset.Dock = DockStyle.Fill;
            panelSunriseSunset.Location = new Point(567, 3);
            panelSunriseSunset.Name = "panelSunriseSunset";
            panelSunriseSunset.Size = new Size(277, 152);
            panelSunriseSunset.TabIndex = 1;
            // 
            // pictureSunset
            // 
            pictureSunset.Anchor = AnchorStyles.None;
            pictureSunset.BackColor = Color.Transparent;
            pictureSunset.Image = (Image)resources.GetObject("pictureSunset.Image");
            pictureSunset.Location = new Point(16, 74);
            pictureSunset.Name = "pictureSunset";
            pictureSunset.Size = new Size(136, 94);
            pictureSunset.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureSunset.TabIndex = 20;
            pictureSunset.TabStop = false;
            // 
            // labelSunset
            // 
            labelSunset.Anchor = AnchorStyles.None;
            labelSunset.AutoSize = true;
            labelSunset.BackColor = Color.Transparent;
            labelSunset.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelSunset.ForeColor = Color.Gainsboro;
            labelSunset.Location = new Point(164, 106);
            labelSunset.Name = "labelSunset";
            labelSunset.Size = new Size(90, 28);
            labelSunset.TabIndex = 19;
            labelSunset.Text = "5:35 PM";
            // 
            // laeblSunsetTitle
            // 
            laeblSunsetTitle.Anchor = AnchorStyles.None;
            laeblSunsetTitle.AutoSize = true;
            laeblSunsetTitle.BackColor = Color.Transparent;
            laeblSunsetTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            laeblSunsetTitle.ForeColor = Color.Gainsboro;
            laeblSunsetTitle.Location = new Point(170, 81);
            laeblSunsetTitle.Name = "laeblSunsetTitle";
            laeblSunsetTitle.Size = new Size(75, 28);
            laeblSunsetTitle.TabIndex = 18;
            laeblSunsetTitle.Text = "Sunset";
            // 
            // pictureSunrise
            // 
            pictureSunrise.Anchor = AnchorStyles.None;
            pictureSunrise.BackColor = Color.Transparent;
            pictureSunrise.Image = (Image)resources.GetObject("pictureSunrise.Image");
            pictureSunrise.Location = new Point(16, -3);
            pictureSunrise.Name = "pictureSunrise";
            pictureSunrise.Size = new Size(136, 106);
            pictureSunrise.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureSunrise.TabIndex = 17;
            pictureSunrise.TabStop = false;
            // 
            // labelSunrise
            // 
            labelSunrise.Anchor = AnchorStyles.None;
            labelSunrise.AutoSize = true;
            labelSunrise.BackColor = Color.Transparent;
            labelSunrise.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelSunrise.ForeColor = Color.Gainsboro;
            labelSunrise.Location = new Point(160, 42);
            labelSunrise.Name = "labelSunrise";
            labelSunrise.Size = new Size(92, 28);
            labelSunrise.TabIndex = 16;
            labelSunrise.Text = "5:40 AM";
            // 
            // labelSunriseTitle
            // 
            labelSunriseTitle.Anchor = AnchorStyles.None;
            labelSunriseTitle.AutoSize = true;
            labelSunriseTitle.BackColor = Color.Transparent;
            labelSunriseTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelSunriseTitle.ForeColor = Color.Gainsboro;
            labelSunriseTitle.Location = new Point(164, 18);
            labelSunriseTitle.Name = "labelSunriseTitle";
            labelSunriseTitle.Size = new Size(81, 28);
            labelSunriseTitle.TabIndex = 15;
            labelSunriseTitle.Text = "Sunrise";
            // 
            // panelWindSpeed
            // 
            panelWindSpeed.BackColor = Color.FromArgb(18, 151, 244);
            panelWindSpeed.BorderColor = Color.White;
            panelWindSpeed.BorderRadius = 10;
            panelWindSpeed.BorderSize = 2;
            panelWindSpeed.Color1 = Color.FromArgb(18, 151, 244);
            panelWindSpeed.Color2 = Color.FromArgb(37, 64, 129);
            panelWindSpeed.ColorOrientation = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            panelWindSpeed.Controls.Add(labelWindSpeed);
            panelWindSpeed.Controls.Add(labelWindSpeedTitle);
            panelWindSpeed.Controls.Add(pictureWindSpeed);
            panelWindSpeed.Dock = DockStyle.Fill;
            panelWindSpeed.Location = new Point(285, 3);
            panelWindSpeed.Name = "panelWindSpeed";
            panelWindSpeed.Size = new Size(276, 152);
            panelWindSpeed.TabIndex = 1;
            // 
            // labelWindSpeed
            // 
            labelWindSpeed.Anchor = AnchorStyles.None;
            labelWindSpeed.AutoSize = true;
            labelWindSpeed.BackColor = Color.Transparent;
            labelWindSpeed.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelWindSpeed.ForeColor = Color.Gainsboro;
            labelWindSpeed.Location = new Point(138, 81);
            labelWindSpeed.Name = "labelWindSpeed";
            labelWindSpeed.Size = new Size(100, 32);
            labelWindSpeed.TabIndex = 4;
            labelWindSpeed.Text = "10 mph";
            // 
            // labelWindSpeedTitle
            // 
            labelWindSpeedTitle.Anchor = AnchorStyles.None;
            labelWindSpeedTitle.AutoSize = true;
            labelWindSpeedTitle.BackColor = Color.Transparent;
            labelWindSpeedTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelWindSpeedTitle.ForeColor = Color.Gainsboro;
            labelWindSpeedTitle.Location = new Point(114, 36);
            labelWindSpeedTitle.Name = "labelWindSpeedTitle";
            labelWindSpeedTitle.Size = new Size(151, 32);
            labelWindSpeedTitle.TabIndex = 3;
            labelWindSpeedTitle.Text = "Wind Speed";
            // 
            // pictureWindSpeed
            // 
            pictureWindSpeed.Anchor = AnchorStyles.None;
            pictureWindSpeed.BackColor = Color.Transparent;
            pictureWindSpeed.Image = (Image)resources.GetObject("pictureWindSpeed.Image");
            pictureWindSpeed.Location = new Point(3, 14);
            pictureWindSpeed.Name = "pictureWindSpeed";
            pictureWindSpeed.Size = new Size(129, 125);
            pictureWindSpeed.SizeMode = PictureBoxSizeMode.Zoom;
            pictureWindSpeed.TabIndex = 5;
            pictureWindSpeed.TabStop = false;
            // 
            // panelHumidity
            // 
            panelHumidity.BackColor = Color.FromArgb(18, 151, 244);
            panelHumidity.BorderColor = Color.White;
            panelHumidity.BorderRadius = 10;
            panelHumidity.BorderSize = 2;
            panelHumidity.Color1 = Color.FromArgb(18, 151, 244);
            panelHumidity.Color2 = Color.FromArgb(37, 64, 129);
            panelHumidity.ColorOrientation = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            panelHumidity.Controls.Add(labelHumidity);
            panelHumidity.Controls.Add(labelHumidityTitle);
            panelHumidity.Controls.Add(pictureHumidity);
            panelHumidity.Dock = DockStyle.Fill;
            panelHumidity.Location = new Point(3, 3);
            panelHumidity.Name = "panelHumidity";
            panelHumidity.Size = new Size(276, 152);
            panelHumidity.TabIndex = 0;
            // 
            // labelHumidity
            // 
            labelHumidity.Anchor = AnchorStyles.None;
            labelHumidity.AutoSize = true;
            labelHumidity.BackColor = Color.Transparent;
            labelHumidity.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelHumidity.ForeColor = Color.Gainsboro;
            labelHumidity.Location = new Point(143, 81);
            labelHumidity.Name = "labelHumidity";
            labelHumidity.Size = new Size(100, 32);
            labelHumidity.TabIndex = 1;
            labelHumidity.Text = "10 mph";
            // 
            // labelHumidityTitle
            // 
            labelHumidityTitle.Anchor = AnchorStyles.None;
            labelHumidityTitle.AutoSize = true;
            labelHumidityTitle.BackColor = Color.Transparent;
            labelHumidityTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelHumidityTitle.ForeColor = Color.Gainsboro;
            labelHumidityTitle.Location = new Point(132, 37);
            labelHumidityTitle.Name = "labelHumidityTitle";
            labelHumidityTitle.Size = new Size(120, 32);
            labelHumidityTitle.TabIndex = 0;
            labelHumidityTitle.Text = "Humidity";
            // 
            // pictureHumidity
            // 
            pictureHumidity.Anchor = AnchorStyles.None;
            pictureHumidity.BackColor = Color.Transparent;
            pictureHumidity.Image = (Image)resources.GetObject("pictureHumidity.Image");
            pictureHumidity.Location = new Point(-45, -14);
            pictureHumidity.Name = "pictureHumidity";
            pictureHumidity.Size = new Size(234, 189);
            pictureHumidity.SizeMode = PictureBoxSizeMode.Zoom;
            pictureHumidity.TabIndex = 2;
            pictureHumidity.TabStop = false;
            // 
            // labelDetails
            // 
            labelDetails.AutoSize = true;
            labelDetails.Dock = DockStyle.Top;
            labelDetails.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelDetails.ForeColor = Color.Gainsboro;
            labelDetails.Location = new Point(0, 0);
            labelDetails.Name = "labelDetails";
            labelDetails.Padding = new Padding(10);
            labelDetails.Size = new Size(246, 58);
            labelDetails.TabIndex = 10;
            labelDetails.Text = "Weather Details";
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(panelGeneralInfo);
            Controls.Add(panelMain);
            Name = "HomeForm";
            Size = new Size(1182, 744);
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureWeatherIcon).EndInit();
            panelGeneralInfo.ResumeLayout(false);
            panelForecast.ResumeLayout(false);
            panelForecast.PerformLayout();
            panelForecastTable.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picture7).EndInit();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picture6).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picture5).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picture4).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picture3).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picture2).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picture1).EndInit();
            panelDetails.ResumeLayout(false);
            panelDetails.PerformLayout();
            panelDetailsTable.ResumeLayout(false);
            panelClouds.ResumeLayout(false);
            panelClouds.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureClouds).EndInit();
            panelUVIndex.ResumeLayout(false);
            panelUVIndex.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureUVIndex).EndInit();
            panelPressure.ResumeLayout(false);
            panelPressure.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picturePressure).EndInit();
            panelSunriseSunset.ResumeLayout(false);
            panelSunriseSunset.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureSunset).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureSunrise).EndInit();
            panelWindSpeed.ResumeLayout(false);
            panelWindSpeed.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureWindSpeed).EndInit();
            panelHumidity.ResumeLayout(false);
            panelHumidity.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureHumidity).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMain;
        private Panel panelGeneralInfo;
        private Panel panelForecast;
        private Panel panelDetails;
        private Label labelDetails;
        private Label labelForecast;
        private TableLayoutPanel panelDetailsTable;
        private TableLayoutPanel panelForecastTable;
        private Label labelLocation;
        private Label labelCurrentDateTime;
        private Label labelDescription;
        private Label labelFeelsLike;
        private Label labelTemperature;
        private PictureBox pictureWeatherIcon;
        private TextBox textboxSearch;
        private ReaLTaiizor.Controls.Separator separator1;
        private FontAwesome.Sharp.IconButton buttonSearch;
        private CustomControls.CustomPanel panelSearch;
        private FontAwesome.Sharp.IconButton buttonHomeSearch;
        private TextBox textboxHomeSearch;
        private CustomControls.CustomPanel panelHumidity;
        private CustomControls.CustomPanel panel7;
        private CustomControls.CustomPanel panel6;
        private CustomControls.CustomPanel panel5;
        private CustomControls.CustomPanel panel4;
        private CustomControls.CustomPanel panel3;
        private CustomControls.CustomPanel panel2;
        private CustomControls.CustomPanel panel1;
        private CustomControls.CustomPanel panelClouds;
        private CustomControls.CustomPanel panelUVIndex;
        private CustomControls.CustomPanel panelPressure;
        private CustomControls.CustomPanel panelSunriseSunset;
        private CustomControls.CustomPanel panelWindSpeed;
        private Label labelHumidityTitle;
        private Label labelHumidity;
        private PictureBox pictureHumidity;
        private Label labelWindSpeed;
        private Label labelWindSpeedTitle;
        private PictureBox pictureWindSpeed;
        private Label labelClouds;
        private Label labelCloudsTitle;
        private PictureBox pictureClouds;
        private Label labelUVIndex;
        private Label labelUVIndexTitle;
        private PictureBox pictureUVIndex;
        private Label labelPressure;
        private Label labelPressureTitle;
        private PictureBox picturePressure;
        private Label labelSunset;
        private Label laeblSunsetTitle;
        private Label labelSunrise;
        private Label labelSunriseTitle;
        private PictureBox pictureSunrise;
        private PictureBox pictureSunset;
        private Label label1Description;
        private PictureBox picture1;
        private Label panel7Day;
        private Label label7Date;
        private Label label7Description;
        private PictureBox picture7;
        private Label label6Date;
        private Label label6Day;
        private Label label6Description;
        private PictureBox picture6;
        private Label label5Date;
        private Label label5Day;
        private Label label5Description;
        private PictureBox picture5;
        private Label label4Date;
        private Label label4Day;
        private Label label4Description;
        private PictureBox picture4;
        private Label label3Date;
        private Label label3Day;
        private Label label3Description;
        private PictureBox picture3;
        private Label label2Date;
        private Label label2Day;
        private Label label2Description;
        private PictureBox picture2;
        private Label label1Date;
        private Label label1Day;
    }
}
