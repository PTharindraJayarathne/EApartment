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
    public partial class AdminLoginUC : UserControl
    {
        // Connection 
        SqlConnection con = new SqlConnection(Properties.Settings.Default.EApartmentConnectionString);
        SqlCommand cmd = new SqlCommand();

        public AdminLoginUC()
        {
            InitializeComponent();
        }

        // To clear the text boxes
        private void ClearFields()
        {
            txtCH_ID.Text = "";
            txtS_ID.Text = "";
            txtL_ID.Text = "";
            txtPassword.Text = "";
            txtUsername.Text = "";
            dgvlogin.DataSource = null;
        }

        // To valid data
        private bool DataValid()
        {
            if (txtUsername.Text == "")
            {
                MessageBox.Show("Enter Username");
                return false;
            }
            if (txtPassword.Text == "")
            {
                MessageBox.Show("Enter Password");
                return false;
            }

            return true;
        }

        // By clicking btnAll button you can view all Login details.
        private void btnALL_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("Select * from Login_Table", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvlogin.DataSource = dt;

            foreach (DataGridViewRow row in dgvlogin.Rows)
            {
                row.ReadOnly = true;
            }

            dgvlogin.Columns[0].Width = 65;
            dgvlogin.Columns[1].Width = 95;
            dgvlogin.Columns[2].Width = 95;
            dgvlogin.Columns[3].Width = 80;
            dgvlogin.Columns[4].Width = 65;
            dgvlogin.Columns[5].Width = 65;

            con.Close();
        }

        //To Search data after giving CH_ID or S_ID or Login ID.
        private void btnSearch_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("Select * from Login_Table " +
                "where Lg_ID=@Lg_ID or S_ID=@S_ID or CH_ID=@CH_ID", con);
            cmd.Parameters.AddWithValue("@CH_ID", txtCH_ID.Text);
            cmd.Parameters.AddWithValue("@Lg_ID", txtL_ID.Text);
            cmd.Parameters.AddWithValue("@S_ID", txtS_ID.Text);

            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                txtCH_ID.Text = sdr["CH_ID"].ToString();
                txtL_ID.Text = sdr["Lg_ID"].ToString();
                txtS_ID.Text = sdr["S_ID"].ToString();
                txtUsername.Text = sdr["LgUsername"].ToString();
                txtPassword.Text = sdr["LgPassword"].ToString();
                cmbRole.SelectedItem = sdr["Role"].ToString();
                sdr.Close();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvlogin.DataSource = dt;

                dgvlogin.Columns[0].Width = 65;
                dgvlogin.Columns[1].Width = 95;
                dgvlogin.Columns[2].Width = 95;
                dgvlogin.Columns[3].Width = 80;
                dgvlogin.Columns[4].Width = 65;
                dgvlogin.Columns[5].Width = 65;

                MessageBox.Show("Data Search Successfully", "Message", MessageBoxButtons.OK);

            }
            else
            {
                MessageBox.Show("Please Enter CH_ID or Staff ID or Login ID", "Message", MessageBoxButtons.OK);
            }

            con.Close();
        }

        // To Clear fields.
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
                cmd = new SqlCommand("Insert into Login_Table values " +
                    "(@LgUsername,@LgPassword,@Role,@S_ID,@CH_ID) ", con);
                cmd.Parameters.AddWithValue("@CH_ID", txtCH_ID.Text);
                cmd.Parameters.AddWithValue("@S_ID", txtS_ID.Text);
                cmd.Parameters.AddWithValue("@LgUsername", txtUsername.Text);
                cmd.Parameters.AddWithValue("@LgPassword", txtPassword.Text);
                cmd.Parameters.AddWithValue("@Role", cmbRole.SelectedItem);
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
                    cmd = new SqlCommand("delete Login_Table " +
                        "where Lg_ID=@Lg_ID", con);
                    cmd.Parameters.AddWithValue("@Lg_ID", txtL_ID.Text);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
                MessageBox.Show("Data Deleted Successfully", "Message", MessageBoxButtons.OK);

                ClearFields();
            }
        }

        // To update data which already reacorded.
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (DataValid())
            {

                con.Open();
                cmd = new SqlCommand("Update Login_Table set CH_ID= '" + txtCH_ID.Text + "', S_ID= '" + txtS_ID.Text + "', " +
                    "LgUsername ='" + txtUsername.Text + "',LgPassword='" + txtPassword.Text + "'," +
             "Role='" + cmbRole.SelectedItem + "'" +
             " where  Lg_ID='" + txtL_ID.Text + "' or CH_ID='" + txtCH_ID.Text + "' or S_ID='" + txtS_ID.Text + "'  ", con);

                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Data Updated Successfully", "Message", MessageBoxButtons.OK);

                ClearFields();
            }
        }
    }
}
