using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fusogram_csharp.Migrations
{
    // Classe de migração para criar a tabela de Usuários no banco de dados
    public partial class fusomigration : Migration
    {
        // Método para aplicar a migração (criar a tabela)
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios", // Nome da tabela
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"), // Coluna de identidade
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false), // Coluna para o nome (não nulo)
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false), // Coluna para o email (não nulo)
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false) // Coluna para a senha (não nulo)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id); // Chave primária da tabela
                });
        }

        // Método para desfazer a migração (remover a tabela)
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios"); // Remove a tabela de Usuários
        }
    }
}
