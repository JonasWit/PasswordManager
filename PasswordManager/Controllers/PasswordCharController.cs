using PasswordManager.Dependancies;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace PasswordManager.Controllers
{
    [Service]
    public class PasswordCharController
    {
        public void Copy(string character)
        {
            if (!string.IsNullOrEmpty(character))
            {
                Clipboard.SetDataObject(character);
            }
        }
    }
}
