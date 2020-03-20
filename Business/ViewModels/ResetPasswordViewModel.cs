using System.ComponentModel.DataAnnotations;

namespace WeVsVirus.Business.ViewModels
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "E-Mail-Adresse fehlt")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Neues Passwort fehlt.")]
        [StringLength(100, ErrorMessage = "Das Passwort muss aus mindestens sechs Zeichen bestehen.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Die Passwörter stimmen nicht überein.")]
        public string ConfirmPassword { get; set; }
        public string Token { get; set; }
    }
}