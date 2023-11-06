using fusogram_csharp.Models;

namespace fusogram_csharp.Repository.Impl
{
    public class SeguidorRepositoryImpl : ISeguidorRepository
    {
        private readonly FusogramContext _context;
        public SeguidorRepositoryImpl(FusogramContext context)
        {
            _context = context;
        }

        public bool Desseguir(Seguidor seguidor)
        {
            try
            {
                _context.Remove(seguidor);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Seguidor GetSeguidor(int idSeguidor, int idSeguido)
        {
            return _context.Seguidores.FirstOrDefault(s => s.IdUsuarioSeguidor == idSeguidor && s.IdUsuarioSeguido == idSeguido);
        }

        public bool Seguir(Seguidor seguidor)
        {
            try
            {
                _context.Add(seguidor);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
