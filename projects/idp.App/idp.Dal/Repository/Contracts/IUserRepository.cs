using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using idp.Dal.Models;

namespace idp.Dal.Repository.Contracts
{
    public interface IUserRepository
    {
        void Add(User newUser);
        IEnumerable<User> GetAll();
        void Delete(int id);
        void Update(User newUser);
        User GetUser(string username, string password);
        Task<User> GetUserAsync(string username, string password);
        Task SyncUserAsync(string username, string password, int? officeId, string userFio);
    }
}
