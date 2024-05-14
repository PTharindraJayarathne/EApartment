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
    public partial class AdminDependentUC : UserControl
    {
        // Connection 
        SqlConnection con = new SqlConnection(Properties.Settings.Default.EApartmentConnectionString);
        SqlCommand cmd = new SqlCommand();
        public AdminDependentUC()
        {
            InitializeComponent();
        }

        // To clear the text boxes
        private void ClearFields()
        {
            txtCH_ID.Text = "";
            txtD_NIC.Text = "";
            txtD_PassportNo.Text = "";
            txtName.Text = "";
            txtOccupation.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            txtMobileNo.Text = "";
            txtRelationship.Text = "";
            txtNationality.Text = "";
            txtCountry.Text = "";
            cmbGender.Text = String.Empty;
            dgvDependent.DataSource = null;
        }
        // To valid data
        private bool DataValid()
        {
            if (txtCH_ID.Text == "")
            {
                MessageBox.Show("Enter Chief Occupant ID");
                return false;
            }
            if (txtD_NIC.Text == "")
            {
                MessageBox.Show("Enter Dependent NIC");
                return false;
            }
            if (txtD_PassportNo.Text == "")
            {
                MessageBox.Show("Enter Dependent Passport Number");
                return false;
            }
            if (txtOccupation.Text == "")
            {
                MessageBox.Show("Enter Dependent Occupation");
                return false;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Enter Dependent Email");
                return false;
            }
            if (txtAddress.Text == "")
            {
                MessageBox.Show("Enter Dependent Address");
                return false;
            }
            if (txtMobileNo.Text == "")
            {
                MessageBox.Show("Enter Dependent Mobile Number");
                return false;
            }
            if (txtNationality.Text == "")
            {
                MessageBox.Show("Enter Dependent Nationality");
                return false;
            }
            if (txtCountry.Text == "")
            {
                MessageBox.Show("Enter Dependent Country");
                return false;
            }
            //if (cmbGender.Text = "" )
            //{
            //    MessageBox.Show("Enter Dependent Gender");
            //    return false;
            //}

            return true;
        }
        private void dgvDependent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //string sql = "select * from DEpendent_Table";
            //dgvDependent.DataSource= Data.getdata(sql);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        // To Clear fields.
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
            
        }
        //To Search data after giving CH_ID or Dependent NIC or Dependent PassportNo
        private void btnSearch_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("Select * from Dependent_Table " +
                "where CH_ID=@CH_ID or NIC=@NIC or PassportNo=@PassportNo", con);
            cmd.Parameters.AddWithValue("@CH_ID", txtCH_ID.Text);
            cmd.Parameters.AddWithValue("@NIC", txtD_NIC.Text);
            cmd.Parameters.AddWithValue("@PassportNo", txtD_PassportNo.Text);

            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                txtCH_ID.Text = sdr["CH_ID"].ToString();
                txtName.Text = sdr["Name"].ToString();
                txtD_NIC.Text = sdr["NIC"].ToString();
                txtD_PassportNo.Text = sdr["PassportNO"].ToString();
                txtNationality.Text = sdr["Nationality"].ToString();
                txtCountry.Text = sdr["Country"].ToString();
                cmbGender.SelectedItem = sdr["Gender"].ToString();
                txtOccupation.Text = sdr["Occupation"].ToString();
                txtMobileNo.Text = sdr["MobileNo"].ToString();
                txtEmail.Text = sdr["Email"].ToString();
                txtAddress.Text = sdr["Address"].ToString();
                txtRelationship.Text = sdr["Realationship"].ToString();
                sdr.Close();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvDependent.DataSource = dt;

                dgvDependent.Columns[0].Width = 50;
                dgvDependent.Columns[1].Width = 50;
                dgvDependent.Columns[2].Width = 95;
                dgvDependent.Columns[4].Width = 95;
                dgvDependent.Columns[5].Width = 95;
                dgvDependent.Columns[6].Width = 75;
                dgvDependent.Columns[7].Width = 75;
                dgvDependent.Columns[8].Width = 60;
                dgvDependent.Columns[9].Width = 80;
                dgvDependent.Columns[10].Width = 95;
                dgvDependent.Columns[11].Width = 150;
                dgvDependent.Columns[12].Width = 200;

                MessageBox.Show("Data Search Successfully", "Message", MessageBoxButtons.OK);

            }
            else
            {
                MessageBox.Show("Please Enter CH_ID or Dependent NIC or Dependent Passport Number", "Message", MessageBoxButtons.OK);
            }

            con.Close();

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
                    cmd = new SqlCommand("delete Dependent_Table " +
                        "where NIC=@NIC or PassportNo=@PassportNo", con);
                    cmd.Parameters.AddWithValue("@NIC", txtD_NIC.Text);
                    cmd.Parameters.AddWithValue("@PassportNo", txtD_PassportNo.Text);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
                MessageBox.Show("Data Deleted Successfully", "Message", MessageBoxButtons.OK);

                ClearFields();
            }
        }
        //To save data entered into the text boxes
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (DataValid())
            {
                con.Open();
                cmd = new SqlCommand("Insert into Dependent_Table values " +
                    "(@CH_ID,@Realationship,@Name,@NIC,@PassportNo,@Nationality,@Country," +
                    "@Gender,@Occupation,@MobileNo,@Email,@Address) ", con);
                cmd.Parameters.AddWithValue("@CH_ID", txtCH_ID.Text);
                cmd.Parameters.AddWithValue("@Realationship", txtRelationship.Text);
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@NIC", txtD_NIC.Text);
                cmd.Parameters.AddWithValue("@PassportNo", txtD_PassportNo.Text);
                cmd.Parameters.AddWithValue("@Nationality", txtNationality.Text);
                cmd.Parameters.AddWithValue("@Country", txtCountry.Text);
                cmd.Parameters.AddWithValue("@Gender", cmbGender.SelectedItem);
                cmd.Parameters.AddWithValue("@Occupation", txtOccupation.Text);
                cmd.Parameters.AddWithValue("@MobileNo", txtMobileNo.Text);
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
                cmd = new SqlCommand("Update Dependent_Table set CH_ID= '"+txtCH_ID.Text+ "', Realationship= '"+txtRelationship.Text+"', Name='" + txtName.Text + "'," +
             "NIC='" + txtD_NIC.Text + "',PassportNo='" + txtD_PassportNo.Text + "'," +
             "Nationality ='" + txtNationality.Text + "',Country='" + txtCountry.Text + "'," +
             "Gender='" + cmbGender.SelectedItem + "',Occupation='" + txtOccupation.Text + "'," +
             "MobileNo='" + txtMobileNo.Text + "' , Email='" + txtEmail.Text + "'," +
             "Address='" + txtAddress.Text + "' where  PassportNo='" + txtD_PassportNo.Text + "' or NIC='" + txtD_NIC.Text + "' ", con);

                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Data Updated Successfully", "Message", MessageBoxButtons.OK);

                ClearFields();
            }
        }
    }
}
