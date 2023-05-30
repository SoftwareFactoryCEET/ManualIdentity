using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace sena.ceet.adso.WebApplicationWithIdentityMVC003.Models
{
    [Table("Usuarios")]
    public class Usuario : IdentityUser
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool Estado { get; set; }
    }
}
