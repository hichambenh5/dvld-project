using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projet19dvld
{
    public partial class changepassowrd : Form
    {
        int _userid = -1;
        clsUser _User;
        public changepassowrd(int userid)
        {
            InitializeComponent();
            _userid = userid;
        }

        private void _ResetDefualtValues()
        {
            txtCurrentPassword.Text = "";
            txtNewPassword.Text = "";
            txtConfirmPassword.Text = "";
            txtCurrentPassword.Focus();
        }

        private void Ctrlusercard1_Load(object sender, EventArgs e)
        {
            

            
        }

        private void Changepassowrd_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();
            clsUser user = clsUser.FindByUserID(_userid);
            if (user == null)
            {
                MessageBox.Show("Could not Find User with id = " + _userid,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();

                return;

            }
            ctrlusercard1.LoaduserInfo(_userid);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
                return;

            // تحقق من كلمة المرور الحالية
            if (clsUser.FindByUsernameAndPassword(_User.UserName, txtCurrentPassword.Text) == null)
            {
                MessageBox.Show("Current password is wrong");
                return;
            }

            // تحقق من التطابق
            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match");
                return;
            }

            _User.Password = txtNewPassword.Text;

            if (_User.Save())
                MessageBox.Show("Password changed successfully");
            else
                MessageBox.Show("Error while saving");

        }

        private void TxtCurrentPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtCurrentPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "Username cannot be blank");
            }
            else
            {
                errorProvider1.SetError(txtCurrentPassword, null);
            }
            if (_User.Password != txtCurrentPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "Current password is wrong!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtCurrentPassword, null);
            }
        }

        private void TxtNewPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNewPassword, "New Password cannot be blank");
            }
            else
            {
                errorProvider1.SetError(txtNewPassword, null);
            }
            
        }

        private void TxtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text.Trim() != txtNewPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Password Confirmation does not match New Password!");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }
            ;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
