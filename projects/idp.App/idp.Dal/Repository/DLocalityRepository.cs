using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using idp.Dal.Models.Dictionaries;
using idp.Dal.Repository.Contracts;

namespace idp.Dal.Repository
{
    public class DLocalityRepository : BaseRepository<DLocality>, IDLocalityRepository
    {
        public DLocalityRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<IEnumerable<DLocality>> GetAsync(string search)
        {
            return _db.Where(l => l.Name.Contains(search));
        }
    }
}
