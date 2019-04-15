using Core.DTOs;
using Core.Entities;
using Core.Repositories;
using Core.Requests;
using Core.Responses;
using Core.Services;
using System.Collections.Generic;
using Utilities;

namespace Services
{
    public class AuthService : IAuthService
    {
        private IAccountRepository _accountRepository;
        private IAuthKeyRepository _authKeyRepository;

        public AuthService(IAccountRepository accountRepository, IAuthKeyRepository authKeyRepository)
        {
            _accountRepository = accountRepository;
            _authKeyRepository = authKeyRepository;
        }
        public AuthResponse Auth(AuthRequest request)
        {
            AuthResponse response = new AuthResponse();
            response.Errors = new List<string>();
            response.Success = true;
            Account account = _accountRepository.GetAccountByEmail(request.Email);
            if (account == null)
            {
                response.Success = false;
                response.Errors.Add("Account does not exist");
                return response;
            }
            if (SHAHasher.ComputeSha256Hash(account.PasswordHash+request.Password) != account.PasswordHashed)
            {
                response.Success = false;
                response.Errors.Add("Passwords do not match");
            }
            if (!response.Success)
                return response;

            AuthKey authkey = _authKeyRepository.GenerateAuthKey(request.Email, request.Password);
            response.Success = true;
            response.AuthKey = authkey.Key;
            response.AccountId = authkey.AccountId;
            return response;
        }
    }

    public class ContactLinkageService : IContactLinkageService
    {
        private IContactLinkageRepository _contactLinkageRepository;
        private IAccountRepository _accountRepository;
        private IAuthKeyRepository _authKeyRepository;

        public ContactLinkageService(IContactLinkageRepository contactLinkageRepository ,IAccountRepository accountRepository, IAuthKeyRepository authKeyRepository)
        {
            _contactLinkageRepository = contactLinkageRepository;
            _accountRepository = accountRepository;
            _authKeyRepository = authKeyRepository;
        }

        public AddContactLinkageResponse AddContactLinkage(AddContactLinkageRequest request)
        {
            AddContactLinkageResponse response = new AddContactLinkageResponse();
            response.Success = true;
            response.Errors = new List<string>();
            if (!_authKeyRepository.Validate(request.AccountId, request.AuthKey))
            {
                response.Success = false;
                response.Errors.Add("You don't have access");
                return response;
            }
            Account toAccount = _accountRepository.GetAccountByEmail(request.Email);
            if(toAccount == null)
            {
                response.Success = false;
                response.Errors.Add("Username does not exist");
                return response;
            }

            _contactLinkageRepository.AddContactLinkage(request.AccountId, toAccount.AccountId);
            response.Success = true;
            return response;
        }

        public GetContactsResponse GetContacts(GetContactsRequest request)
        {
            GetContactsResponse response = new GetContactsResponse();
            response.Success = true;
            response.Errors = new List<string>();
            if (!_authKeyRepository.Validate(request.AccountId,request.AuthKey))
            {
                response.Success = false;
                response.Errors.Add("You don't have access");
                return response;
            }

            var result = _contactLinkageRepository.GetContactLikagesForUser(request.AccountId);
            List<ContactBasicInformationDTO> dtos = new List<ContactBasicInformationDTO>();
            foreach (var contact in result)
            {
                ContactBasicInformationDTO dto = new ContactBasicInformationDTO()
                {
                    AccountId = request.AccountId == contact.Account1Id ? contact.Account2Id : contact.Account1Id,
                    Username = request.AccountId == contact.Account1Id ? _accountRepository.GetAccountById(contact.Account2Id).Email : _accountRepository.GetAccountById(contact.Account1Id).Email
                };
                dtos.Add(dto);
            }
            response.Contacts = dtos;
            response.Success = true;
            return response;
        }
    }
}
