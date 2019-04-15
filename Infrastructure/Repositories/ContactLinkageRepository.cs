using System.Collections.Generic;
using Core.Entities;
using Core.Repositories;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class ContactLinkageRepository : IContactLinkageRepository
    {
        private AppDbContext _appDbContext;
        private IAccountRepository _accountRepository;

        public ContactLinkageRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void AddContactLinkage(int account1Id, int account2Id)
        {
            ContactLinkage contactLinkage = new ContactLinkage()
            {
                Account1Id = account1Id,
                Account2Id = account2Id
            };
            _appDbContext.ContactLinkages.Add(contactLinkage);
            _appDbContext.SaveChanges();
        }

        public bool CheckLinkage(int account1Id, int account2Id)
        {
            var query = from entity in _appDbContext.ContactLinkages
                        where (entity.Account1Id == account1Id && entity.Account2Id == account2Id)
                        || (entity.Account1Id == account2Id && entity.Account2Id == account1Id)
                        select entity;
            var found = query.FirstOrDefault();
            if (found != null)
            {
                return true;
            }
            return false;
        }

        public List<ContactLinkage> GetContactLikagesForUser(int accountId)
        {
            var query = from entity in _appDbContext.ContactLinkages
                        where entity.Account1Id == accountId || entity.Account2Id == accountId
                        select entity;
            return query.ToList();
        }
    }
}
