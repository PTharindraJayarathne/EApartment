using ChiefOccupantHome.EApartmentDataSetTableAdapters;
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
    public partial class DependentUC : UserControl
    {

        //Connection path
        SqlConnection con = new SqlConnection(Properties.Settings.Default.EApartmentConnectionString);
        SqlCommand cmd = new SqlCommand();
        public DependentUC()
        {
            InitializeComponent();
        }

      
        private void dgvCustomerHomeDependent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        // After pressing the search button view data using datagridview according to the data in the text box.
        private void btnSearch_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("Select * from Dependent_Table" +
                " where CH_ID= '" + txtCH_ID.Text + "' or NIC= '" +txtNIC.Text + "' or PassportNo= '" + txtPNo.Text + "' ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand= cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvCustomerHomeDependent.DataSource = dt;
            
            foreach (DataGridViewRow row in dgvCustomerHomeDependent.Rows)
            {
                row.ReadOnly= true;
            }

            dgvCustomerHomeDependent.Columns[0].Width = 50;
            dgvCustomerHomeDependent.Columns[1].Width = 50;
            dgvCustomerHomeDependent.Columns[2].Width = 95;
            dgvCustomerHomeDependent.Columns[4].Width = 95;
            dgvCustomerHomeDependent.Columns[5].Width = 95;
            dgvCustomerHomeDependent.Columns[6].Width = 75;
            dgvCustomerHomeDependent.Columns[7].Width = 75;
            dgvCustomerHomeDependent.Columns[8].Width = 60;
            dgvCustomerHomeDependent.Columns[9].Width = 80;
            dgvCustomerHomeDependent.Columns[10].Width = 95;
            dgvCustomerHomeDependent.Columns[11].Width = 150;
            dgvCustomerHomeDependent.Columns[12].Width = 200;
            con.Close();
           

        }

        
    }
}
