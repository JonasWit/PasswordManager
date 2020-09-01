using PasswordManager.Controllers;
using PasswordManager.Dependancies;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;

namespace PasswordManager.ViewModels
{
    public class PasswordCharViewModel
    {
        public string Number { get; set; }
        public string Character { get; set; }

        public ICommand Copy { get; set; }

        public PasswordCharViewModel()
        {
            Copy = new RelayCommand(() => DI.Provider.GetService<PasswordCharController>().Copy(Character));
        }
    }
}
