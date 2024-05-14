using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace ChiefOccupantHome
{
    public partial class frmLogin : Form

    {   //Connection path

        SqlConnection con = new SqlConnection(Properties.Settings.Default.EApartmentConnectionString);
        SqlDataAdapter da;
        SqlCommand cmd = new SqlCommand();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            con.Open();
            //Selecting Data from database
            cmd = new SqlCommand("SELECT * FROM Login_Table WHERE " +
                "LgUsername ='" + txtUsername.Text + "' and LgPassword = '" + txtPassword.Text + "'", con);
            da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            //Coding for which form should show according to the user's role after user login
            int i = ds.Tables[0].Rows.Count;
            if (i == 1)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr[3].ToString() == "Admin")
                {
                    frmAdminDashboard AD = new frmAdminDashboard();
                    AD.Show();
                    this.Hide();

                }
                else if ((dr[3].ToString() == "Customer"))
                {
                    frmCustomerHome CH = new frmCustomerHome();
                    CH.Show();
                    this.Hide();
                }
            }
            // Data validation Message Box
            else
            {
                MessageBox.Show("Please check your Username or Pasword", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            con.Close();

        }
        // Exit from the application
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
