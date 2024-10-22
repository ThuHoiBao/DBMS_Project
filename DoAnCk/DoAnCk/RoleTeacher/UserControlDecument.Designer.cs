namespace DoAnCk.RoleTeacher
{
    partial class UserControlDecument
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
            this.lblSTT = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblDate = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.picImage = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.lblId = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSTT
            // 
            this.lblSTT.BackColor = System.Drawing.Color.Transparent;
            this.lblSTT.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSTT.Location = new System.Drawing.Point(17, 21);
            this.lblSTT.Name = "lblSTT";
            this.lblSTT.Size = new System.Drawing.Size(15, 27);
            this.lblSTT.TabIndex = 13;
            this.lblSTT.Text = "1";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = false;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(413, 21);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(262, 27);
            this.lblTitle.TabIndex = 12;
            this.lblTitle.Text = "Lập Trình Winform";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = false;
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(202, 21);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(144, 27);
            this.lblDate.TabIndex = 11;
            this.lblDate.Text = "Winform_09";
            // 
            // picImage
            // 
            this.picImage.Image = global::DoAnCk.Properties.Resources.graduation;
            this.picImage.ImageRotate = 0F;
            this.picImage.Location = new System.Drawing.Point(97, 8);
            this.picImage.Name = "picImage";
            this.picImage.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picImage.Size = new System.Drawing.Size(50, 50);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImage.TabIndex = 10;
            this.picImage.TabStop = false;
            // 
            // lblId
            // 
            this.lblId.BackColor = System.Drawing.Color.Transparent;
            this.lblId.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.Location = new System.Drawing.Point(66, 21);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(15, 27);
            this.lblId.TabIndex = 14;
            this.lblId.Text = "1";
            this.lblId.Visible = false;
            // 
            // UserControlDecument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.lblSTT);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.picImage);
            this.Name = "UserControlDecument";
            this.Size = new System.Drawing.Size(691, 65);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Guna.UI2.WinForms.Guna2HtmlLabel lblSTT;
        public Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        public Guna.UI2.WinForms.Guna2HtmlLabel lblDate;
        public Guna.UI2.WinForms.Guna2CirclePictureBox picImage;
        public Guna.UI2.WinForms.Guna2HtmlLabel lblId;
    }
}
