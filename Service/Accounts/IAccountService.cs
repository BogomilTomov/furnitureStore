using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Accounts
{
    public interface IAccountService
    {
        public Task<bool> UserNameExists(string userName);

        public Task<bool> EmailExists(string email);
    
    }
}
