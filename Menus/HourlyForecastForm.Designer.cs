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
            panelHourly = new FlowLayoutPanel();
            panel2 = new Panel();
            dropdownDaily = new ReaLTaiizor.Controls.MaterialComboBox();
            panel1 = new Panel();
            labelDate = new Label();
            labelLocation = new Label();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelHourly
            // 
            panelHourly.AutoScroll = true;
            panelHourly.Dock = DockStyle.Fill;
            panelHourly.FlowDirection = FlowDirection.TopDown;
            panelHourly.Location = new Point(15, 167);
            panelHourly.Name = "panelHourly";
            panelHourly.Size = new Size(1152, 562);
            panelHourly.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(dropdownDaily);
            panel2.Location = new Point(858, 44);
            panel2.Name = "panel2";
            panel2.Size = new Size(247, 49);
            panel2.TabIndex = 8;
            // 
            // dropdownDaily
            // 
            dropdownDaily.AutoResize = false;
            dropdownDaily.BackColor = Color.FromArgb(255, 255, 192);
            dropdownDaily.Depth = 0;
            dropdownDaily.DrawMode = DrawMode.OwnerDrawVariable;
            dropdownDaily.DropDownHeight = 174;
            dropdownDaily.DropDownStyle = ComboBoxStyle.DropDownList;
            dropdownDaily.DropDownWidth = 148;
            dropdownDaily.FlatStyle = FlatStyle.Popup;
            dropdownDaily.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dropdownDaily.ForeColor = Color.Yellow;
            dropdownDaily.FormattingEnabled = true;
            dropdownDaily.IntegralHeight = false;
            dropdownDaily.ItemHeight = 43;
            dropdownDaily.Items.AddRange(new object[] { "Monday", "Tuesday", "wednesday", "Thursday", "Friday", "Sturday", "Sunday" });
            dropdownDaily.Location = new Point(1, 0);
            dropdownDaily.MaxDropDownItems = 4;
            dropdownDaily.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            dropdownDaily.Name = "dropdownDaily";
            dropdownDaily.Size = new Size(246, 49);
            dropdownDaily.StartIndex = 0;
            dropdownDaily.TabIndex = 6;
            dropdownDaily.SelectedIndexChanged += dropdownDaily_SelectedIndexChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(labelDate);
            panel1.Controls.Add(labelLocation);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(15, 15);
            panel1.Name = "panel1";
            panel1.Size = new Size(1152, 152);
            panel1.TabIndex = 2;
            // 
            // labelDate
            // 
            labelDate.Anchor = AnchorStyles.None;
            labelDate.AutoSize = true;
            labelDate.BackColor = Color.Transparent;
            labelDate.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelDate.ForeColor = Color.Gainsboro;
            labelDate.Location = new Point(38, 79);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(268, 30);
            labelDate.TabIndex = 2;
            labelDate.Text = "April 6, 2025, Wedneday";
            // 
            // labelLocation
            // 
            labelLocation.Anchor = AnchorStyles.None;
            labelLocation.AutoSize = true;
            labelLocation.BackColor = Color.Transparent;
            labelLocation.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelLocation.ForeColor = Color.Gainsboro;
            labelLocation.Location = new Point(38, 34);
            labelLocation.Name = "labelLocation";
            labelLocation.Size = new Size(393, 30);
            labelLocation.TabIndex = 1;
            labelLocation.Text = "Lambusan, San Remiogio 6011, Cebu";
            // 
            // HourlyForecastForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(50, 50, 79);
            Controls.Add(panelHourly);
            Controls.Add(panel1);
            Name = "HourlyForecastForm";
            Padding = new Padding(15);
            Size = new Size(1182, 744);
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private FlowLayoutPanel panelHourly;
        private Panel panel1;
        public Label labelDate;
        public Label labelLocation;
        private ReaLTaiizor.Controls.MaterialComboBox dropdownDaily;
        private Panel panel2;
    }
}
