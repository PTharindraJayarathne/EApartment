namespace ChiefOccupantHome
{
    partial class frmReports
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
            this.pnltop1 = new System.Windows.Forms.Panel();
            this.pnltop2 = new System.Windows.Forms.Panel();
            this.pnlDown = new System.Windows.Forms.Panel();
            this.lblEApartment = new System.Windows.Forms.Label();
            this.pctbuildingIcon = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblReport = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.pnltop2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctbuildingIcon)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnltop1
            // 
            this.pnltop1.BackColor = System.Drawing.Color.MediumPurple;
            this.pnltop1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnltop1.Location = new System.Drawing.Point(0, 0);
            this.pnltop1.Name = "pnltop1";
            this.pnltop1.Size = new System.Drawing.Size(1024, 20);
            this.pnltop1.TabIndex = 0;
            // 
            // pnltop2
            // 
            this.pnltop2.BackColor = System.Drawing.Color.BlueViolet;
            this.pnltop2.Controls.Add(this.button1);
            this.pnltop2.Controls.Add(this.panel1);
            this.pnltop2.Controls.Add(this.pctbuildingIcon);
            this.pnltop2.Controls.Add(this.lblEApartment);
            this.pnltop2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnltop2.Location = new System.Drawing.Point(0, 20);
            this.pnltop2.Name = "pnltop2";
            this.pnltop2.Size = new System.Drawing.Size(1024, 88);
            this.pnltop2.TabIndex = 1;
            // 
            // pnlDown
            // 
            this.pnlDown.BackColor = System.Drawing.Color.BlueViolet;
            this.pnlDown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDown.Location = new System.Drawing.Point(0, 748);
            this.pnlDown.Name = "pnlDown";
            this.pnlDown.Size = new System.Drawing.Size(1024, 17);
            this.pnlDown.TabIndex = 2;
            // 
            // lblEApartment
            // 
            this.lblEApartment.AutoSize = true;
            this.lblEApartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEApartment.ForeColor = System.Drawing.Color.White;
            this.lblEApartment.Location = new System.Drawing.Point(364, 31);
            this.lblEApartment.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEApartment.Name = "lblEApartment";
            this.lblEApartment.Size = new System.Drawing.Size(489, 33);
            this.lblEApartment.TabIndex = 5;
            this.lblEApartment.Text = "E-Apartments Managment System";
            // 
            // pctbuildingIcon
            // 
            this.pctbuildingIcon.Image = global::ChiefOccupantHome.Properties.Resources.bulding_icon;
            this.pctbuildingIcon.Location = new System.Drawing.Point(866, -7);
            this.pctbuildingIcon.Margin = new System.Windows.Forms.Padding(2);
            this.pctbuildingIcon.Name = "pctbuildingIcon";
            this.pctbuildingIcon.Size = new System.Drawing.Size(101, 95);
            this.pctbuildingIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctbuildingIcon.TabIndex = 4;
            this.pctbuildingIcon.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Indigo;
            this.panel1.Controls.Add(this.lblReport);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(269, 88);
            this.panel1.TabIndex = 3;
            // 
            // lblReport
            // 
            this.lblReport.AutoSize = true;
            this.lblReport.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReport.ForeColor = System.Drawing.Color.White;
            this.lblReport.Location = new System.Drawing.Point(76, 25);
            this.lblReport.Name = "lblReport";
            this.lblReport.Size = new System.Drawing.Size(116, 39);
            this.lblReport.TabIndex = 3;
            this.lblReport.Text = "Report";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Indigo;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 710);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1024, 38);
            this.panel2.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(992, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(29, 40);
            this.button1.TabIndex = 4;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // frmReports
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1024, 765);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlDown);
            this.Controls.Add(this.pnltop2);
            this.Controls.Add(this.pnltop1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmReports";
            this.pnltop2.ResumeLayout(false);
            this.pnltop2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctbuildingIcon)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnltop1;
        private System.Windows.Forms.Panel pnltop2;
        private System.Windows.Forms.Panel pnlDown;
        private System.Windows.Forms.Label lblEApartment;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblReport;
        private System.Windows.Forms.PictureBox pctbuildingIcon;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
    }
}