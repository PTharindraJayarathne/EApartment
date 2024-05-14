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
    public partial class frmAdminDashboard : Form
    {
        public frmAdminDashboard()
        {
            InitializeComponent();
            // Hide submenus when opening the admin dashboard
            Submenupanles();
            //Initiation of what to display when opening the admin dashboard
            Sidepnl2.Height = btnAdminHome.Height;
            Sidepnl2.Top = btnAdminHome.Top;
            adminHomeUC1.BringToFront();

        }
        // Method (to hide submenus when opening admin dashboard)
        private void Submenupanles()
        {
            pnlCustomer.Visible = false;
            pnlProperty.Visible = false;
            pnlLeaseAgre.Visible = false;
            pnlAdmin.Visible = false;
            pnlSettings.Visible = false;
        }
        // Method (to hide submenu after clicking a button in submenu)
        private void hidesubmenu()
        {
            if (pnlCustomer.Visible == true)
                pnlCustomer.Visible = false;
            if (pnlProperty.Visible == true)
                pnlProperty.Visible = false;
            if (pnlLeaseAgre.Visible == true)
                pnlLeaseAgre.Visible = false;
            if (pnlAdmin.Visible == true)
                pnlAdmin.Visible = false;
            if (pnlSettings.Visible == true)
                pnlSettings.Visible = false;
        }



        // Method (to show submenu when clicking the buttons in the main menu)
        private void showsubmenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hidesubmenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }





        private void btnCustomer_Click(object sender, EventArgs e)
        {
            // To determine where the side pane should display
            Sidepnl2.Height = btnCustomer.Height;
            Sidepnl2.Top = btnCustomer.Top;

            showsubmenu(pnlCustomer);
        }

        private void btnChiefOccupant_Click(object sender, EventArgs e)
        {

            Sidepnl2.Height = btnCustomer.Height;
            Sidepnl2.Top = btnCustomer.Top;
            adminChiefOccupantUC1.BringToFront();

            hidesubmenu();
        }

        private void btnDependent_Click(object sender, EventArgs e)
        {
            Sidepnl2.Height = btnCustomer.Height;
            Sidepnl2.Top = btnCustomer.Top;
            adminDependentUC1.BringToFront();


            hidesubmenu();
        }

        private void btnApplicant_Click(object sender, EventArgs e)
        {
            Sidepnl2.Height = btnCustomer.Height;
            Sidepnl2.Top = btnCustomer.Top;
            adminApplicantUC1.BringToFront();

            hidesubmenu();
        }

        private void btnApplicantAcceptance_Click(object sender, EventArgs e)
        {
            Sidepnl2.Height = btnCustomer.Height;
            Sidepnl2.Top = btnCustomer.Top;
            adminApplicantAcceptanceUC1.BringToFront();

            hidesubmenu();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            Sidepnl2.Height = btnCustomer.Height;
            Sidepnl2.Top = btnCustomer.Top;
            adminPaymentUC1.BringToFront();

            hidesubmenu();
        }



        private void btnProperty_Click(object sender, EventArgs e)
        {
            Sidepnl2.Height = btnProperty.Height;
            Sidepnl2.Top = btnProperty.Top;

            showsubmenu(pnlProperty);
        }

        private void btnApartment_Click(object sender, EventArgs e)
        {
            Sidepnl2.Height = btnProperty.Height;
            Sidepnl2.Top = btnProperty.Top;
            adminApartmentUC1.BringToFront();

            hidesubmenu();
        }

        private void btnParkingAndBuildings_Click(object sender, EventArgs e)
        {

            Sidepnl2.Height = btnProperty.Height;
            Sidepnl2.Top = btnProperty.Top;
            adminParkingAndBuildingsUC1.BringToFront();

            hidesubmenu();
        }

        private void btnrealParking_Click(object sender, EventArgs e)
        {
            Sidepnl2.Height = btnProperty.Height;
            Sidepnl2.Top = btnProperty.Top;
            adminRealParkingUC1.BringToFront();

            hidesubmenu();
        }




        private void btnLeaseAgre_Click_1(object sender, EventArgs e)
        {

            Sidepnl2.Height = btnLeaseAgre.Height;
            Sidepnl2.Top = btnLeaseAgre.Top;
            showsubmenu(pnlLeaseAgre);
        }
        private void btnLeaseDetails_Click_1(object sender, EventArgs e)
        {
            Sidepnl2.Height = btnLeaseAgre.Height;
            Sidepnl2.Top = btnLeaseAgre.Top;
            adminLeaseAgreementUC1.BringToFront();

            hidesubmenu();
        }
        private void btnExpansionRequest_Click(object sender, EventArgs e)
        {
            Sidepnl2.Height = btnLeaseAgre.Height;
            Sidepnl2.Top = btnLeaseAgre.Top;
            adminLeaseExpansionRequestUC1.BringToFront();

            hidesubmenu();
        }
        private void btnRequestAcceptance_Click_1(object sender, EventArgs e)
        {
            Sidepnl2.Height = btnLeaseAgre.Height;
            Sidepnl2.Top = btnLeaseAgre.Top;
            adminLeaseRequestAcceptanceUC1.BringToFront();

            hidesubmenu();
        }






        private void btnAAdmin_Click_1(object sender, EventArgs e)
        {
            Sidepnl2.Height = btnAAdmin.Height;
            Sidepnl2.Top = btnAAdmin.Top;

            showsubmenu(pnlAdmin);
        }



        private void btnStaff_Click_1(object sender, EventArgs e)
        {
            Sidepnl2.Height = btnAAdmin.Height;
            Sidepnl2.Top = btnAAdmin.Top;
            adminStaffUC1.BringToFront();

            hidesubmenu();
        }





        private void btnAdminHome_Click(object sender, EventArgs e)
        {
            Sidepnl2.Height = btnAdminHome.Height;
            Sidepnl2.Top = btnAdminHome.Top;
            adminHomeUC1.BringToFront();
        }

       

        private void btnSettings_Click_1(object sender, EventArgs e)
        {
            // To determine where the side pane should display
            Sidepnl2.Height = btnSettings.Height;
            Sidepnl2.Top = btnSettings.Top;
            showsubmenu(pnlSettings);

        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            Sidepnl2.Height = btnSettings.Height;
            Sidepnl2.Top = btnSettings.Top;
            adminLoginUC1.BringToFront();

            hidesubmenu();
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            Sidepnl2.Height = btnSignOut.Height;
            Sidepnl2.Top = btnSignOut.Top;

            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
            this.Hide();


        }

        private void adminRealParkingUC1_Load(object sender, EventArgs e)
        {

        }
    }
}
