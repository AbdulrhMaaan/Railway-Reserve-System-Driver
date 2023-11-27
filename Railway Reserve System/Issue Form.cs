using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Railway_Reserve_System
{
    public partial class IssueForm : Form
    {
        public IssueForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool write = true;
            if (Trip_id.Text == "" && IssueBox.Text == "")
            {
                MessageBox.Show("Invalid Username or Password ");
                write = false;
            }
            if (Trip_id.Text != "" && IssueBox.Text == "")
            {
                MessageBox.Show("Invalid Username or Password ");
                write = false;
            }
            if (Trip_id.Text != "" && IssueBox.Text == "")
            {
                MessageBox.Show("Invalid Username or Password ");
                write = false;
            }
            if (write == true)
            {
                SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-8E90E5QS;Initial Catalog=Railway Reservation System;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("AddComplain", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter d = cmd.Parameters.Add("@trip_id", SqlDbType.Int);
                SqlParameter spm = cmd.Parameters.Add("@com", SqlDbType.VarChar);
                cmd.Parameters["@com"].Value = IssueBox.Text;
                cmd.Parameters["@trip_id"].Value = Trip_id.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Train Departure Time Changed Successfully.");
                this.Hide();
                DriverForm f1 = new DriverForm();
                f1.ShowDialog();
            }
            }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            DriverForm f1 = new DriverForm();
            f1.ShowDialog();
        }

        private void IssueForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            DriverForm f1 = new DriverForm();
            f1.ShowDialog();
        }

        private void IssueForm_Load(object sender, EventArgs e)
        {

        }

        private void IssueBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
