using PasswordManager.Dependancies;
using PasswordManager.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using PasswordManager.ViewModels;
using PasswordManager.Models;

namespace PasswordManager.Controllers
{
    public class AppController
    {
        public bool Busy { get; set; }
        public AppPage Page { get; private set; } = AppPage.Welcome;

        public void RefreshViewModels()
        {
            var vmc = DI.Provider.GetService<ViewModelsController>();

            foreach (var vm in vmc.AppViewModels)
            {
                if (vm is IViewModelRefreshable)
                {
                    var refreshableVm = vm as IViewModelRefreshable;
                    refreshableVm.Refresh();
                }
            }
        }

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
