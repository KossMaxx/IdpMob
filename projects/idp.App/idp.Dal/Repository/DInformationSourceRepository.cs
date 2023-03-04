using System;
using System.Collections.Generic;
using System.Text;
using idp.Dal.Models.Dictionaries;
using idp.Dal.Repository.Contracts;

namespace idp.Dal.Repository
{
    public class DInformationSourceRepository : BaseRepository<DInformationSource>, IDInformationSourceRepository
    {
        public DInformationSourceRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
