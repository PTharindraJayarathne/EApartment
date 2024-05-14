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
    public partial class AdminParkingAndBuildingsUC : UserControl
    {
        // Connection 
        SqlConnection con = new SqlConnection(Properties.Settings.Default.EApartmentConnectionString);
        SqlCommand cmd = new SqlCommand();

        public AdminParkingAndBuildingsUC()
        {
            InitializeComponent();
        }

        // To clear the text boxes
        private void ClearFields()
        {
            txtLocation.Text = "";
            txtB_ID.Text = "";
            dgvBuilding.DataSource = null;
        }

        // To valid data
        private bool DataValid()
        {

            if (txtLocation.Text == "")
            {
                MessageBox.Show("Enter Building ID");
                return false;
            }
            return true;
        }


        private void AdminParkingAndBuildingsUC_Load(object sender, EventArgs e)
        {

        }

        // By clicking btnAll button you can view all Buildings details.
        private void btnAll_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("Select * from Building_Table", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvBuilding.DataSource = dt;

            foreach (DataGridViewRow row in dgvBuilding.Rows)
            {
                row.ReadOnly = true;
            }

            dgvBuilding.Columns[1].Width = 500;

            con.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("Select * from  Building_Table " +
                "where B_ID=@B_ID", con);
            cmd.Parameters.AddWithValue("@B_ID", txtB_ID.Text);

            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                txtB_ID.Text = sdr["B_ID"].ToString();
                txtLocation.Text = sdr["Location"].ToString();
                sdr.Close();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvBuilding.DataSource = dt;

                dgvBuilding.Columns[1].Width = 500;
                con.Close();

                MessageBox.Show("Data Search Successfully", "Message", MessageBoxButtons.OK);

            }
            else
            {
                MessageBox.Show("Please Enter B_ID", "Message", MessageBoxButtons.OK);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (DataValid())
            {
                con.Open();
                cmd = new SqlCommand("Insert into Building_Table values (@Location) ", con);
                cmd.Parameters.AddWithValue("@Location", txtLocation.Text);
                cmd.ExecuteNonQuery();


                con.Close();
                MessageBox.Show("Data Saved Successfully", "Message", MessageBoxButtons.OK);

                ClearFields();
            }
        }

        //To update data which already reacorded
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (DataValid())
            {

                con.Open();
                cmd = new SqlCommand("Update Building_Table set Location='" + txtLocation.Text + "' where B_ID= '" + txtB_ID.Text + "' ", con);
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
                    cmd = new SqlCommand("delete Building_Table " +
                        "where B_ID=@B_ID", con);
                    cmd.Parameters.AddWithValue("@B_ID", txtB_ID.Text);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
                MessageBox.Show("Data Deleted Successfully", "Message", MessageBoxButtons.OK);

                ClearFields();
            }
        }

        // To clear Data
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}
