using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChiefOccupantHome
{
    public partial class frmCustomerHome : Form
    {
        public frmCustomerHome()
        {
            InitializeComponent();
            SidePnl.Height= btnPersonal.Height;
            personalUC1.BringToFront();
        }

        private void frmCustomerHome_Load(object sender, EventArgs e)
        {

        }

        private void pctLeaseAgre_Click(object sender, EventArgs e)
        {

        }

        private void btnPersonal_Click(object sender, EventArgs e)
        {
            SidePnl.Height= btnPersonal.Height;
            SidePnl.Top= btnPersonal.Top;
            personalUC1.BringToFront();
        }

        private void btnApartment_Click(object sender, EventArgs e)
        {
            SidePnl.Height = btnApartment.Height;
            SidePnl.Top = btnApartment.Top;
            apartmentUC1.BringToFront();
        }

        private void btnDependent_Click(object sender, EventArgs e)
        {
            SidePnl.Height = btnDependent.Height;
            SidePnl.Top = btnDependent.Top;
            dependentUC1.BringToFront();


        }

        private void btnLeaseAgre_Click(object sender, EventArgs e)
        {
            SidePnl.Height = btnLeaseAgre.Height;
            SidePnl.Top = btnLeaseAgre.Top;
            leaseAgreementUC1.BringToFront();
        }

        private void leaseAgreementUC1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
            this.Hide();
        }




    }
}
