namespace ChiefOccupantHome
{
    partial class frmCustomerHome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblHome = new System.Windows.Forms.Label();
            this.pnlEApartment = new System.Windows.Forms.Panel();
            this.lblEApartment = new System.Windows.Forms.Label();
            this.pctbuildingIcon = new System.Windows.Forms.PictureBox();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.SidePnl = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pctApartment = new System.Windows.Forms.PictureBox();
            this.pctDependent = new System.Windows.Forms.PictureBox();
            this.pctLeaseAgre = new System.Windows.Forms.PictureBox();
            this.btnDependent = new System.Windows.Forms.Button();
            this.btnLeaseAgre = new System.Windows.Forms.Button();
            this.btnApartment = new System.Windows.Forms.Button();
            this.btnPersonal = new System.Windows.Forms.Button();
            this.pctHomeIcon = new System.Windows.Forms.PictureBox();
            this.pnlUpper = new System.Windows.Forms.Panel();
            this.leaseAgreementUC1 = new ChiefOccupantHome.LeaseAgreementUC();
            this.apartmentUC1 = new ChiefOccupantHome.ApartmentUC();
            this.dependentUC1 = new ChiefOccupantHome.DependentUC();
            this.personalUC1 = new ChiefOccupantHome.PersonalUC();
            this.btnSignOut = new System.Windows.Forms.Button();
            this.pctLog = new System.Windows.Forms.PictureBox();
            this.pnlEApartment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctbuildingIcon)).BeginInit();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctApartment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctDependent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctLeaseAgre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctHomeIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctLog)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHome
            // 
            this.lblHome.AutoSize = true;
            this.lblHome.Font = new System.Drawing.Font("Microsoft YaHei", 19.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHome.ForeColor = System.Drawing.Color.White;
            this.lblHome.Location = new System.Drawing.Point(103, 50);
            this.lblHome.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHome.Name = "lblHome";
            this.lblHome.Size = new System.Drawing.Size(99, 34);
            this.lblHome.TabIndex = 7;
            this.lblHome.Text = "HOME";
            // 
            // pnlEApartment
            // 
            this.pnlEApartment.BackColor = System.Drawing.Color.BlueViolet;
            this.pnlEApartment.Controls.Add(this.lblEApartment);
            this.pnlEApartment.Controls.Add(this.pctbuildingIcon);
            this.pnlEApartment.ForeColor = System.Drawing.Color.White;
            this.pnlEApartment.Location = new System.Drawing.Point(274, 17);
            this.pnlEApartment.Margin = new System.Windows.Forms.Padding(2);
            this.pnlEApartment.Name = "pnlEApartment";
            this.pnlEApartment.Size = new System.Drawing.Size(998, 93);
            this.pnlEApartment.TabIndex = 8;
            // 
            // lblEApartment
            // 
            this.lblEApartment.AutoSize = true;
            this.lblEApartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F, System.Drawing.FontStyle.Bold);
            this.lblEApartment.Location = new System.Drawing.Point(375, 33);
            this.lblEApartment.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEApartment.Name = "lblEApartment";
            this.lblEApartment.Size = new System.Drawing.Size(434, 30);
            this.lblEApartment.TabIndex = 4;
            this.lblEApartment.Text = "E-Apartments Managment System";
            // 
            // pctbuildingIcon
            // 
            this.pctbuildingIcon.Image = global::ChiefOccupantHome.Properties.Resources.bulding_icon;
            this.pctbuildingIcon.Location = new System.Drawing.Point(854, -10);
            this.pctbuildingIcon.Margin = new System.Windows.Forms.Padding(2);
            this.pctbuildingIcon.Name = "pctbuildingIcon";
            this.pctbuildingIcon.Size = new System.Drawing.Size(109, 102);
            this.pctbuildingIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctbuildingIcon.TabIndex = 3;
            this.pctbuildingIcon.TabStop = false;
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.Indigo;
            this.pnlMenu.Controls.Add(this.pctLog);
            this.pnlMenu.Controls.Add(this.btnSignOut);
            this.pnlMenu.Controls.Add(this.SidePnl);
            this.pnlMenu.Controls.Add(this.pictureBox4);
            this.pnlMenu.Controls.Add(this.pctApartment);
            this.pnlMenu.Controls.Add(this.pctDependent);
            this.pnlMenu.Controls.Add(this.pctLeaseAgre);
            this.pnlMenu.Controls.Add(this.btnDependent);
            this.pnlMenu.Controls.Add(this.btnLeaseAgre);
            this.pnlMenu.Controls.Add(this.btnApartment);
            this.pnlMenu.Controls.Add(this.btnPersonal);
            this.pnlMenu.Controls.Add(this.pctHomeIcon);
            this.pnlMenu.Controls.Add(this.lblHome);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.ForeColor = System.Drawing.Color.White;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Margin = new System.Windows.Forms.Padding(2);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(274, 613);
            this.pnlMenu.TabIndex = 9;
            // 
            // SidePnl
            // 
            this.SidePnl.BackColor = System.Drawing.Color.MediumPurple;
            this.SidePnl.Location = new System.Drawing.Point(0, 125);
            this.SidePnl.Margin = new System.Windows.Forms.Padding(2);
            this.SidePnl.Name = "SidePnl";
            this.SidePnl.Size = new System.Drawing.Size(14, 63);
            this.SidePnl.TabIndex = 0;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::ChiefOccupantHome.Properties.Resources.personalIcon;
            this.pictureBox4.Location = new System.Drawing.Point(28, 136);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(34, 35);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 16;
            this.pictureBox4.TabStop = false;
            // 
            // pctApartment
            // 
            this.pctApartment.Image = global::ChiefOccupantHome.Properties.Resources.departmenticon;
            this.pctApartment.Location = new System.Drawing.Point(28, 305);
            this.pctApartment.Margin = new System.Windows.Forms.Padding(2);
            this.pctApartment.Name = "pctApartment";
            this.pctApartment.Size = new System.Drawing.Size(34, 35);
            this.pctApartment.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctApartment.TabIndex = 15;
            this.pctApartment.TabStop = false;
            // 
            // pctDependent
            // 
            this.pctDependent.Image = global::ChiefOccupantHome.Properties.Resources.dependentIcon;
            this.pctDependent.Location = new System.Drawing.Point(28, 222);
            this.pctDependent.Margin = new System.Windows.Forms.Padding(2);
            this.pctDependent.Name = "pctDependent";
            this.pctDependent.Size = new System.Drawing.Size(34, 35);
            this.pctDependent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctDependent.TabIndex = 14;
            this.pctDependent.TabStop = false;
            // 
            // pctLeaseAgre
            // 
            this.pctLeaseAgre.Image = global::ChiefOccupantHome.Properties.Resources.contractIcon6;
            this.pctLeaseAgre.Location = new System.Drawing.Point(28, 389);
            this.pctLeaseAgre.Margin = new System.Windows.Forms.Padding(2);
            this.pctLeaseAgre.Name = "pctLeaseAgre";
            this.pctLeaseAgre.Size = new System.Drawing.Size(34, 35);
            this.pctLeaseAgre.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctLeaseAgre.TabIndex = 13;
            this.pctLeaseAgre.TabStop = false;
            this.pctLeaseAgre.Click += new System.EventHandler(this.pctLeaseAgre_Click);
            // 
            // btnDependent
            // 
            this.btnDependent.FlatAppearance.BorderSize = 0;
            this.btnDependent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDependent.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDependent.Location = new System.Drawing.Point(2, 208);
            this.btnDependent.Margin = new System.Windows.Forms.Padding(2);
            this.btnDependent.Name = "btnDependent";
            this.btnDependent.Size = new System.Drawing.Size(272, 63);
            this.btnDependent.TabIndex = 12;
            this.btnDependent.Text = "           Dependent";
            this.btnDependent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDependent.UseVisualStyleBackColor = true;
            this.btnDependent.Click += new System.EventHandler(this.btnDependent_Click);
            // 
            // btnLeaseAgre
            // 
            this.btnLeaseAgre.FlatAppearance.BorderSize = 0;
            this.btnLeaseAgre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeaseAgre.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeaseAgre.Location = new System.Drawing.Point(0, 374);
            this.btnLeaseAgre.Margin = new System.Windows.Forms.Padding(2);
            this.btnLeaseAgre.Name = "btnLeaseAgre";
            this.btnLeaseAgre.Size = new System.Drawing.Size(274, 63);
            this.btnLeaseAgre.TabIndex = 10;
            this.btnLeaseAgre.Text = "          Lease Agreement";
            this.btnLeaseAgre.UseVisualStyleBackColor = true;
            this.btnLeaseAgre.Click += new System.EventHandler(this.btnLeaseAgre_Click);
            // 
            // btnApartment
            // 
            this.btnApartment.FlatAppearance.BorderSize = 0;
            this.btnApartment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApartment.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApartment.Location = new System.Drawing.Point(2, 291);
            this.btnApartment.Margin = new System.Windows.Forms.Padding(2);
            this.btnApartment.Name = "btnApartment";
            this.btnApartment.Size = new System.Drawing.Size(272, 63);
            this.btnApartment.TabIndex = 9;
            this.btnApartment.Text = "           Apartment";
            this.btnApartment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnApartment.UseVisualStyleBackColor = true;
            this.btnApartment.Click += new System.EventHandler(this.btnApartment_Click);
            // 
            // btnPersonal
            // 
            this.btnPersonal.FlatAppearance.BorderSize = 0;
            this.btnPersonal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPersonal.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPersonal.Location = new System.Drawing.Point(0, 125);
            this.btnPersonal.Margin = new System.Windows.Forms.Padding(2);
            this.btnPersonal.Name = "btnPersonal";
            this.btnPersonal.Size = new System.Drawing.Size(274, 63);
            this.btnPersonal.TabIndex = 8;
            this.btnPersonal.Text = "            Personal";
            this.btnPersonal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPersonal.UseVisualStyleBackColor = true;
            this.btnPersonal.Click += new System.EventHandler(this.btnPersonal_Click);
            // 
            // pctHomeIcon
            // 
            this.pctHomeIcon.Image = global::ChiefOccupantHome.Properties.Resources._115_1153942_white_home_icon_png_white_home_logo_transparent1;
            this.pctHomeIcon.Location = new System.Drawing.Point(64, 49);
            this.pctHomeIcon.Margin = new System.Windows.Forms.Padding(2);
            this.pctHomeIcon.Name = "pctHomeIcon";
            this.pctHomeIcon.Size = new System.Drawing.Size(34, 35);
            this.pctHomeIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctHomeIcon.TabIndex = 6;
            this.pctHomeIcon.TabStop = false;
            // 
            // pnlUpper
            // 
            this.pnlUpper.BackColor = System.Drawing.Color.MediumPurple;
            this.pnlUpper.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUpper.Location = new System.Drawing.Point(274, 0);
            this.pnlUpper.Margin = new System.Windows.Forms.Padding(2);
            this.pnlUpper.Name = "pnlUpper";
            this.pnlUpper.Size = new System.Drawing.Size(998, 20);
            this.pnlUpper.TabIndex = 8;
            // 
            // leaseAgreementUC1
            // 
            this.leaseAgreementUC1.Location = new System.Drawing.Point(274, 111);
            this.leaseAgreementUC1.Name = "leaseAgreementUC1";
            this.leaseAgreementUC1.Size = new System.Drawing.Size(998, 500);
            this.leaseAgreementUC1.TabIndex = 18;
            this.leaseAgreementUC1.Load += new System.EventHandler(this.leaseAgreementUC1_Load);
            // 
            // apartmentUC1
            // 
            this.apartmentUC1.Location = new System.Drawing.Point(275, 111);
            this.apartmentUC1.Margin = new System.Windows.Forms.Padding(2);
            this.apartmentUC1.Name = "apartmentUC1";
            this.apartmentUC1.Size = new System.Drawing.Size(998, 500);
            this.apartmentUC1.TabIndex = 18;
            // 
            // dependentUC1
            // 
            this.dependentUC1.Location = new System.Drawing.Point(274, 110);
            this.dependentUC1.Name = "dependentUC1";
            this.dependentUC1.Size = new System.Drawing.Size(998, 500);
            this.dependentUC1.TabIndex = 18;
            // 
            // personalUC1
            // 
            this.personalUC1.Location = new System.Drawing.Point(274, 110);
            this.personalUC1.Margin = new System.Windows.Forms.Padding(2);
            this.personalUC1.Name = "personalUC1";
            this.personalUC1.Size = new System.Drawing.Size(998, 503);
            this.personalUC1.TabIndex = 10;
            // 
            // btnSignOut
            // 
            this.btnSignOut.FlatAppearance.BorderSize = 0;
            this.btnSignOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSignOut.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignOut.Location = new System.Drawing.Point(4, 504);
            this.btnSignOut.Margin = new System.Windows.Forms.Padding(2);
            this.btnSignOut.Name = "btnSignOut";
            this.btnSignOut.Size = new System.Drawing.Size(270, 63);
            this.btnSignOut.TabIndex = 18;
            this.btnSignOut.Text = "Sign Out";
            this.btnSignOut.UseVisualStyleBackColor = true;
            this.btnSignOut.Click += new System.EventHandler(this.btnSignOut_Click);
            // 
            // pctLog
            // 
            this.pctLog.Image = global::ChiefOccupantHome.Properties.Resources.loginIcon1;
            this.pctLog.Location = new System.Drawing.Point(38, 511);
            this.pctLog.Margin = new System.Windows.Forms.Padding(2);
            this.pctLog.Name = "pctLog";
            this.pctLog.Size = new System.Drawing.Size(44, 46);
            this.pctLog.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctLog.TabIndex = 19;
            this.pctLog.TabStop = false;
            // 
            // frmCustomerHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 613);
            this.Controls.Add(this.leaseAgreementUC1);
            this.Controls.Add(this.apartmentUC1);
            this.Controls.Add(this.dependentUC1);
            this.Controls.Add(this.personalUC1);
            this.Controls.Add(this.pnlUpper);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlEApartment);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmCustomerHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCustomerHome";
            this.Load += new System.EventHandler(this.frmCustomerHome_Load);
            this.pnlEApartment.ResumeLayout(false);
            this.pnlEApartment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctbuildingIcon)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctApartment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctDependent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctLeaseAgre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctHomeIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblHome;
        private System.Windows.Forms.PictureBox pctHomeIcon;
        private System.Windows.Forms.Panel pnlEApartment;
        private System.Windows.Forms.Label lblEApartment;
        private System.Windows.Forms.PictureBox pctbuildingIcon;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pctApartment;
        private System.Windows.Forms.PictureBox pctDependent;
        private System.Windows.Forms.PictureBox pctLeaseAgre;
        private System.Windows.Forms.Button btnDependent;
        private System.Windows.Forms.Button btnLeaseAgre;
        private System.Windows.Forms.Button btnApartment;
        private System.Windows.Forms.Button btnPersonal;
        private System.Windows.Forms.Panel pnlUpper;
        private System.Windows.Forms.Panel SidePnl;
        private PersonalUC personalUC1;
        private DependentUC dependentUC1;
        private ApartmentUC apartmentUC1;
        private LeaseAgreementUC leaseAgreementUC1;
        private System.Windows.Forms.PictureBox pctLog;
        private System.Windows.Forms.Button btnSignOut;
    }
}