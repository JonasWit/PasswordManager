using DeviceId;
using System;
using System.Diagnostics;
using System.IO;

namespace PasswordManager.Config
{
    public static class Definitions
    {
        public static string GeneralPassword = "";

        public const string JsonExtractName = "Passwords.json";
        public static string DBName => $"PasswordManagerLite.db";
        public static string AccessKey => GeneralPassword;
        public static string CorePath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "PasswordManagerLite");
        public static string Location => Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
        public static string GetDrviceId() => 
            new DeviceIdBuilder()
                .AddMachineName()
                .AddMotherboardSerialNumber()
                .ToString();
    }
}
