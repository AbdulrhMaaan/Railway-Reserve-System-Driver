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
    public partial class Edit_trainTime : Form
    {
        public Edit_trainTime()
        {
            InitializeComponent();

        }

        private void Confirm_Button_Click(object sender, EventArgs e)
        {
            
            bool write = true;
            if (TrainBox.Text == "" && TimeBox.Text == "")
            {
                MessageBox.Show("Invalid Username or Password ");
                write = false;
            }
            if (TrainBox.Text != "" && TimeBox.Text == "")
            {
                MessageBox.Show("Invalid Username or Password ");
                write = false;
            }
            if (TrainBox.Text != "" && TimeBox.Text == "")
            { 
                MessageBox.Show("Invalid Username or Password ");
                write = false;       
            }
            if (write == true)
            {
                SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-8E90E5QS;Initial Catalog=Railway Reservation System;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("edit_train", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter d = cmd.Parameters.Add("@t_id", SqlDbType.Int);
                SqlParameter spm = cmd.Parameters.Add("@depart", SqlDbType.Time);
                cmd.Parameters["@t_id"].Value = TrainBox.Text;
                cmd.Parameters["@depart"].Value = TimeBox.Text;
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

        private void Edit_trainTime_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            DriverForm f1 = new DriverForm();
            f1.ShowDialog();
            
        }
    }
}