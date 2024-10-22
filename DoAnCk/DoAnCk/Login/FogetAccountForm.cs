using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnCk
{
    public partial class FogetAccountForm : Form
    {
        public FogetAccountForm()
        {
            InitializeComponent();
        }

        private void FogetAccountForm_Load(object sender, EventArgs e)
        {

        }

        private void btnUnSeenPass_Click(object sender, EventArgs e)
        {
            txtConfirmPass.PasswordChar = '*';
            txtPassWord.PasswordChar = '*';
            btnSeenPass.Visible = true;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            txtPassWord.PasswordChar = '\0';
            txtConfirmPass.PasswordChar = '\0';
            btnSeenPass.Visible = false;
        }
        bool check = true;
        public void Check()
        {
            errorProvider1.Clear();
            if (txtNameAccount.Text == "")
            {
                errorProvider1.SetError(txtNameAccount, "Bạn Chưa Nhập gì?");
                check = false;
            }
            if (txtPassWord.Text == "")
            {
                errorProvider1.SetError(txtPassWord, "Bạn Chưa Nhập gì?");
                check = false;
            }
            if (txtConfirmPass.Text == "")
            {
                errorProvider1.SetError(txtConfirmPass, "Bạn Chưa Nhập gì?");
                check = false;
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            User user = new User();
            check = true;
            Check();
            if (check==true)
            {
                if (txtConfirmPass.Text == txtPassWord.Text)
                {
                    if (user.UpdatePassWord(txtPassWord.Text, txtNameAccount.Text))
                    {
                        MessageBox.Show("Update successful!!", "Update Pass Word", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("User Account does not exist", "Update Pass Word", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }

                else
                {
                    MessageBox.Show("Confirm Pass Word is not the same as Pass Word", "Update Pass Word", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
           
        }
    }
}
