using Core.Requests;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace xMessage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : Controller
    {
        private IContactLinkageService _contactLinkageService;

        public ContactsController(IContactLinkageService contactLinkageService)
        {
            _contactLinkageService = contactLinkageService;
        }

        [HttpGet]
        public JsonResult Get(GetContactsRequest request)
        {
            return Json(_contactLinkageService.GetContacts(request));
        }

        [HttpPost]
        public JsonResult Post([FromBody] AddContactLinkageRequest request)
        {
            return Json(_contactLinkageService.AddContactLinkage(request));
        }
    }
}
