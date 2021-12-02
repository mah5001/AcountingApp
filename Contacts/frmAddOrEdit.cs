using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data.Context;
using Data.Models;
using ValidationComponents;

namespace Contacts
{

    public partial class frmAddOrEdit : Form
    {
        public int customerId = 0;
        UnitOfWork db = new UnitOfWork();
        public frmAddOrEdit()
        {
            InitializeComponent();
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog imgDialog = new OpenFileDialog();
            imgDialog.Filter =
                "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            
            if (imgDialog.ShowDialog() == DialogResult.OK)
            {
                pctImage.ImageLocation = imgDialog.FileName;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (BaseValidator.IsFormValid(this.components))
            {
                string ImgName = Guid.NewGuid().ToString() + Path.GetExtension(pctImage.ImageLocation);
                string path = Application.StartupPath + "/Images/";
               
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                pctImage.Image.Save(path + ImgName);
                Customers customers = new Customers()
                {
                    Address = txtAddres.Text,
                    CustomerImage = ImgName,
                    Email = txtEmail.Text,
                    FullName = txtFullName.Text,
                    Mobile = txtMobile.Text
                };
                if (customerId == 0)
                {
                    db.CustomerRepository.InsertCustomer(customers);
                }
                else
                {
                    customers.CustomerID = customerId;
                    db.CustomerRepository.UpdateCustomer(customers);
                }
                
                db.Save();
                DialogResult = DialogResult.OK;
            }
        }

        private void frmAddOrEdit_Load(object sender, EventArgs e)
        {
            if (customerId != 0)
            {
                this.Text = "ویرایش شخص";
                this.btnSubmit.Text = "ویرایش";
                var customer = db.CustomerRepository.GetCustomerById(customerId);
                txtFullName.Text = customer.FullName;
                txtMobile.Text = customer.Mobile;
                txtEmail.Text = customer.Email;
                txtAddres.Text = customer.Address;
                pctImage.ImageLocation = Application.StartupPath + "/Images/" + customer.CustomerImage;
            }
        }
    }
}
