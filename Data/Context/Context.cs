using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class AcountingDB:DbContext
    {
        public DbSet<Models.Customers> Customers { get; set; }
        public DbSet<Models.Login> Login { get; set; }
        public DbSet<Models.Transactions> Transactions { get; set; }
        public DbSet<Models.TransactionType> TransactionType { get; set; }


    }
}
