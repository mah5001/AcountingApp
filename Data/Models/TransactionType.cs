using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class TransactionType
    {
        [Key]
        public int TypeId { get; set; }
        [Display(Name ="نوع تراکنش")]
        [MaxLength(10)]
        public string TypeTitle { get; set; }
    }
}
