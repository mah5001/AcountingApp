using Data.Context;
using Data.Models;
using Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class LoginRepository : ILoginRepository
    {
        AcountingDB db;
        public LoginRepository(AcountingDB context)
        {
            db = context;
        }

        public List<Login> GetAll()
        {
            return db.Login.ToList();
        }

        public Login GetById(int id)
        {
            return db.Login.Find(id);
        }

        public bool isUserExist(string username, string password)
        {
            return db.Login.Any(c=>c.UserName == username && c.Password == password);
        }

        public void Update(Login login)
        {
            db.Entry(login).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
