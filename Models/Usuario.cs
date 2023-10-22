namespace fusogram_csharp.Models
{
    // Classe que representa a entidade "Usuario" no banco de dados
    public class Usuario
    {
        public int Id { get; set; }       // Propriedade para armazenar o ID do usuário
        public string Nome { get; set; }  // Propriedade para armazenar o nome do usuário
        public string Email { get; set; } // Propriedade para armazenar o email do usuário
        public string Senha { get; set; } // Propriedade para armazenar a senha do usuário

        // Esta classe é usada para mapear objetos da entidade "Usuario" entre o aplicativo e o banco de dados.
    }
}
