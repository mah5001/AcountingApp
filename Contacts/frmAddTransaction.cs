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

namespace Contacts
{
    public partial class frmAddTransaction : Form
    {
        private UnitOfWork db;
        public int AccountID = 0;
        public frmAddTransaction()
        {
            InitializeComponent();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dgCustomers.DataSource = db.CustomerRepository.GetNameCustomers(txtSearch.Text);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (BaseValidator.IsFormValid(this.components))
            {
                if (rbPay.Checked || rbRecive.Checked)
                {
                    db = new UnitOfWork();
                    Data.Models.Transactions acounting = new Data.Models.Transactions()
                    {
                        Amount = int.Parse(nupAmount.Value.ToString()),
                        CustomerId = db.CustomerRepository.GetCustomerIDByName(txtCustomer.Text),
                        TypeId = (rbRecive.Checked) ? 1 : 2,
                        DateTime = DateTime.Now,
                        Description = txtDesc.Text,

                    };
                    if (AccountID == 0)
                    {
                        db.acountingRepository.Insert(acounting);

                    }
                    else
                    {
                        acounting.ID = AccountID;
                        db.acountingRepository.Update(acounting);

                    }
                    db.Save();
                    db.Dispose();
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    RtlMessageBox.Show("لطفا نوع تراکنش را انتخاب نمایید.", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void dgCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void frmAddTransaction_Load(object sender, EventArgs e)
        {
            db = new UnitOfWork();
            dgCustomers.AutoGenerateColumns = false;
            dgCustomers.DataSource = db.CustomerRepository.GetNameCustomers();
            if (AccountID != 0)
            {
                var account = db.acountingRepository.GetById(AccountID);
                txtCustomer.Text = db.CustomerRepository.GetCustomerNameByID(account.CustomerId);
                txtDesc.Text = account.Description;
                nupAmount.Text = account.Amount.ToString();
                if (account.TypeId == 1)
                {
                    rbRecive.Checked = true;
                }
                else
                {
                    rbPay.Checked = true;
                }

                this.Text = ".ویرایش";
                btnSubmit.Text = "ویرایش";
                db.Dispose();
            }
        }

        private void dgCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCustomer.Text = dgCustomers.CurrentRow.Cells[0].Value.ToString();
        }
    }
}
