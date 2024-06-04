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
    public partial class Vehicles : Form
    {
        public Vehicles()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-KCKGKPJ\\MSSQLSERVER01;Initial Catalog=\"Ayubo Drive Final\";Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into Vehicles values (@ID,@Name,@VehicleType )", con);
            cmd.Parameters.AddWithValue("@ID",int.Parse(txtID.Text));
            cmd.Parameters.AddWithValue("@Name", txtNam1.Text);
            cmd.Parameters.AddWithValue("@VehicleType", textBox1.Text);
           
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Inserted");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-KCKGKPJ\\MSSQLSERVER01;Initial Catalog=\"Ayubo Drive Final\";Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("update Vehicles set Name=@Name,VehicleType=@VehicleType where ID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(txtID.Text));
            cmd.Parameters.AddWithValue("@Name", txtNam1.Text);
            cmd.Parameters.AddWithValue("@VehicleType", textBox1.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Updated");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-KCKGKPJ\\MSSQLSERVER01;Initial Catalog=\"Ayubo Drive Final\";Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Vehicles", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-KCKGKPJ\\MSSQLSERVER01;Initial Catalog=\"Ayubo Drive Final\";Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete Vehicles where CustomerId=@CustomerId", con);
            cmd.Parameters.AddWithValue("@ID", txtID.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Deleted");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            CustomerDashboard form1 = new CustomerDashboard();
            form1.Show();
            this.Hide();
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
