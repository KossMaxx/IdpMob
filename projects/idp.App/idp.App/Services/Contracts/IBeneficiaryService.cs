using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using idp.App.Models;
using idp.Dal.Models;

namespace idp.App.Services.Contracts
{
    public interface IBeneficiaryService
    {
        Task<IEnumerable<BeneficiaryDto>> GetAllAsync(string creatorName);
        Beneficiary Get(int id);
        void Update(Beneficiary newBen);
        void Add(Beneficiary newBen);
        Task<string> SynchronizeBeneficiaries();
        void Delete(int id);
    }
}
