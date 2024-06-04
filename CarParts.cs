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
    public partial class CarParts : Form
    {
        public CarParts()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-KCKGKPJ\\MSSQLSERVER01;Initial Catalog=\"Ayubo Drive Final\";Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Carparts values (@ItemID,@ItemName,@SoldItems)", con);
            cmd.Parameters.AddWithValue("@ItemID",(txtID.Text));
            cmd.Parameters.AddWithValue("@ItemName", txtNam.Text);
            cmd.Parameters.AddWithValue("@SoldItems", int.Parse(txtSold.Text));


            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Inserted");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-KCKGKPJ\\MSSQLSERVER01;Initial Catalog=\"Ayubo Drive Final\";Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete Carparts where Id=@Id", con);
            cmd.Parameters.AddWithValue("@ID", txtID.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Deleted");

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            CustomerDashboard form1 = new CustomerDashboard();
            form1.Show();
            this.Hide();
        }

        private void CarParts_Load(object sender, EventArgs e)
        {

        }
    }
}
