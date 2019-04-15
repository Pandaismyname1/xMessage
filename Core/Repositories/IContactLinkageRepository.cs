using Core.Entities;
using System.Collections.Generic;

namespace Core.Repositories
{
    public interface IContactLinkageRepository
    {
        void AddContactLinkage(int account1Id, int account2Id);
        List<ContactLinkage> GetContactLikagesForUser(int accountId);
        bool CheckLinkage(int account1Id, int account2Id);
    }
}
