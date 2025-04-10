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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HourlyForecastForm));
            panelHourly = new FlowLayoutPanel();
            panel2 = new Panel();
            dropdownDaily = new ReaLTaiizor.Controls.MaterialComboBox();
            panel1 = new Panel();
            labelDate = new Label();
            labelLocation = new Label();
            panelInfoBar = new Panel();
            labelInfoBarMessage = new Label();
            buttonCloseInfoBar = new FontAwesome.Sharp.IconButton();
            iconInfoBar = new FontAwesome.Sharp.IconButton();
            panelLoadingOverlay = new Panel();
            pictureLoadingSpinner = new PictureBox();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            panelInfoBar.SuspendLayout();
            panelLoadingOverlay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureLoadingSpinner).BeginInit();
            SuspendLayout();
            // 
            // panelHourly
            // 
            panelHourly.AutoScroll = true;
            panelHourly.Dock = DockStyle.Fill;
            panelHourly.FlowDirection = FlowDirection.TopDown;
            panelHourly.Location = new Point(15, 177);
            panelHourly.Name = "panelHourly";
            panelHourly.Size = new Size(1152, 552);
            panelHourly.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(dropdownDaily);
            panel2.Location = new Point(858, 36);
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
            panel1.Location = new Point(15, 50);
            panel1.Name = "panel1";
            panel1.Size = new Size(1152, 127);
            panel1.TabIndex = 2;
            // 
            // labelDate
            // 
            labelDate.Anchor = AnchorStyles.None;
            labelDate.AutoSize = true;
            labelDate.BackColor = Color.Transparent;
            labelDate.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelDate.ForeColor = Color.Gainsboro;
            labelDate.Location = new Point(38, 66);
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
            labelLocation.Location = new Point(38, 21);
            labelLocation.Name = "labelLocation";
            labelLocation.Size = new Size(393, 30);
            labelLocation.TabIndex = 1;
            labelLocation.Text = "Lambusan, San Remiogio 6011, Cebu";
            // 
            // panelInfoBar
            // 
            panelInfoBar.BackColor = Color.CornflowerBlue;
            panelInfoBar.Controls.Add(labelInfoBarMessage);
            panelInfoBar.Controls.Add(buttonCloseInfoBar);
            panelInfoBar.Controls.Add(iconInfoBar);
            panelInfoBar.Dock = DockStyle.Top;
            panelInfoBar.Location = new Point(15, 15);
            panelInfoBar.Name = "panelInfoBar";
            panelInfoBar.Size = new Size(1152, 35);
            panelInfoBar.TabIndex = 44;
            panelInfoBar.Visible = false;
            // 
            // labelInfoBarMessage
            // 
            labelInfoBarMessage.Dock = DockStyle.Fill;
            labelInfoBarMessage.Location = new Point(35, 0);
            labelInfoBarMessage.Name = "labelInfoBarMessage";
            labelInfoBarMessage.Padding = new Padding(5, 0, 0, 0);
            labelInfoBarMessage.Size = new Size(1082, 35);
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
            buttonCloseInfoBar.Location = new Point(1117, 0);
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
            panelLoadingOverlay.Location = new Point(15, 15);
            panelLoadingOverlay.Name = "panelLoadingOverlay";
            panelLoadingOverlay.Size = new Size(1152, 714);
            panelLoadingOverlay.TabIndex = 50;
            panelLoadingOverlay.Visible = false;
            // 
            // pictureLoadingSpinner
            // 
            pictureLoadingSpinner.Anchor = AnchorStyles.None;
            pictureLoadingSpinner.Image = (Image)resources.GetObject("pictureLoadingSpinner.Image");
            pictureLoadingSpinner.Location = new Point(811, 393);
            pictureLoadingSpinner.Name = "pictureLoadingSpinner";
            pictureLoadingSpinner.Size = new Size(498, 498);
            pictureLoadingSpinner.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureLoadingSpinner.TabIndex = 13;
            pictureLoadingSpinner.TabStop = false;
            // 
            // HourlyForecastForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(50, 50, 79);
            Controls.Add(panelHourly);
            Controls.Add(panel1);
            Controls.Add(panelInfoBar);
            Controls.Add(panelLoadingOverlay);
            Name = "HourlyForecastForm";
            Padding = new Padding(15);
            Size = new Size(1182, 744);
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelInfoBar.ResumeLayout(false);
            panelLoadingOverlay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureLoadingSpinner).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private FlowLayoutPanel panelHourly;
        private Panel panel1;
        public Label labelDate;
        public Label labelLocation;
        private ReaLTaiizor.Controls.MaterialComboBox dropdownDaily;
        private Panel panel2;
        private Panel panelInfoBar;
        private Label labelInfoBarMessage;
        private FontAwesome.Sharp.IconButton buttonCloseInfoBar;
        private FontAwesome.Sharp.IconButton iconInfoBar;
        private Panel panelLoadingOverlay;
        private PictureBox pictureLoadingSpinner;
    }
}
