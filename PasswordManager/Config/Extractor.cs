using PasswordManager.Dependancies;
using PasswordManager.Infrastructure;
using PasswordManager.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Config
{
    [Service]
    public class Extractor
    {
        private readonly FilesHandler filesHandler;
        private readonly IAppRepository appRepository;
        private readonly string location;

        public Extractor(FilesHandler filesHandler, IAppRepository appRepository)
        {
            this.filesHandler = filesHandler;
            this.appRepository = appRepository;
            location = Definitions.Location;
        }

        public Task ExtractJson()
        {
            var json = filesHandler.Serialize(appRepository.GetPasswords());
            return filesHandler.SaveJsonFile(json, Path.Combine(location, Definitions.JsonExtractName));
        }

        public Task ExtractDatabase() => filesHandler.SaveDatabaseCopy(Path.Combine(location, Definitions.DBName));
    }
}
