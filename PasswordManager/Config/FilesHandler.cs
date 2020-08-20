using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PasswordManager.Config
{
    public class FilesHandler
    {
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
    }
}
