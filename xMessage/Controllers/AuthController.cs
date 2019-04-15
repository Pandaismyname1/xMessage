using Core.Requests;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace xMessage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public JsonResult Get([FromQuery] AuthRequest request)
        {
            return Json(_authService.Auth(request));
        }
    }
}
