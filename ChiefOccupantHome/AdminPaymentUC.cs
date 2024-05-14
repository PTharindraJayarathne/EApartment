using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.VisualBasic;

namespace ChiefOccupantHome
{

    public partial class AdminPaymentUC : UserControl
    {
        //Connection
        SqlConnection con = new SqlConnection(Properties.Settings.Default.EApartmentConnectionString);
        SqlCommand cmd = new SqlCommand();
        public AdminPaymentUC()
        {
            InitializeComponent();
        }

        // To clear the text boxes
        private void ClearFields()
        {
            txtCH_ID.Text = "";
            txtNIC.Text = "";
            txtPNo.Text = "";
            txtAP_ID.Text = "";
            txtMonth.Text = "";
            txtRent.Text = "";
            txtParkingSpaceID.Text = "";
            txtFee.Text = "";
            txtCH_PAY_ID.Text = "";
            txtTotal.Text = "";
            //dtpPayment.DataSource = null;
        }

        // To valid data
        private bool DataValid()
        {
            if (txtCH_ID.Text == "")
            {
                MessageBox.Show("Enter Chief Occupant ID");
                return false;
            }
            if (txtAP_ID.Text == "")
            {
                MessageBox.Show("Enter Chief Occupant Apartment ID");
                return false;
            }
            if (txtMonth.Text == "")
            {
                MessageBox.Show("Enter Month");
                return false;
            }
            if (txtRent.Text == "")
            {
                MessageBox.Show("Enter Rent of the Apartment");
                return false;
            }
            if (!Information.IsNumeric(txtRent.Text))
            {
                MessageBox.Show("Please enter a numeric Value for Rent of the Apartment");
                return false;
            }
            if (txtParkingSpaceID.Text == "")
            {
                MessageBox.Show("Enter Chief Occupant Parking Space ID");
                return false;
            }
            if (txtFee.Text == "")
            {
                MessageBox.Show("Enter Parking Space Fee");
                return false;
            }
            if (!Information.IsNumeric(txtFee.Text))
            {
                MessageBox.Show("Please enter a numeric Value for Parking Space Fee");
                return false;
            }

            return true;
        }


        //To Search
        private void btnSearch_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("Select a.CH_PAY_ID, a.CH_ID, a.AP_ID, a.Month, a.Rent, a.PS_ID, a.Fee, a.Date, b.NIC, b.PassportNo " +
                " from ChiefOccupantPay_Table a,ChiefOccupant_Table b " +
                "where a.CH_ID=b.CH_ID and a.CH_ID=@CH_ID and b.CH_ID=@CH_ID or a.CH_PAY_ID=@CH_PAY_ID", con);
            cmd.Parameters.AddWithValue("@CH_ID", txtCH_ID.Text);
            cmd.Parameters.AddWithValue("@CH_PAY_ID", txtCH_PAY_ID.Text);

            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                txtCH_PAY_ID.Text = sdr["CH_PAY_ID"].ToString();
                txtCH_ID.Text = sdr["CH_ID"].ToString();
                txtAP_ID.Text = sdr["AP_ID"].ToString();
                txtMonth.Text = sdr["Month"].ToString();
                txtRent.Text = sdr["Rent"].ToString();
                txtParkingSpaceID.Text = sdr["PS_ID"].ToString();
                txtFee.Text = sdr["Fee"].ToString();
                dtpPayment.Value = (DateTime)sdr["Date"];
                txtNIC.Text = sdr["NIC"].ToString();
                txtPNo.Text = sdr["PassportNo"].ToString();
                sdr.Close();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvPayment.DataSource = dt;

                dgvPayment.Columns[0].Width = 70;
                dgvPayment.Columns[1].Width = 50;
                dgvPayment.Columns[2].Width = 50;
                dgvPayment.Columns[4].Width = 95;
                dgvPayment.Columns[5].Width = 50;
                dgvPayment.Columns[6].Width = 95;
                dgvPayment.Columns[7].Width = 95;
                dgvPayment.Columns[8].Width = 95;
                dgvPayment.Columns[9].Width = 95;


                MessageBox.Show("Data Search Successfully", "Message", MessageBoxButtons.OK);

            }
            else
            {
                MessageBox.Show("Please Enter CH_ID", "Message", MessageBoxButtons.OK);
            }

