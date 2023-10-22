using fusogram_csharp.Models;

namespace fusogram_csharp.Repository.Impl
{
    public class UsuarioRepositoryImpl : IUsuarioRepository
    {
        private readonly FusogramContext _context;
        public UsuarioRepositoryImpl(FusogramContext context)
        {
            _context = context;
        }
        public void Salvar(Usuario usuario)
        {
            _context.Add(usuario);
            _context.SaveChanges();
        }
    }
}
