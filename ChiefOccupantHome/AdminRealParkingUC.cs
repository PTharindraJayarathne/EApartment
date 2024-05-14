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
    public partial class AdminRealParkingUC : UserControl
    {
        // Connection 
        SqlConnection con = new SqlConnection(Properties.Settings.Default.EApartmentConnectionString);
        SqlCommand cmd = new SqlCommand();

        public AdminRealParkingUC()
        {
            InitializeComponent();
        }

        // To clear the text boxes
        private void ClearFields()
        {
            txtP_ID.Text = "";
            txtB_ID.Text = "";
            txtFee.Text = "";
            dgvParking.DataSource = null;
        }

        // To valid data
        private bool DataValid()
        {
            if (txtB_ID.Text == "")
            {
                MessageBox.Show("Enter Building ID");
                return false;
            }
            if (txtFee.Text == "")
            {
                MessageBox.Show("Enter Parking Fee");
                return false;
            }
            if (!Information.IsNumeric(txtFee.Text))
            {
                MessageBox.Show("Please enter a numeric Value for Parking Fee");
                return false;
            }

            return true;
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        // By clicking btnAll button you can view all Parking details.
        private void btnALL_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("Select * from Parking_Table", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvParking.DataSource = dt;

            foreach (DataGridViewRow row in dgvParking.Rows)
            {
                row.ReadOnly = true;
            }

            dgvParking.Columns[0].Width = 95;
            dgvParking.Columns[1].Width = 95;
            dgvParking.Columns[2].Width = 200;
            dgvParking.Columns[3].Width = 200;


            con.Close();
        }

        //To Search data after giving B_ID or P_ID.
        private void btnSearch_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("Select * from Parking_Table " +
                "where P_ID=@P_ID or B_ID=@B_ID", con);
            cmd.Parameters.AddWithValue("@P_ID", txtP_ID.Text);
            cmd.Parameters.AddWithValue("@B_ID", txtB_ID.Text);

            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                txtP_ID.Text = sdr["P_ID"].ToString();
                txtB_ID.Text = sdr["B_ID"].ToString();
                txtFee.Text = sdr["Fee"].ToString();
                cmbState.SelectedItem = sdr["State"].ToString();
                sdr.Close();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvParking.DataSource = dt;

                dgvParking.Columns[0].Width = 95;
                dgvParking.Columns[1].Width = 95;
                dgvParking.Columns[2].Width = 200;
                dgvParking.Columns[3].Width = 200;

                MessageBox.Show("Data Search Successfully", "Message", MessageBoxButtons.OK);

            }
            else
            {
                MessageBox.Show("Please Enter Parking ID or Building ID", "Message", MessageBoxButtons.OK);
            }

            con.Close();
        }

        // To Clear fields.
        private void btnCl_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        //To save data entered into the text boxes
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (DataValid())
            {
                con.Open();
                cmd = new SqlCommand("Insert into Parking_Table values " +
                    "(@B_ID,@Fee,@State) ", con);
                cmd.Parameters.AddWithValue("@B_ID", txtB_ID.Text);
                cmd.Parameters.AddWithValue("@Fee", txtFee.Text);
                cmd.Parameters.AddWithValue("@State", cmbState.SelectedItem);
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
                cmd = new SqlCommand("Update Parking_Table set B_ID= '" + txtB_ID.Text + "', Fee= '" + txtFee.Text + "',State='" + cmbState.SelectedItem + "'" +
             " where  P_ID='" + txtP_ID.Text + "' ", con);

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
                    cmd = new SqlCommand("delete Parking_Table " +
                        "where P_ID=@P_ID", con);
                    cmd.Parameters.AddWithValue("@P_ID", txtP_ID.Text);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
                MessageBox.Show("Data Deleted Successfully", "Message", MessageBoxButtons.OK);

                ClearFields();
            }
        }
    }
}
