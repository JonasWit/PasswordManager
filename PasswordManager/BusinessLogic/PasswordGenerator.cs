using Microsoft.EntityFrameworkCore.Internal;
using PasswordManager.Data;
using PasswordManager.Dependancies;
using PasswordManager.Infrastructure;
using PasswordManager.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.ServiceProcess;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace PasswordManager.BusinessLogic
{
    public class PasswordGenerator : IPasswordGenerator
    {
        const string LOWER_CASE = @"abcdefghijklmnopqursuvwxyz";
        const string UPPER_CAES = @"ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string POLISH_CHARS = @"żśćąęćźłńŻŹĄĘĆŹŁŃ";
        const string NUMBERS = @"1234567890";
        const string SPECIALS = @"!@£$%^&*()#€";

        public List<PasswordRecord> Passwords { get; private set; }

        private readonly IAppRepository appRepository;
        public PasswordGenerator(IAppRepository appRepository) => this.appRepository = appRepository;

        public string GeneratePassword(bool useLowercase, bool useUppercase, bool useNumbers, bool useSpecial, bool usePolish,
            int passwordSize)
        {
            string charSet = "";
            if (useLowercase) charSet += LOWER_CASE;
            if (useUppercase) charSet += UPPER_CAES;
            if (useNumbers) charSet += NUMBERS;
            if (useSpecial) charSet += SPECIALS;
            if (usePolish) charSet += POLISH_CHARS;

            if (passwordSize < 5)
            {
                passwordSize = 5;
            }

            Passwords = appRepository.GetPasswords();

            var password = "";

            while (password == "" || !Check(useLowercase, useUppercase, useNumbers, useSpecial, usePolish, password))
            {
                password = Generate(passwordSize, charSet);
            }

            return password;
        }

        private string Generate(int passwordSize, string charSet)
        {
            char[] password = new char[passwordSize];
            Random random = new Random();

            for (var counter = 0; counter < passwordSize; counter++)
            {
                password[counter] = charSet[random.Next(charSet.Length - 1)];
            }

            return String.Join(null, password);
        }

        private bool Check(bool useLowercase, bool useUppercase, bool useNumbers, bool useSpecial, bool usePolish, string password)
        {
            if (Passwords.Any(x => x.Password == password)) return false;
            if (useLowercase) if (Regex.Matches(password, $"[{LOWER_CASE}]").Count == 0) return false ;
            if (useUppercase) if (Regex.Matches(password, $"[{UPPER_CAES}]").Count == 0) return false;
            if (useNumbers) if (Regex.Matches(password, $"[{NUMBERS}]").Count == 0) return false;
            if (useSpecial) if (Regex.Matches(password, $"[{SPECIALS}]").Count == 0) return false;
            if (usePolish) if (Regex.Matches(password, $"[{POLISH_CHARS}]").Count == 0) return false;

            return true;
        }

    }
}



