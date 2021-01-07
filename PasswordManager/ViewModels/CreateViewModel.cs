using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;
using PasswordManager.Controllers;
using PasswordManager.Dependancies;

namespace PasswordManager.ViewModels
{
    public class CreateViewModel : BaseViewModel
    {
        private string name;
        public string Name { get => name; set { name = value; OnPropertyChanged(); } }

        private string login;
        public string Login { get => login; set { login = value; OnPropertyChanged(); } }

        private string email;
        public string Email { get => email; set { email = value; OnPropertyChanged(); } }

        private string password;
        public string Password { get => password; set { password = value; OnPropertyChanged(); } }

        private string customPassword;
        public string CustomPassword { get => customPassword; set { customPassword = value; OnPropertyChanged(); } }

        private ObservableCollection<int> passwordLenghtValues;
        public ObservableCollection<int> PasswordLenghtValues { get => passwordLenghtValues; set { passwordLenghtValues = value; OnPropertyChanged(); } }

        private int passwordLenght;
        public int PasswordLenght { get => passwordLenght; set { passwordLenght = value; OnPropertyChanged(); } }

        private bool useLower;
        public bool UserLower { get => useLower; set { useLower = value; OnPropertyChanged(); } }

        private bool useUpper;
        public bool UseUpper { get => useUpper; set { useUpper = value; OnPropertyChanged(); } }

        private bool useNumber;
        public bool UseNumber { get => useNumber; set { useNumber = value; OnPropertyChanged(); } }

        private bool useSpecial;
        public bool UseSpecial { get => useSpecial; set { useSpecial = value; OnPropertyChanged(); } }

        private bool usePolish;
        public bool UsePolish { get => usePolish; set { usePolish = value; OnPropertyChanged(); } }

        public ICommand GeneratePassword { get; set; }
        public ICommand CopyPassword { get; set; }    
        public ICommand SavePassword { get; set; }

        public CreateViewModel()
        {
            SetUpCommands();
            SetUpControls();
        }

        private void SetUpControls()
        {
            PasswordLenghtValues = new ObservableCollection<int> { 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 21 };
            PasswordLenght = 16;
            UserLower = true;
            UseUpper = true;
            UseNumber = true;
            UseSpecial = true;
            UsePolish = false;
        }

        private void SetUpCommands()
        {
            GeneratePassword = new RelayCommand(async () => await DI.Provider.GetService<CreatePageController>().GeneratePassword());
            CopyPassword = new RelayCommand(() => DI.Provider.GetService<CreatePageController>().CopyPassword());
            SavePassword = new RelayCommand(async () => await DI.Provider.GetService<CreatePageController>().SavePassword());
        }
    }
}
