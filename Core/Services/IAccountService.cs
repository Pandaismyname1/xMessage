using Core.Requests;
using Core.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public interface IAccountService
    {
        AddAccountResponse AddAccount(AddAccountRequest request);
    }
}
