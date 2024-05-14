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
    public partial class AdminLeaseRequestAcceptanceUC : UserControl
    {
        // Connection 
        SqlConnection con = new SqlConnection(Properties.Settings.Default.EApartmentConnectionString);
        SqlCommand cmd = new SqlCommand();

        public AdminLeaseRequestAcceptanceUC()
        {
            InitializeComponent();
        }

        // To clear the text boxes
        private void ClearFields()
        {
            txtCH_ID.Text = "";
            txtLAER_ID.Text = "";
            txtLA_ID.Text = "";
            dgvLAEAcceptance.DataSource = null;
        }

        //To Search data after giving Chief Occupant ID or Lease Agreement ID or Lease Agreement Extension Requset ID.
        private void btnSearch_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("Select * from LeaseExpansionRequest_Table " +
                "where LAER_ID=@LAER_ID or LA_ID=@LA_ID or CH_ID=@CH_ID", con);
            cmd.Parameters.AddWithValue("@LAER_ID", txtLAER_ID.Text);
            cmd.Parameters.AddWithValue("@LA_ID", txtLA_ID.Text);
            cmd.Parameters.AddWithValue("@CH_ID", txtCH_ID.Text);

            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                txtLAER_ID.Text = sdr["LAER_ID"].ToString();
                txtLA_ID.Text = sdr["LA_ID"].ToString();
                txtCH_ID.Text = sdr["CH_ID"].ToString();
                sdr.Close();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvLAEAcceptance.DataSource = dt;

                dgvLAEAcceptance.Columns[0].Width = 80;
                dgvLAEAcceptance.Columns[1].Width = 80;
                dgvLAEAcceptance.Columns[2].Width = 80;
                dgvLAEAcceptance.Columns[3].Width = 80;
                dgvLAEAcceptance.Columns[4].Width = 200;
                dgvLAEAcceptance.Columns[5].Width = 200;
                dgvLAEAcceptance.Columns[6].Width = 155;

                MessageBox.Show("Data Search Successfully", "Message", MessageBoxButtons.OK);

            }
            else
            {
                MessageBox.Show("Please Enter Chief Occupant ID or Lease Agreement ID or " +
                    "Lease Agreement Extension Requset ID", "Message", MessageBoxButtons.OK);
            }

            con.Close();
        }

        // To Clear fields.
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        //To search all the records by ascending order of the date "RequestedDate".
        private void btnAll_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("Select * from LeaseExpansionRequest_Table order by RequestedDate Asc;", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvLAEAcceptance.DataSource = dt;

            foreach (DataGridViewRow row in dgvLAEAcceptance.Rows)
            {
                row.ReadOnly = true;
            }
            dgvLAEAcceptance.Columns[0].Width = 80;
            dgvLAEAcceptance.Columns[1].Width = 80;
            dgvLAEAcceptance.Columns[2].Width = 80;
            dgvLAEAcceptance.Columns[3].Width = 80;
            dgvLAEAcceptance.Columns[4].Width = 200;
            dgvLAEAcceptance.Columns[5].Width = 200;
            dgvLAEAcceptance.Columns[6].Width = 155;

            con.Close();
        }

        // Delete the selected record in datagrideview from database.
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

                int rowIndex = dgvLAEAcceptance.CurrentCell.RowIndex;
                dgvLAEAcceptance.Rows.RemoveAt(rowIndex);
            }
            con.Close();
            MessageBox.Show("Data Deleted Successfully", "Message", MessageBoxButtons.OK);


        }
    }
}
