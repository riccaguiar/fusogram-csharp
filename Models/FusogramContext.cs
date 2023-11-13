using Microsoft.EntityFrameworkCore;

namespace fusogram_csharp.Models
{
    public class FusogramContext : DbContext
    {
        public FusogramContext(DbContextOptions<FusogramContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Seguidor> Seguidores { get; set; }
        public DbSet<Publicacao> Publicacaos { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }

    }
}
