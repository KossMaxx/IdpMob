using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using idp.Dal.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace idp.Dal.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class 
    {
        protected readonly ApplicationContext _context;
        protected readonly DbSet<T> _db;

        public BaseRepository(ApplicationContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }

        public void Add(T newEntity)
        {
            _db.Add(newEntity);
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<T> newEntities)
        {
            _db.AddRange(newEntities);
            _context.SaveChanges();
        }

        public void AddRangeWithClear(IEnumerable<T> newEntities)
        {
            if (_db.Any())
            {
                _db.RemoveRange(_db);
            }
            _db.AddRange(newEntities);
            _context.SaveChanges();
        }

        public virtual T Get(int id)
        {
            return _db.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _db;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Task.Run(GetAll);
        }

        public void Delete(int id)
        {
           var item = _db.Find(id);
           _db.Remove(item);
           _context.SaveChanges();
        }

        public virtual void Update(T newEntity)
        {
            _context.Entry(newEntity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
