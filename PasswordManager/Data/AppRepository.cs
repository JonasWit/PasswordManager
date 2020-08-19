using PasswordManager.Dependancies;
using PasswordManager.Infrastructure;
using PasswordManager.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace PasswordManager.Data
{
    [Service]
    public class AppRepository : IAppRepository
    {
        private readonly PMContext pmContext;

        public AppRepository(PMContext pMContext) => this.pmContext = pMContext;

        public List<PasswordRecord> GetPasswords() => pmContext.Passwords.ToList();

        public Task<int> CreatePassword(string login, string password)
        {
            pmContext.Passwords.Add(new PasswordRecord { Login = login, Password = password });
            return pmContext.SaveChangesAsync();
        }

        public Task<int> CreatePassword(PasswordRecord record)
        {
            pmContext.Passwords.Add(new PasswordRecord 
            {
                Name = record.Name,
                Password = record.Password,
                Lenght = record.Lenght,
                Login = record.Login,
                LowerCases = record.LowerCases,
                UpperCases = record.UpperCases,
                NumbersCases = record.NumbersCases,
                PolishCases = record.PolishCases,
                SpecialCases = record.SpecialCases
            });

            return pmContext.SaveChangesAsync();
        }
    }
}
