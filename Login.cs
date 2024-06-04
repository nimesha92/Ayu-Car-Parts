using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ayubo_drive_Final
{
    public partial class Login : Form
    {
        // Define username and password
        private string username = "admin";
        private string password = "password";

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Get input from text boxes
            string inputUsername = txtUsername.Text;
            string inputPassword = txtPassword.Text;

            // Check if input matches username and password
            if (inputUsername == username && inputPassword == password)
            {
                MessageBox.Show("Login successful!");
                // Navigate to menu page
                OpenMenuForm();
            }
            else
            {
                MessageBox.Show("Incorrect username or password. Please try again.");
            }
        }

        private void OpenMenuForm()
        {
          
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnIogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // For simplicity, using hardcoded values for username and password
            if (username == "esoft" && password == "123")
            {
                // Hide the login form
                this.Hide();

                // Show the menu form
                CustomerDashboard form1 = new CustomerDashboard();
                form1.Show();// Use Show() if you don't want the menu form to be modal
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.");
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Customers form1 = new Customers();
            form1.Show();
            this.Hide();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Collect data from the form
            string email = txtUserEmail.Text;
            string password = txtUserPassword.Text;

            // Validate inputs (basic validation)
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill in both fields.");
                return;
            }

            // Verify credentials against database
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-KCKGKPJ\\MSSQLSERVER01;Initial Catalog=\"Ayubo Drive Final\";Integrated Security=True;Encrypt=False");

                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email AND Password = @Password";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password);

                        int userCount = (int)cmd.ExecuteScalar();
                        if (userCount > 0)
                        {
                            //MessageBox.Show("Login successful.");
                            // Proceed to the next step in your application
                            Customerdash form1 = new Customerdash();
                            form1.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid email or password.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Register form1 = new Register();
            form1.Show();
            this.Hide();
        }
    }
}