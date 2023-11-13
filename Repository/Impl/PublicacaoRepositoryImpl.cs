using fusogram_csharp.Models;

namespace fusogram_csharp.Repository.Impl
{
    public class PublicacaoRepositoryImpl : IPublicacaoRepository
    {
        private readonly FusogramContext _context;
        public PublicacaoRepositoryImpl(FusogramContext context)
        {
            _context = context;
        }

        public void Publicar(Publicacao publicacao)
        {
            _context.Add(publicacao);
            _context.SaveChanges();
        }
    }
}
