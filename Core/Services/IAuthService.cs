using Core.Requests;
using Core.Responses;

namespace Core.Services
{
    public interface IAuthService
    {
        AuthResponse Auth(AuthRequest request);
    }
}
