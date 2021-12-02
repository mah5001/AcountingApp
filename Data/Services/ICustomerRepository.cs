using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;
using Data.ViewModels;


namespace Data.Services
{
    public interface ICustomerRepository
    {
        List<Customers> GetAllCustomers();
        IEnumerable<Customers> GetCustomersByFilter(string parameter);
        List<ListCustomersViewModel> GetNameCustomers(string parameter = "");
        Customers GetCustomerById(int customerId);
        bool InsertCustomer(Customers customers);
        bool UpdateCustomer(Customers customers);
        bool DeleteCustomer(Customers customers);
        bool DeleteCustomer(int customerId);
        int GetCustomerIDByName(string name);
        string GetCustomerNameByID(int customerId);
        List<TransactionSummuryViewModel> GetTransactionSummuries();
    }
}
