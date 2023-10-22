using Microsoft.EntityFrameworkCore;

namespace fusogram_csharp.Models
{
    // Classe que representa o contexto do banco de dados
    public class FusogramContext : DbContext
    {
        // Construtor que recebe as opções de configuração do contexto do banco de dados
        public FusogramContext(DbContextOptions<FusogramContext> options) : base(options)
        {
            // O construtor base é chamado com as opções de configuração fornecidas
        }

        // Define uma propriedade DbSet para a entidade "Usuario"
        public DbSet<Usuario> Usuarios { get; set; }

        // Este é o contexto do banco de dados usado pelo Entity Framework Core para interagir com o banco de dados.

        // O construtor recebe as opções de configuração que determinam a conexão com o banco de dados.

        // A propriedade DbSet permite acessar a tabela "Usuarios" no banco de dados como uma coleção de objetos da entidade "Usuario".

        // O Entity Framework Core usará este contexto para executar operações de banco de dados, como consultas e atualizações, na tabela "Usuarios".
    }
}
