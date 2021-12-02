using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Transactions
    {
        [Key]
        public int ID { get; set; }
        public int CustomerId { get; set; }
        public int TypeId { get; set; }
        public int Amount { get; set; }
        [MaxLength(800)]
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public virtual TransactionType TransactionType { get; set; }
        public virtual Customers Customer { get; set; }
    }
}
