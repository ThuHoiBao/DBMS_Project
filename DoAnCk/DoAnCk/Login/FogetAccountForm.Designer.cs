namespace DoAnCk
{
    partial class FogetAccountForm
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
            this.components = new System.ComponentModel.Container();
            this.btnUpdate = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPassWord = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtConfirmPass = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNameAccount = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSeenPass = new Guna.UI2.WinForms.Guna2Button();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.btnUnSeenPass = new Guna.UI2.WinForms.Guna2Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnUpdate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnUpdate.BorderRadius = 15;
            this.btnUpdate.DisabledState.BorderColor = System.Drawing.Color.Red;
            this.btnUpdate.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnUpdate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnUpdate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnUpdate.FillColor = System.Drawing.Color.Green;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnUpdate.Location = new System.Drawing.Point(97, 393);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(166, 39);
            this.btnUpdate.TabIndex = 38;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(24, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 38);
            this.label1.TabIndex = 37;
            this.label1.Text = "Forget Account";
            // 
            // txtPassWord
            // 
            this.txtPassWord.BorderRadius = 5;
            this.txtPassWord.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassWord.DefaultText = "";
            this.txtPassWord.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPassWord.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPassWord.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassWord.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassWord.FillColor = System.Drawing.Color.DarkSlateGray;
            this.txtPassWord.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPassWord.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.txtPassWord.ForeColor = System.Drawing.Color.White;
            this.txtPassWord.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPassWord.Location = new System.Drawing.Point(249, 271);
            this.txtPassWord.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.PasswordChar = '*';
            this.txtPassWord.PlaceholderText = "";
            this.txtPassWord.SelectedText = "";
            this.txtPassWord.Size = new System.Drawing.Size(210, 30);
            this.txtPassWord.TabIndex = 44;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(57, 276);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 25);
            this.label6.TabIndex = 45;
            this.label6.Text = "New Password";
            // 
            // txtConfirmPass
            // 
            this.txtConfirmPass.BorderRadius = 5;
            this.txtConfirmPass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtConfirmPass.DefaultText = "";
            this.txtConfirmPass.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtConfirmPass.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtConfirmPass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtConfirmPass.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtConfirmPass.FillColor = System.Drawing.Color.DarkSlateGray;
            this.txtConfirmPass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtConfirmPass.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.txtConfirmPass.ForeColor = System.Drawing.Color.White;
            this.txtConfirmPass.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtConfirmPass.Location = new System.Drawing.Point(249, 311);
            this.txtConfirmPass.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtConfirmPass.Name = "txtConfirmPass";
            this.txtConfirmPass.PasswordChar = '*';
            this.txtConfirmPass.PlaceholderText = "";
            this.txtConfirmPass.SelectedText = "";
            this.txtConfirmPass.Size = new System.Drawing.Size(210, 30);
            this.txtConfirmPass.TabIndex = 41;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(57, 316);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 25);
            this.label3.TabIndex = 46;
            this.label3.Text = "Confirm Password";
            // 
            // txtNameAccount
            // 
            this.txtNameAccount.BorderRadius = 5;
            this.txtNameAccount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNameAccount.DefaultText = "";
            this.txtNameAccount.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNameAccount.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNameAccount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNameAccount.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNameAccount.FillColor = System.Drawing.Color.DarkSlateGray;
            this.txtNameAccount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNameAccount.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.txtNameAccount.ForeColor = System.Drawing.Color.White;
            this.txtNameAccount.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNameAccount.Location = new System.Drawing.Point(249, 231);
            this.txtNameAccount.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtNameAccount.Name = "txtNameAccount";
            this.txtNameAccount.PasswordChar = '\0';
            this.txtNameAccount.PlaceholderText = "";
            this.txtNameAccount.SelectedText = "";
            this.txtNameAccount.Size = new System.Drawing.Size(210, 30);
            this.txtNameAccount.TabIndex = 43;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(57, 231);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 25);
            this.label2.TabIndex = 48;
            this.label2.Text = "User Account";
            // 
            // btnSeenPass
            // 
            this.btnSeenPass.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSeenPass.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSeenPass.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSeenPass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSeenPass.FillColor = System.Drawing.Color.DarkSlateGray;
            this.btnSeenPass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSeenPass.ForeColor = System.Drawing.Color.White;
            this.btnSeenPass.Image = global::DoAnCk.Properties.Resources.eye;
            this.btnSeenPass.ImageSize = new System.Drawing.Size(30, 30);
            this.btnSeenPass.Location = new System.Drawing.Point(465, 271);
            this.btnSeenPass.Name = "btnSeenPass";
            this.btnSeenPass.Size = new System.Drawing.Size(39, 39);
            this.btnSeenPass.TabIndex = 51;
            this.btnSeenPass.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.Image = global::DoAnCk.Properties.Resources.rmitXin;
            this.guna2CirclePictureBox1.ImageRotate = 0F;
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(298, 69);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(191, 121);
            this.guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2CirclePictureBox1.TabIndex = 40;
            this.guna2CirclePictureBox1.TabStop = false;
            // 
            // btnUnSeenPass
            // 
            this.btnUnSeenPass.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnUnSeenPass.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnUnSeenPass.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnUnSeenPass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnUnSeenPass.FillColor = System.Drawing.Color.DarkSlateGray;
            this.btnUnSeenPass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnUnSeenPass.ForeColor = System.Drawing.Color.White;
            this.btnUnSeenPass.Image = global::DoAnCk.Properties.Resources.unseen;
            this.btnUnSeenPass.ImageSize = new System.Drawing.Size(30, 30);
            this.btnUnSeenPass.Location = new System.Drawing.Point(465, 271);
            this.btnUnSeenPass.Name = "btnUnSeenPass";
            this.btnUnSeenPass.Size = new System.Drawing.Size(39, 39);
            this.btnUnSeenPass.TabIndex = 61;
            this.btnUnSeenPass.Click += new System.EventHandler(this.btnUnSeenPass_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FogetAccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(550, 812);
            this.Controls.Add(this.btnSeenPass);
            this.Controls.Add(this.btnUnSeenPass);
            this.Controls.Add(this.txtPassWord);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtConfirmPass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNameAccount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.guna2CirclePictureBox1);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FogetAccountForm";
            this.Text = "FogetAccountForm";
            this.Load += new System.EventHandler(this.FogetAccountForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private Guna.UI2.WinForms.Guna2Button btnUpdate;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btnSeenPass;
        private Guna.UI2.WinForms.Guna2TextBox txtPassWord;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2TextBox txtConfirmPass;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txtNameAccount;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button btnUnSeenPass;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}