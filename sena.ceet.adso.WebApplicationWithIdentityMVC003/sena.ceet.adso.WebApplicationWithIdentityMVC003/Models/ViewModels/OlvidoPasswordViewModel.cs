using System.ComponentModel.DataAnnotations;

namespace sena.ceet.adso.WebApplicationWithIdentityMVC003.Models.ViewModels
{
    public class OlvidoPasswordViewModel
    {
        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
