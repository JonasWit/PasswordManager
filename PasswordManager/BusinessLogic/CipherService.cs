using Microsoft.AspNetCore.DataProtection;
using PasswordManager.Config;
using PasswordManager.Dependancies;

namespace PasswordManager.BusinessLogic
{
    [Service]
    public class CipherService
    {
        private readonly IDataProtectionProvider dataProtectionProvider;
        private readonly string key = Definitions.AccessKey;

        public CipherService(IDataProtectionProvider dataProtectionProvider) => this.dataProtectionProvider = dataProtectionProvider;

        public string Encrypt(string input) =>  dataProtectionProvider.CreateProtector(key).Protect(input);
        public string Encrypt(string input, string generalPassword) => dataProtectionProvider.CreateProtector(generalPassword).Protect(input);
        public string Decrypt(string cipherText) => dataProtectionProvider.CreateProtector(key).Unprotect(cipherText);
    }
}
