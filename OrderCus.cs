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
    public partial class OrderCus : Form
    {
        public OrderCus()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-KCKGKPJ\\MSSQLSERVER01;Initial Catalog=\"Ayubo Drive Final\";Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Orders values (@ID,@CustomerName,@Address,@Quantity,@OrderType,@Telephone)", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(txtID.Text));
            cmd.Parameters.AddWithValue("@CustomerName", txtNam1.Text);
            cmd.Parameters.AddWithValue("@Address", txtAdd.Text);
            cmd.Parameters.AddWithValue("@Quantity", int.Parse(txtqun.Text));
            cmd.Parameters.AddWithValue("@OrderType", cmbVt.Text);
            cmd.Parameters.AddWithValue("@Telephone", int.Parse(txtTele.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Ordered");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Connection string to your database
            string connectionString = "Data Source=DESKTOP-KCKGKPJ\\MSSQLSERVER01;Initial Catalog=\"Ayubo Drive Final\";Integrated Security=True;Encrypt=False";

            // Initialize the connection
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    con.Open();

                    // Define the command with a parameterized query
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Orders WHERE ID = @ID;", con);

                    // Parse the ID from the TextBox and add it as a parameter
                    int id;
                    if (int.TryParse(txtID.Text, out id))
                    {
                        cmd.Parameters.Add(new SqlParameter("@ID", id));

                        // Use SqlDataAdapter to fill the DataTable
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Set the DataGridView's DataSource to the DataTable
                        dataGridView1.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("Invalid ID format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (SqlException ex)
                {
                    // Handle SQL related exceptions
                    MessageBox.Show("SQL error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Ensure the connection is closed
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            CustomerDashboard form1 = new CustomerDashboard();
            form1.Show();
            this.Hide();
        }
    }
}
