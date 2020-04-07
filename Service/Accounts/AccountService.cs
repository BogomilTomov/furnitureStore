using Data;
using Data.Repositories;
using Models;
using Service.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Accounts
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<bool> UserNameExists(string username)
        {
            return await _accountRepository.UserNameExists(username);
        }

        public async Task<bool> EmailExists(string email)
        {
            return await _accountRepository.EmailExists(email);
        }
    }
}
