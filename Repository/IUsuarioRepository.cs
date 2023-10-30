using fusogram_csharp.Models;

namespace fusogram_csharp.Repository
{
    public interface IUsuarioRepository
    {
        public Usuario GetUsuarioPorId(int id);
        public Usuario GetUsuarioPorLoginSenha(string email, string senha);
        public void Salvar(Usuario usuario);
        public bool VerificarEmail(string email);
        public void AtualizarUsuario(Usuario usuario);
    }
}