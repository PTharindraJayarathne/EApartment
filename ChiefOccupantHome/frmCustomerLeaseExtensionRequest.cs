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
using System.Xml.Linq;

namespace ChiefOccupantHome
{
    public partial class frmCustomerLeaseExtensionRequest : Form
    {
        // Connection 
        SqlConnection con = new SqlConnection(Properties.Settings.Default.EApartmentConnectionString);
        SqlCommand cmd = new SqlCommand();
        public frmCustomerLeaseExtensionRequest()
        {
            InitializeComponent();
        }

        // To valid data
        private bool DataValid()
        {
            if (txtCH.Text == "")
            {
                MessageBox.Show("Enter your Chief Occupant ID");
                return false;
            }
            if (txtLAID.Text == "")
            {
                MessageBox.Show("Enter your Lease Agreement ID");
                return false;
            }
            if (txtAPID.Text == "")
            {
                MessageBox.Show("Enter your Apartment ID");
                return false;
            }
            if (txtAPstate.Text == "")
            {
                MessageBox.Show("Enter Apartment State");
                return false;
            }
            if (txtLperiod.Text == "")
            {
                MessageBox.Show("Enter your Leasing Period");
                return false;
            }


            return true;
        }
        // To clear the text boxes
        private void ClearFields()
        {
            txtCH.Text = "";
            txtLAID.Text = "";
            txtAPID.Text = "";
            txtAPstate.Text = "";
            txtLperiod.Text = "";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {

            ClearFields();

            LeaseAgreementUC leaseAgreementUC = new LeaseAgreementUC();
            leaseAgreementUC.Show();
            this.Hide();
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            if (DataValid())
            {
                con.Open();
                cmd = new SqlCommand("Insert into LeaseExpansionRequest_Table values " +
                    "(@LA_ID,@CH_ID,@AP_ID,@ApartmentState,@RequestedDate,@LeasingPeriod) ", con);
                cmd.Parameters.AddWithValue("@LA_ID", txtLAID.Text);
                cmd.Parameters.AddWithValue("@CH_ID", txtCH.Text);
                cmd.Parameters.AddWithValue("@AP_ID", txtAPID.Text);
                cmd.Parameters.AddWithValue("@ApartmentState", txtAPstate.Text);
                //dtpLEARequest.Value.ToString("yyyy-MM-dd");
                cmd.Parameters.AddWithValue("@RequestedDate", dtpLEARequest.Value);
                cmd.Parameters.AddWithValue("@LeasingPeriod", txtLperiod.Text);


                cmd.ExecuteNonQuery();


                con.Close();
                MessageBox.Show("Request Saved Successfully", "Message", MessageBoxButtons.OK);

                ClearFields();
                
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }
    }
}
