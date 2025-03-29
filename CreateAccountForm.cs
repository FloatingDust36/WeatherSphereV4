using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeatherSphereV4.CustomControls;

namespace WeatherSphereV4
{
    public partial class CreateAccountForm : CustomForm
    {
        public CreateAccountForm()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            // Show the main form
            BaseForm baseForm = new BaseForm();
            baseForm.Show();
            this.Hide();
        }

        private void buttonCreateAccount_Click(object sender, EventArgs e)
        {
            // Show the main form
            BaseForm baseForm = new BaseForm();
            baseForm.Show();
            this.Hide();
        }

        private void labelCreate_Click(object sender, EventArgs e)
        {
            panelCreate.Visible = true;
            panelLogin.Visible = false;
        }

        private void labelLogin_Click(object sender, EventArgs e)
        {
            panelLogin.Visible = true;
            panelCreate.Visible = false;
        }

        private void TextBox_MouseEnter(object sender, EventArgs e)
        {
            if (sender == textboxUsername)
            {
                barUsername.BackColor = Color.FromArgb(18, 151, 244);
            }
            else if (sender == textboxCreateUsername)
            {
                barCreateUsername.BackColor = Color.FromArgb(18, 151, 244);
            }
            else if(sender == textboxPassword)
            {
                barPassword.BackColor = Color.FromArgb(18, 151, 244);
            }
            else if (sender == textboxCreatePassword)
            {
                barCreatePassword.BackColor = Color.FromArgb(18, 151, 244);
            }
        }

        private void TextBox_MouseLeave(object sender, EventArgs e)
        {
            if (sender == textboxUsername)
            {
                barUsername.BackColor = Color.Gainsboro;
            }
            else if (sender == textboxCreateUsername)
            {
                barCreateUsername.BackColor = Color.Gainsboro;
            }
            else if (sender == textboxPassword)
            {
                barPassword.BackColor = Color.Gainsboro;
            }
            else if (sender == textboxCreatePassword)
            {
                barCreatePassword.BackColor = Color.Gainsboro;
            }
        }

        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonControl_MouseEnter(object sender, EventArgs e)
        {
            if (sender is PictureBox)
            {
                PictureBox pictureBox = (PictureBox)sender;
                pictureBox.BackColor = Color.FromArgb(18, 151, 244);
            }
        }

        private void buttonContol_MouseLeave(object sender, EventArgs e)
        {
            if (sender is PictureBox)
            {
                PictureBox pictureBox = (PictureBox)sender;
                pictureBox.BackColor = Color.Transparent;
            }
        }

        private void labelUnderline_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                label.Font = new Font(label.Font, FontStyle.Underline | FontStyle.Bold);
            }
        }

        private void labelUnderline_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                label.Font = new Font(label.Font, FontStyle.Regular | FontStyle.Bold);
            }
        }


    }
}
