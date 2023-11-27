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
    public partial class DriverForm : Form
    {
        public DriverForm()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-8E90E5QS;Initial Catalog=Railway Reservation System;Integrated Security=True");
            con.Open();
            //Salary--------------------------------------------------------------------//
            SqlCommand salarycmd = new SqlCommand("getSalary",con);
            salarycmd.CommandType = CommandType.StoredProcedure;
            SqlParameter d = salarycmd.Parameters.Add("@driver_id",SqlDbType.Int);
            SqlParameter spm = salarycmd.Parameters.Add("@@salary", SqlDbType.Float);
            spm.Direction = ParameterDirection.Output;
            salarycmd.Parameters["@driver_id"].Value = 1;
            //Begin Shift----------------------------------------------------------//
            SqlCommand ShiftBcmd = new SqlCommand("getShiftb", con);
            ShiftBcmd.CommandType = CommandType.StoredProcedure;
            SqlParameter g = ShiftBcmd.Parameters.Add("@driver_id", SqlDbType.Int);
            SqlParameter s = ShiftBcmd.Parameters.Add("@@begin", SqlDbType.Time);
            s.Direction = ParameterDirection.Output;
            ShiftBcmd.Parameters["@driver_id"].Value = 1;
            //End Shift---------------------------------------------------------------//
            SqlCommand ShiftEcmd = new SqlCommand("getShiftend", con);
            ShiftEcmd.CommandType = CommandType.StoredProcedure;
            SqlParameter a = ShiftEcmd.Parameters.Add("@driver_id", SqlDbType.Int);
            SqlParameter m = ShiftEcmd.Parameters.Add("@@end", SqlDbType.Time);
            m.Direction = ParameterDirection.Output;
            ShiftEcmd.Parameters["@driver_id"].Value = 1;
            //----------------------------------------------------------------------//
            ShiftBcmd.ExecuteNonQuery();
            ShiftEcmd.ExecuteNonQuery();
            salarycmd.ExecuteNonQuery();
            Salary.Text = Convert.ToString(salarycmd.Parameters["@@salary"].Value);
            Begin.Text = Convert.ToString(ShiftBcmd.Parameters["@@begin"].Value);
            End.Text = Convert.ToString(ShiftEcmd.Parameters["@@end"].Value);
            con.Close();
        }

        private void edit_Train_Click(object sender, EventArgs e)
        {
            this.Hide();
            Edit_trainTime f2 = new Edit_trainTime();
            f2.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
             IssueForm f3 = new IssueForm();
            f3.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            RateForm f = new RateForm();
            f.ShowDialog();
        }
    }
}
