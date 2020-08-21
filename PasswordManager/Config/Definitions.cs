using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace PasswordManager.Config
{
    public static class Definitions
    {
        public const string DBName = "PMDB.db";
        public const string JsonExtractName = "Passwords.json";

        public static string CorePath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "PasswordManagerLite");
        public static string Location => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    }
}
