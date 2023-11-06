﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using fusogram_csharp.Models;

#nullable disable

namespace fusogram_csharp.Migrations
{
    [DbContext(typeof(FusogramContext))]
    partial class FusogramContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("fusogram_csharp.Models.Seguidor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("IdUsuarioSeguido")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuarioSeguidor")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdUsuarioSeguido");

                    b.HasIndex("IdUsuarioSeguidor");

                    b.ToTable("Seguidores");
                });

            modelBuilder.Entity("fusogram_csharp.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FotoPerfil")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("fusogram_csharp.Models.Seguidor", b =>
                {
                    b.HasOne("fusogram_csharp.Models.Usuario", "UsuarioSeguido")
                        .WithMany()
                        .HasForeignKey("IdUsuarioSeguido");

                    b.HasOne("fusogram_csharp.Models.Usuario", "UsuarioSeguidor")
                        .WithMany()
                        .HasForeignKey("IdUsuarioSeguidor");

                    b.Navigation("UsuarioSeguido");

                    b.Navigation("UsuarioSeguidor");
                });
#pragma warning restore 612, 618
        }
    }
}
