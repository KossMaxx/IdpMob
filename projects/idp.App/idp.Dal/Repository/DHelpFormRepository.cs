using System;
using System.Collections.Generic;
using System.Text;
using idp.Dal.Models.Dictionaries;
using idp.Dal.Repository.Contracts;

namespace idp.Dal.Repository
{
    public class DHelpFormRepository : BaseRepository<DHelpForm>, IDHelpFormRepository
    {
        public DHelpFormRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
