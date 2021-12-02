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

namespace Contacts
{
    public partial class frmReport : Form
    {
        public frmReport()
        {
            InitializeComponent();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            using(UnitOfWork db = new UnitOfWork())
            {
                List<Data.ViewModels.ListCustomersViewModel> listCustomers = new List<Data.ViewModels.ListCustomersViewModel>();
                listCustomers.Add(new Data.ViewModels.ListCustomersViewModel() { CustomerID = 0, FullName = "انتخاب کنید" });
                listCustomers.AddRange(db.CustomerRepository.GetNameCustomers());
                cbCustomers.DataSource = listCustomers;
                cbCustomers.ValueMember = "CustomerId";
                cbCustomers.DisplayMember = "FullName";
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            
            Filter();
        }
        void Filter()
        {
            
            using (UnitOfWork db = new UnitOfWork())
            {
                List<Data.Models.Transactions> res = new List<Data.Models.Transactions>();
                DateTime? startDate;
                DateTime? endDate;
                int type = (rbRec.Checked) ? 1 : 2;
                if ((int)cbCustomers.SelectedValue != 0)
                {
                    if (type!=0)
                    {
                        int customerid = int.Parse(cbCustomers.SelectedValue.ToString());
                        res.AddRange(db.acountingRepository.Get(c => c.TypeId == type && c.CustomerId == customerid));
                    }
                    if (type == 0)
                    {
                        int customerid = int.Parse(cbCustomers.SelectedValue.ToString());
                        res.AddRange(db.acountingRepository.Get(c => c.CustomerId == customerid));
                    }
                }
                else
                {
                    if (type!=0)
                    {
                        res.AddRange(db.acountingRepository.Get(c => c.TypeId == type));
                    }
                    if(type==0)
                    {
                        res.AddRange(db.acountingRepository.Get());
                    }
                }
                if (txtFromDate.Text != "    /  /")
                {
                    startDate = txtFromDate.Text.ToDateTime();
                    res = res.Where(r => r.DateTime >= startDate.Value).ToList();
                }
                if (txtToDate.Text != "    /  /")
                {
                    endDate = txtToDate.Text.ToDateTime();
                    res = res.Where(r => r.DateTime <= endDate.Value).ToList();
                }

                dgvTransaction.Rows.Clear();
                foreach (var acounting in res)
                {
                    var customerNmae = db.CustomerRepository.GetCustomerNameByID(acounting.CustomerId);
                    dgvTransaction.Rows.Add(acounting.ID, customerNmae, acounting.Amount.ToRial(), acounting.DateTime.ToShamsi(), acounting.Description);
                }

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTransaction.CurrentRow != null)
            {
                int id = int.Parse(dgvTransaction.CurrentRow.Cells[0].Value.ToString());
                if (RtlMessageBox.Show("آیا از حذف مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    using (UnitOfWork db = new UnitOfWork())
                    {
                        db.acountingRepository.Delete(id);
                        db.Save();
                    }
                    Filter();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvTransaction.CurrentRow != null)
            {
                int id = int.Parse(dgvTransaction.CurrentRow.Cells[0].Value.ToString());
                frmAddTransaction frm = new frmAddTransaction();
                frm.AccountID = id;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Filter();
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataTable dtPrint = new DataTable();
            dtPrint.Columns.Add("Customer");
            dtPrint.Columns.Add("Amount");
            dtPrint.Columns.Add("Date");
            dtPrint.Columns.Add("Description");
            foreach (DataGridViewRow item in dgvTransaction.Rows)
            {
                dtPrint.Rows.Add(
                    item.Cells[1].Value.ToString(),
                    item.Cells[2].Value.ToString(),
                    item.Cells[3].Value.ToString(),
                    item.Cells[4].Value.ToString()
                );
            }
            stiReport1.Load(Application.StartupPath + "/Report.mrt");
            stiReport1.RegData("DT", dtPrint);
            stiReport1.Show();
        }
    }
}
