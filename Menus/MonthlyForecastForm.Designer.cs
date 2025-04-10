namespace WeatherSphereV4
{
    partial class MonthlyForecastForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonthlyForecastForm));
            tableLayoutPanelCalendar = new TableLayoutPanel();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel1 = new Panel();
            btnPreviousMonth = new PictureBox();
            btnNextMonth = new PictureBox();
            labelMonth = new Label();
            panelInfoBar = new Panel();
            labelInfoBarMessage = new Label();
            buttonCloseInfoBar = new FontAwesome.Sharp.IconButton();
            iconInfoBar = new FontAwesome.Sharp.IconButton();
            panelLoadingOverlay = new Panel();
            pictureLoadingSpinner = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)btnPreviousMonth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnNextMonth).BeginInit();
            panelInfoBar.SuspendLayout();
            panelLoadingOverlay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureLoadingSpinner).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanelCalendar
            // 
            tableLayoutPanelCalendar.ColumnCount = 7;
            tableLayoutPanelCalendar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28939F));
            tableLayoutPanelCalendar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2851F));
            tableLayoutPanelCalendar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2851F));
            tableLayoutPanelCalendar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2851F));
            tableLayoutPanelCalendar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2851F));
            tableLayoutPanelCalendar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2851F));
            tableLayoutPanelCalendar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2851067F));
            tableLayoutPanelCalendar.Dock = DockStyle.Fill;
            tableLayoutPanelCalendar.Location = new Point(20, 131);
            tableLayoutPanelCalendar.Name = "tableLayoutPanelCalendar";
            tableLayoutPanelCalendar.RowCount = 7;
            tableLayoutPanelCalendar.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanelCalendar.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanelCalendar.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanelCalendar.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanelCalendar.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanelCalendar.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanelCalendar.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tableLayoutPanelCalendar.Size = new Size(1142, 593);
            tableLayoutPanelCalendar.TabIndex = 0;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label7.ForeColor = Color.Gainsboro;
            label7.Location = new Point(38, 10);
            label7.Name = "label7";
            label7.Size = new Size(88, 25);
            label7.TabIndex = 0;
            label7.Text = "Saturday";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.ForeColor = Color.Gainsboro;
            label6.Location = new Point(48, 10);
            label6.Name = "label6";
            label6.Size = new Size(64, 25);
            label6.TabIndex = 0;
            label6.Text = "Friday";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.ForeColor = Color.Gainsboro;
            label5.Location = new Point(38, 10);
            label5.Name = "label5";
            label5.Size = new Size(91, 25);
            label5.TabIndex = 0;
            label5.Text = "Thursday";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.ForeColor = Color.Gainsboro;
            label4.Location = new Point(22, 10);
            label4.Name = "label4";
            label4.Size = new Size(111, 25);
            label4.TabIndex = 0;
            label4.Text = "Wednesday";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.ForeColor = Color.Gainsboro;
            label3.Location = new Point(40, 10);
            label3.Name = "label3";
            label3.Size = new Size(82, 25);
            label3.TabIndex = 0;
            label3.Text = "Tuesday";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.ForeColor = Color.Gainsboro;
            label2.Location = new Point(42, 10);
            label2.Name = "label2";
            label2.Size = new Size(82, 25);
            label2.TabIndex = 0;
            label2.Text = "Monday";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.ForeColor = Color.Gainsboro;
            label1.Location = new Point(45, 10);
            label1.Name = "label1";
            label1.Size = new Size(75, 25);
            label1.TabIndex = 0;
            label1.Text = "Sunday";
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(20, 55);
            panel1.Name = "panel1";
            panel1.Size = new Size(1142, 76);
            panel1.TabIndex = 1;
            // 
            // btnPreviousMonth
            // 
            btnPreviousMonth.BackColor = Color.Transparent;
            btnPreviousMonth.Image = (Image)resources.GetObject("btnPreviousMonth.Image");
            btnPreviousMonth.Location = new Point(6, 8);
            btnPreviousMonth.Name = "btnPreviousMonth";
            btnPreviousMonth.Size = new Size(40, 40);
            btnPreviousMonth.SizeMode = PictureBoxSizeMode.StretchImage;
            btnPreviousMonth.TabIndex = 0;
            btnPreviousMonth.TabStop = false;
            btnPreviousMonth.Click += btnPreviousMonth_Click;
            // 
            // btnNextMonth
            // 
            btnNextMonth.BackColor = Color.Transparent;
            btnNextMonth.Image = (Image)resources.GetObject("btnNextMonth.Image");
            btnNextMonth.Location = new Point(8, 7);
            btnNextMonth.Name = "btnNextMonth";
            btnNextMonth.Size = new Size(40, 40);
            btnNextMonth.SizeMode = PictureBoxSizeMode.StretchImage;
            btnNextMonth.TabIndex = 0;
            btnNextMonth.TabStop = false;
            btnNextMonth.Click += btnNextMonth_Click;
            // 
            // labelMonth
            // 
            labelMonth.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelMonth.AutoSize = true;
            labelMonth.BackColor = Color.Transparent;
            labelMonth.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelMonth.ForeColor = Color.Gainsboro;
            labelMonth.Location = new Point(52, 11);
            labelMonth.Name = "labelMonth";
            labelMonth.Size = new Size(70, 32);
            labelMonth.TabIndex = 0;
            labelMonth.Text = "April";
            // 
            // panelInfoBar
            // 
            panelInfoBar.BackColor = Color.CornflowerBlue;
            panelInfoBar.Controls.Add(labelInfoBarMessage);
            panelInfoBar.Controls.Add(buttonCloseInfoBar);
            panelInfoBar.Controls.Add(iconInfoBar);
            panelInfoBar.Dock = DockStyle.Top;
            panelInfoBar.Location = new Point(20, 20);
            panelInfoBar.Name = "panelInfoBar";
            panelInfoBar.Size = new Size(1142, 35);
            panelInfoBar.TabIndex = 45;
            panelInfoBar.Visible = false;
            // 
            // labelInfoBarMessage
            // 
            labelInfoBarMessage.Dock = DockStyle.Fill;
            labelInfoBarMessage.Location = new Point(35, 0);
            labelInfoBarMessage.Name = "labelInfoBarMessage";
            labelInfoBarMessage.Padding = new Padding(5, 0, 0, 0);
            labelInfoBarMessage.Size = new Size(1072, 35);
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
            buttonCloseInfoBar.Location = new Point(1107, 0);
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
            panelLoadingOverlay.Location = new Point(20, 20);
            panelLoadingOverlay.Name = "panelLoadingOverlay";
            panelLoadingOverlay.Size = new Size(1142, 704);
            panelLoadingOverlay.TabIndex = 51;
            panelLoadingOverlay.Visible = false;
            // 
            // pictureLoadingSpinner
            // 
            pictureLoadingSpinner.Anchor = AnchorStyles.None;
            pictureLoadingSpinner.Image = (Image)resources.GetObject("pictureLoadingSpinner.Image");
            pictureLoadingSpinner.Location = new Point(1282, 695);
            pictureLoadingSpinner.Name = "pictureLoadingSpinner";
            pictureLoadingSpinner.Size = new Size(498, 498);
            pictureLoadingSpinner.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureLoadingSpinner.TabIndex = 13;
            pictureLoadingSpinner.TabStop = false;
            // 
            // MonthlyForecastForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(50, 50, 79);
            Controls.Add(tableLayoutPanelCalendar);
            Controls.Add(panel1);
            Controls.Add(panelInfoBar);
            Controls.Add(panelLoadingOverlay);
            Name = "MonthlyForecastForm";
            Padding = new Padding(20);
            Size = new Size(1182, 744);
            Load += MonthlyForecastForm_Load;
            ((System.ComponentModel.ISupportInitialize)btnPreviousMonth).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnNextMonth).EndInit();
            panelInfoBar.ResumeLayout(false);
            panelLoadingOverlay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureLoadingSpinner).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanelCalendar;
        private CustomControls.CustomPanel customPanel2;
        private Label label1;
        private CustomControls.CustomPanel customPanel7;
        private Label label7;
        private CustomControls.CustomPanel customPanel6;
        private Label label6;
        private CustomControls.CustomPanel customPanel5;
        private Label label5;
        private CustomControls.CustomPanel customPanel4;
        private Label label4;
        private CustomControls.CustomPanel customPanel3;
        private Label label3;
        private CustomControls.CustomPanel customPanel1;
        private Label label2;
        private Panel panel1;
        private CustomControls.CustomPanel customPanel8;
        private Label labelMonth;
        private CustomControls.CustomPanel customPanel9;
        private CustomControls.CustomPanel customPanel10;
        private PictureBox btnPreviousMonth;
        private PictureBox btnNextMonth;
        private Panel panelInfoBar;
        private Label labelInfoBarMessage;
        private FontAwesome.Sharp.IconButton buttonCloseInfoBar;
        private FontAwesome.Sharp.IconButton iconInfoBar;
        private Panel panelLoadingOverlay;
        private PictureBox pictureLoadingSpinner;
    }
}
