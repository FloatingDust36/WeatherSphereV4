namespace WeatherSphereV4.UserControls
{
    partial class MonthlyControl
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
            panelMonthly = new WeatherSphereV4.CustomControls.CustomPanel();
            labelTemperature = new Label();
            labelDay = new Label();
            pictureWeatherIcon = new PictureBox();
            panelMonthly.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureWeatherIcon).BeginInit();
            SuspendLayout();
            // 
            // panelMonthly
            // 
            panelMonthly.BackColor = Color.MediumSlateBlue;
            panelMonthly.BorderColor = Color.White;
            panelMonthly.BorderRadius = 15;
            panelMonthly.BorderSize = 0;
            panelMonthly.Color1 = Color.FromArgb(100, 0, 0, 128);
            panelMonthly.Color2 = Color.FromArgb(200, 25, 25, 50);
            panelMonthly.ColorOrientation = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            panelMonthly.Controls.Add(labelTemperature);
            panelMonthly.Controls.Add(labelDay);
            panelMonthly.Controls.Add(pictureWeatherIcon);
            panelMonthly.Dock = DockStyle.Fill;
            panelMonthly.Location = new Point(0, 0);
            panelMonthly.Name = "panelMonthly";
            panelMonthly.Size = new Size(157, 90);
            panelMonthly.TabIndex = 11;
            // 
            // labelTemperature
            // 
            labelTemperature.AutoSize = true;
            labelTemperature.BackColor = Color.Transparent;
            labelTemperature.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTemperature.ForeColor = Color.Gainsboro;
            labelTemperature.Location = new Point(89, 43);
            labelTemperature.Name = "labelTemperature";
            labelTemperature.Size = new Size(0, 25);
            labelTemperature.TabIndex = 2;
            // 
            // labelDay
            // 
            labelDay.AutoSize = true;
            labelDay.BackColor = Color.Transparent;
            labelDay.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelDay.ForeColor = Color.Gainsboro;
            labelDay.Location = new Point(18, 3);
            labelDay.Name = "labelDay";
            labelDay.Size = new Size(32, 25);
            labelDay.TabIndex = 0;
            labelDay.Text = "30";
            // 
            // pictureWeatherIcon
            // 
            pictureWeatherIcon.BackColor = Color.Transparent;
            pictureWeatherIcon.Location = new Point(7, 22);
            pictureWeatherIcon.Name = "pictureWeatherIcon";
            pictureWeatherIcon.Size = new Size(84, 67);
            pictureWeatherIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureWeatherIcon.TabIndex = 1;
            pictureWeatherIcon.TabStop = false;
            // 
            // MonthlyControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelMonthly);
            Name = "MonthlyControl";
            Size = new Size(157, 90);
            panelMonthly.ResumeLayout(false);
            panelMonthly.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureWeatherIcon).EndInit();
            ResumeLayout(false);
        }

        #endregion
        public Label labelTemperature;
        public Label labelDay;
        public PictureBox pictureWeatherIcon;
        public CustomControls.CustomPanel panelMonthly;
    }
}
