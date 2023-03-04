using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using idp.Dal.Models;
using idp.Dal.Repository.Contracts;

namespace idp.Dal.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _db;

        public UserRepository(ApplicationContext context)
        {
            _db = context;
        }

        public void Add(User newUser)
        {
            newUser.Password = GetPasswordHash(newUser.Password);
            _db.Users.Add(newUser);
            _db.SaveChanges();
        }

        public void Update(User newUser)
        {
            var user = _db.Users.Find(newUser.Id);
            if (user != null)
            {
                user.Username = newUser.Username;
                user.Password = GetPasswordHash(newUser.Password);
                user.Email = newUser.Email;
                user.PhoneNumber = newUser.PhoneNumber;
                user.Fio = newUser.Fio;
                user.OfficeId = newUser.OfficeId;

                _db.Users.Update(user);
                _db.SaveChanges();
            }
        }

        public IEnumerable<User> GetAll()
        {
            return _db.Users;
        }

        public void Delete(int id)
        {
            var user = _db.Users.Find(id);
            if (user != null)
            {
                _db.Users.Remove(user);
            }

            _db.SaveChanges();
        }

        public User GetUser(string username, string password)
        {
            var user = _db.Users.FirstOrDefault(u =>
                u.Username == username && u.Password == GetPasswordHash(password));

            return user;
        }

        public async Task<User> GetUserAsync(string username, string password)
        {
            return await Task.Run(()=>GetUser(username, password));
        }

        private void SyncUser(string username, string password, int? officeId, string userFio = "")
        {
            var user = _db.Users.FirstOrDefault(u => u.Username == username);

            if (user == null)
            {
                Add(new User
                {
                    Username = username,
                    Password = password,
                    OfficeId = officeId,
                    Fio = userFio
                });
                return;
            }

            user.Password = password;
            user.OfficeId = officeId;
            user.Fio = userFio;
            Update(user);
        }

        public async Task SyncUserAsync(string username, string password, int? officeId,string userFio)
        {
            await Task.Run(() =>
            {
                SyncUser(username,password,officeId, userFio);
            });
        }

        private string GetPasswordHash(string password)
        {
            byte[] hash;
            using (var sha1 = new System.Security.Cryptography.SHA1CryptoServiceProvider())
            {
                hash = sha1.ComputeHash(Encoding.Unicode.GetBytes($"idp{password}mobile"));
            }
            var passwordHash = new StringBuilder();
            foreach (byte b in hash)
            {
                passwordHash.AppendFormat("{0:x2}", b);
            }
            return passwordHash.ToString();
        }
    }
}
