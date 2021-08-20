using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareApi.Models
{
   public interface IShareRepository
    {
        Share GetBy(int id);
        bool TryGetShare(int id, out Share share);
        IEnumerable<Share> GetAll();
        IEnumerable<Share> GetBy(string name = null);
        void Add(Share share);
        void Delete(Share share);
        void Update(Share share);
        void SaveChanges();
    }
}
