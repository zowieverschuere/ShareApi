using Microsoft.EntityFrameworkCore;
using ShareApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareApi.Data.Repositories
{
    public class ShareRepository : IShareRepository
    {

        private readonly ShareContext _context;
        private readonly DbSet<Share> _shares;

        public ShareRepository(ShareContext dbContext)
        {
            _context = dbContext;
            _shares = dbContext.Shares;
        }
        public void Add(Share share)
        {
            _shares.Add(share);
        }

        public void Delete(Share share)
        {
            _shares.Remove(share);
        }

        public IEnumerable<Share> GetAll()
        {
            return _shares.ToList();
        }

        public Share GetBy(int id)
        {
            return _shares.SingleOrDefault(s => s.Id == id);
        }

        public IEnumerable<Share> GetBy(string name = null)
        {
               var shares = _shares.AsQueryable();
                if (!string.IsNullOrEmpty(name))
                    shares = shares.Where(s => s.Name.IndexOf(name) >= 0);
                return shares.OrderBy(s => s.Name).ToList();

        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public bool TryGetShare(int id, out Share share)
        {
            share = _context.Shares.FirstOrDefault(s => s.Id == id);
            return share != null;
        }

        public void Update(Share share)
        {
            _shares.Update(share);
        }
    }
}
