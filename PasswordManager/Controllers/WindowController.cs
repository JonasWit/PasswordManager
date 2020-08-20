using PasswordManager.Dependancies;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace PasswordManager.Controllers
{
    [Service]
    public class WindowController
    {
        public void Exit() => Application.Current.Shutdown();
    }
}
