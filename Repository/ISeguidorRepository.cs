using fusogram_csharp.Models;

namespace fusogram_csharp.Repository
{
    public interface ISeguidorRepository
    {
        public bool Seguir(Seguidor seguidor);
        public bool Desseguir(Seguidor seguidor);
        public Seguidor GetSeguidor(int idSeguidor, int idSeguido);
    }
}
