using Microsoft.VisualBasic;
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

namespace ChiefOccupantHome
{
    public partial class AdminLeaseAgreementUC : UserControl
    {
        //Connection
        SqlConnection con = new SqlConnection(Properties.Settings.Default.EApartmentConnectionString);
        SqlCommand cmd = new SqlCommand();

        public AdminLeaseAgreementUC()
        {
            InitializeComponent();
        }

        // To clear the text boxes
        private void ClearFields()
        {
            txtCH_ID.Text = "";
            txtNIC.Text = "";
            txtpassportNo.Text = "";
            txtAP_ID.Text = "";
            txtRent.Text = "";
            txtPS_ID.Text = "";
            txtFee.Text = "";
            txtLA_ID.Text = "";
            txtRFe.Text = "";
            txtRDeposit.Text = "";
        }

        private bool DataValid()
        {
            if (txtCH_ID.Text == "")
            {
                MessageBox.Show("Enter Chief Occupant ID");
                return false;
            }
            if (txtAP_ID.Text == "")
            {
                MessageBox.Show("Enter Chief Occupant Apartment ID");
                return false;
            }
            if (txtPS_ID.Text == "")
            {
                MessageBox.Show("Enter Chief Occupant Parking Space ID");
                return false;
            }
            if (txtRFe.Text == "")
            {
                MessageBox.Show("Enter Reservation Fee");
                return false;
            }
            if (!Information.IsNumeric(txtRFe.Text))
            {
                MessageBox.Show("Please enter a numeric Value for Reservation Fee");
                return false;
            }
            if (txtRDeposit.Text == "")
            {
                MessageBox.Show("Enter Refundable Deposit");
                return false;
            }
            if (!Information.IsNumeric(txtRDeposit.Text))
            {
                MessageBox.Show("Please enter a numeric Value for Parking Space Fee");
                return false;
            }

            return true;
        }



        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        // To Search
        private void btnSearch_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("Select a.LA_ID, a.CH_ID, a.AP_ID, a.PS_ID, a.ReservatioFee, a.RefundableDeposite," +
                " a.StarttingDate,a.EndingDate, b.NIC, b.PassportNo, c.Rent, d.Fee " +
                " from LeaseAggrement_Table a,ChiefOccupant_Table b, Apartment_Table c, ParkingSpace_Table d " +
                "where a.CH_ID=b.CH_ID and a.CH_ID=c.CH_ID and a.CH_ID=d.CH_ID and b.CH_ID=c.CH_ID and b.CH_ID=d.CH_ID and c.CH_ID=d.CH_ID " +
                "and a.CH_ID=@CH_ID and b.CH_ID=@CH_ID and c.CH_ID=@CH_ID and d.CH_ID=@CH_ID or a.LA_ID=@LA_ID", con);
            cmd.Parameters.AddWithValue("@CH_ID", txtCH_ID.Text);
            cmd.Parameters.AddWithValue("@LA_ID", txtLA_ID.Text);

            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                txtLA_ID.Text = sdr["LA_ID"].ToString();
                txtCH_ID.Text = sdr["CH_ID"].ToString();
                txtAP_ID.Text = sdr["AP_ID"].ToString();
                txtPS_ID.Text = sdr["PS_ID"].ToString();
                txtRent.Text = sdr["Rent"].ToString();
                txtFee.Text = sdr["Fee"].ToString();
                txtRFe.Text = sdr["ReservatioFee"].ToString();
                txtRDeposit.Text = sdr["RefundableDeposite"].ToString();
                dtpAgED.Value = (DateTime)sdr["EndingDate"];
                dtpAgSD.Value = (DateTime)sdr["StarttingDate"];
                txtNIC.Text = sdr["NIC"].ToString();
                txtpassportNo.Text = sdr["PassportNo"].ToString();
                sdr.Close();


                MessageBox.Show("Data Search Successfully", "Message", MessageBoxButtons.OK);

            }
            else
            {
                MessageBox.Show("Please Enter CH_ID", "Message", MessageBoxButtons.OK);
            }

            con.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (DataValid())
            {
                con.Open();
                cmd = new SqlCommand("Insert into LeaseAggrement_Table values " +
                    "(@CH_ID,@AP_ID,@PS_ID,@ReservatioFee,@RefundableDeposite,@StarttingDate,@EndingDate) ", con);
                cmd.Parameters.AddWithValue("@CH_ID", txtCH_ID.Text);
                cmd.Parameters.AddWithValue("@AP_ID", txtAP_ID.Text);
                cmd.Parameters.AddWithValue("@PS_ID", txtPS_ID.Text);
                cmd.Parameters.AddWithValue("@ReservatioFee", txtRFe.Text);
                cmd.Parameters.AddWithValue("@RefundableDeposite", txtRDeposit.Text);
                cmd.Parameters.AddWithValue("@StarttingDate", dtpAgSD.Value);
                cmd.Parameters.AddWithValue("@EndingDate", dtpAgED.Value);
                cmd.ExecuteNonQuery();


                con.Close();
                MessageBox.Show("Data Saved Successfully", "Message", MessageBoxButtons.OK);

                ClearFields();
            }
        }

        //To Update records.
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (DataValid())
            {

                con.Open();
                cmd = new SqlCommand("Update LeaseAggrement_Table set CH_ID='" + txtCH_ID.Text + "', AP_ID='" + txtAP_ID.Text + "',PS_ID='" + txtPS_ID.Text + "'," +
                " ReservatioFee='" + txtRFe.Text + "', RefundableDeposite='" + txtRDeposit.Text + "', StarttingDate='" + dtpAgSD.Value + "', EndingDate='"+ dtpAgED.Value + "' where LA_ID= '" + txtLA_ID.Text + "' ", con);

                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Data Updated Successfully", "Message", MessageBoxButtons.OK);

                ClearFields();
            }
        }

        // To Delete Records.
        private void btnDelete_Click(object sender, EventArgs e)
        {
            con.Open();
            //Verify to delete the record
            var confirmResult = MessageBox.Show("Are you sure to delete this record ??",
                                   "Confirm Delete!!",
                                   MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                cmd = new SqlCommand("delete LeaseAggrement_Table " +
                    "where LA_ID=@LA_ID", con);
                cmd.Parameters.AddWithValue("@LA_ID", txtLA_ID.Text);
                cmd.ExecuteNonQuery();
            }
            con.Close();
            MessageBox.Show("Data Deleted Successfully", "Message", MessageBoxButtons.OK);

            ClearFields();
        }
    }
}
