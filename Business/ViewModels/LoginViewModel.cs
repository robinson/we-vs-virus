using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeVsVirus.Business.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "E-Mail-Addresse fehlt.")]
        [EmailAddress(ErrorMessage = "Das ist keine gültige E-Mail-Adresse.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Passwort fehlt.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}