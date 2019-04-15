using Core.Entities;
using Core.Repositories;
using Utilities;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class AuthKeyRepository : IAuthKeyRepository
    {

        private AppDbContext _appDbContext;
        private IAccountRepository _accountRepository;

        public AuthKeyRepository(AppDbContext appDbContext, IAccountRepository accountRepository)
        {
            _appDbContext = appDbContext;
            _accountRepository = accountRepository;
        }

        public AuthKey GenerateAuthKey(string email, string password)
        {
            Account account = _accountRepository.GetAccountByEmail(email);
            if (account == null) return null;

            string hash = SHAHasher.ComputeSha256Hash(RandomStringGenerator.CreateString(256));
            AuthKey authKey = new AuthKey()
            {
                AccountId = account.AccountId,
                Key = hash
            };
            _appDbContext.AuthKeys.Add(authKey);
            _appDbContext.SaveChanges();
            return authKey;
        }

        public bool Validate(int userId, string authKey)
        {
            var query = from entity in _appDbContext.AuthKeys
                        where entity.AccountId == userId && entity.Key == authKey
                        select entity;
            if (query.FirstOrDefault() != null)
                return true;
            return false;
        }
    }
}
