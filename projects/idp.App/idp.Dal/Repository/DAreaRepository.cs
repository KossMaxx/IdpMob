using System;
using System.Collections.Generic;
using System.Text;
using idp.Dal.Models.Dictionaries;
using idp.Dal.Repository.Contracts;

namespace idp.Dal.Repository
{
    public class DAreaRepository : BaseRepository<DArea>, IDAreaRepository
    {
        public DAreaRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
