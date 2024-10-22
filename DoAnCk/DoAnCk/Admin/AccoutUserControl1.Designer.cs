namespace DoAnCk
{
    partial class ucAccount
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
            this.components = new System.ComponentModel.Container();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.checkAccept = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.lblSTT = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblUserName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblUserAccount = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.picImage = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // checkAccept
            // 
            this.checkAccept.AllowDrop = true;
            this.checkAccept.BackColor = System.Drawing.Color.Transparent;
            this.checkAccept.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.checkAccept.CheckedState.BorderRadius = 2;
            this.checkAccept.CheckedState.BorderThickness = 0;
            this.checkAccept.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.checkAccept.Location = new System.Drawing.Point(721, 19);
            this.checkAccept.Name = "checkAccept";
            this.checkAccept.Size = new System.Drawing.Size(30, 30);
            this.checkAccept.TabIndex = 4;
            this.checkAccept.Text = "guna2CustomCheckBox1";
            this.checkAccept.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.checkAccept.UncheckedState.BorderRadius = 2;
            this.checkAccept.UncheckedState.BorderThickness = 0;
            this.checkAccept.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            // 
            // lblSTT
            // 
            this.lblSTT.BackColor = System.Drawing.Color.Transparent;
            this.lblSTT.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSTT.Location = new System.Drawing.Point(13, 22);
            this.lblSTT.Name = "lblSTT";
            this.lblSTT.Size = new System.Drawing.Size(15, 27);
            this.lblSTT.TabIndex = 5;
            this.lblSTT.Text = "1";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = false;
            this.lblUserName.BackColor = System.Drawing.Color.Transparent;
            this.lblUserName.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(409, 22);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(306, 27);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "Hoàng Thị Thanh Tuyền";
            // 
            // lblUserAccount
            // 
            this.lblUserAccount.AutoSize = false;
            this.lblUserAccount.BackColor = System.Drawing.Color.Transparent;
            this.lblUserAccount.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserAccount.Location = new System.Drawing.Point(265, 22);
            this.lblUserAccount.Name = "lblUserAccount";
            this.lblUserAccount.Size = new System.Drawing.Size(179, 27);
            this.lblUserAccount.TabIndex = 1;
            this.lblUserAccount.Text = "SV22110431";
            // 
            // picImage
            // 
            this.picImage.Image = global::DoAnCk.Properties.Resources._391566479_1319251892287625_6431812767372344325_n;
            this.picImage.ImageRotate = 0F;
            this.picImage.Location = new System.Drawing.Point(100, 3);
            this.picImage.Name = "picImage";
            this.picImage.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picImage.Size = new System.Drawing.Size(64, 64);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImage.TabIndex = 0;
            this.picImage.TabStop = false;
            this.picImage.Click += new System.EventHandler(this.picImage_Click);
            // 
            // ucAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblSTT);
            this.Controls.Add(this.checkAccept);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblUserAccount);
            this.Controls.Add(this.picImage);
            this.Name = "ucAccount";
            this.Size = new System.Drawing.Size(833, 71);
            this.Load += new System.EventHandler(this.ucAccount_Load);
            this.DoubleClick += new System.EventHandler(this.ucAccount_DoubleClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ucAccount_MouseDoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        public Guna.UI2.WinForms.Guna2HtmlLabel lblSTT;
        public Guna.UI2.WinForms.Guna2CirclePictureBox picImage;
        public Guna.UI2.WinForms.Guna2CustomCheckBox checkAccept;
        public Guna.UI2.WinForms.Guna2HtmlLabel lblUserName;
        public Guna.UI2.WinForms.Guna2HtmlLabel lblUserAccount;
    }
}
