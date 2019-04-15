using Core.Entities;

namespace Core.Repositories
{
    public interface IAuthKeyRepository
    {
        AuthKey GenerateAuthKey(string email, string password);
        bool Validate(int userId, string authKey);
    }
}
