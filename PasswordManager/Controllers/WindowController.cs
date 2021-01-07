using PasswordManager.Dependancies;
using System.Diagnostics;
using System.Windows;

namespace PasswordManager.Controllers
{
    [Service]
    public class WindowController
    {
        public void Exit() => Application.Current.Shutdown();

        public void About()
        {
            var psi = new ProcessStartInfo
            {
                FileName = "https://www.systemywp.pl",
                UseShellExecute = true
            };
            Process.Start(psi);
        }
    }
}
