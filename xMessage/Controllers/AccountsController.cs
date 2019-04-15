using Core.Requests;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;

namespace xMessage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : Controller
    {
        private IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public JsonResult Post([FromBody] AddAccountRequest request)
        {
            return Json(_accountService.AddAccount(request));
        }
    }
}
