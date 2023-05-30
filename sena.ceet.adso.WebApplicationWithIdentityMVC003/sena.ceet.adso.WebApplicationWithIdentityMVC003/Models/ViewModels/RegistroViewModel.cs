using System.ComponentModel.DataAnnotations;

namespace sena.ceet.adso.WebApplicationWithIdentityMVC003.Models.ViewModels
{
    public class RegistroViewModel
    {
        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage ="Ingrese una dirección de correo electrónico válida")]
        public string Email { get; set; }


        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [StringLength(50, ErrorMessage = "La {0} debe estar entre al menos {2} y máximo {1} caracteres de longitud", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }


        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [StringLength(50, ErrorMessage = "La {0} debe estar entre al menos {2} y máximo {1} caracteres de longitud", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string ConfirmPassword { get; set; }

        [RegularExpression("^[0-9]+$", ErrorMessage = "Ingresa solo números.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria")]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio")]
        public bool Estado { get; set; }
    }
}
