using System.Globalization;
using System.Windows.Controls;

namespace PasswordManager.ValidationRules
{
    public class MaxLenghtValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo) => 
            string.IsNullOrWhiteSpace((value ?? "").ToString()) ? 
                ValidationResult.ValidResult : (value.ToString().Length > 100 ? 
                    new ValidationResult(false, "Max 100 characters!") : ValidationResult.ValidResult);

    }
}
