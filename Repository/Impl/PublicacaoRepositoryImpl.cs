using fusogram_csharp.Dtos;
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



        public List<PublicacaoFeedRespostaDto> GetPublicacoesFeed(int idUsuario)
        {
            var feed =
                from publicacoes in _context.Publicacaos
                join seguidores in _context.Seguidores on publicacoes.IdUsuario equals seguidores.IdUsuarioSeguido
                where seguidores.IdUsuarioSeguidor == idUsuario
                select new PublicacaoFeedRespostaDto
                {
                    IdPublicacao = publicacoes.Id,
                    Descricao = publicacoes.Descricao,
                    Foto = publicacoes.Foto,
                    IdUsuario = publicacoes.IdUsuario
                };

            return feed.ToList();
        }

        public List<PublicacaoFeedRespostaDto> GetPublicacoesFeedUsuario(int idUsuario)
        {
            var feedusuario =
                from publicacoes in _context.Publicacaos
                where publicacoes.IdUsuario == idUsuario
                select new PublicacaoFeedRespostaDto
                {
                    IdPublicacao = publicacoes.Id,
                    Descricao = publicacoes.Descricao,
                    Foto = publicacoes.Foto,
                    IdUsuario = publicacoes.IdUsuario
                };

            return feedusuario.ToList();
        }

        public int GetQtdePublicacoes(int idUsuario)
        {
            return _context.Publicacaos.Count(p => p.IdUsuario == idUsuario);
        }

        public void Publicar(Publicacao publicacao)
        {
            _context.Add(publicacao);
            _context.SaveChanges();
        }



    }
}
