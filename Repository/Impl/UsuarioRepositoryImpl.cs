using fusogram_csharp.Models;

namespace fusogram_csharp.Repository.Impl
{
    // Classe que implementa a interface IUsuarioRepository para operações de repositório relacionadas a usuários
    public class UsuarioRepositoryImpl : IUsuarioRepository
    {
        private readonly FusogramContext _context;

        // Construtor que recebe o contexto do banco de dados
        public UsuarioRepositoryImpl(FusogramContext context)
        {
            _context = context; // Inicializa o contexto do banco de dados
        }

        public Usuario GetUsuarioPorId(int id)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Id == id);
        }

        public Usuario GetUsuarioPorLoginSenha(string email, string senha)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }

        // Método para salvar um usuário no banco de dados
        public void Salvar(Usuario usuario)
        {
            _context.Add(usuario);  // Adiciona o usuário ao contexto
            _context.SaveChanges(); // Salva as alterações no banco de dados
        }

        public bool VerificarEmail(string email)
        {
            return _context.Usuarios.Any(u => u.Email == email);
        }
    }
}
