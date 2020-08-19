using PasswordManager.Dependancies;
using PasswordManager.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.Controllers
{
    [Service]
    public class AppController
    {
        public bool Busy { get; set; }
        public AppPage Page { get; private set; }

        public void EnableBusyState()
        {
            if (Busy) return;

            Busy = true;





        }


        public void DisableBusyState()
        {
            if (!Busy) return;

            Busy = false;




        }

    }
}
