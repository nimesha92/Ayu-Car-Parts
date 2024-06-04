using Ayubo_drive_Final;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportAppServer;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace Ayubo_drive_Final
{
    public partial class Customers : Form
    {

        public Customers()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-KCKGKPJ\\MSSQLSERVER01;Initial Catalog=\"Ayubo Drive Final\";Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("update Customers set FirstName=@FirstName,LastName=@LastName,Address=@Address,VehicleType=@VehicleType where ID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(txtID.Text));
            cmd.Parameters.AddWithValue("@FirstName", txtNam1.Text);
            cmd.Parameters.AddWithValue("@LastName", txtNam2.Text);
            cmd.Parameters.AddWithValue("@Address", txtAdd.Text);
            cmd.Parameters.AddWithValue("@VehicleType", cmbVt.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Updated");

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-KCKGKPJ\\MSSQLSERVER01;Initial Catalog=\"Ayubo Drive Final\";Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete Customers where Id=@Id", con);
            cmd.Parameters.AddWithValue("@ID", txtID.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Deleted");

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-KCKGKPJ\\MSSQLSERVER01;Initial Catalog=\"Ayubo Drive Final\";Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Customers values (@ID,@FirstName,@LastName,@Address,@VehicleType)", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(txtID.Text));
            cmd.Parameters.AddWithValue("@FirstName", txtNam1.Text);
            cmd.Parameters.AddWithValue("@LastName", txtNam2.Text);
            cmd.Parameters.AddWithValue("@Address", txtAdd.Text);
            cmd.Parameters.AddWithValue("@VehicleType", cmbVt.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Inserted");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-KCKGKPJ\\MSSQLSERVER01;Initial Catalog=\"Ayubo Drive Final\";Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Customers", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void cmbVt_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Login form1 = new Login();
            form1.Show();
            this.Hide();

        }

        private void txtNam2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtTele_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNam1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAdd_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtNam1.Clear();
            txtNam2.Clear();
            txtAdd.Clear();
            cmbVt.SelectedIndex = -1;



        }







        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form4 fW = new Form4();
            fW.Show();

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-KCKGKPJ\\MSSQLSERVER01;Initial Catalog=\"Ayubo Drive Final\";Integrated Security=True;Encrypt=False");
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("Select * from Customers", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "Customers");
            CrystalReport9 a = new CrystalReport9();
            fW.crystalReportViewer1.ReportSource = a;
            fW.crystalReportViewer1.Refresh();
            con.Close();
        }
    }
    }
