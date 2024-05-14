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

    public partial class AdminStaffUC : UserControl
    {
        // Connection 
        SqlConnection con = new SqlConnection(Properties.Settings.Default.EApartmentConnectionString);
        SqlCommand cmd = new SqlCommand();

        public AdminStaffUC()
        {
            InitializeComponent();
        }

        // To clear the text boxes
        private void ClearFields()
        {
            txtS_ID.Text = "";
            txtNIC.Text = "";
            txtName.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            txtTeleNo.Text = "";
            txtPosition.Text = "";
            txtSalary.Text = "";
        }

        // To valid data
        private bool DataValid()
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Enter Staff Member Name");
                return false;
            }
            if (txtNIC.Text == "")
            {
                MessageBox.Show("Enter Staff Member NIC");
                return false;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Enter Staff Member Email");
                return false;
            }
            if (txtAddress.Text == "")
            {
                MessageBox.Show("Enter Staff Membert Address");
                return false;
            }
            if (txtTeleNo.Text == "")
            {
                MessageBox.Show("Enter Staff Member Telephone Number ");
                return false;
            }
            if (txtPosition.Text == "")
            {
                MessageBox.Show("Enter Staff Member Position");
                return false;
            }
            if (txtSalary.Text == "")
            {
                MessageBox.Show("Enter Staff Member Salary");
                return false;
            }
            if (!Information.IsNumeric(txtSalary.Text))
            {
                MessageBox.Show("Please enter a numeric Value for Staff Member Salary");
                return false;
            }

            return true;
        }

        //To Search data after giving S_ID or NIC.
        private void btnSearch_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("Select * from  Staff_Table " +
                "where S_ID=@S_ID or NIC=@NIC", con);
            cmd.Parameters.AddWithValue("@S_ID", txtS_ID.Text);
            cmd.Parameters.AddWithValue("@NIC", txtNIC.Text);

            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                txtS_ID.Text = sdr["S_ID"].ToString();
                txtName.Text = sdr["Name"].ToString();
                txtNIC.Text = sdr["NIC"].ToString();
                txtPosition.Text = sdr["Position"].ToString();
                txtSalary.Text = sdr["Salary"].ToString();
                txtTeleNo.Text = sdr["TeleNo"].ToString();
                cmbGender.SelectedItem = sdr["Gender"].ToString();
                txtEmail.Text = sdr["Email"].ToString();
                txtAddress.Text = sdr["Address"].ToString();

                MessageBox.Show("Data Search Successfully", "Message", MessageBoxButtons.OK);

            }
            else
            {
                MessageBox.Show("Please Enter Staff ID or Staff NIC", "Message", MessageBoxButtons.OK);
            }

            con.Close();
        }

        // To clear data in text boxes.
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        // To update data which already reacorded.
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (DataValid())
            {

                con.Open();
                cmd = new SqlCommand("Update Staff_Table set Name='" + txtName.Text +
             "',NIC='" + txtNIC.Text + "'," + "Position='" + txtPosition.Text + "'" +
             ",Salary ='" + txtSalary.Text + "',TeleNo='" + txtTeleNo.Text + "'," +
             "Gender='" + cmbGender.SelectedItem + "',Email='" + txtEmail.Text + "'," +
             "Address='" + txtAddress.Text + "' " + "where S_ID= '" + txtS_ID.Text + "' or NIC='" + txtNIC.Text + "' ", con);

                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Data Updated Successfully", "Message", MessageBoxButtons.OK);

                ClearFields();
            }
        }

        //To save data entered into the text boxes
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (DataValid())
            {
                con.Open();
                cmd = new SqlCommand("Insert into Staff_Table values " +
                    "(@Name,@NIC,@Gender,@Position,@Salary," +
                    "@TeleNo,@Email,@Address) ", con);
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@NIC", txtNIC.Text);
                cmd.Parameters.AddWithValue("@Position", txtPosition.Text);
                cmd.Parameters.AddWithValue("@Salary", txtSalary.Text);
                cmd.Parameters.AddWithValue("@Gender", cmbGender.SelectedItem);
                cmd.Parameters.AddWithValue("@TeleNo", txtTeleNo.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmd.ExecuteNonQuery();


                con.Close();
                MessageBox.Show("Data Saved Successfully", "Message", MessageBoxButtons.OK);

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
                    cmd = new SqlCommand("delete Staff_Table " +
                        "where S_ID=@S_ID or NIC=@NIC", con);
                    cmd.Parameters.AddWithValue("@S_ID", txtS_ID.Text);
                    cmd.Parameters.AddWithValue("@NIC", txtNIC.Text);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
                MessageBox.Show("Data Deleted Successfully", "Message", MessageBoxButtons.OK);

                ClearFields();
            }
        }
    }
}
