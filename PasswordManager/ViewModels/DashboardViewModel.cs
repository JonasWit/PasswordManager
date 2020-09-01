using Microsoft.Extensions.DependencyInjection;
using PasswordManager.Controllers;
using PasswordManager.Dependancies;
using PasswordManager.Infrastructure;
using PasswordManager.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PasswordManager.ViewModels
{
    class DashboardViewModel : BaseViewModel, IViewModelRefreshable
    {
        private ObservableCollection<PasswordRecord> passwords;
        public ObservableCollection<PasswordRecord> Passwords { get => passwords; set { passwords = value; OnPropertyChanged(); } }

        private ObservableCollection<PasswordCharViewModel> passwordCharacters;
        public ObservableCollection<PasswordCharViewModel> PasswordCharacters { get => passwordCharacters; set { passwordCharacters = value; OnPropertyChanged(); } }

        public ICommand GetPassword { get; set; }

        public DashboardViewModel()
        {
            SetupCommands();
            Refresh();
            PasswordCharacters = new ObservableCollection<PasswordCharViewModel>();
        }

        public void SetupCommands()
        {
            GetPassword = new RelayCommand(() => DI.Provider.GetService<DashboardController>().GetPassword());
        }

        public void RefreshPasswordSplitter(PasswordRecord record)
        {
            PasswordCharacters = new ObservableCollection<PasswordCharViewModel>();

            for (int i = 0; i < record.Password.Length; i++)
            {
                PasswordCharacters.Add(new PasswordCharViewModel
                {  
                    Number = (i + 1).ToString(),
                    Character = record.Password[i].ToString()
                });
            }
        }

        public void Refresh()
        {
            var repo = DI.Provider.GetService<IAppRepository>();
            Passwords = new ObservableCollection<PasswordRecord>(repo.GetPasswords());
        }
    }
}
