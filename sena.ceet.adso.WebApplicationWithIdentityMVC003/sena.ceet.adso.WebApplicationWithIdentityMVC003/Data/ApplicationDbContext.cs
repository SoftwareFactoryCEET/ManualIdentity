using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using sena.ceet.adso.WebApplicationWithIdentityMVC003.Models;

namespace sena.ceet.adso.WebApplicationWithIdentityMVC003.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) 
            : base(options)
        {
            
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
