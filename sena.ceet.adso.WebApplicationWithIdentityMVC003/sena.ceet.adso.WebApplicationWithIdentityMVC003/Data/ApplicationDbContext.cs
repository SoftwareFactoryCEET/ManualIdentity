using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace sena.ceet.adso.WebApplicationWithIdentityMVC003.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) 
            : base(options)
        {
            
        }
    }
}
