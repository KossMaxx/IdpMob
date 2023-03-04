using System;
using System.Collections.Generic;
using System.Text;
using idp.Dal.Models.Dictionaries;
using idp.Dal.Repository.Contracts;

namespace idp.Dal.Repository
{
    public class DNotLawHelpRepository : BaseRepository<DNotLawHelp>, IDNotLawHelpRepository
    {
        public DNotLawHelpRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
