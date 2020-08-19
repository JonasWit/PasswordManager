using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Infrastructure
{
    public interface IPasswordGenerator
    {
        string GeneratePassword(bool useLowercase, bool useUppercase, bool useNumbers, bool useSpecial, bool usePolish, int passwordSize);
    }
}
