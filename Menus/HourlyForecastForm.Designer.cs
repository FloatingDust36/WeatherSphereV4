namespace WeatherSphereV4
{
    partial class HourlyForecastForm
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
            panelDaily = new FlowLayoutPanel();
            panelHourly = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // panelDaily
            // 
            panelDaily.Dock = DockStyle.Top;
            panelDaily.Location = new Point(15, 15);
            panelDaily.Name = "panelDaily";
            panelDaily.Size = new Size(1152, 152);
            panelDaily.TabIndex = 0;
            // 
            // panelHourly
            // 
            panelHourly.Dock = DockStyle.Fill;
            panelHourly.FlowDirection = FlowDirection.TopDown;
            panelHourly.Location = new Point(15, 167);
            panelHourly.Name = "panelHourly";
            panelHourly.Size = new Size(1152, 562);
            panelHourly.TabIndex = 1;
            // 
            // HourlyForecastForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(50, 50, 79);
            Controls.Add(panelHourly);
            Controls.Add(panelDaily);
            Name = "HourlyForecastForm";
            Padding = new Padding(15);
            Size = new Size(1182, 744);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel panelDaily;
        private FlowLayoutPanel panelHourly;
    }
}
