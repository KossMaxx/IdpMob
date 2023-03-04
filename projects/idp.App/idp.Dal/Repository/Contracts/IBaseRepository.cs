using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace idp.Dal.Repository.Contracts
{
    public interface IBaseRepository<T> where T : class
    {
        void Add(T newEntity);
        void AddRange(IEnumerable<T> newEntities);
        void AddRangeWithClear(IEnumerable<T> newEntities);
        T Get(int id);
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        void Delete(int id);
        void Update(T newEntity);
    }
}
