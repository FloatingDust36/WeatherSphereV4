namespace WeatherSphereV4
{
    partial class FavoritesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FavoritesForm));
            panel1 = new Panel();
            listBoxFavorites = new ListBox();
            panelControl = new Panel();
            buttonRemoveFavorite = new ReaLTaiizor.Controls.CyberButton();
            buttonGoToFavorite = new ReaLTaiizor.Controls.CyberButton();
            panelLoadingOverlay = new Panel();
            pictureLoadingSpinner = new PictureBox();
            panelInfoBar = new Panel();
            labelInfoBarMessage = new Label();
            buttonCloseInfoBar = new FontAwesome.Sharp.IconButton();
            iconInfoBar = new FontAwesome.Sharp.IconButton();
            panel1.SuspendLayout();
            panelControl.SuspendLayout();
            panelLoadingOverlay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureLoadingSpinner).BeginInit();
            panelInfoBar.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(listBoxFavorites);
            panel1.Controls.Add(panelControl);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(20, 20);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(2);
            panel1.Size = new Size(1142, 704);
            panel1.TabIndex = 0;
            // 
            // listBoxFavorites
            // 
            listBoxFavorites.BackColor = Color.FromArgb(25, 25, 50);
            listBoxFavorites.Dock = DockStyle.Fill;
            listBoxFavorites.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            listBoxFavorites.ForeColor = Color.Gainsboro;
            listBoxFavorites.FormattingEnabled = true;
            listBoxFavorites.ItemHeight = 30;
            listBoxFavorites.Location = new Point(2, 2);
            listBoxFavorites.Name = "listBoxFavorites";
            listBoxFavorites.Size = new Size(1138, 583);
            listBoxFavorites.TabIndex = 3;
            listBoxFavorites.SelectedIndexChanged += listBoxFavorites_SelectedIndexChanged;
            // 
            // panelControl
            // 
            panelControl.Controls.Add(buttonRemoveFavorite);
            panelControl.Controls.Add(buttonGoToFavorite);
            panelControl.Dock = DockStyle.Bottom;
            panelControl.Location = new Point(2, 585);
            panelControl.Name = "panelControl";
            panelControl.Size = new Size(1138, 117);
            panelControl.TabIndex = 2;
            // 
            // buttonRemoveFavorite
            // 
            buttonRemoveFavorite.Alpha = 20;
            buttonRemoveFavorite.BackColor = Color.Transparent;
            buttonRemoveFavorite.Background = true;
            buttonRemoveFavorite.Background_WidthPen = 4F;
            buttonRemoveFavorite.BackgroundPen = true;
            buttonRemoveFavorite.ColorBackground = Color.FromArgb(37, 52, 68);
            buttonRemoveFavorite.ColorBackground_1 = Color.Navy;
            buttonRemoveFavorite.ColorBackground_2 = Color.FromArgb(25, 25, 50);
            buttonRemoveFavorite.ColorBackground_Pen = Color.FromArgb(29, 200, 238);
            buttonRemoveFavorite.ColorLighting = Color.FromArgb(29, 200, 238);
            buttonRemoveFavorite.ColorPen_1 = Color.FromArgb(37, 52, 68);
            buttonRemoveFavorite.ColorPen_2 = Color.FromArgb(41, 63, 86);
            buttonRemoveFavorite.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            buttonRemoveFavorite.Effect_1 = true;
            buttonRemoveFavorite.Effect_1_ColorBackground = Color.FromArgb(29, 200, 238);
            buttonRemoveFavorite.Effect_1_Transparency = 25;
            buttonRemoveFavorite.Effect_2 = true;
            buttonRemoveFavorite.Effect_2_ColorBackground = Color.White;
            buttonRemoveFavorite.Effect_2_Transparency = 20;
            buttonRemoveFavorite.Enabled = false;
            buttonRemoveFavorite.Font = new Font("Arial", 11F);
            buttonRemoveFavorite.ForeColor = Color.FromArgb(245, 245, 245);
            buttonRemoveFavorite.Lighting = true;
            buttonRemoveFavorite.LinearGradient_Background = true;
            buttonRemoveFavorite.LinearGradientPen = false;
            buttonRemoveFavorite.Location = new Point(658, 21);
            buttonRemoveFavorite.Name = "buttonRemoveFavorite";
            buttonRemoveFavorite.PenWidth = 15;
            buttonRemoveFavorite.Rounding = true;
            buttonRemoveFavorite.RoundingInt = 70;
            buttonRemoveFavorite.Size = new Size(221, 75);
            buttonRemoveFavorite.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            buttonRemoveFavorite.TabIndex = 4;
            buttonRemoveFavorite.Tag = "Cyber";
            buttonRemoveFavorite.TextButton = "Remove Favorite";
            buttonRemoveFavorite.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            buttonRemoveFavorite.Timer_Effect_1 = 5;
            buttonRemoveFavorite.Timer_RGB = 300;
            buttonRemoveFavorite.Click += buttonRemoveFavorite_Click;
            // 
            // buttonGoToFavorite
            // 
            buttonGoToFavorite.Alpha = 20;
            buttonGoToFavorite.BackColor = Color.Transparent;
            buttonGoToFavorite.Background = true;
            buttonGoToFavorite.Background_WidthPen = 4F;
            buttonGoToFavorite.BackgroundPen = true;
            buttonGoToFavorite.ColorBackground = Color.FromArgb(37, 52, 68);
            buttonGoToFavorite.ColorBackground_1 = Color.Navy;
            buttonGoToFavorite.ColorBackground_2 = Color.FromArgb(25, 25, 50);
            buttonGoToFavorite.ColorBackground_Pen = Color.FromArgb(29, 200, 238);
            buttonGoToFavorite.ColorLighting = Color.FromArgb(29, 200, 238);
            buttonGoToFavorite.ColorPen_1 = Color.FromArgb(37, 52, 68);
            buttonGoToFavorite.ColorPen_2 = Color.FromArgb(41, 63, 86);
            buttonGoToFavorite.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            buttonGoToFavorite.Effect_1 = true;
            buttonGoToFavorite.Effect_1_ColorBackground = Color.FromArgb(29, 200, 238);
            buttonGoToFavorite.Effect_1_Transparency = 25;
            buttonGoToFavorite.Effect_2 = true;
            buttonGoToFavorite.Effect_2_ColorBackground = Color.White;
            buttonGoToFavorite.Effect_2_Transparency = 20;
            buttonGoToFavorite.Enabled = false;
            buttonGoToFavorite.Font = new Font("Arial", 11F);
            buttonGoToFavorite.ForeColor = Color.FromArgb(245, 245, 245);
            buttonGoToFavorite.Lighting = true;
            buttonGoToFavorite.LinearGradient_Background = true;
            buttonGoToFavorite.LinearGradientPen = false;
            buttonGoToFavorite.Location = new Point(304, 21);
            buttonGoToFavorite.Name = "buttonGoToFavorite";
            buttonGoToFavorite.PenWidth = 15;
            buttonGoToFavorite.Rounding = true;
            buttonGoToFavorite.RoundingInt = 70;
            buttonGoToFavorite.Size = new Size(221, 75);
            buttonGoToFavorite.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            buttonGoToFavorite.TabIndex = 3;
            buttonGoToFavorite.Tag = "Cyber";
            buttonGoToFavorite.TextButton = "Go To Location";
            buttonGoToFavorite.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            buttonGoToFavorite.Timer_Effect_1 = 5;
            buttonGoToFavorite.Timer_RGB = 300;
            buttonGoToFavorite.Click += buttonGoToFavorite_Click;
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
            pictureLoadingSpinner.Location = new Point(796, 320);
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
            // FavoritesForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(50, 50, 79);
            Controls.Add(panelInfoBar);
            Controls.Add(panel1);
            Controls.Add(panelLoadingOverlay);
            Name = "FavoritesForm";
            Padding = new Padding(20);
            Size = new Size(1182, 744);
            Load += FavoritesForm_Load;
            panel1.ResumeLayout(false);
            panelControl.ResumeLayout(false);
            panelLoadingOverlay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureLoadingSpinner).EndInit();
            panelInfoBar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private ReaLTaiizor.Controls.CyberButton buttonGoToFavorite;
        private Panel panelControl;
        private ReaLTaiizor.Controls.CyberButton buttonRemoveFavorite;
        private Panel panelLoadingOverlay;
        private PictureBox pictureLoadingSpinner;
        private Panel panelInfoBar;
        private Label labelInfoBarMessage;
        private FontAwesome.Sharp.IconButton buttonCloseInfoBar;
        private FontAwesome.Sharp.IconButton iconInfoBar;
        private ListBox listBoxFavorites;
    }
}
