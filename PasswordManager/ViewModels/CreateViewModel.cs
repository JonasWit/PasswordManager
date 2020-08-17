using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace PasswordManager.ViewModels
{
    public class CreateViewModel : BaseViewModel
    {
        private string name;
        public string Name { get => name; set { name = value; OnPropertyChanged(); } }




    }
}
