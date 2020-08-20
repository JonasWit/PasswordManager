using Microsoft.Extensions.DependencyInjection;
using PasswordManager.BusinessLogic;
using PasswordManager.Dependancies;
using PasswordManager.Models;
using System.Collections.Generic;

namespace PasswordManager.ViewModels
{
    public class WelcomeViewModel : BaseViewModel, IViewModelRefreshable
    {
        public List<PasswordRecord> Passwords { get; set; }

        private string avgLenght;
        public string AvgLenght { get => avgLenght; set { avgLenght = value; OnPropertyChanged(); } }

        private string avgStrenght;
        public string AvgStrenght { get => avgStrenght; set { avgStrenght = value; OnPropertyChanged(); } }

        private double lenghtRating;
        public double LenghtRating { get => lenghtRating; set { lenghtRating = value; OnPropertyChanged(); } }

        private double strenghtRating;
        public double StrenghtRating { get => strenghtRating; set { strenghtRating = value; OnPropertyChanged(); } }

        private double generalRating;
        public double GeneralRating { get => generalRating; set { generalRating = value; OnPropertyChanged(); } }

        private string generalRatingMessage;
        public string GeneralRatingMessage { get => generalRatingMessage; set { generalRatingMessage = value; OnPropertyChanged(); } }

        private double verySecureRating;
        public double VerySecureRating { get => verySecureRating; set { verySecureRating = value; OnPropertyChanged(); } }

        private string verySecureMessage;
        public string VerySecureMessage { get => verySecureMessage; set { verySecureMessage = value; OnPropertyChanged(); } }

        private double uniqueRating;
        public double UniqueRating { get => uniqueRating; set { uniqueRating = value; OnPropertyChanged(); } }

        private string uniqueMessage;
        public string UniqueMessage { get => uniqueMessage; set { uniqueMessage = value; OnPropertyChanged(); } }

        public WelcomeViewModel()
        {
            Refresh();
        }

        public void Refresh()
        {
            var passwordReviewer = DI.Provider.GetService<PasswordReviewer>();
            passwordReviewer.Assess();

            AvgLenght = passwordReviewer.AvgLenght;
            AvgStrenght = passwordReviewer.AvgStrenght;
            LenghtRating = passwordReviewer.LenghtRating;
            StrenghtRating = passwordReviewer.StrenghtRating;
            GeneralRating = passwordReviewer.GeneralRating;
            VerySecureMessage = passwordReviewer.VerySecureMessage;
            VerySecureRating = passwordReviewer.VerySecureRating;
            GeneralRatingMessage = passwordReviewer.GeneralRatingMessage;
            UniqueMessage = passwordReviewer.UniqueMessage;
            UniqueRating = passwordReviewer.UniqueRating;
        }
    }
}
