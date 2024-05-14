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
    public partial class PersonalUC : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.EApartmentConnectionString);
        SqlCommand cmd = new SqlCommand();
        public PersonalUC()
        {
            InitializeComponent();
        }
        //To Search data after giving CH_ID, NIC, PassportNo
        private void btnSearch_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("Select * from  ChiefOccupant_Table " +
                "where CH_ID=@CH_ID or NIC=@NIC or PassportNo=@PassportNo", con);
            cmd.Parameters.AddWithValue("@CH_ID", txtCH_ID.Text);
            cmd.Parameters.AddWithValue("@NIC", txtNIC.Text);
            cmd.Parameters.AddWithValue("@PassportNo", txtPassportNo.Text);

            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                txtCH_ID.Text = sdr["CH_ID"].ToString();
                txtName.Text = sdr["Name"].ToString();
                txtNIC.Text = sdr["NIC"].ToString();
                txtPassportNo.Text = sdr["PassportNO"].ToString();
                txtNationality.Text = sdr["Nationality"].ToString();
                txtCountry.Text = sdr["Country"].ToString();
                txtGender.Text = sdr["Gender"].ToString();
                txtOccupation.Text = sdr["Occupation"].ToString();
                txtM1No.Text = sdr["MobileNo1"].ToString();
                txtM2No.Text = sdr["MobileNo2"].ToString();
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
    }
}
