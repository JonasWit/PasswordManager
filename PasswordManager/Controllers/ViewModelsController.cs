using PasswordManager.Dependancies;
using PasswordManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.Controllers
{
    [Service]
    public class ViewModelsController
    {
        public List<BaseViewModel> AppViewModels { get; set; } = new List<BaseViewModel>();

        public T GetViewModel<T>() where T : BaseViewModel, new()
        {
            foreach (var item in AppViewModels)
            {
                if (item is T)
                {
                    return item as T;
                }
            }

            return null;
        }

        public bool CreateViewModel<T>() where T : BaseViewModel, new()
        {
            DeleteViewModel<T>();
            AppViewModels.Add(new T());

            return true;
        }

        public bool DeleteViewModel<T>() where T : BaseViewModel, new()
        {
            T model = null;

            foreach (var item in AppViewModels)
            {
                if (item is T)
                {
                    model = item as T;
                }
            }

            if (model != null)
            {
                AppViewModels.Remove(model);
                return true;
            }

            return false;
        }

        public bool CheckViewModel<T>() where T : BaseViewModel
        {
            foreach (var item in AppViewModels)
            {
                if (item is T)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
