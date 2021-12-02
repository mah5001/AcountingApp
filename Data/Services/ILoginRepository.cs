using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public interface ILoginRepository
    {
        bool isUserExist(string username,string password);
        void Update(Login login);
        Login GetById(int id);
        List<Login> GetAll();
    }
}
