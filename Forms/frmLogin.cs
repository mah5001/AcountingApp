using Data.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValidationComponents;

namespace Forms
{
    public partial class frmLogin : Form
    {
        public bool IsEdit;
        public frmLogin()
        {
            InitializeComponent();
        }
        private void Athenticate()
        {
            if (BaseValidator.IsFormValid(this.components))
            {
                using (UnitOfWork db = new UnitOfWork())
                {
                    if (IsEdit)
                    {
                        var user = db.LoginRepository.GetAll().First();
                        user.UserName = txtUserName.Text;
                        user.Password = txtPassword.Text;
                        db.LoginRepository.Update(user);
                        db.Save();
                        Application.Restart();
                    }
                    else
                    {


                        if (db.LoginRepository.GetAll().Any(l => l.UserName == txtUserName.Text && l.Password == txtPassword.Text))
                        {
                            DialogResult = DialogResult.OK;

                        }
                        else
                        {
                            RtlMessageBox.Show("نام کاربری و کلمه عبور مطابقت ندارند", "خطا", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                        }
                    }
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Athenticate();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            if (IsEdit)
            {
                this.Text = "ویرایش حساب کاربری";
                btnSubmit.Text = "اعمال";
                using (UnitOfWork db = new UnitOfWork())
                {
                    var user = db.LoginRepository.GetAll().First();
                    txtUserName.Text = user.UserName;
                    txtPassword.Text = user.Password;
                }
            }
        }
    }
}
