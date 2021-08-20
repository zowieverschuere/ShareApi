using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareApi.Models
{
    public interface IUserRepository
    {
        User GetByEmail(string email);
        void Add(User customer);
        void Update(User customer);
        void SaveChanges();
      
      
    }
}
