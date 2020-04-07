using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IAccountRepository
    {
        public Task<bool> UserNameExists(string userName);

        public Task<bool> EmailExists(string email);

    }
}
