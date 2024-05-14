using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChiefOccupantHome
{
    public partial class LeaseAgreementUC : UserControl
    {
        //Connection path
        SqlConnection con = new SqlConnection(Properties.Settings.Default.EApartmentConnectionString);
        SqlCommand cmd = new SqlCommand();
        public LeaseAgreementUC()
        {
            InitializeComponent();
        }

        private void btnLeaseExtensionRequestForm_Click(object sender, EventArgs e)
        {
            
            frmCustomerLeaseExtensionRequest fleq= new frmCustomerLeaseExtensionRequest();
            fleq.Show();
            
            
        }

        private void dgvPaymentDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("Select a.LA_ID, a.CH_ID, a.AP_ID, a.PS_ID, a.ReservatioFee, a.RefundableDeposite, a.StarttingDate, a.EndingDate, b.Rent, c.Fee " +
                " from LeaseAggrement_Table a,Apartment_Table b, ParkingSpace_Table c " +
                "where a.CH_ID=b.CH_ID and b.CH_ID= c.CH_ID  and a.CH_ID=@CH_ID and b.CH_ID=@CH_ID and c.CH_ID=@CH_ID or a.LA_ID=@LA_ID", con);
            cmd.Parameters.AddWithValue("@CH_ID", txtCH_ID.Text);
            cmd.Parameters.AddWithValue("@LA_ID", txtLA_ID.Text);

            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();

            if (sdr.Read())
            {
                txtCH_ID.Text = sdr["CH_ID"].ToString();
                txtLA_ID.Text = sdr["LA_ID"].ToString();
                txtAP_ID.Text = sdr["AP_ID"].ToString();
                txtPS_ID.Text = sdr["PS_ID"].ToString();
                txtReFee.Text = sdr["ReservatioFee"].ToString();
                txtReDeposit.Text = sdr["RefundableDeposite"].ToString();
                txtAgreeSD.Text = sdr["StarttingDate"].ToString();
                txtAgreeED.Text = sdr["EndingDate"].ToString();
                txtMRent.Text = sdr["Rent"].ToString();
                txtFee.Text = sdr["Fee"].ToString();

                MessageBox.Show("Data Search Successfully", "Message", MessageBoxButtons.OK);

            }
            else
            {
                MessageBox.Show("Please Enter CH_ID", "Message", MessageBoxButtons.OK);
            }

            con.Close();
        }

        private void btnPaymentDetails_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("Select * from ChiefOccupantPay_Table  where CH_ID= '" + txtCH_ID.Text + "' ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvPaymentDetails.DataSource = dt;

            foreach (DataGridViewRow row in dgvPaymentDetails.Rows)
            {
                row.ReadOnly = true;
            }

            dgvPaymentDetails.Columns[0].Width = 50;
            dgvPaymentDetails.Columns[1].Width = 50;
            dgvPaymentDetails.Columns[2].Width = 50;
            dgvPaymentDetails.Columns[3].Width = 75;
            dgvPaymentDetails.Columns[4].Width = 95;
            dgvPaymentDetails.Columns[5].Width = 50;
            dgvPaymentDetails.Columns[6].Width = 95;
            dgvPaymentDetails.Columns[7].Width = 75;
            
            con.Close();
        }
    }
}
