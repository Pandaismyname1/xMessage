using Core.Requests;
using Core.Responses;

namespace Core.Services
{
    public interface IContactLinkageService
    {
        AddContactLinkageResponse AddContactLinkage(AddContactLinkageRequest request);
        GetContactsResponse GetContacts(GetContactsRequest request);
    }
}
