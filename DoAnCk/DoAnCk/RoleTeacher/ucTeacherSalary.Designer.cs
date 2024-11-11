namespace DoAnCk.RoleTeacher
{
    partial class ucTeacherSalary
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
            this.lblCoursePrice = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblSTT = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblCourseName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblCourseId = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTotalStudent = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.SuspendLayout();
            // 
            // lblCoursePrice
            // 
            this.lblCoursePrice.AutoSize = false;
            this.lblCoursePrice.BackColor = System.Drawing.Color.Transparent;
            this.lblCoursePrice.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCoursePrice.Location = new System.Drawing.Point(473, 19);
            this.lblCoursePrice.Name = "lblCoursePrice";
            this.lblCoursePrice.Size = new System.Drawing.Size(111, 27);
            this.lblCoursePrice.TabIndex = 28;
            this.lblCoursePrice.Text = "1000";
            this.lblCoursePrice.Click += new System.EventHandler(this.lblCoursePrice_Click);
            // 
            // lblSTT
            // 
            this.lblSTT.BackColor = System.Drawing.Color.Transparent;
            this.lblSTT.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSTT.Location = new System.Drawing.Point(6, 19);
            this.lblSTT.Name = "lblSTT";
            this.lblSTT.Size = new System.Drawing.Size(15, 27);
            this.lblSTT.TabIndex = 27;
            this.lblSTT.Text = "1";
            // 
            // lblCourseName
            // 
            this.lblCourseName.AutoSize = false;
            this.lblCourseName.BackColor = System.Drawing.Color.Transparent;
            this.lblCourseName.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCourseName.Location = new System.Drawing.Point(226, 19);
            this.lblCourseName.Name = "lblCourseName";
            this.lblCourseName.Size = new System.Drawing.Size(262, 27);
            this.lblCourseName.TabIndex = 26;
            this.lblCourseName.Text = "Lập Trình Winform";
            // 
            // lblCourseId
            // 
            this.lblCourseId.AutoSize = false;
            this.lblCourseId.BackColor = System.Drawing.Color.Transparent;
            this.lblCourseId.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCourseId.Location = new System.Drawing.Point(49, 19);
            this.lblCourseId.Name = "lblCourseId";
            this.lblCourseId.Size = new System.Drawing.Size(144, 27);
            this.lblCourseId.TabIndex = 25;
            this.lblCourseId.Text = "Winform_09";
            // 
            // lblTotalStudent
            // 
            this.lblTotalStudent.AutoSize = false;
            this.lblTotalStudent.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalStudent.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalStudent.Location = new System.Drawing.Point(634, 19);
            this.lblTotalStudent.Name = "lblTotalStudent";
            this.lblTotalStudent.Size = new System.Drawing.Size(111, 27);
            this.lblTotalStudent.TabIndex = 29;
            this.lblTotalStudent.Text = "30";
            // 
            // ucTeacherSalary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTotalStudent);
            this.Controls.Add(this.lblCoursePrice);
            this.Controls.Add(this.lblSTT);
            this.Controls.Add(this.lblCourseName);
            this.Controls.Add(this.lblCourseId);
            this.Name = "ucTeacherSalary";
            this.Size = new System.Drawing.Size(720, 65);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Guna.UI2.WinForms.Guna2HtmlLabel lblCoursePrice;
        public Guna.UI2.WinForms.Guna2HtmlLabel lblSTT;
        public Guna.UI2.WinForms.Guna2HtmlLabel lblCourseName;
        public Guna.UI2.WinForms.Guna2HtmlLabel lblCourseId;
        public Guna.UI2.WinForms.Guna2HtmlLabel lblTotalStudent;
    }
}
