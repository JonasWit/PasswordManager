using PasswordManager.Dependancies;
using PasswordManager.Models;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;

namespace PasswordManager.Config
{
    [Service]
    public class FilesHandler
    {
        private readonly string location;

        public FilesHandler() => location = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public bool HandleRootFolder()
        {
            try
            {
                if (!Directory.Exists(Definitions.CorePath))
                {
                    DirectoryInfo di = Directory.CreateDirectory(Definitions.CorePath);
                    di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CheckRootFolderContent()
        {
            try
            {
                if (Directory.Exists(Definitions.CorePath))
                {
                    if (Directory.GetFiles(Definitions.CorePath, Definitions.DBName).Length == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool HandleFolder(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    DirectoryInfo di = Directory.CreateDirectory(path);
                    di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public string Serialize(List<PasswordRecord> input) => JsonSerializer.Serialize(input);

        public Task SaveJsonFile(string json, string path)
        {
            RemoveExtractFile(Path.GetFileName(path));
            return File.WriteAllTextAsync(path, json);
        }

        public Task SaveDatabaseCopy(string path)
        {
            RemoveExtractFile(Path.GetFileName(path));
            return Task.Run(() =>File.Copy(Path.Combine(Definitions.CorePath, Definitions.DBName), Path.Combine(location, Definitions.DBName)));
        }

        private void RemoveExtractFile(string fileName)
        {
            string[] files = Directory.GetFiles(location, fileName, SearchOption.AllDirectories);

            foreach (var file in files)
            {
                if (File.Exists(file))
                {
                    File.Delete(file);
                }
            }

        }
    }
}
