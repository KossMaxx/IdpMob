using System;
using System.Collections.Generic;
using System.Text;
using idp.Dal.Models.Dictionaries;
using idp.Dal.Repository.Contracts;

namespace idp.Dal.Repository
{
    public class DActivityFormRepository : BaseRepository<DActivityForm>, IDActivityFormRepository
    {
        public DActivityFormRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
