using Core.Repositories;
using Core.Requests;
using Core.Responses;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class AccountService : IAccountService
    {
        private IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public AddAccountResponse AddAccount(AddAccountRequest request)
        {
            AddAccountResponse response = new AddAccountResponse();
            response.Errors = new List<string>();
            if (_accountRepository.GetAccountByEmail(request.Email) != null)
            {
                response.Success = false;
                response.Errors.Add("Email Already exists");
                return response;
            }
            _accountRepository.AddAccount(request.Email, request.Password);
            response.Success = true;
            return response;
        }
    }
}
