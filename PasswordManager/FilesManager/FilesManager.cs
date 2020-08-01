using PasswordManager.DI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PasswordManager.FilesManager
{
    [Service]
    public class FilesManager
    {
        public bool HandleRootFolder()
        {
            try
            {
                if (!Directory.Exists("C:\\SWPConfiguration"))
                {
                    DirectoryInfo di = Directory.CreateDirectory("C:\\SWPConfiguration");
                    di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
                }

                return true;
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
