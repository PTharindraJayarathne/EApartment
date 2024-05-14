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
using System.Xml.Linq;

namespace ChiefOccupantHome
{
    public partial class AdminLeaseExpansionRequestUC : UserControl
    {
        // Connection 
        SqlConnection con = new SqlConnection(Properties.Settings.Default.EApartmentConnectionString);
        SqlCommand cmd = new SqlCommand();
        public AdminLeaseExpansionRequestUC()
        {
            InitializeComponent();
        }

        // To clear the text boxes
        private void ClearFields()
        {
            txtCH_ID.Text = "";
            txtLA_ID.Text = "";
            txtLAER_ID.Text = "";
            txtAP_ID.Text = "";
            txtAPState.Text = "";
            txtLPeriod.Text = "";
            dgvLAExtentionRequest.DataSource = null;
        }

        // To valid data
        private bool DataValid()
        {
            if (txtCH_ID.Text == "")
            {
                MessageBox.Show("Enter Chief Occupant ID");
                return false;
            }
            if (txtAP_ID.Text == "")
            {
                MessageBox.Show("Enter Chief Occupant's Apartment ID");
                return false;
            }
            if (txtLA_ID.Text == "")
            {
                MessageBox.Show("Enter Lease Agreement ID");
                return false;
            }
            if (txtAPState.Text == "")
            {
                MessageBox.Show("Enter State of the Apartment");
                return false;
            }
            if (txtLPeriod.Text == "")
            {
                MessageBox.Show("Enter Period of the Lease Agreement");
                return false;
            }

            return true;
        }



        private void btnSearch_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("Select * from LeaseExpansionRequest_Table " +
                "where CH_ID=@CH_ID or LAER_ID=@LAER_ID or LA_ID=@LA_ID", con);
            cmd.Parameters.AddWithValue("@CH_ID", txtCH_ID.Text);
            cmd.Parameters.AddWithValue("@LAER_ID", txtLAER_ID.Text);
            cmd.Parameters.AddWithValue("@LA_ID", txtLA_ID.Text);

            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                txtCH_ID.Text = sdr["CH_ID"].ToString();
                txtLAER_ID.Text = sdr["LAER_ID"].ToString();
                txtLA_ID.Text = sdr["LA_ID"].ToString();
                txtAP_ID.Text = sdr["AP_ID"].ToString();
                txtAPState.Text = sdr["ApartmentState"].ToString();
                dtpRequestedDate.Value = (DateTime)sdr["RequestedDate"];
                txtLPeriod.Text = sdr["LeasingPeriod"].ToString();
                sdr.Close();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvLAExtentionRequest.DataSource = dt;

                dgvLAExtentionRequest.Columns[0].Width = 65;
                dgvLAExtentionRequest.Columns[1].Width = 65;
                dgvLAExtentionRequest.Columns[2].Width = 65;
                dgvLAExtentionRequest.Columns[3].Width = 65;
                dgvLAExtentionRequest.Columns[4].Width = 95;
                dgvLAExtentionRequest.Columns[5].Width = 95;
                dgvLAExtentionRequest.Columns[6].Width = 115;

                MessageBox.Show("Data Search Successfully", "Message", MessageBoxButtons.OK);

            }
            else
            {
                MessageBox.Show("Please Enter CH_ID or Lease Agreement ID or Lease Agreement Extension Request ID", "Message", MessageBoxButtons.OK);
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
                cmd = new SqlCommand("Insert into LeaseExpansionRequest_Table values " +
                    "(@LA_ID,@CH_ID,@AP_ID,@ApartmentState,@RequestedDate,@LeasingPeriod) ", con);
                cmd.Parameters.AddWithValue("@CH_ID", txtCH_ID.Text);
                cmd.Parameters.AddWithValue("@AP_ID", txtAP_ID.Text);
                cmd.Parameters.AddWithValue("@LA_ID", txtLA_ID.Text);
                cmd.Parameters.AddWithValue("@ApartmentState", txtAPState.Text);
                cmd.Parameters.AddWithValue("@LeasingPeriod", txtLPeriod.Text);
                cmd.Parameters.AddWithValue("@RequestedDate", dtpRequestedDate.Value);
                cmd.ExecuteNonQuery();


                con.Close();
                MessageBox.Show("Data Saved Successfully", "Message", MessageBoxButtons.OK);

                ClearFields();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (DataValid())
            {

                con.Open();
                cmd = new SqlCommand("Update LeaseExpansionRequest_Table set CH_ID= '" + txtCH_ID.Text + "', AP_ID= '" + txtAP_ID.Text + "', LA_ID='" + txtLA_ID.Text + "'," +
             "ApartmentState='" + txtAPState.Text + "',LeasingPeriod='" + txtLPeriod.Text + "'," +
             "RequestedDate='" + dtpRequestedDate.Value + "' where  LAER_ID='" + txtLAER_ID.Text + "' ", con);

                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Data Updated Successfully", "Message", MessageBoxButtons.OK);

                ClearFields();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            con.Open();
            //Verify to delete the record
            var confirmResult = MessageBox.Show("Are you sure to delete this record ??",
                                   "Confirm Delete!!",
                                   MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                cmd = new SqlCommand("delete LeaseExpansionRequest_Table " +
                    "where LAER_ID=@LAER_ID", con);
                cmd.Parameters.AddWithValue("@LAER_ID", txtLAER_ID.Text);
                cmd.ExecuteNonQuery();
            }
            con.Close();
            MessageBox.Show("Data Deleted Successfully", "Message", MessageBoxButtons.OK);

            ClearFields();
        }
    }
}
