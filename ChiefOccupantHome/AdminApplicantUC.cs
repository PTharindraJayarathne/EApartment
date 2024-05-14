using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common.CommandTrees.ExpressionBuilder;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace ChiefOccupantHome
{
    public partial class AdminApplicantUC : UserControl
    {
        // Connection 
        SqlConnection con = new SqlConnection(Properties.Settings.Default.EApartmentConnectionString);
        SqlCommand cmd = new SqlCommand();

        //public object Information { get; private set; }

        public AdminApplicantUC()
        {
            InitializeComponent();
        }

        // To clear the text boxes
        private void ClearFields()
        {
            txtAPL_ID.Text = "";
            txtNIC.Text = "";
            txtPNo.Text = "";
            txtName.Text = "";
            txtOccupation.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            txtMobileNo.Text = "";
            txtLandline.Text = "";
            txtNationality.Text = "";
            txtCountry.Text = "";
            //cmbGender.Text = String.Empty;
            txtReserFee.Text = "";
            txtAgreeSD.Text = "";
            txtAP_ID.Text = "";

        }

        // To valid data
        private bool DataValid()
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Enter Applicant Full Name");
                return false;
            }
            if (txtNIC.Text == "")
            {
                MessageBox.Show("Enter Applicant NIC Number");
                return false;
            }
            if (txtPNo.Text == "")
            {
                MessageBox.Show("Enter Applicant Passport Number");
                return false;
            }
            if (txtOccupation.Text == "")
            {
                MessageBox.Show("Enter Applicant Occupation");
                return false;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Enter Applicant Email");
                return false;
            }
            if (txtAddress.Text == "")
            {
                MessageBox.Show("Enter Applicant Address");
                return false;
            }
            if (txtMobileNo.Text == "")
            {
                MessageBox.Show("Enter Applicant Mobile Number");
                return false;
            }
            if (txtNationality.Text == "")
            {
                MessageBox.Show("Enter Applicant Nationality");
                return false;
            }
            if (txtCountry.Text == "")
            {
                MessageBox.Show("Enter Applicant Country");
                return false;
            }


            if (!Information.IsNumeric(txtReserFee.Text))
            {
                MessageBox.Show("Please enter a numeric Value for Reservation Fee");
                return false;
            }

            return true;
        }

        

        private void cmbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        //To save data entered into the text boxes
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (DataValid())
            {
                con.Open();
                string sql = "INSERT INTO [Applicant_Table]([AP_ID],[ReservationFee],[Date],[AggrementStartingDate]," +
                    "[Name],[NIC],[PassportNo],[Nationality],[Country],[Gender],[Occupation]," +
                    "[MobileNo],[Landline],[Email],[Address]) " +
                    "VALUES ('"+ txtAP_ID.Text + "','" + txtReserFee.Text + "','"+ dtpApplicant.Value + "','"+ txtAgreeSD.Text+"','"+ txtName.Text + "','"+ txtNIC.Text + "','"
                    + txtPNo.Text + "','"+ txtNationality.Text + "','"+ txtCountry.Text + "','" + cmbGender.SelectedItem + "','"+ txtOccupation.Text + "','"
                    + txtMobileNo.Text+"','"+ txtLandline.Text + "','"+ txtEmail.Text + "','" + txtAddress.Text+"');";

                cmd = new SqlCommand(sql, con);


                cmd.ExecuteNonQuery();


                con.Close();
                MessageBox.Show("Data Saved Successfully", "Message", MessageBoxButtons.OK);

                ClearFields();
            }
         
        }

        // To clear data in text boxes
        private void btnCL_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        // To update data which already reacorded.
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (DataValid())
            {

                con.Open();
                cmd = new SqlCommand("Update Applicant_Table set AP_ID='" + txtAP_ID.Text + "',ReservationFee='" + txtReserFee.Text + "'," +
                "Date='"+dtpApplicant.Value+ "', AggrementStartingDate='"+txtAgreeSD.Text+ "', Name='" + txtName.Text + "', NIC='" + txtNIC.Text + "',PassportNo='" + txtPNo.Text + "'," +
                "Nationality ='" + txtNationality.Text + "',Country='" + txtCountry.Text + "', Gender='" + cmbGender.SelectedItem + "', " +
                "Occupation='" + txtOccupation.Text + "',MobileNo='" + txtMobileNo.Text + "', Landline='" + txtLandline.Text + "', " +
                "Email='" + txtEmail.Text + "', Address='" + txtAddress.Text + "'" +
                " where APL_ID= '" + txtAPL_ID.Text + "' or PassportNo='" + txtPNo.Text + "' or NIC='" + txtNIC.Text + "' ", con);

                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Data Updated Successfully", "Message", MessageBoxButtons.OK);

                ClearFields();
            }
        }

        //To delete record 
        private void btnDelete_Click(object sender, EventArgs e)
        {
            
                con.Open();
                //Verify to delete the record
                var confirmResult = MessageBox.Show("Are you sure to delete this record ??",
                                       "Confirm Delete!!",
                                       MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    cmd = new SqlCommand("delete Applicant_Table " +
                        "where APL_ID=@APL_ID or NIC=@NIC or PassportNo=@PassportNo", con);
                    cmd.Parameters.AddWithValue("@APL_ID", txtAPL_ID.Text);
                    cmd.Parameters.AddWithValue("@NIC", txtNIC.Text);
                    cmd.Parameters.AddWithValue("@PassportNo", txtPNo.Text);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
                MessageBox.Show("Data Deleted Successfully", "Message", MessageBoxButtons.OK);

                ClearFields();
            
        }

        //To Search data after giving APL_ID or NIC or PassportNo
        private void btnSearch_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("Select * from  Applicant_Table " +
                "where APL_ID=@APL_ID or NIC=@NIC or PassportNo=@PassportNo", con);
            cmd.Parameters.AddWithValue("@APL_ID", txtAPL_ID.Text);
            cmd.Parameters.AddWithValue("@NIC", txtNIC.Text);
            cmd.Parameters.AddWithValue("@PassportNo", txtPNo.Text);

            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                txtAPL_ID.Text = sdr["APL_ID"].ToString();
                txtAP_ID.Text = sdr["AP_ID"].ToString();
                txtReserFee.Text = sdr["ReservationFee"].ToString();
                //dtpApplicant.Text = sdr["Dob"].Value.ToString();
                dtpApplicant.Value = (DateTime)sdr["Date"];
                txtAgreeSD.Text = sdr["AggrementStartingDate"].ToString();
                txtName.Text = sdr["Name"].ToString();
                txtNIC.Text = sdr["NIC"].ToString();
                txtPNo.Text = sdr["PassportNO"].ToString();
                txtNationality.Text = sdr["Nationality"].ToString();
                txtCountry.Text = sdr["Country"].ToString();
                cmbGender.SelectedItem = sdr["Gender"].ToString();
                txtOccupation.Text = sdr["Occupation"].ToString();
                txtMobileNo.Text = sdr["MobileNo"].ToString();
                txtLandline.Text = sdr["Landline"].ToString();
                txtEmail.Text = sdr["Email"].ToString();
                txtAddress.Text = sdr["Address"].ToString();

                //MessageBox.Show("Data Search Successfully", "Message", MessageBoxButtons.OK);

            }
            else
            {
                MessageBox.Show("Please Enter APL_ID or NIC or PassportNO", "Message", MessageBoxButtons.OK);
            }

            con.Close();

        }

        private void dtpApplicant_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
