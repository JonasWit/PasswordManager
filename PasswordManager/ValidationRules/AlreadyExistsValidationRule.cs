using PasswordManager.Dependancies;
using PasswordManager.Infrastructure;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;

namespace PasswordManager.ValidationRules
{
    public class AlreadyExistsValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var repo = DI.Provider.GetService<IAppRepository>();
            var passwords = repo.GetPasswords();

            return value != null ? (passwords.Any(x => x.Password == value.ToString())
                ? new ValidationResult(false, "Password already exists!")
                : ValidationResult.ValidResult) : ValidationResult.ValidResult;
        }
    }
}
