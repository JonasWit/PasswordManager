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
                }
                catch (Exception)
                {
                    password.Password = "Nie odszyfrowano!";
                    //password.Login = "Nie odszyfrowano!";
                    //password.Email = "Nie odszyfrowano!";
                    //password.Name = "Nie odszyfrowano!";
                    //password.Lenght = 0;
                    //password.UpperCases = false;
                    //password.LowerCases = false;
                    //password.SpecialCases = false;
                    //password.NumbersCases = false;
                    //password.PolishCases = false;
                    //password.Created = DateTime.Now;
                    //password.CreatedBy = "Nie odszyfrowano!";
                }
            }

            result.RemoveAll(x => x.Password.Equals("Nie odszyfrowano!"));
            return result;
        }

        public PasswordRecord GetPassword(string name)
        {
            var result =  pmContext.Passwords.FirstOrDefault(x => x.Name == name);

            try
            {
                result.Password = cipherService.Decrypt(result.Password);
            }
            catch (Exception)
            {
                //result.Password = "Nie odszyfrowano!";
                //result.Login = "Nie odszyfrowano!";
                //result.Email = "Nie odszyfrowano!";
                //result.Name = "Nie odszyfrowano!";
                //result.Lenght = 0;
                //result.UpperCases = false;
                //result.LowerCases = false;
                //result.SpecialCases = false;
                //result.NumbersCases = false;
                //result.PolishCases = false;
                //result.Created = DateTime.Now;
                //result.CreatedBy = "Nie odszyfrowano!";

                result = null;
            }

            return result;
        }

        public Task<int> CreatePassword(PasswordRecord record)
        {
            pmContext.Passwords.Add(new PasswordRecord
            {
                Name = record.Name,
                Password = cipherService.Encrypt(record.Password),
                Lenght = record.Lenght,
                Login = record.Login,
                LowerCases = record.LowerCases,
                UpperCases = record.UpperCases,
                NumbersCases = record.NumbersCases,
                PolishCases = record.PolishCases,
                SpecialCases = record.SpecialCases,
                Email = record.Email,
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
    }
}
