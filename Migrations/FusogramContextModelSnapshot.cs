// Este arquivo é gerado automaticamente pelo Entity Framework Core para representar o modelo de banco de dados atual.

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using fusogram_csharp.Models;

#nullable disable

namespace fusogram_csharp.Migrations
{
    // Classe que representa uma "fotografia" do modelo atual do banco de dados
    [DbContext(typeof(FusogramContext))]
    partial class FusogramContextModelSnapshot : ModelSnapshot
    {
        // Método que constrói o modelo do banco de dados
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618

            // Configurações gerais do modelo
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            // Configuração específica para SQL Server - uso de colunas de identidade
            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            // Configuração da entidade "Usuario"
            modelBuilder.Entity("fusogram_csharp.Models.Usuario", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd() // Coluna de identidade (autoincremento)
                    .HasColumnType("int");

                // Configuração específica para SQL Server - uso de coluna de identidade
                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                b.Property<string>("Email")
                    .IsRequired() // Campo obrigatório
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Nome")
                    .IsRequired() // Campo obrigatório
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Senha")
                    .IsRequired() // Campo obrigatório
                    .HasColumnType("nvarchar(max)");

                b.HasKey("Id"); // Chave primária da entidade

                b.ToTable("Usuarios"); // Nome da tabela
            });
#pragma warning restore 612, 618
        }
    }
}
