using Core.Entities;
using Core.Repositories;
using System;
using Utilities;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private AppDbContext _appDbContext;

        public AccountRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void AddAccount(string email, string password)
        {
            string hash = SHAHasher.ComputeSha256Hash(RandomStringGenerator.CreateString(256));
            string hashedPassword = SHAHasher.ComputeSha256Hash(hash + password);
            Account newAccount = new Account()
            {
                Email = email,
                PasswordHash = hash,
                PasswordHashed = hashedPassword
            };
            _appDbContext.Accounts.Add(newAccount);
            _appDbContext.SaveChanges();
        }

        public Account GetAccountByEmail(string email)
        {
            var query = from entity in _appDbContext.Accounts
                        where entity.Email.ToLower() == email.ToLower()
                        select entity;
            var result = query.ToList();
            if (result.Count >= 1)
                return result[0];
            return null;
        }

        public Account GetAccountById(int id)
        {
            var query = from entity in _appDbContext.Accounts
                        where entity.AccountId == id
                        select entity;
            var result = query.ToList();
            if (result.Count == 1)
                return result[0];
            return null;
        }
    }
}
