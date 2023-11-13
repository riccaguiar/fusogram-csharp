using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fusogram_csharp.Migrations
{
    /// <inheritdoc />
    public partial class ComentariosAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdPublicacao = table.Column<int>(type: "int", nullable: false),
                    PublicacaoComentario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comentarios_Publicacaos_PublicacaoComentario",
                        column: x => x.PublicacaoComentario,
                        principalTable: "Publicacaos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comentarios_Usuarios_IdPublicacao",
                        column: x => x.IdPublicacao,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_IdPublicacao",
                table: "Comentarios",
                column: "IdPublicacao");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_PublicacaoComentario",
                table: "Comentarios",
                column: "PublicacaoComentario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentarios");
        }
    }
}
