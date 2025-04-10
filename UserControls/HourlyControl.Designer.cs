namespace WeatherSphereV4.UserControls
{
    partial class HourlyControl
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
            customPanel1 = new WeatherSphereV4.CustomControls.CustomPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel7 = new Panel();
            label11 = new Label();
            labelPressure = new Label();
            panel6 = new Panel();
            label9 = new Label();
            labelUVIndex = new Label();
            panel5 = new Panel();
            label7 = new Label();
            labelCloudCover = new Label();
            panel4 = new Panel();
            label1 = new Label();
            labelWindSpeed = new Label();
            panel3 = new Panel();
            label3 = new Label();
            labelHumidity = new Label();
            panel2 = new Panel();
            label2 = new Label();
            labelFeelsLike = new Label();
            labelTime = new Label();
            panel1 = new Panel();
            pictureWeatherIcon = new PictureBox();
            labelDescription = new Label();
            customPanel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureWeatherIcon).BeginInit();
            SuspendLayout();
            // 
            // customPanel1
            // 
            customPanel1.BackColor = Color.Transparent;
            customPanel1.BorderColor = Color.White;
            customPanel1.BorderRadius = 20;
            customPanel1.BorderSize = 2;
            customPanel1.Color1 = Color.Navy;
            customPanel1.Color2 = Color.FromArgb(25, 25, 50);
            customPanel1.ColorOrientation = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            customPanel1.Controls.Add(tableLayoutPanel1);
            customPanel1.Dock = DockStyle.Fill;
            customPanel1.Location = new Point(0, 0);
            customPanel1.Name = "customPanel1";
            customPanel1.Size = new Size(1118, 167);
            customPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 41.36905F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58.63095F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 815F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 2, 0);
            tableLayoutPanel1.Controls.Add(labelTime, 0, 0);
            tableLayoutPanel1.Controls.Add(panel1, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1118, 167);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel2.Controls.Add(panel7, 2, 1);
            tableLayoutPanel2.Controls.Add(panel6, 1, 1);
            tableLayoutPanel2.Controls.Add(panel5, 0, 1);
            tableLayoutPanel2.Controls.Add(panel4, 2, 0);
            tableLayoutPanel2.Controls.Add(panel3, 1, 0);
            tableLayoutPanel2.Controls.Add(panel2, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(305, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(810, 161);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // panel7
            // 
            panel7.Controls.Add(label11);
            panel7.Controls.Add(labelPressure);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(542, 83);
            panel7.Name = "panel7";
            panel7.Size = new Size(265, 75);
            panel7.TabIndex = 9;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label11.ForeColor = Color.Gray;
            label11.Location = new Point(87, 9);
            label11.Name = "label11";
            label11.Size = new Size(92, 28);
            label11.TabIndex = 4;
            label11.Text = "Pressure";
            // 
            // labelPressure
            // 
            labelPressure.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelPressure.AutoSize = true;
            labelPressure.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelPressure.ForeColor = Color.Gainsboro;
            labelPressure.Location = new Point(75, 37);
            labelPressure.Name = "labelPressure";
            labelPressure.Size = new Size(118, 28);
            labelPressure.TabIndex = 3;
            labelPressure.Text = "1010.5 hPa";
            // 
            // panel6
            // 
            panel6.Controls.Add(label9);
            panel6.Controls.Add(labelUVIndex);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(272, 83);
            panel6.Name = "panel6";
            panel6.Size = new Size(264, 75);
            panel6.TabIndex = 8;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label9.ForeColor = Color.Gray;
            label9.Location = new Point(83, 9);
            label9.Name = "label9";
            label9.Size = new Size(97, 28);
            label9.TabIndex = 4;
            label9.Text = "UV Index";
            // 
            // labelUVIndex
            // 
            labelUVIndex.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelUVIndex.AutoSize = true;
            labelUVIndex.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelUVIndex.ForeColor = Color.Gainsboro;
            labelUVIndex.Location = new Point(114, 37);
            labelUVIndex.Name = "labelUVIndex";
            labelUVIndex.Size = new Size(24, 28);
            labelUVIndex.TabIndex = 3;
            labelUVIndex.Text = "0";
            // 
            // panel5
            // 
            panel5.Controls.Add(label7);
            panel5.Controls.Add(labelCloudCover);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(3, 83);
            panel5.Name = "panel5";
            panel5.Size = new Size(263, 75);
            panel5.TabIndex = 7;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label7.ForeColor = Color.Gray;
            label7.Location = new Point(88, 9);
            label7.Name = "label7";
            label7.Size = new Size(75, 28);
            label7.TabIndex = 4;
            label7.Text = "Clouds";
            // 
            // labelCloudCover
            // 
            labelCloudCover.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelCloudCover.AutoSize = true;
            labelCloudCover.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelCloudCover.ForeColor = Color.Gainsboro;
            labelCloudCover.Location = new Point(95, 37);
            labelCloudCover.Name = "labelCloudCover";
            labelCloudCover.Size = new Size(53, 28);
            labelCloudCover.TabIndex = 3;
            labelCloudCover.Text = "99%";
            // 
            // panel4
            // 
            panel4.Controls.Add(label1);
            panel4.Controls.Add(labelWindSpeed);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(542, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(265, 74);
            panel4.TabIndex = 6;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.ForeColor = Color.Gray;
            label1.Location = new Point(68, 6);
            label1.Name = "label1";
            label1.Size = new Size(125, 28);
            label1.TabIndex = 4;
            label1.Text = "Wind Speed";
            // 
            // labelWindSpeed
            // 
            labelWindSpeed.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelWindSpeed.AutoSize = true;
            labelWindSpeed.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelWindSpeed.ForeColor = Color.Gainsboro;
            labelWindSpeed.Location = new Point(90, 34);
            labelWindSpeed.Name = "labelWindSpeed";
            labelWindSpeed.Size = new Size(78, 28);
            labelWindSpeed.TabIndex = 3;
            labelWindSpeed.Text = "10 m/s";
            // 
            // panel3
            // 
            panel3.Controls.Add(label3);
            panel3.Controls.Add(labelHumidity);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(272, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(264, 74);
            panel3.TabIndex = 5;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.ForeColor = Color.Gray;
            label3.Location = new Point(83, 6);
            label3.Name = "label3";
            label3.Size = new Size(100, 28);
            label3.TabIndex = 4;
            label3.Text = "Humidity";
            // 
            // labelHumidity
            // 
            labelHumidity.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelHumidity.AutoSize = true;
            labelHumidity.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelHumidity.ForeColor = Color.Gainsboro;
            labelHumidity.Location = new Point(114, 34);
            labelHumidity.Name = "labelHumidity";
            labelHumidity.Size = new Size(41, 28);
            labelHumidity.TabIndex = 3;
            labelHumidity.Text = "0%";
            // 
            // panel2
            // 
            panel2.Controls.Add(label2);
            panel2.Controls.Add(labelFeelsLike);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(263, 74);
            panel2.TabIndex = 4;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.ForeColor = Color.Gray;
            label2.Location = new Point(76, 6);
            label2.Name = "label2";
            label2.Size = new Size(103, 28);
            label2.TabIndex = 6;
            label2.Text = "Feels Like";
            // 
            // labelFeelsLike
            // 
            labelFeelsLike.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelFeelsLike.AutoSize = true;
            labelFeelsLike.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelFeelsLike.ForeColor = Color.Gainsboro;
            labelFeelsLike.Location = new Point(92, 34);
            labelFeelsLike.Name = "labelFeelsLike";
            labelFeelsLike.Size = new Size(56, 28);
            labelFeelsLike.TabIndex = 5;
            labelFeelsLike.Text = "99°C";
            // 
            // labelTime
            // 
            labelTime.Anchor = AnchorStyles.None;
            labelTime.AutoSize = true;
            labelTime.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelTime.ForeColor = Color.Gainsboro;
            labelTime.Location = new Point(10, 69);
            labelTime.Name = "labelTime";
            labelTime.Size = new Size(104, 28);
            labelTime.TabIndex = 1;
            labelTime.Text = "12:59 AM";
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureWeatherIcon);
            panel1.Controls.Add(labelDescription);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(128, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(171, 161);
            panel1.TabIndex = 2;
            // 
            // pictureWeatherIcon
            // 
            pictureWeatherIcon.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureWeatherIcon.Location = new Point(28, 48);
            pictureWeatherIcon.Name = "pictureWeatherIcon";
            pictureWeatherIcon.Size = new Size(118, 100);
            pictureWeatherIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureWeatherIcon.TabIndex = 2;
            pictureWeatherIcon.TabStop = false;
            // 
            // labelDescription
            // 
            labelDescription.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelDescription.AutoSize = true;
            labelDescription.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelDescription.ForeColor = Color.Gainsboro;
            labelDescription.Location = new Point(19, 17);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(140, 28);
            labelDescription.TabIndex = 2;
            labelDescription.Text = "Partly Cloudy";
            // 
            // HourlyControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(customPanel1);
            Name = "HourlyControl";
            Size = new Size(1118, 167);
            customPanel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureWeatherIcon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private CustomControls.CustomPanel customPanel1;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel2;
        private Label label3;
        private Panel panel1;
        private Panel panel7;
        private Label label11;
        private Panel panel6;
        private Panel panel5;
        private Label label7;
        private Panel panel4;
        private Panel panel3;
        private Label label1;
        public Label labelTime;
        public PictureBox pictureWeatherIcon;
        public Label labelDescription;
        public Label labelHumidity;
        public Label labelPressure;
        public Label label9;
        public Label labelUVIndex;
        public Label labelCloudCover;
        public Label labelWindSpeed;
        private Label label2;
        public Label labelFeelsLike;
    }
}
