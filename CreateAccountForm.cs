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
using WeatherSphereV4.Services;

namespace WeatherSphereV4
{
    public partial class CreateAccountForm : CustomForm
    {
        public CreateAccountForm()
        {
            InitializeComponent();
        }

        private async void buttonLogin_Click(object sender, EventArgs e)
        {
            // --- 1. Get Input ---
            string username = textboxUsername.Text.Trim();
            string password = textboxPassword.Text; // No trim

            // --- 2. Validate Input ---
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please enter your username.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textboxUsername.Focus();
                return;
            }
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter your password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textboxPassword.Focus();
                return;
            }

            // --- 3. Attempt Login ---
            this.Cursor = Cursors.WaitCursor;
            buttonLogin.Enabled = false; // Disable button during processing

            try
            {
                // Ensure DatabaseManager is ready before calling
                if (!DatabaseManager.IsInitialized)
                {
                    MessageBox.Show("Database connection is not ready. Please restart the application.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Exit if DB isn't ready
                }

                // Get stored hash and UserID for the entered username
                var (storedHash, userID) = await DatabaseManager.GetUserLoginInfoAsync(username);

                // Check if user exists (hash is not null) and password is valid
                if (storedHash != null && userID.HasValue && DatabaseManager.VerifyPassword(password, storedHash))
                {
                    // --- SUCCESS ---
                    Console.WriteLine($"Login successful for user: {username}, UserID: {userID.Value}");

                    WeatherSharedData.SetLoggedInUser(userID.Value); // Store the UserID globally

                    // Proceed to main application
                    BaseForm baseForm = new BaseForm();
                    baseForm.Show();
                    this.Hide(); // Hide the login/create form
                }
                else
                {
                    // --- FAILURE ---
                    Console.WriteLine($"Login failed for user: {username}. User found: {userID.HasValue}, Password valid: {(storedHash != null && DatabaseManager.VerifyPassword(password, storedHash))}");
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Catch unexpected errors during the database operation or verification
                Console.WriteLine($"CRITICAL ERROR during login process for {username}: {ex.ToString()}");
                MessageBox.Show($"An unexpected error occurred during login: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Re-enable button and restore cursor regardless of outcome
                buttonLogin.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }

        private async void buttonCreateAccount_Click(object sender, EventArgs e)
        {
            // --- 1. Get Input ---
            string createUsername = textboxCreateUsername.Text.Trim();
            string createPassword = textboxCreatePassword.Text; // No trim on password
            string confirmPassword = textboxConfirmPassword.Text;

            // --- 2. Validate Input ---
            if (string.IsNullOrEmpty(createUsername))
            {
                MessageBox.Show("Please enter a username.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textboxCreateUsername.Focus();
                return;
            }
            if (string.IsNullOrEmpty(createPassword))
            {
                MessageBox.Show("Please enter a password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textboxCreatePassword.Focus();
                return;
            }
            if (createPassword != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textboxConfirmPassword.Focus();
                textboxConfirmPassword.SelectAll();
                return;
            }
            // Optional: Add password complexity rules here if desired

            // --- 3. Hash Password ---
            // Show some indication that work is being done (optional)
            this.Cursor = Cursors.WaitCursor;
            buttonCreateAccount.Enabled = false; // Disable button during processing

            string hashedPassword = DatabaseManager.HashPassword(createPassword);

            // --- 4. Attempt to Create User in Database ---
            bool success = false;
            try
            {
                // Ensure DatabaseManager is ready before calling
                if (!DatabaseManager.IsInitialized)
                {
                    MessageBox.Show("Database connection is not ready. Please restart the application.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Exit if DB isn't ready
                }

                success = await DatabaseManager.CreateUserAsync(createUsername, hashedPassword);

                if (success)
                {
                    MessageBox.Show("Account created successfully! Please log in.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Optionally clear fields and switch panels:
                    textboxCreateUsername.Clear();
                    textboxCreatePassword.Clear();
                    textboxConfirmPassword.Clear();
                    panelLogin.Visible = true; // Show login panel
                    panelCreate.Visible = false;
                }
                else
                {
                    // CreateUserAsync returns false if username already exists (or potentially other non-exception DB issues)
                    MessageBox.Show("Username already taken. Please choose a different username.", "Creation Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textboxCreateUsername.Focus();
                    textboxCreateUsername.SelectAll();
                }
            }
            catch (Exception ex)
            {
                // Catch unexpected errors during the database operation
                Console.WriteLine($"CRITICAL ERROR during CreateUserAsync call: {ex.ToString()}");
                MessageBox.Show($"An unexpected error occurred while creating the account: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Re-enable button and restore cursor regardless of outcome
                buttonCreateAccount.Enabled = true;
                this.Cursor = Cursors.Default;
            }

            // --- Remove the old code that just showed BaseForm ---
            // BaseForm baseForm = new BaseForm();
            // baseForm.Show();
            // this.Hide();
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
            else if(sender ==textboxConfirmPassword)
            {
                barConfirmPassword.BackColor = Color.FromArgb(18, 151, 244);
            }
            else if (sender == textboxPassword)
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
            else if (sender == textboxConfirmPassword)
            {
                barConfirmPassword.BackColor = Color.Gainsboro;
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
