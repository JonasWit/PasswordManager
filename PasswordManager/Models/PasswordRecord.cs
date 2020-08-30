using System;
using System.ComponentModel.DataAnnotations;

namespace PasswordManager.Models
{
    public class PasswordRecord
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Required]
        [MaxLength(100)]
        public string CreatedBy { get; set; }

        public int Lenght { get; set; }
        public bool LowerCases { get; set; }
        public bool UpperCases { get; set; }
        public bool NumbersCases { get; set; }
        public bool SpecialCases { get; set; }
        public bool PolishCases { get; set; }
    }
}
