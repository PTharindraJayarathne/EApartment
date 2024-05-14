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
    public partial class ApartmentUC : UserControl
    {
        //Connection
        SqlConnection con = new SqlConnection(Properties.Settings.Default.EApartmentConnectionString);
        SqlCommand cmd = new SqlCommand();
        public ApartmentUC()
        {
            InitializeComponent();
        }
        //To Search 
        private void btnSave_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("Select a.AP_ID, a.B_ID, a.PS_ID, a.CH_ID, a.Category, a.Rent, a.State, a.Location, b.NIC, b.PassportNo " +
                " from Apartment_Table a,ChiefOccupant_Table b " +
                "where a.CH_ID=b.CH_ID and a.CH_ID=@CH_ID and b.CH_ID=@CH_ID", con);
                cmd.Parameters.AddWithValue("@CH_ID", txtCH_ID.Text);

            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();

            if (sdr.Read())
            {
                txtCH_ID.Text = sdr["CH_ID"].ToString();
                txtNIC.Text = sdr["NIC"].ToString();
                txtPNo.Text = sdr["PassportNO"].ToString();
                txtAP_ID.Text = sdr["AP_ID"].ToString();
                txtB_ID.Text = sdr["B_ID"].ToString();
                txtPS_ID.Text = sdr["PS_ID"].ToString();
                txtCatogary.Text = sdr["Category"].ToString();
                txtMRent.Text = sdr["Rent"].ToString();
                txtState.Text = sdr["State"].ToString();
                txtLocation.Text = sdr["Location"].ToString();

                MessageBox.Show("Data Search Successfully", "Message", MessageBoxButtons.OK);

            }
            else
            {
                MessageBox.Show("Please Enter CH_ID", "Message", MessageBoxButtons.OK);
            }

            con.Close();
        }
    }
}
