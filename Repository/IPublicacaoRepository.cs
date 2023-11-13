using fusogram_csharp.Models;

namespace fusogram_csharp.Repository
{
    public interface IPublicacaoRepository
    {
        public void Publicar(Publicacao publicacao);
    }   
}
