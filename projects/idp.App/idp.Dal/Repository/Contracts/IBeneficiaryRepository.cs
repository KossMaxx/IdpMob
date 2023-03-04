using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using idp.Dal.Models;

namespace idp.Dal.Repository.Contracts
{
    public interface IBeneficiaryRepository : IBaseRepository<Beneficiary>
    {
        IEnumerable<Beneficiary> GetAll(string creatorName);
        Task<IEnumerable<Beneficiary>> GetAllAsync(string creatorName);
        Task<IEnumerable<Beneficiary>> GetAllForServerAsync(string creatorName);
        void AddSyncError(int id, string message);
    }
}
