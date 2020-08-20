using PasswordManager.Dependancies;
using PasswordManager.Infrastructure;
using PasswordManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PasswordManager.BusinessLogic
{
    [Service]
    public class PasswordReviewer
    {
        const string LOWER_CASE = @"abcdefghijklmnopqursuvwxyz";
        const string UPPER_CAES = @"ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string POLISH_CHARS = @"żśćąęćźłńŻŹĄĘĆŹŁŃ";
        const string NUMBERS = @"1234567890";
        const string SPECIALS = @"!@£$%^&*()#€";

        private readonly IAppRepository appRepository;

        public string AvgLenght { get; private set; }
        public string AvgStrenght { get; private set; }

        public double LenghtRating { get; private set; }
        public double StrenghtRating { get; private set; }
  
        public string GeneralRatingMessage { get; private set; }
        public double GeneralRating { get; private set; }

        public string VerySecureMessage { get; private set; }
        public double VerySecureRating { get; private set; }

        public string UniqueMessage { get; private set; }
        public double UniqueRating { get; private set; }

        public PasswordReviewer(IAppRepository appRepository) => this.appRepository = appRepository;

        public void Assess()
        {
            var passwords = appRepository.GetPasswords();

            if (passwords.Count == 0)
            {
                AvgLenght = $"Avarage lenght of your password is {0}";
                AvgStrenght = $"Avarage lenght of your password is {0}";
                StrenghtRating = 0;
                LenghtRating = 0;
                GeneralRating = 0;
                VerySecureMessage = $"{0} out of {0} passwords are very secure!";
                VerySecureRating = 0;
                GeneralRatingMessage = "No passwords yet!";
                UniqueMessage = "No passwords yet!";
                UniqueRating = 0;
            }
            else
            {
                var avgLenght = AssessAvgLenght(passwords);
                AvgLenght = $"Avarage lenght of your password is {avgLenght}";
                LenghtRating = AssessLenghtRating(avgLenght);

                var avgStrenght = AssessAvgStrenght(passwords);
                AvgStrenght = $"Avarage strenght of your password is {Math.Floor((avgStrenght / 5) * 100)}%";
                StrenghtRating = avgStrenght;
                GeneralRating = AssessGeneralRating(passwords);
                GeneralRatingMessage = CreateGeneralRatingComment(GeneralRating);

                var verySecurePasswords = AssessVerySecure(passwords);
                var verySecureShare = AssessVerySecureShare(verySecurePasswords, passwords.Count);
                VerySecureMessage = $"{verySecureShare}% of passwords are very secure!";
                VerySecureRating = AssessVerySecureRating(passwords.Count, verySecurePasswords);

                UniqueMessage = CreateUniqueRatingComment(passwords);
                UniqueRating = AssessUniqueRating(passwords);
            }
        }

        private string CreateGeneralRatingComment(double rating) =>
            rating switch
            {
                0 => "Why even use passwords?",
                1 => "Why even use passwords?",
                2 => "Why even use passwords?",
                3 => "Could have been better!",
                4 => "Most of your passwords are secure!",
                5 => "Passwords are secure!",
                _ => "",
            };


        private double AssessAvgLenght(List<PasswordRecord> passwords) => Math.Floor(passwords.Average(x => x.Lenght));

        private double AssessAvgStrenght(List<PasswordRecord> passwords)
        {
            var count = passwords.Count();

            var strenghtNumber = 0d;

            foreach (var password in passwords)
            {
                if (password.LowerCases) strenghtNumber++;
                if (password.UpperCases) strenghtNumber++;
                if (password.NumbersCases) strenghtNumber++;
                if (password.SpecialCases) strenghtNumber++;
                if (password.PolishCases) strenghtNumber++;
            }

            var score = strenghtNumber / count;

            return Math.Floor(score);
        }

        private double AssessLenghtRating(double lenght)
        {
            if (lenght < 8)
            {
                return 0;
            }
            else if (lenght < 9)
            {
                return 1;
            }
            else if (lenght < 10)
            {
                return 2;
            }
            else if (lenght < 11)
            {
                return 3;
            }
            else if (lenght < 15)
            {
                return 4;
            }
            else 
            {
                return 5;
            }
        }

        private double AssessStrenghtRating(PasswordRecord password)
        {
            var strenghtNumber = 0d;

            if (password.LowerCases) strenghtNumber++;
            if (password.UpperCases) strenghtNumber++;
            if (password.NumbersCases) strenghtNumber++;
            if (password.SpecialCases) strenghtNumber++;
            if (password.PolishCases) strenghtNumber++;

            return strenghtNumber;
        }

        private double AssessVerySecureShare(double securePasswords, double total) => Math.Floor((securePasswords / total) * 100);

        private double AssessVerySecureRating(double total, double verySecure) => Math.Floor(5 * (verySecure / total));
        
        private double AssessVerySecure(List<PasswordRecord> passwords) => passwords.Count(x => AssessStrenghtRating(x) == 5 && AssessLenghtRating(x.Lenght) == 5);

        private double AssessGeneralRating(List<PasswordRecord> passwords)
        {
            var score = 0d;

            foreach (var password in passwords)
            {
                var lenghtScore = AssessLenghtRating(password.Lenght);
                var strenghtScore = AssessStrenghtRating(password);

                score += Math.Floor((lenghtScore + strenghtScore) / 2d);
            }

            var duplicates = passwords.GroupBy(x => x.Password).Where(x => x.Count() > 1).Select(y => new { Password = y.Key }).ToList().Count;
            var rating = score / passwords.Count;

            if (duplicates != 0)
            {
                rating /= 2;
            }

            return Math.Floor(rating);
        }

        public bool CheckLowerCase(string password) => Regex.Matches(password, $"[{LOWER_CASE}]").Count != 0;

        public bool CheckUpperCase(string password) => Regex.Matches(password, $"[{UPPER_CAES}]").Count != 0;

        public bool CheckNumericCase(string password) => Regex.Matches(password, $"[{NUMBERS}]").Count != 0;

        public bool CheckSpecialCase(string password) => Regex.Matches(password, $"[{SPECIALS}]").Count != 0;

        public bool CheckPolishCase(string password) => Regex.Matches(password, $"[{POLISH_CHARS}]").Count != 0;

        private string CreateUniqueRatingComment(List<PasswordRecord> passwords)
        {
            var duplicates = passwords.GroupBy(x => x.Password).Where(x => x.Count() > 1).Select(y => new { Password = y.Key }).ToList().Count;

            if (duplicates == 0)
            {
                return "All of your passwords are unique!";
            }
            else
            {
                return $"{duplicates} of your passwords are not unique!";
            }
        }

        private double AssessUniqueRating(List<PasswordRecord> passwords) =>
            passwords.GroupBy(x => x.Password).Where(x => x.Count() > 1).Select(y => new { Password = y.Key }).ToList().Count != 0 ? 0 : 5;
    }
}
