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
    public partial class AdminApartmentUC : UserControl
    {
        //Connection
        SqlConnection con = new SqlConnection(Properties.Settings.Default.EApartmentConnectionString);
        SqlCommand cmd = new SqlCommand();
        public AdminApartmentUC()
        {
            InitializeComponent();
        }

        // To clear the text boxes
        private void ClearFields()
        {
            txtAP_ID.Text = "";
            txtParkingSpaceID.Text = "";
            txtB_ID.Text = "";
            txtCH_ID.Text = "";
            txtCatogary.Text = "";
            txtmaxNoOccupant.Text = "";
            txtMonthlyRent.Text = "";
            txtvacntdate.Text = "";
            //cmbState.Text = String.Empty;
            txtLocation.Text = "";
            txtNIC.Text = "";
            txtPNo.Text = "";
            dgvParkingSpaceDetails.DataSource = null;
        }

        // To valid data
        private bool DataValid()
        {
           
            if (txtCH_ID.Text == "")
            {
                MessageBox.Show("Enter Chief Occupant ID");
                return false;
            }
            if (txtB_ID.Text == "")
            {
                MessageBox.Show("Enter Building ID");
                return false;
            }
            if (txtCatogary.Text == "")
            {
                MessageBox.Show("Enter Apartment Catogary");
                return false;
            }
            if (txtmaxNoOccupant.Text == "")
            {
                MessageBox.Show("Enter Maximum Number of Occupants in the Apartment");
                return false;
            }
            if (txtMonthlyRent.Text == "")
            {
                MessageBox.Show("Enter Monthly Rent of the Apartment");
                return false;
            }
            if (!Information.IsNumeric(txtMonthlyRent.Text))
            {
                MessageBox.Show("Please enter a numeric Value for Parking Space Fee");
                return false;
            }
            if (txtLocation.Text == "")
            {
                MessageBox.Show("Enter Location of the Apartment");
                return false;
            }

            return true;
        }


        // By clicking btnAll button you can view all parking space details.
        private void btnAll_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("Select * from ParkingSpace_Table", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvParkingSpaceDetails.DataSource = dt;

            foreach (DataGridViewRow row in dgvParkingSpaceDetails.Rows)
            {
                row.ReadOnly = true;
            }

            dgvParkingSpaceDetails.Columns[0].Width = 50;
            dgvParkingSpaceDetails.Columns[1].Width = 50;
            dgvParkingSpaceDetails.Columns[2].Width = 50;
            dgvParkingSpaceDetails.Columns[3].Width = 60;
            dgvParkingSpaceDetails.Columns[4].Width = 75;

            con.Close();
        }

        private void txtPNo_TextChanged(object sender, EventArgs e)
        {

        }

        // Search Records By giving CH_ID or AP_ID or B_ID.
        private void btnSearch_Click(object sender, EventArgs e)
        {

            con.Open();
            cmd = new SqlCommand("Select a.AP_ID, a.B_ID, a.PS_ID, a.CH_ID, a.Category, a.MaxNoOccupants," +
                " a.Rent, a.State, a.VacantDate,a.Location, b.NIC, b.PassportNo " +
                " from Apartment_Table a,ChiefOccupant_Table b " +
                "where a.B_ID=@B_ID or a.AP_ID=@AP_ID or a.CH_ID=b.CH_ID and a.CH_ID=@CH_ID and b.CH_ID=@CH_ID", con);
            cmd.Parameters.AddWithValue("@CH_ID", txtCH_ID.Text);
            cmd.Parameters.AddWithValue("@AP_ID", txtAP_ID.Text);
            cmd.Parameters.AddWithValue("@B_ID", txtB_ID.Text);

            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                txtAP_ID.Text = sdr["AP_ID"].ToString();
                txtB_ID.Text = sdr["B_ID"].ToString();
                txtParkingSpaceID.Text = sdr["PS_ID"].ToString();
                txtCH_ID.Text = sdr["CH_ID"].ToString();
                txtCatogary.Text = sdr["Category"].ToString();
                txtmaxNoOccupant.Text = sdr["MaxNoOccupants"].ToString();
                txtMonthlyRent.Text = sdr["Rent"].ToString();
                cmbState.SelectedItem = sdr["State"].ToString();
                txtLocation.Text = sdr["Location"].ToString();
                txtvacntdate.Text = sdr["VacantDate"].ToString();
                txtNIC.Text = sdr["NIC"].ToString();
                txtPNo.Text = sdr["PassportNo"].ToString();
                sdr.Close();


                MessageBox.Show("Data Search Successfully", "Message", MessageBoxButtons.OK);

            }
            else
            {
                MessageBox.Show("Please Enter CH_ID or Apartment ID", "Message", MessageBoxButtons.OK);
            }

            con.Close();
        }

        //View Parking Space Details by clicking btnParkingSpaceDetails button (Enter relavent Apartment ID to "txtAP_ID" or Parking Space ID to "txtParkingSpaceID").
        private void btnParkingSpaceDetails_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("Select * from ParkingSpace_Table  where PS_ID='" + txtParkingSpaceID.Text + "' or AP_ID= '" + txtAP_ID.Text + "' ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvParkingSpaceDetails.DataSource = dt;

            foreach (DataGridViewRow row in dgvParkingSpaceDetails.Rows)
            {
                row.ReadOnly = true;
            }

            dgvParkingSpaceDetails.Columns[0].Width = 50;
            dgvParkingSpaceDetails.Columns[1].Width = 50;
            dgvParkingSpaceDetails.Columns[2].Width = 50;
            dgvParkingSpaceDetails.Columns[3].Width = 60;
            dgvParkingSpaceDetails.Columns[4].Width = 75;

            con.Close();
        }

        //To update data which already reacorded.        

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (DataValid())
            {

                con.Open();
                cmd = new SqlCommand("Update Apartment_Table set B_ID='" + txtB_ID.Text + "',PS_ID='" + txtParkingSpaceID.Text + "', CH_ID='" + txtCH_ID.Text + "'" +
             ",Category ='" + txtCatogary.Text + "',MaxNoOccupants='" + txtmaxNoOccupant.Text + "'," +
             "State='" + cmbState.SelectedItem + "',Location='" + txtLocation.Text + "'," +
             "VacantDate='" + txtvacntdate.Text + "', Rent='" + txtMonthlyRent.Text + "' where CH_ID= '" + txtCH_ID.Text + "'" +
             " or AP_ID='" + txtAP_ID.Text + "' ", con);

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
                    cmd = new SqlCommand("delete Apartment_Table " +
                        "where AP_ID=@AP_ID", con);
                    cmd.Parameters.AddWithValue("@AP_ID", txtAP_ID.Text);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
                MessageBox.Show("Data Deleted Successfully", "Message", MessageBoxButtons.OK);

                ClearFields();
            }
        }

        // To Clear fields.
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        //To Save a new record
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (DataValid())
            {
                con.Open();
                cmd = new SqlCommand("Insert into Apartment_Table values " +
                    "(@B_ID,@PS_ID,@CH_ID,@Category," +
                    "@MaxNoOccupants,@Rent,@State,@VacantDate,@Location) ", con);
                cmd.Parameters.AddWithValue("@B_ID", txtB_ID.Text);
                cmd.Parameters.AddWithValue("@PS_ID", txtParkingSpaceID.Text);
                cmd.Parameters.AddWithValue("@CH_ID", txtCH_ID.Text);
                cmd.Parameters.AddWithValue("@Category", txtCatogary.Text);
                cmd.Parameters.AddWithValue("@State", cmbState.SelectedItem);
                cmd.Parameters.AddWithValue("@MaxNoOccupants", txtmaxNoOccupant.Text);
                cmd.Parameters.AddWithValue("@Rent", txtMonthlyRent.Text);
                cmd.Parameters.AddWithValue("@VacantDate", txtvacntdate.Text);
                cmd.Parameters.AddWithValue("@Location", txtLocation.Text);
                cmd.ExecuteNonQuery();


                con.Close();
                MessageBox.Show("Data Saved Successfully", "Message", MessageBoxButtons.OK);

                ClearFields();
            }
        }
    }
}
