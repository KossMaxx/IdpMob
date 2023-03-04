using System;
using System.Collections.Generic;
using System.Text;
using idp.Dal.Models.Dictionaries;
using idp.Dal.Repository.Contracts;

namespace idp.Dal.Repository
{
    public class DLivingPlaceRepository : BaseRepository<DLivingPlace>, IDLivingPlaceRepository
    {
        public DLivingPlaceRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
