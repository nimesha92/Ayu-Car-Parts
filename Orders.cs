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
    public partial class Orders : Form
    {
        public Orders()
        {
            InitializeComponent();
        }

        private void cmbVt_SelectedIndexChanged(object sender, EventArgs e)
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
            cmd.Parameters.AddWithValue("@Quantity",int.Parse(txtqun.Text));
            cmd.Parameters.AddWithValue("@OrderType",cmbVt.Text);
            cmd.Parameters.AddWithValue("@Telephone",int.Parse(txtTel.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully inserted");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\"Ayubo Drive Final\";Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("update Orders set CustomerName=@CustomerName,Address=@Address,Quantity=@Quantity,VehicleType=@VehicleType where ID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(txtID.Text));
            cmd.Parameters.AddWithValue("@CustomerName", txtNam1.Text);
            cmd.Parameters.AddWithValue("@Address", txtAdd.Text);
            cmd.Parameters.AddWithValue("@Quantity",int.Parse( txtqun.Text));
            cmd.Parameters.AddWithValue("@OrderType", cmbVt.Text);
            cmd.Parameters.AddWithValue("@Telephone",int.Parse( cmbVt.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Updated");

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            CustomerDashboard form1 = new CustomerDashboard();
            form1.Show();
            this.Hide();
        }

        private void txtNam1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-KCKGKPJ\\MSSQLSERVER01;Initial Catalog=\"Ayubo Drive Final\";Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Orders", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
    }
}
