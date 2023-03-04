using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using idp.Dal.Models;

namespace idp.Dal.Repository.Contracts
{
    public interface ITokenRepository
    {
        void Add(string newToken, DateTime newExpireDate);
        Task AddAsync(string newToken, DateTime newExpireDate);
        bool CheckToken();
        string Get();
        Task<string> GetAsync();
    }
}
