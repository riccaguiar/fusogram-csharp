using fusogram_csharp.Models;

namespace fusogram_csharp.Repository
{
    public interface IComentarioRepository
    {
        public void Comentar(Comentario comentario);
        List<Comentario> GetCometarioPorPublicacao(int idPublicacao);
    }
}
