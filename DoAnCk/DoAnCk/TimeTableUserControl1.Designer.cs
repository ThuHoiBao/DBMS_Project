namespace DoAnCk
{
    partial class TimeTableUserControl1
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
            this.lblNumber = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel6 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblCourseName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblNameTeacher = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = false;
            this.lblNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblNumber.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumber.Location = new System.Drawing.Point(41, 36);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(119, 27);
            this.lblNumber.TabIndex = 26;
            this.lblNumber.Text = "7,8,9,10";
            // 
            // guna2HtmlLabel6
            // 
            this.guna2HtmlLabel6.AutoSize = false;
            this.guna2HtmlLabel6.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel6.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel6.Location = new System.Drawing.Point(3, 36);
            this.guna2HtmlLabel6.Name = "guna2HtmlLabel6";
            this.guna2HtmlLabel6.Size = new System.Drawing.Size(87, 27);
            this.guna2HtmlLabel6.TabIndex = 25;
            this.guna2HtmlLabel6.Text = "Tiết:";
            // 
            // lblCourseName
            // 
            this.lblCourseName.AutoSize = false;
            this.lblCourseName.BackColor = System.Drawing.Color.Transparent;
            this.lblCourseName.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCourseName.Location = new System.Drawing.Point(3, 13);
            this.lblCourseName.Name = "lblCourseName";
            this.lblCourseName.Size = new System.Drawing.Size(233, 27);
            this.lblCourseName.TabIndex = 21;
            this.lblCourseName.Text = "Lập Trình Winform";
            // 
            // lblNameTeacher
            // 
            this.lblNameTeacher.AutoSize = false;
            this.lblNameTeacher.BackColor = System.Drawing.Color.Transparent;
            this.lblNameTeacher.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameTeacher.Location = new System.Drawing.Point(3, 56);
            this.lblNameTeacher.Name = "lblNameTeacher";
            this.lblNameTeacher.Size = new System.Drawing.Size(238, 27);
            this.lblNameTeacher.TabIndex = 27;
            this.lblNameTeacher.Text = null;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Location = new System.Drawing.Point(0, 89);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(170, 44);
            this.panel1.TabIndex = 28;
            // 
            // TimeTableUserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkTurquoise;
            this.Controls.Add(this.lblNameTeacher);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.guna2HtmlLabel6);
            this.Controls.Add(this.lblCourseName);
            this.Name = "TimeTableUserControl1";
            this.Size = new System.Drawing.Size(149, 132);
            this.ResumeLayout(false);

        }

        #endregion

        public Guna.UI2.WinForms.Guna2HtmlLabel lblNumber;
        public Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel6;
        public Guna.UI2.WinForms.Guna2HtmlLabel lblCourseName;
        public Guna.UI2.WinForms.Guna2HtmlLabel lblNameTeacher;
        private System.Windows.Forms.Panel panel1;
    }
}
