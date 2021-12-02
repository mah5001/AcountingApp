using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;
using Data.ViewModels;
using Data.Context;
using Data.Services;
using Data.Repository;

namespace Data.Context
{
    public class UnitOfWork : IDisposable
    {
        AcountingDB db = new AcountingDB();
        private ICustomerRepository _customerRepository;

        public ICustomerRepository CustomerRepository
        {
            get
            {
                if (_customerRepository == null)
                {
                    _customerRepository = new CustomerRepository(db);
                }

                return _customerRepository;
            }
        }

        private GenericRepository<Transactions> _transactionRepository;

        public GenericRepository<Transactions> acountingRepository
        {
            get
            {
                if (_transactionRepository == null)
                {
                    _transactionRepository = new GenericRepository<Transactions>(db);
                }

                return _transactionRepository;
            }
        }
        private ILoginRepository loginRepository;
        public ILoginRepository LoginRepository
        {
            get
            {
                if (loginRepository == null)
                {
                    loginRepository = new LoginRepository(db);
                }

                return loginRepository;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
