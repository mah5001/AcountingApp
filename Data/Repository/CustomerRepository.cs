using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;
using Data.ViewModels;
using Data.Context;
using Data.Services;
using System.Data.Entity;

namespace Data.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private AcountingDB db;

        public CustomerRepository(AcountingDB context)
        {
            db = context;
        }
        public bool DeleteCustomer(Customers customers)
        {
            try
            {
                db.Entry(customers).State = EntityState.Deleted;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteCustomer(int customerId)
        {
            try
            {
                var customer = GetCustomerById(customerId);
                DeleteCustomer(customer);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Customers> GetAllCustomers()
        {
            return db.Customers.ToList();
        }

        public Customers GetCustomerById(int customerId)
        {
            return db.Customers.Find(customerId);
        }

        public int GetCustomerIDByName(string name)
        {

            return db.Customers.First(c => c.FullName == name).CustomerID;
        }

        public string GetCustomerNameByID(int customerId)
        {
            return db.Customers.Find(customerId).FullName;
        }

        public IEnumerable<Customers> GetCustomersByFilter(string parameter)
        {
            return db.Customers.Where(c => c.FullName.Contains(parameter) || c.Mobile.Contains(parameter) || c.Email.Contains(parameter)).ToList();
        }

        public List<ListCustomersViewModel> GetNameCustomers(string parameter = "")
        {
            if (parameter == "")
            {
                return db.Customers.Select(c => new ListCustomersViewModel()
                {
                    FullName = c.FullName,
                    CustomerID = c.CustomerID
                }
                ).ToList();
            }
            return db.Customers.Where(c => c.FullName.Contains(parameter)).Select(c => new ListCustomersViewModel()
            {
                FullName = c.FullName,
                CustomerID = c.CustomerID
            }).ToList();
        }

        public List<TransactionSummuryViewModel> GetTransactionSummuries()
        {
            List<TransactionSummuryViewModel> l = new List<TransactionSummuryViewModel>();
            foreach (var item in db.Transactions.ToList())
            {
                l.Add(new TransactionSummuryViewModel() { To = item.Customer.FullName,Amount=item.Amount.ToString("#,0 ریال")});
            }
            //return db.Transactions.Select(c => new TransactionSummuryViewModel() { To = c.Customer.FullName, Amount = c.Amount.ToString("#,0 ریال") }).ToList();
            return l;
        }

        public bool InsertCustomer(Customers customers)
        {
            try
            {
                db.Customers.Add(customers);
                return true;
            }
            catch
            {
                return false;
            }
        }



        public bool UpdateCustomer(Customers customers)
        {
            //  try
            // {
            var local = db.Set<Customers>()
                .Local
                .FirstOrDefault(f => f.CustomerID == customers.CustomerID);
            if (local != null)
            {
                db.Entry(local).State = EntityState.Detached;
            }
            db.Entry(customers).State = EntityState.Modified;
            return true;
            //  }
            //    catch
            // {
            //   return false;
            //}
        }
    }
}
