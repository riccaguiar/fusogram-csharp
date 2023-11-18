using fusogram_csharp.Dtos;
using fusogram_csharp.Models;

namespace fusogram_csharp.Repository
{
    public interface IPublicacaoRepository
    {
        public void Publicar(Publicacao publicacao);
        List<PublicacaoFeedRespostaDto> GetPublicacoesFeed(int idUsuario);
        List<PublicacaoFeedRespostaDto> GetPublicacoesFeedUsuario(int idUsuario);
        int GetQtdePublicacoes(int idUsuario);
    }
}