            con.Close();
        }

        // To Save Data
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (DataValid())
            {
                con.Open();
                cmd = new SqlCommand("Insert into ChiefOccupantPay_Table values " +
                    "(@CH_ID,@AP_ID,@Month,@Rent,@PS_ID,@Fee,@Date) ", con);
                cmd.Parameters.AddWithValue("@CH_ID", txtCH_ID.Text);
                cmd.Parameters.AddWithValue("@AP_ID", txtAP_ID.Text);
                cmd.Parameters.AddWithValue("@Month", txtMonth.Text);
                cmd.Parameters.AddWithValue("@Rent", txtRent.Text);
                cmd.Parameters.AddWithValue("@PS_ID", txtParkingSpaceID.Text);
                cmd.Parameters.AddWithValue("@Fee", txtFee.Text);
                cmd.Parameters.AddWithValue("@Date", dtpPayment.Value);
                cmd.ExecuteNonQuery();


                con.Close();
                MessageBox.Show("Data Saved Successfully", "Message", MessageBoxButtons.OK);

                ClearFields();
            }
        }

        //To Update Data
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (DataValid())
            {

                con.Open();
                cmd = new SqlCommand("Update ChiefOccupantPay_Table set CH_ID='" + txtCH_ID.Text + "', AP_ID='" + txtAP_ID.Text + "',Month='" + txtMonth.Text + "'," +
                " Rent='" + txtRent.Text + "', PS_ID='" + txtParkingSpaceID.Text + "', Date='" + dtpPayment.Value + "' where CH_PAY_ID= '" + txtCH_PAY_ID.Text + "' ", con);

                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Data Updated Successfully", "Message", MessageBoxButtons.OK);

                ClearFields();
            }
        }

        //To delete record 
        private void btnDelete_Click(object sender, EventArgs e)
        {
            con.Open();
            //Verify to delete the record
            var confirmResult = MessageBox.Show("Are you sure to delete this record ??",
                                   "Confirm Delete!!",
                                   MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                cmd = new SqlCommand("delete ChiefOccupantPay_Table " +
                    "where CH_PAY_ID=@CH_PAY_ID", con);
                cmd.Parameters.AddWithValue("@CH_PAY_ID", txtCH_PAY_ID.Text);
                cmd.ExecuteNonQuery();
            }
            con.Close();
            MessageBox.Show("Data Deleted Successfully", "Message", MessageBoxButtons.OK);

            ClearFields();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            double num1, num2, res;
           num1 = Convert.ToDouble(txtRent.Text);
           num2 = Convert.ToDouble(txtFee.Text);
            res = num1+ num2;
            txtTotal.Text = Convert.ToString(res);
        }


        // To generate a report
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            string titel = "Monthly Payment";
            e.Graphics.DrawString(titel, new Font("Times New Roman", 25, FontStyle.Bold), Brushes.Black, new PointF(100, 100));


            string payid = "Payment ID :" + txtCH_PAY_ID.Text;
            e.Graphics.DrawString(payid, new Font("Times New Roman", 15, FontStyle.Bold), Brushes.Black, new PointF(100, 200));

            string CHid = "Chief Occupant ID :" + txtCH_ID.Text;
            e.Graphics.DrawString(CHid, new Font("Times New Roman", 15, FontStyle.Bold), Brushes.Black, new PointF(100, 250));

            string nic = "Chief Occupant NIC :" + txtNIC.Text;
            e.Graphics.DrawString(nic, new Font("Times New Roman",15,FontStyle.Bold), Brushes.Black, new PointF(100,300));


            string Month = "Month :" + txtMonth.Text;
            e.Graphics.DrawString(Month, new Font("Times New Roman", 15, FontStyle.Bold), Brushes.Black, new PointF(100, 400));

            string date = "Date :" + dtpPayment.Value.ToString("yyyy-MM-dd");
            e.Graphics.DrawString(date, new Font("Times New Roman", 15, FontStyle.Bold), Brushes.Black, new PointF(100, 450));


            string APid = "Apartment ID :" + txtAP_ID.Text;
            e.Graphics.DrawString(APid, new Font("Times New Roman", 15, FontStyle.Bold), Brushes.Black, new PointF(100, 550));
            string rent = "Apartment Rent :" + txtRent.Text;
            e.Graphics.DrawString(rent, new Font("Times New Roman", 15, FontStyle.Bold), Brushes.Black, new PointF(100, 600));
            string PSid = "Parking Space ID :" + txtParkingSpaceID.Text;
            e.Graphics.DrawString(PSid        , new Font("Times New Roman", 15, FontStyle.Bold), Brushes.Black, new PointF(100, 650));
            string fee = "Parking Space Fee :" + txtFee.Text;
            e.Graphics.DrawString(fee, new Font("Times New Roman", 15, FontStyle.Bold), Brushes.Black, new PointF(100, 700));

            string total = "Total :" + txtTotal.Text;
            e.Graphics.DrawString(total, new Font("Times New Roman", 15, FontStyle.Bold), Brushes.Black, new PointF(100, 750));
 
        }

        Bitmap bmp;

        private void btnReport_Click(object sender, EventArgs e)
        {

            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
                      

        }



        private void AdminPaymentUC_Load(object sender, EventArgs e)
        {
            //using (EApartmentDataSet db = new EApartmentDataSet()) 
            //{
            //    pro.DataSource = db.ChiefOccupantPay_Table.ToList;

            //}


            //Graphics g = this.CreateGraphics();
            //bmp = new Bitmap(this.Size.Width, this.Size.Height, g);
            //Graphics mg = Graphics.FromImage(bmp);
            //mg.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);
            //printPreviewDialog1.ShowDialog();
        }
    }
}
