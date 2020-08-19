using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PasswordManager.PMExtensions
{
    public static class PmExtensions
    {
        public static bool ContainsAny(this string inputString, params string[] lookupStrings) => lookupStrings.Any(inputString.Contains);
    }
}
