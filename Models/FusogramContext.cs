using Microsoft.EntityFrameworkCore;

namespace fusogram_csharp.Models
{
    public class FusogramContext : DbContext
    {
        public FusogramContext(DbContextOptions<FusogramContext> option) : base(option)
            {

            }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
