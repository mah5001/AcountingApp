using Data.Bussiness;
using Data.Context;
using Data.ViewModels;
using Forms;
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
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }
        public void Up()
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                lsPeople.DataSource = db.CustomerRepository.GetAllCustomers().Select(c => c.FullName).ToList();
                dgSmallTransaction.AutoGenerateColumns = false;
                dgSmallTransaction.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgSmallTransaction.DataSource = db.CustomerRepository.GetTransactionSummuries().ToList();
                Report();
            }
        }
        private void frmHome_Load(object sender, EventArgs e)
        {
            
            Up();
            Athenthicate();
        }
        private void Athenthicate()
        {
            this.Hide();
            frmLogin frmlgn = new frmLogin();
            if (frmlgn.ShowDialog() == DialogResult.OK)
            {
                Report();
                lblDate.Text = DateTime.Now.ToShamsi();
                lblTime.Text = DateTime.Now.ToString("HH:mm:ss");

                this.Show();
            }
            else
            {
                Application.Exit();
            }
        }

        void Report()
        {

            ReportViewModel rp = Account.ReportForMain();
            lblRecive.Text = rp.SumOfRecipent.ToString("#,0");
            lblSend.Text = rp.SumOfPay.ToString("#,0");
            lblExist.Text = rp.Remaininmg.ToString("#,0");

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPeople_Click(object sender, EventArgs e)
        {
            frmCustomers frmcustomer = new frmCustomers();
            frmcustomer.ShowDialog();
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            Up();
        }

        private void btnEditPass_Click(object sender, EventArgs e)
        {
            frmLogin f = new frmLogin();
            f.IsEdit = true;
            if(f.ShowDialog() == DialogResult.OK)
            {
                RtlMessageBox.Show("با موفقیت اتجام شد.","اطلاعات",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void btnNewTransaction_Click(object sender, EventArgs e)
        {
            frmAddTransaction f = new frmAddTransaction();
            if(f.ShowDialog()== DialogResult.OK)
            {
                RtlMessageBox.Show("با موفقیت انجام شد","اطلاعات",MessageBoxButtons.OK,MessageBoxIcon.Information);
                Up();
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            frmReport f = new frmReport();
            f.ShowDialog();
        }
    }
}
