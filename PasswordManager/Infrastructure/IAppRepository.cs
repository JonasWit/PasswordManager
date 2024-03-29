﻿using PasswordManager.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Infrastructure
{
    public interface IAppRepository
    {
        List<PasswordRecord> GetPasswords();
        void ChangeGeneralPassword(string newPassword);
        PasswordRecord GetPassword(string name);
        Task<int> CreatePassword(PasswordRecord record);
        Task<int> DeletePassword(int id);
    }
}
