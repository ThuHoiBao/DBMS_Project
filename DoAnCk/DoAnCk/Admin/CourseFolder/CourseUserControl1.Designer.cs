namespace DoAnCk
{
    partial class CourseUserControl1
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
            this.picImage = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSTT
            // 
            this.lblSTT.BackColor = System.Drawing.Color.Transparent;
            this.lblSTT.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSTT.Location = new System.Drawing.Point(19, 22);
            this.lblSTT.Name = "lblSTT";
            this.lblSTT.Size = new System.Drawing.Size(15, 27);
            this.lblSTT.TabIndex = 9;
            this.lblSTT.Text = "1";
            // 
            // lblCourseName
            // 
            this.lblCourseName.AutoSize = false;
            this.lblCourseName.BackColor = System.Drawing.Color.Transparent;
            this.lblCourseName.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCourseName.Location = new System.Drawing.Point(415, 22);
            this.lblCourseName.Name = "lblCourseName";
            this.lblCourseName.Size = new System.Drawing.Size(262, 27);
            this.lblCourseName.TabIndex = 8;
            this.lblCourseName.Text = "Lập Trình Winform";
            // 
            // lblCourseId
            // 
            this.lblCourseId.AutoSize = false;
            this.lblCourseId.BackColor = System.Drawing.Color.Transparent;
            this.lblCourseId.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCourseId.Location = new System.Drawing.Point(204, 22);
            this.lblCourseId.Name = "lblCourseId";
            this.lblCourseId.Size = new System.Drawing.Size(144, 27);
            this.lblCourseId.TabIndex = 7;
            this.lblCourseId.Text = "Winform_09";
            this.lblCourseId.Click += new System.EventHandler(this.lblCourseId_Click);
            // 
            // picImage
            // 
            this.picImage.Image = global::DoAnCk.Properties.Resources.graduation;
            this.picImage.ImageRotate = 0F;
            this.picImage.Location = new System.Drawing.Point(99, 9);
            this.picImage.Name = "picImage";
            this.picImage.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picImage.Size = new System.Drawing.Size(50, 50);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImage.TabIndex = 6;
            this.picImage.TabStop = false;
            // 
            // CourseUserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblSTT);
            this.Controls.Add(this.lblCourseName);
            this.Controls.Add(this.lblCourseId);
            this.Controls.Add(this.picImage);
            this.Name = "CourseUserControl1";
            this.Size = new System.Drawing.Size(693, 67);
            this.Load += new System.EventHandler(this.CourseUserControl1_Load);
            this.DoubleClick += new System.EventHandler(this.CourseUserControl1_DoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Guna.UI2.WinForms.Guna2HtmlLabel lblSTT;
        public Guna.UI2.WinForms.Guna2HtmlLabel lblCourseName;
        public Guna.UI2.WinForms.Guna2HtmlLabel lblCourseId;
        public Guna.UI2.WinForms.Guna2CirclePictureBox picImage;
    }
}
