﻿using PasswordManager.Dependancies;
using PasswordManager.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using PasswordManager.ViewModels;

namespace PasswordManager.Controllers
{
    [Service]
    public class AppController
    {
        public bool Busy { get; set; }
        public AppPage Page { get; private set; } = AppPage.Welcome;

        public void EnableBusyState()
        {
            if (Busy) return;
            Busy = true;

            var wvm = DI.Provider.GetService<ViewModelsController>().GetViewModel<WindowViewModel>();
            Page = wvm.CurrentPage;
            wvm.CurrentPage = AppPage.Loading;
        }


        public void DisableBusyState()
        {
            if (!Busy) return;
            Busy = false;

            var wvm = DI.Provider.GetService<ViewModelsController>().GetViewModel<WindowViewModel>();
            wvm.CurrentPage = Page;
        }

    }
}
