using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Principal;
using System.Text;

namespace PasswordManager.Config
{
    public class SystemData
    {
        public DriveInfo[] Drives => DriveInfo.GetDrives();
        public WindowsIdentity User => WindowsIdentity.GetCurrent();
    }
}
