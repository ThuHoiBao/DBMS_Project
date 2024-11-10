namespace DoAnCk.RoleStudent
{
    partial class UserControlCourse
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
            this.lblCourseName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblCourseId = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.checkAccept = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.picImage = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.lblIdRegister = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSTT
            // 
            this.lblSTT.BackColor = System.Drawing.Color.Transparent;
            this.lblSTT.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSTT.Location = new System.Drawing.Point(7, 16);
            this.lblSTT.Name = "lblSTT";
            this.lblSTT.Size = new System.Drawing.Size(15, 27);
            this.lblSTT.TabIndex = 13;
            this.lblSTT.Text = "1";
            // 
            // lblCourseName
            // 
            this.lblCourseName.AutoSize = false;
            this.lblCourseName.BackColor = System.Drawing.Color.Transparent;
            this.lblCourseName.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCourseName.Location = new System.Drawing.Point(345, 16);
            this.lblCourseName.Name = "lblCourseName";
            this.lblCourseName.Size = new System.Drawing.Size(262, 27);
            this.lblCourseName.TabIndex = 12;
            this.lblCourseName.Text = "Lập Trình Winform";
            // 
            // lblCourseId
            // 
            this.lblCourseId.AutoSize = false;
            this.lblCourseId.BackColor = System.Drawing.Color.Transparent;
            this.lblCourseId.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCourseId.Location = new System.Drawing.Point(168, 16);
            this.lblCourseId.Name = "lblCourseId";
            this.lblCourseId.Size = new System.Drawing.Size(144, 27);
            this.lblCourseId.TabIndex = 11;
            this.lblCourseId.Text = "Winform_09";
            // 
            // checkAccept
            // 
            this.checkAccept.AllowDrop = true;
            this.checkAccept.BackColor = System.Drawing.Color.Transparent;
            this.checkAccept.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.checkAccept.CheckedState.BorderRadius = 2;
            this.checkAccept.CheckedState.BorderThickness = 0;
            this.checkAccept.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.checkAccept.Location = new System.Drawing.Point(626, 16);
            this.checkAccept.Name = "checkAccept";
            this.checkAccept.Size = new System.Drawing.Size(30, 30);
            this.checkAccept.TabIndex = 14;
            this.checkAccept.Text = "guna2CustomCheckBox1";
            this.checkAccept.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.checkAccept.UncheckedState.BorderRadius = 2;
            this.checkAccept.UncheckedState.BorderThickness = 0;
            this.checkAccept.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            // 
            // picImage
            // 
            this.picImage.Image = global::DoAnCk.Properties.Resources.graduation;
            this.picImage.ImageRotate = 0F;
            this.picImage.Location = new System.Drawing.Point(87, 3);
            this.picImage.Name = "picImage";
            this.picImage.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picImage.Size = new System.Drawing.Size(50, 50);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImage.TabIndex = 10;
            this.picImage.TabStop = false;
            // 
            // lblIdRegister
            // 
            this.lblIdRegister.BackColor = System.Drawing.Color.Transparent;
            this.lblIdRegister.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdRegister.Location = new System.Drawing.Point(102, 16);
            this.lblIdRegister.Name = "lblIdRegister";
            this.lblIdRegister.Size = new System.Drawing.Size(15, 27);
            this.lblIdRegister.TabIndex = 15;
            this.lblIdRegister.Text = "1";
            this.lblIdRegister.Visible = false;
            // 
            // UserControlCourseStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblIdRegister);
            this.Controls.Add(this.checkAccept);
            this.Controls.Add(this.lblSTT);
            this.Controls.Add(this.lblCourseName);
            this.Controls.Add(this.lblCourseId);
            this.Controls.Add(this.picImage);
            this.Name = "UserControlCourseStudent";
            this.Size = new System.Drawing.Size(708, 65);
            this.Load += new System.EventHandler(this.UserControlCourseStudent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Guna.UI2.WinForms.Guna2HtmlLabel lblSTT;
        public Guna.UI2.WinForms.Guna2HtmlLabel lblCourseName;
        public Guna.UI2.WinForms.Guna2HtmlLabel lblCourseId;
        public Guna.UI2.WinForms.Guna2CirclePictureBox picImage;
        public Guna.UI2.WinForms.Guna2CustomCheckBox checkAccept;
        public Guna.UI2.WinForms.Guna2HtmlLabel lblIdRegister;
    }
}
