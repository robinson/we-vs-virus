using System.ComponentModel.DataAnnotations;

namespace WeVsVirus.Business.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Altes Passwort fehlt.")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Neues Passwort fehlt.")]
        [StringLength(100, ErrorMessage = "Das Passwort muss aus mindestens sechs Zeichen bestehen.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Die Passwörter stimmen nicht überein.")]
        public string ConfirmPassword { get; set; }
    }
}