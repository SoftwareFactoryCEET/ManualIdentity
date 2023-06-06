using System.ComponentModel.DataAnnotations;

namespace sena.ceet.adso.WebApplicationWithIdentityMVC003.Models.ViewModels
{
    public class AccesoViewModel
    {
        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage ="Ingrese una cuenta de correo válida")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "Recordar datos?")]
        public bool RememberMe { get; set; }
    }
}
