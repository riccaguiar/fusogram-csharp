using fusogram_csharp.Models;

namespace fusogram_csharp.Repository
{
    // Interface que define operações de repositório relacionadas a usuários
    public interface IUsuarioRepository
    {
        Usuario GetUsuarioPorId(int v);
        Usuario GetUsuarioPorLoginSenha(string email, string senha);

        // Método para salvar um usuário no repositório
        public void Salvar(Usuario usuario);

        public bool VerificarEmail(string email);
    }
}
