using System.ComponentModel.DataAnnotations;

namespace WeVsVirus.Business.ViewModels
{
    public class SignUpDriverViewModel
    {
        [Required(ErrorMessage = "Vorname fehlt")]
        public string Firstname { get; set; }
        
        [Required(ErrorMessage = "Nachname fehlt")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "E-Mail-Adresse fehlt")]
        [EmailAddress]
        public string Email { get; set; }

    }
}
