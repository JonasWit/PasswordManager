using System;
using System.Diagnostics;
using System.IO;

namespace PasswordManager.Config
{
    public static class Definitions
    {
        public const string JsonExtractName = "Passwords.json";
        public static string DBName => $"PMDB_{Environment.UserName}.db";
        public static string AccessKey => $"ProdAccessKey{Environment.UserName}";

        public static string CorePath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "PasswordManagerLite");
        public static string Location => Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
    }
}
