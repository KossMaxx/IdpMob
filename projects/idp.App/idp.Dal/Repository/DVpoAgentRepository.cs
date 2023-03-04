using System;
using System.Collections.Generic;
using System.Text;
using idp.Dal.Models.Dictionaries;
using idp.Dal.Repository.Contracts;

namespace idp.Dal.Repository
{
    public class DVpoAgentRepository : BaseRepository<DVpoAgent>, IDVpoAgentRepository
    {
        public DVpoAgentRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
