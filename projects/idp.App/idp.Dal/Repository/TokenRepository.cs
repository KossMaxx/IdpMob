using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using idp.Dal.Models;
using idp.Dal.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace idp.Dal.Repository
{
    public class TokenRepository : ITokenRepository
    {
        private readonly ApplicationContext _db;

        public TokenRepository(ApplicationContext context)
        {
            _db = context;
        }

        public string Get()
        {
            var token = _db.Tokens.AsNoTracking().FirstOrDefault();

            if (token == null || token.expires_in < DateTime.Now)
            {
                return null;
            }

            return token.access_token;
        }

        public async Task<string> GetAsync()
        {
            return await Task.Run(Get);
        }

        public void Add(string newToken, DateTime newExpireDate)
        {
            var token = _db.Tokens.AsNoTracking().FirstOrDefault();
            if (token == null)
            {
                _db.Tokens.Add(new Token
                {
                    access_token = newToken,
                    expires_in = newExpireDate
                });
            }
            else
            {
                token.access_token = newToken;
                token.expires_in = newExpireDate;
                _db.Update(token);
            }

            _db.SaveChanges();
        }

        public async Task AddAsync(string newToken, DateTime newExpireDate)
        {
            await Task.Run(()=>Add(newToken, newExpireDate));
        }

        public bool CheckToken()
        {
            var token = _db.Tokens.AsNoTracking().FirstOrDefault();
            if (token == null)
            {
                return false;
            }

            return token.expires_in > DateTime.Now;
        }
    }
}
