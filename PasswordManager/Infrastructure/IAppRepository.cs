using PasswordManager.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Infrastructure
{
    public interface IAppRepository
    {
        List<PasswordRecord> GetPasswords();
        Task<int> CreatePassword(string login, string password);
        Task<int> CreatePassword(PasswordRecord record);
    }
}
