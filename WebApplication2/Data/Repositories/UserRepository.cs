using Microsoft.EntityFrameworkCore;
using ShareApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareApi.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ShareContext _context;
        private readonly DbSet<User> _customers;

        public UserRepository(ShareContext dbContext)
        {
            _context = dbContext;
            _customers = dbContext.Customers;
        }

        public void Add(User customer)
        {
            _customers.Add(customer);
        }

        public User GetByEmail(string email)
        {
            return _customers.Include(x => x.Shares).SingleOrDefault(x => x.Email == email);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(User customer)
        {
            _context.Update(customer);
        }

     
    }
}
