using idp.Dal.Models.Dictionaries;
using idp.Dal.Repository.Contracts;

namespace idp.Dal.Repository
{
    public class DExternalInstitutionTypeRepository : BaseRepository<DExternalInstitutionType>, IDExternalInstitutionTypeRepository
    {
        public DExternalInstitutionTypeRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
