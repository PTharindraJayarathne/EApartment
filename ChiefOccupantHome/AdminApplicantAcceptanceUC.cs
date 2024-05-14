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
    public partial class AdminApplicantAcceptanceUC : UserControl
    {
        // Connection 
        SqlConnection con = new SqlConnection(Properties.Settings.Default.EApartmentConnectionString);
        SqlCommand cmd = new SqlCommand();

        public AdminApplicantAcceptanceUC()
        {
            InitializeComponent();
        }

        // To clear the text boxes
        private void ClearFields()
        {
            txtAPL_ID.Text = "";
            txtNIC.Text = "";
            txtPNO.Text = "";
            dgvApplicantAcceptance.DataSource = null;
        }

        //To Search data after giving Applicant ID or NIC or Passport Number.
        private void btnSearch_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("Select APL_ID,AP_ID,NIC,PassportNo,ReservationFee,Date,AggrementStartingDate from Applicant_Table " +
                "where APL_ID=@APL_ID or NIC=@NIC or PassportNo=@PassportNo", con);
            cmd.Parameters.AddWithValue("@APL_ID", txtAPL_ID.Text);
            cmd.Parameters.AddWithValue("@NIC", txtNIC.Text);
            cmd.Parameters.AddWithValue("@PassportNo", txtPNO.Text);

            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                txtAPL_ID.Text = sdr["APL_ID"].ToString();
                txtNIC.Text = sdr["NIC"].ToString();
                txtPNO.Text = sdr["PassportNo"].ToString();
                sdr.Close();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvApplicantAcceptance.DataSource = dt;

                dgvApplicantAcceptance.Columns[0].Width = 80;
                dgvApplicantAcceptance.Columns[1].Width = 80;
                dgvApplicantAcceptance.Columns[2].Width = 100;
                dgvApplicantAcceptance.Columns[3].Width = 100;
                dgvApplicantAcceptance.Columns[4].Width = 200;
                dgvApplicantAcceptance.Columns[5].Width = 200;
                dgvApplicantAcceptance.Columns[6].Width = 200;

                MessageBox.Show("Data Search Successfully", "Message", MessageBoxButtons.OK);

            }
            else
            {
                MessageBox.Show("Please Enter Applicant ID or NIC or Passport Number", "Message", MessageBoxButtons.OK);
            }

            con.Close();
        }

        // To Clear fields.
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        //To search all the records by ascending order of the date "Date".
        private void btnAll_Click(object sender, EventArgs e)
        {

            con.Open();
            cmd = new SqlCommand("Select APL_ID,AP_ID,NIC,PassportNo,ReservationFee,Date,AggrementStartingDate from Applicant_Table order by Date Asc;", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvApplicantAcceptance.DataSource = dt;

            foreach (DataGridViewRow row in dgvApplicantAcceptance.Rows)
            {
                row.ReadOnly = true;
            }
            dgvApplicantAcceptance.Columns[0].Width = 80;
            dgvApplicantAcceptance.Columns[1].Width = 80;
            dgvApplicantAcceptance.Columns[2].Width = 100;
            dgvApplicantAcceptance.Columns[3].Width = 100;
            dgvApplicantAcceptance.Columns[4].Width = 200;
            dgvApplicantAcceptance.Columns[5].Width = 200;
            dgvApplicantAcceptance.Columns[6].Width = 200;

            con.Close();
        }

        // Delete the selected record in datagrideview.
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
                    "where APL_ID=@APL_ID", con);
                cmd.Parameters.AddWithValue("@APL_ID", txtAPL_ID.Text);
                cmd.ExecuteNonQuery();

                int rowIndex = dgvApplicantAcceptance.CurrentCell.RowIndex;
                dgvApplicantAcceptance.Rows.RemoveAt(rowIndex);
            }
            con.Close();
            MessageBox.Show("Data Deleted Successfully", "Message", MessageBoxButtons.OK);

        }
    }
}
