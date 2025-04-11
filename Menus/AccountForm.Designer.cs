namespace WeatherSphereV4
{
    partial class AccountForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountForm));
            panelLoadingOverlay = new Panel();
            pictureLoadingSpinner = new PictureBox();
            panelInfoBar = new Panel();
            labelInfoBarMessage = new Label();
            buttonCloseInfoBar = new FontAwesome.Sharp.IconButton();
            iconInfoBar = new FontAwesome.Sharp.IconButton();
            panel1 = new Panel();
            buttonDeleteAccount = new ReaLTaiizor.Controls.CyberButton();
            buttonLogout = new ReaLTaiizor.Controls.CyberButton();
            groupBoxChangePassword = new GroupBox();
            buttonChangePassword = new WeatherSphereV4.CustomControls.CustomButton();
            textboxConfirmNewPassword = new TextBox();
            textboxNewPassword = new TextBox();
            textboxCurrentPassword = new TextBox();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            groupBox1 = new GroupBox();
            labelLastLoginDisplay = new Label();
            labelDateCreatedDisplay = new Label();
            labelUsernameDisplay = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panelLoadingOverlay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureLoadingSpinner).BeginInit();
            panelInfoBar.SuspendLayout();
            panel1.SuspendLayout();
            groupBoxChangePassword.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panelLoadingOverlay
            // 
            panelLoadingOverlay.Controls.Add(pictureLoadingSpinner);
            panelLoadingOverlay.Dock = DockStyle.Fill;
            panelLoadingOverlay.Location = new Point(20, 20);
            panelLoadingOverlay.Name = "panelLoadingOverlay";
            panelLoadingOverlay.Size = new Size(1142, 704);
            panelLoadingOverlay.TabIndex = 13;
            panelLoadingOverlay.Visible = false;
            // 
            // pictureLoadingSpinner
            // 
            pictureLoadingSpinner.Anchor = AnchorStyles.None;
            pictureLoadingSpinner.Image = (Image)resources.GetObject("pictureLoadingSpinner.Image");
            pictureLoadingSpinner.Location = new Point(339, 105);
            pictureLoadingSpinner.Name = "pictureLoadingSpinner";
            pictureLoadingSpinner.Size = new Size(498, 498);
            pictureLoadingSpinner.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureLoadingSpinner.TabIndex = 13;
            pictureLoadingSpinner.TabStop = false;
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
            panelInfoBar.TabIndex = 43;
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
            // panel1
            // 
            panel1.Controls.Add(buttonDeleteAccount);
            panel1.Controls.Add(buttonLogout);
            panel1.Controls.Add(groupBoxChangePassword);
            panel1.Controls.Add(groupBox1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(20, 20);
            panel1.Name = "panel1";
            panel1.Size = new Size(1142, 704);
            panel1.TabIndex = 14;
            // 
            // buttonDeleteAccount
            // 
            buttonDeleteAccount.Alpha = 20;
            buttonDeleteAccount.BackColor = Color.Transparent;
            buttonDeleteAccount.Background = true;
            buttonDeleteAccount.Background_WidthPen = 4F;
            buttonDeleteAccount.BackgroundPen = true;
            buttonDeleteAccount.ColorBackground = Color.FromArgb(37, 52, 68);
            buttonDeleteAccount.ColorBackground_1 = Color.Red;
            buttonDeleteAccount.ColorBackground_2 = Color.FromArgb(25, 25, 50);
            buttonDeleteAccount.ColorBackground_Pen = Color.FromArgb(29, 200, 238);
            buttonDeleteAccount.ColorLighting = Color.FromArgb(29, 200, 238);
            buttonDeleteAccount.ColorPen_1 = Color.FromArgb(37, 52, 68);
            buttonDeleteAccount.ColorPen_2 = Color.FromArgb(41, 63, 86);
            buttonDeleteAccount.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            buttonDeleteAccount.Effect_1 = true;
            buttonDeleteAccount.Effect_1_ColorBackground = Color.FromArgb(29, 200, 238);
            buttonDeleteAccount.Effect_1_Transparency = 25;
            buttonDeleteAccount.Effect_2 = true;
            buttonDeleteAccount.Effect_2_ColorBackground = Color.White;
            buttonDeleteAccount.Effect_2_Transparency = 20;
            buttonDeleteAccount.Enabled = false;
            buttonDeleteAccount.Font = new Font("Arial", 11F);
            buttonDeleteAccount.ForeColor = Color.FromArgb(245, 245, 245);
            buttonDeleteAccount.Lighting = true;
            buttonDeleteAccount.LinearGradient_Background = true;
            buttonDeleteAccount.LinearGradientPen = false;
            buttonDeleteAccount.Location = new Point(559, 528);
            buttonDeleteAccount.Name = "buttonDeleteAccount";
            buttonDeleteAccount.PenWidth = 15;
            buttonDeleteAccount.Rounding = true;
            buttonDeleteAccount.RoundingInt = 70;
            buttonDeleteAccount.Size = new Size(221, 75);
            buttonDeleteAccount.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            buttonDeleteAccount.TabIndex = 6;
            buttonDeleteAccount.Tag = "Cyber";
            buttonDeleteAccount.TextButton = "Delete Account";
            buttonDeleteAccount.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            buttonDeleteAccount.Timer_Effect_1 = 5;
            buttonDeleteAccount.Timer_RGB = 300;
            buttonDeleteAccount.Click += buttonDeleteAccount_Click;
            // 
            // buttonLogout
            // 
            buttonLogout.Alpha = 20;
            buttonLogout.BackColor = Color.Transparent;
            buttonLogout.Background = true;
            buttonLogout.Background_WidthPen = 4F;
            buttonLogout.BackgroundPen = true;
            buttonLogout.ColorBackground = Color.FromArgb(37, 52, 68);
            buttonLogout.ColorBackground_1 = Color.Navy;
            buttonLogout.ColorBackground_2 = Color.FromArgb(25, 25, 50);
            buttonLogout.ColorBackground_Pen = Color.FromArgb(29, 200, 238);
            buttonLogout.ColorLighting = Color.FromArgb(29, 200, 238);
            buttonLogout.ColorPen_1 = Color.FromArgb(37, 52, 68);
            buttonLogout.ColorPen_2 = Color.FromArgb(41, 63, 86);
            buttonLogout.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            buttonLogout.Effect_1 = true;
            buttonLogout.Effect_1_ColorBackground = Color.FromArgb(29, 200, 238);
            buttonLogout.Effect_1_Transparency = 25;
            buttonLogout.Effect_2 = true;
            buttonLogout.Effect_2_ColorBackground = Color.White;
            buttonLogout.Effect_2_Transparency = 20;
            buttonLogout.Enabled = false;
            buttonLogout.Font = new Font("Arial", 11F);
            buttonLogout.ForeColor = Color.FromArgb(245, 245, 245);
            buttonLogout.Lighting = true;
            buttonLogout.LinearGradient_Background = true;
            buttonLogout.LinearGradientPen = false;
            buttonLogout.Location = new Point(808, 528);
            buttonLogout.Name = "buttonLogout";
            buttonLogout.PenWidth = 15;
            buttonLogout.Rounding = true;
            buttonLogout.RoundingInt = 70;
            buttonLogout.Size = new Size(221, 75);
            buttonLogout.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            buttonLogout.TabIndex = 5;
            buttonLogout.Tag = "Cyber";
            buttonLogout.TextButton = "Logout";
            buttonLogout.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            buttonLogout.Timer_Effect_1 = 5;
            buttonLogout.Timer_RGB = 300;
            buttonLogout.Click += buttonLogout_Click;
            // 
            // groupBoxChangePassword
            // 
            groupBoxChangePassword.Controls.Add(buttonChangePassword);
            groupBoxChangePassword.Controls.Add(textboxConfirmNewPassword);
            groupBoxChangePassword.Controls.Add(textboxNewPassword);
            groupBoxChangePassword.Controls.Add(textboxCurrentPassword);
            groupBoxChangePassword.Controls.Add(label7);
            groupBoxChangePassword.Controls.Add(label8);
            groupBoxChangePassword.Controls.Add(label9);
            groupBoxChangePassword.Location = new Point(659, 57);
            groupBoxChangePassword.Name = "groupBoxChangePassword";
            groupBoxChangePassword.Size = new Size(370, 323);
            groupBoxChangePassword.TabIndex = 1;
            groupBoxChangePassword.TabStop = false;
            // 
            // buttonChangePassword
            // 
            buttonChangePassword.BackColor = Color.FromArgb(255, 192, 192);
            buttonChangePassword.BorderColor = Color.PaleVioletRed;
            buttonChangePassword.BorderRadius = 18;
            buttonChangePassword.BorderSize = 0;
            buttonChangePassword.Color1 = Color.Navy;
            buttonChangePassword.Color2 = Color.FromArgb(25, 25, 50);
            buttonChangePassword.ColorOrientation = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            buttonChangePassword.Enabled = false;
            buttonChangePassword.FlatAppearance.BorderSize = 0;
            buttonChangePassword.FlatStyle = FlatStyle.Flat;
            buttonChangePassword.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonChangePassword.ForeColor = Color.White;
            buttonChangePassword.GlowColor = Color.FromArgb(128, 255, 255, 255);
            buttonChangePassword.GlowSize = 10;
            buttonChangePassword.Location = new Point(87, 268);
            buttonChangePassword.Name = "buttonChangePassword";
            buttonChangePassword.ShadowColor = Color.Gray;
            buttonChangePassword.ShadowSize = 5;
            buttonChangePassword.Size = new Size(194, 37);
            buttonChangePassword.TabIndex = 21;
            buttonChangePassword.Text = "Change Password";
            buttonChangePassword.UseVisualStyleBackColor = false;
            buttonChangePassword.Click += buttonChangePassword_Click;
            // 
            // textboxConfirmNewPassword
            // 
            textboxConfirmNewPassword.BackColor = Color.FromArgb(31, 48, 62);
            textboxConfirmNewPassword.BorderStyle = BorderStyle.None;
            textboxConfirmNewPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textboxConfirmNewPassword.ForeColor = Color.Gainsboro;
            textboxConfirmNewPassword.Location = new Point(19, 228);
            textboxConfirmNewPassword.Name = "textboxConfirmNewPassword";
            textboxConfirmNewPassword.PasswordChar = '●';
            textboxConfirmNewPassword.PlaceholderText = "Confirm Password";
            textboxConfirmNewPassword.Size = new Size(329, 24);
            textboxConfirmNewPassword.TabIndex = 8;
            textboxConfirmNewPassword.UseSystemPasswordChar = true;
            // 
            // textboxNewPassword
            // 
            textboxNewPassword.BackColor = Color.FromArgb(31, 48, 62);
            textboxNewPassword.BorderStyle = BorderStyle.None;
            textboxNewPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textboxNewPassword.ForeColor = Color.Gainsboro;
            textboxNewPassword.Location = new Point(19, 145);
            textboxNewPassword.Name = "textboxNewPassword";
            textboxNewPassword.PasswordChar = '●';
            textboxNewPassword.PlaceholderText = "New Password";
            textboxNewPassword.Size = new Size(329, 24);
            textboxNewPassword.TabIndex = 7;
            textboxNewPassword.UseSystemPasswordChar = true;
            // 
            // textboxCurrentPassword
            // 
            textboxCurrentPassword.BackColor = Color.FromArgb(31, 48, 62);
            textboxCurrentPassword.BorderStyle = BorderStyle.None;
            textboxCurrentPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textboxCurrentPassword.ForeColor = Color.Gainsboro;
            textboxCurrentPassword.Location = new Point(21, 65);
            textboxCurrentPassword.Name = "textboxCurrentPassword";
            textboxCurrentPassword.PasswordChar = '●';
            textboxCurrentPassword.PlaceholderText = "Current Password";
            textboxCurrentPassword.Size = new Size(329, 24);
            textboxCurrentPassword.TabIndex = 6;
            textboxCurrentPassword.UseSystemPasswordChar = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Gainsboro;
            label7.Location = new Point(19, 191);
            label7.Name = "label7";
            label7.Size = new Size(209, 25);
            label7.TabIndex = 2;
            label7.Text = "Confirm New Password:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Gainsboro;
            label8.Location = new Point(19, 107);
            label8.Name = "label8";
            label8.Size = new Size(137, 25);
            label8.TabIndex = 1;
            label8.Text = "New Password:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.Gainsboro;
            label9.Location = new Point(19, 27);
            label9.Name = "label9";
            label9.Size = new Size(163, 25);
            label9.TabIndex = 0;
            label9.Text = "Current Password:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(labelLastLoginDisplay);
            groupBox1.Controls.Add(labelDateCreatedDisplay);
            groupBox1.Controls.Add(labelUsernameDisplay);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(85, 57);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(370, 323);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // labelLastLoginDisplay
            // 
            labelLastLoginDisplay.BackColor = Color.FromArgb(31, 48, 62);
            labelLastLoginDisplay.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelLastLoginDisplay.ForeColor = Color.Gainsboro;
            labelLastLoginDisplay.Location = new Point(19, 255);
            labelLastLoginDisplay.Name = "labelLastLoginDisplay";
            labelLastLoginDisplay.Size = new Size(331, 38);
            labelLastLoginDisplay.TabIndex = 5;
            labelLastLoginDisplay.Text = "Loading...";
            // 
            // labelDateCreatedDisplay
            // 
            labelDateCreatedDisplay.BackColor = Color.FromArgb(31, 48, 62);
            labelDateCreatedDisplay.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelDateCreatedDisplay.ForeColor = Color.Gainsboro;
            labelDateCreatedDisplay.Location = new Point(19, 158);
            labelDateCreatedDisplay.Name = "labelDateCreatedDisplay";
            labelDateCreatedDisplay.Size = new Size(331, 38);
            labelDateCreatedDisplay.TabIndex = 4;
            labelDateCreatedDisplay.Text = "Loading...";
            // 
            // labelUsernameDisplay
            // 
            labelUsernameDisplay.BackColor = Color.FromArgb(31, 48, 62);
            labelUsernameDisplay.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelUsernameDisplay.ForeColor = Color.Gainsboro;
            labelUsernameDisplay.Location = new Point(19, 65);
            labelUsernameDisplay.Name = "labelUsernameDisplay";
            labelUsernameDisplay.Size = new Size(331, 38);
            labelUsernameDisplay.TabIndex = 3;
            labelUsernameDisplay.Text = "Loading...";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Gainsboro;
            label3.Location = new Point(19, 218);
            label3.Name = "label3";
            label3.Size = new Size(97, 25);
            label3.TabIndex = 2;
            label3.Text = "Last Login";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Gainsboro;
            label2.Location = new Point(19, 120);
            label2.Name = "label2";
            label2.Size = new Size(136, 25);
            label2.TabIndex = 1;
            label2.Text = "Member Since:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Gainsboro;
            label1.Location = new Point(19, 27);
            label1.Name = "label1";
            label1.Size = new Size(100, 25);
            label1.TabIndex = 0;
            label1.Text = "Username:";
            // 
            // AccountForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(50, 50, 79);
            Controls.Add(panelInfoBar);
            Controls.Add(panel1);
            Controls.Add(panelLoadingOverlay);
            Name = "AccountForm";
            Padding = new Padding(20);
            Size = new Size(1182, 744);
            Load += AccountForm_Load;
            Resize += AccountForm_Resize;
            panelLoadingOverlay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureLoadingSpinner).EndInit();
            panelInfoBar.ResumeLayout(false);
            panel1.ResumeLayout(false);
            groupBoxChangePassword.ResumeLayout(false);
            groupBoxChangePassword.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelLoadingOverlay;
        private PictureBox pictureLoadingSpinner;
        private Panel panelInfoBar;
        private Label labelInfoBarMessage;
        private FontAwesome.Sharp.IconButton buttonCloseInfoBar;
        private FontAwesome.Sharp.IconButton iconInfoBar;
        private Panel panel1;
        private GroupBox groupBox1;
        private Label label1;
        private Label labelUsernameDisplay;
        private Label label3;
        private Label label2;
        private Label labelLastLoginDisplay;
        private Label labelDateCreatedDisplay;
        private GroupBox groupBoxChangePassword;
        private Label label4;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox textboxCurrentPassword;
        private TextBox textboxNewPassword;
        private TextBox textboxConfirmNewPassword;
        private CustomControls.CustomButton buttonChangePassword;
        private ReaLTaiizor.Controls.CyberButton buttonLogout;
        private ReaLTaiizor.Controls.CyberButton buttonDeleteAccount;
    }
}
