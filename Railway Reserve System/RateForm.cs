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
    public partial class RateForm : Form
    {
        public RateForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool write = true;
            if (ID.Text == "" && Rate.Text == "")
            {
                MessageBox.Show("Invalid Username or Password ");
                write = false;
            }
            if (ID.Text != "" && Rate.Text == "")
            {
                MessageBox.Show("Invalid Username or Password ");
                write = false;
            }
            if (ID.Text != "" && Rate.Text == "")
            {
                MessageBox.Show("Invalid Username or Password ");
                write = false;
            }
            if (write == true)
            {
                SqlConnection con = new SqlConnection(@"Data Source=3RAFA\ABDO;Initial Catalog=Driver;Integrated Security=True");
                con.Open();
                string UpdateString = @"update Driver set user_rating=@userRate where Ticket_id=@ticket_id";
                SqlCommand cmd = new SqlCommand(UpdateString, con);
                cmd.CommandType = CommandType.Text;
                SqlParameter p1 = new SqlParameter("@userRate", Rate);
                cmd.Parameters.Add(p1);
                SqlParameter p2 = new SqlParameter("@ticket_id", ID);
                cmd.Parameters.Add(p2);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Thanks For Rating");
                this.Hide();
                DriverForm f = new DriverForm();
                f.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            DriverForm f1 = new DriverForm();
            f1.ShowDialog();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            DriverForm f1 = new DriverForm();
            f1.ShowDialog();
        }
    }
}