using PasswordManager.BusinessLogic;
using PasswordManager.Config;
using PasswordManager.Dependancies;
using PasswordManager.Infrastructure;
using PasswordManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasswordManager.Data
{
    [Service]
    public class AppRepository : IAppRepository
    {
        private readonly PMContext pmContext;
        private readonly CipherService cipherService;

        public AppRepository(PMContext pMContext, CipherService cipherService)
        {
            this.pmContext = pMContext;
            this.cipherService = cipherService;
        }

        public List<PasswordRecord> GetPasswords()
        {
            var result = pmContext.Passwords.ToList();

            foreach (var password in result)
            {
                try
                {
                    password.Password = cipherService.Decrypt(password.Password);
                    password.Name = cipherService.Decrypt(password.Name);
                    password.Login = cipherService.Decrypt(password.Login);
                    password.Email = cipherService.Decrypt(password.Email);
                }
                catch (Exception)
                {
                    password.Password = "Nie odszyfrowano!";
                }
            }

            result.RemoveAll(x => x.Password.Equals("Nie odszyfrowano!"));
            return result;
        }

        public PasswordRecord GetPassword(string name)
        {
            var result = pmContext.Passwords.FirstOrDefault(x => x.Name == name);

            try
            {
                result.Password = cipherService.Decrypt(result.Password);
                result.Name = cipherService.Decrypt(result.Name);
                result.Login = cipherService.Decrypt(result.Login);
                result.Email = cipherService.Decrypt(result.Email);
            }
            catch (Exception)
            {
                result = null;
            }

            return result;
        }

        public Task<int> CreatePassword(PasswordRecord record)
        {
            pmContext.Passwords.Add(new PasswordRecord
            {
                Name = cipherService.Encrypt(record.Name),
                Password = cipherService.Encrypt(record.Password),
                Lenght = record.Lenght,
                Login = cipherService.Encrypt(record.Login),
                LowerCases = record.LowerCases,
                UpperCases = record.UpperCases,
                NumbersCases = record.NumbersCases,
                PolishCases = record.PolishCases,
                SpecialCases = record.SpecialCases,
                Email = cipherService.Encrypt(record.Email),
                Created = DateTime.Now,
                CreatedBy = Environment.UserName
            });

            return pmContext.SaveChangesAsync();
        }

        public Task<int> DeletePassword(int id)
        {
            var entityToRemove = pmContext.Passwords.FirstOrDefault(x => x.Id == id);
            pmContext.Passwords.Remove(entityToRemove);
            return pmContext.SaveChangesAsync();
        }

        public void ChangeGeneralPassword(string newPassword)
        {
            var result = pmContext.Passwords.ToList();

            foreach (var password in result)
            {
                password.Password = cipherService.Decrypt(password.Password);
                password.Password = cipherService.Encrypt(password.Password, newPassword);
                password.Name = cipherService.Decrypt(password.Name);
                password.Name = cipherService.Encrypt(password.Name, newPassword);
                password.Login = cipherService.Decrypt(password.Login);
                password.Login = cipherService.Encrypt(password.Login, newPassword);
                password.Email = cipherService.Decrypt(password.Email);
                password.Email = cipherService.Encrypt(password.Email, newPassword);
            }

            pmContext.UpdateRange();
            pmContext.SaveChanges();
        }
    }
}
