using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ayubo_drive_Final
{
    public partial class CustomerDashboard : Form
    {
        public CustomerDashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           Vehicles form1 = new Vehicles();
            form1.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login form1 = new Login();
            form1.Show();
            this.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Orders form1 = new Orders();
            form1.Show();
            this.Hide();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
           CarParts form1 = new CarParts();
            form1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Customers form1 = new Customers();
            form1.Show();
            this.Hide();
        }
    }
}
