using Core.DTOs;
using System.Collections.Generic;

namespace Core.Responses
{
    public class GetContactsResponse : GenericResponse
    {
        public List<ContactBasicInformationDTO> Contacts { get; set; }
    }

    public class AddContactLinkageResponse : GenericResponse
    {

    }
}
