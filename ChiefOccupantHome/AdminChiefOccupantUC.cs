using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Net.NetworkInformation;

namespace ChiefOccupantHome
{
    public partial class AdminChiefOccupantUC : UserControl
    {
        // Connection 
        SqlConnection con = new SqlConnection(Properties.Settings.Default.EApartmentConnectionString);
        SqlCommand cmd = new SqlCommand();
        public AdminChiefOccupantUC()
        {
            InitializeComponent();
        }

        // To clear the text boxes
        private void ClearFields()
        {
            txtCH_ID.Text = "";
            txtNIC.Text = "";
            txtPassportNO.Text = "";
            txtFullName.Text = "";
            txtOccupation.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            txtMobile1.Text = "";
            txtMobile2.Text = "";
            txtLandline.Text = "";
            txtNationality.Text = "";
            txtCountry.Text = "";
            cmbGender.Text = String.Empty;
        }

        // To valid data
        private bool DataValid()
        {
            if (txtFullName.Text == "")
            {
                MessageBox.Show("Enter Chief Occupant Name");
                return false;
            }
            if (txtNIC.Text == "")
            {
                MessageBox.Show("Enter Chief Occupant NIC");
                return false;
            }
            if (txtPassportNO.Text == "")
            {
                MessageBox.Show("Enter Chief Occupant Passport Number");
                return false;
            }
            if (txtOccupation.Text == "")
            {
                MessageBox.Show("Enter Chief Occupant Occupation");
                return false;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Enter Chief Occupant Email");
                return false;
            }
            if (txtAddress.Text == "")
            {
                MessageBox.Show("Enter Chief Occupant Address");
                return false;
            }
            if (txtMobile1.Text == "")
            {
                MessageBox.Show("Enter Chief Occupant Mobile Number 1");
                return false;
            }
            if (txtNationality.Text == "")
            {
                MessageBox.Show("Enter Chief Occupant Nationality");
                return false;
            }
            if (txtCountry.Text == "")
            {
                MessageBox.Show("Enter Chief Occupant Country");
                return false;
            }

                return true;
            }

            // To clear data in text boxes
            private void btnClear_Click(object sender, EventArgs e)
            {
                ClearFields();
            }
            //To save data entered into the text boxes
            private void btnSave_Click(object sender, EventArgs e)
                {
                if (DataValid())
                    {
                    con.Open();
                    cmd = new SqlCommand("Insert into ChiefOccupant_Table values " +
                        "(@Name,@NIC,@PassportNo,@Nationality,@Country," +
                        "@Gender,@Occupation,@MobileNo1,@MobileNo2,@Landline,@Email,@Address) ", con);
                    cmd.Parameters.AddWithValue("@Name", txtFullName.Text);
                    cmd.Parameters.AddWithValue("@NIC", txtNIC.Text);
                    cmd.Parameters.AddWithValue("@PassportNo", txtPassportNO.Text);
                    cmd.Parameters.AddWithValue("@Nationality", txtNationality.Text);
                    cmd.Parameters.AddWithValue("@Country", txtCountry.Text);
                    cmd.Parameters.AddWithValue("@Gender", cmbGender.SelectedItem);
                    cmd.Parameters.AddWithValue("@Occupation", txtOccupation.Text);
                    cmd.Parameters.AddWithValue("@MobileNo1", txtMobile1.Text);
                    cmd.Parameters.AddWithValue("@MobileNo2", txtMobile2.Text);
                    cmd.Parameters.AddWithValue("@Landline", txtLandline.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.ExecuteNonQuery();


                    con.Close();
                    MessageBox.Show("Data Saved Successfully", "Message", MessageBoxButtons.OK);

                    ClearFields();
                    }

                }
            // To update data which already reacorded.
            private void btnUpdate_Click(object sender, EventArgs e)
            {
            if (DataValid())
            {

                con.Open();
                cmd = new SqlCommand("Update ChiefOccupant_Table set Name='" + txtFullName.Text +
             "',NIC='" + txtNIC.Text + "'," + "PassportNo='" + txtPassportNO.Text + "'" +
             ",Nationality ='" + txtNationality.Text + "',Country='" + txtCountry.Text + "'," +
             "Gender='" + cmbGender.SelectedItem + "',Occupation='" + txtOccupation.Text + "'," +
             "MobileNo1='" + txtMobile1.Text + "',MobileNo2='" + txtMobile2.Text + "'," +
             "Landline='" + txtLandline.Text + "'," + "Email='" + txtEmail.Text + "'," +
             "Address='" + txtAddress.Text + "' " + "where CH_ID= '" + txtCH_ID.Text + "'" +
             " or PassportNo='" + txtPassportNO.Text + "' or NIC='" + txtNIC.Text + "' ", con);

                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Data Updated Successfully", "Message", MessageBoxButtons.OK);

                ClearFields();
            }

            }

            //To delete record  
            private void btnDelete_Click(object sender, EventArgs e)
            {
            if (DataValid())
            {
                con.Open();
                //Verify to delete the record
                var confirmResult = MessageBox.Show("Are you sure to delete this record ??",
                                       "Confirm Delete!!",
                                       MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    cmd = new SqlCommand("delete ChiefOccupant_Table " +
                        "where CH_ID=@CH_ID or NIC=@NIC or PassportNo=@PassportNo", con);
                    cmd.Parameters.AddWithValue("@CH_ID", txtCH_ID.Text);
                    cmd.Parameters.AddWithValue("@NIC", txtNIC.Text);
                    cmd.Parameters.AddWithValue("@PassportNo", txtPassportNO.Text);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
                MessageBox.Show("Data Deleted Successfully", "Message", MessageBoxButtons.OK);

                ClearFields();
            }
            }
              //To Search data after giving CH_ID or NIC or PassportNo
            private void btnSearch_Click(object sender, EventArgs e)
                {
                    con.Open();
                    cmd = new SqlCommand("Select * from  ChiefOccupant_Table " +
                        "where CH_ID=@CH_ID or NIC=@NIC or PassportNo=@PassportNo", con);
                    cmd.Parameters.AddWithValue("@CH_ID", txtCH_ID.Text);
                    cmd.Parameters.AddWithValue("@NIC", txtNIC.Text);
                    cmd.Parameters.AddWithValue("@PassportNo", txtPassportNO.Text);

                    SqlDataReader sdr;
                    sdr = cmd.ExecuteReader();
                    if(sdr.Read())
                    {
                        txtCH_ID.Text = sdr["CH_ID"].ToString();
                        txtFullName.Text = sdr["Name"].ToString();
                        txtNIC.Text = sdr["NIC"].ToString();
                        txtPassportNO.Text = sdr["PassportNO"].ToString();
                        txtNationality.Text = sdr["Nationality"].ToString();
                        txtCountry.Text = sdr["Country"].ToString();
                        cmbGender.SelectedItem = sdr["Gender"].ToString();
                        txtOccupation.Text = sdr["Occupation"].ToString();
                        txtMobile1.Text = sdr["MobileNo1"].ToString();
                        txtMobile2.Text = sdr["MobileNo2"].ToString();
                        txtLandline.Text = sdr["Landline"].ToString();
                        txtEmail.Text = sdr["Email"].ToString();
                        txtAddress.Text = sdr["Address"].ToString();

                        MessageBox.Show("Data Search Successfully", "Message", MessageBoxButtons.OK);

                    }
                    else 
                    {
                        MessageBox.Show("Please Enter CH_ID or NIC or PassportNO", "Message", MessageBoxButtons.OK);
                    }

                    con.Close();
            
                }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
    
}

