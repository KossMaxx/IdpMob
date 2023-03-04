using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using idp.Dal.Models.Dictionaries;

namespace idp.Dal.Repository.Contracts
{
    public interface IDLocalityRepository : IBaseRepository<DLocality>
    {
        Task<IEnumerable<DLocality>> GetAsync(string search);
    }
}
