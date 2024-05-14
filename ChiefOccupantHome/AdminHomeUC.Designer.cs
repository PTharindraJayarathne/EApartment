namespace ChiefOccupantHome
{
    partial class AdminHomeUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlEApartment = new System.Windows.Forms.Panel();
            this.lblEApartment = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pctbuildingIcon = new System.Windows.Forms.PictureBox();
            this.pnlEApartment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctbuildingIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlEApartment
            // 
            this.pnlEApartment.BackColor = System.Drawing.Color.BlueViolet;
            this.pnlEApartment.Controls.Add(this.lblEApartment);
            this.pnlEApartment.Controls.Add(this.pctbuildingIcon);
            this.pnlEApartment.ForeColor = System.Drawing.Color.White;
            this.pnlEApartment.Location = new System.Drawing.Point(0, -1);
            this.pnlEApartment.Margin = new System.Windows.Forms.Padding(2);
            this.pnlEApartment.Name = "pnlEApartment";
            this.pnlEApartment.Size = new System.Drawing.Size(1167, 93);
            this.pnlEApartment.TabIndex = 19;
            // 
            // lblEApartment
            // 
            this.lblEApartment.AutoSize = true;
            this.lblEApartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEApartment.Location = new System.Drawing.Point(415, 30);
            this.lblEApartment.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEApartment.Name = "lblEApartment";
            this.lblEApartment.Size = new System.Drawing.Size(489, 33);
            this.lblEApartment.TabIndex = 4;
            this.lblEApartment.Text = "E-Apartments Managment System";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::ChiefOccupantHome.Properties.Resources.BackgroundImage;
            this.pictureBox2.Location = new System.Drawing.Point(0, 92);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1167, 616);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 20;
            this.pictureBox2.TabStop = false;
            // 
            // pctbuildingIcon
            // 
            this.pctbuildingIcon.Image = global::ChiefOccupantHome.Properties.Resources.bulding_icon;
            this.pctbuildingIcon.Location = new System.Drawing.Point(945, -9);
            this.pctbuildingIcon.Margin = new System.Windows.Forms.Padding(2);
            this.pctbuildingIcon.Name = "pctbuildingIcon";
            this.pctbuildingIcon.Size = new System.Drawing.Size(118, 113);
            this.pctbuildingIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctbuildingIcon.TabIndex = 3;
            this.pctbuildingIcon.TabStop = false;
            // 
            // AdminHomeUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pnlEApartment);
            this.Name = "AdminHomeUC";
            this.Size = new System.Drawing.Size(1167, 706);
            this.pnlEApartment.ResumeLayout(false);
            this.pnlEApartment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctbuildingIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel pnlEApartment;
        private System.Windows.Forms.Label lblEApartment;
        private System.Windows.Forms.PictureBox pctbuildingIcon;
    }
}
