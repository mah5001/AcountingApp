using Data.Context;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Bussiness
{
    public class Account
    {
        public static ReportViewModel ReportForMain()
        {
            ReportViewModel rp = new ReportViewModel();
            using (UnitOfWork db = new UnitOfWork())
            {
                DateTime starDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                //DateTime endDateTime = new DateTime(DateTime.Now.Year,DateTime.Now.Month,31);
                DateTime endDateTime = starDateTime.AddMonths(1).AddDays(-1);
                var res1 = db.acountingRepository.Get(c => c.TypeId == 1 && c.DateTime >= starDateTime && c.DateTime <= endDateTime).Select(c => c.Amount).ToList();
                var recive = res1.Sum();
                var res2 = db.acountingRepository.Get(c => c.TypeId == 2 && c.DateTime >= starDateTime && c.DateTime <= endDateTime).Select(c => c.Amount).ToList();
                var pay = res2.Sum();
                rp.SumOfPay = pay;
                rp.SumOfRecipent = recive;
                rp.Remaininmg = (recive - pay);
            }

            return rp;
        }
    }
}
