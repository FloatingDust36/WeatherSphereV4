namespace WeatherSphereV4.UserControls
{
    partial class DailyControl
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
            panelDailyControl = new WeatherSphereV4.CustomControls.CustomPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            labelDay = new Label();
            pictureWeatherIcon = new PictureBox();
            panelDailyControl.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureWeatherIcon).BeginInit();
            SuspendLayout();
            // 
            // panelDailyControl
            // 
            panelDailyControl.BackColor = Color.MediumSlateBlue;
            panelDailyControl.BorderColor = Color.White;
            panelDailyControl.BorderRadius = 20;
            panelDailyControl.BorderSize = 2;
            panelDailyControl.Color1 = Color.FromArgb(100, 0, 0, 128);
            panelDailyControl.Color2 = Color.FromArgb(200, 25, 25, 50);
            panelDailyControl.ColorOrientation = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            panelDailyControl.Controls.Add(tableLayoutPanel1);
            panelDailyControl.Dock = DockStyle.Fill;
            panelDailyControl.Location = new Point(0, 0);
            panelDailyControl.Name = "panelDailyControl";
            panelDailyControl.Size = new Size(260, 120);
            panelDailyControl.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 57.2F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42.8F));
            tableLayoutPanel1.Controls.Add(labelDay, 0, 0);
            tableLayoutPanel1.Controls.Add(pictureWeatherIcon, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(10, 0, 5, 0);
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(260, 120);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // labelDay
            // 
            labelDay.Anchor = AnchorStyles.None;
            labelDay.AutoSize = true;
            labelDay.BackColor = Color.Transparent;
            labelDay.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelDay.ForeColor = Color.Gainsboro;
            labelDay.Location = new Point(13, 45);
            labelDay.Name = "labelDay";
            labelDay.Size = new Size(133, 30);
            labelDay.TabIndex = 0;
            labelDay.Text = "Wednesday";
            // 
            // pictureWeatherIcon
            // 
            pictureWeatherIcon.Anchor = AnchorStyles.None;
            pictureWeatherIcon.BackColor = Color.Transparent;
            pictureWeatherIcon.Location = new Point(157, 18);
            pictureWeatherIcon.Name = "pictureWeatherIcon";
            pictureWeatherIcon.Size = new Size(91, 83);
            pictureWeatherIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureWeatherIcon.TabIndex = 1;
            pictureWeatherIcon.TabStop = false;
            // 
            // DailyControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(panelDailyControl);
            Name = "DailyControl";
            Size = new Size(260, 120);
            panelDailyControl.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureWeatherIcon).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel tableLayoutPanel1;
        public Label labelDay;
        public PictureBox pictureWeatherIcon;
        public CustomControls.CustomPanel panelDailyControl;
    }
}
