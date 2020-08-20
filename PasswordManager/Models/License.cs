using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text;

namespace PasswordManager.Models
{
    public class License
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(21)]
        public string Key { get; set; }

        public DateTime ActivationDate { get; set; }

        public DateTime NextCheck { get; set; }
    }
}
