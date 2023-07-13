﻿// <auto-generated />
using System;
using Escola.API.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Escola.API.Migrations
{
    [DbContext(typeof(EscolaDbContexto))]
    partial class EscolaDbContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.6.23329.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Escola.API.Model.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("PK_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2")
                        .HasColumnName("DATA_NASCIMENTO");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("EMAIL");

                    b.Property<string>("Genero")
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("GENERO");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("NOME");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("SOBRENOME");

                    b.Property<string>("Telefone")
                        .HasMaxLength(30)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("TELEFONE");

                    b.HasKey("Id")
                        .HasName("Pk_aluno_id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("ALUNO", (string)null);
                });

            modelBuilder.Entity("Escola.API.Model.Boletim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AlunoId")
                        .HasColumnType("INT");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("order_date");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.ToTable("BOLETINS", (string)null);
                });

            modelBuilder.Entity("Escola.API.Model.Materia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("MATERIAS", (string)null);
                });

            modelBuilder.Entity("Escola.API.Model.NotaMateria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BoletimId")
                        .HasColumnType("int");

                    b.Property<int>("MateriaId")
                        .HasColumnType("int");

                    b.Property<double>("Nota")
                        .HasColumnType("float")
                        .HasColumnName("NOTA");

                    b.HasKey("Id");

                    b.HasIndex("BoletimId");

                    b.HasIndex("MateriaId");

                    b.ToTable("NOTA_MATERIAS", (string)null);
                });

            modelBuilder.Entity("Escola.API.Model.Turma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Curso")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasDefaultValue("Curso Basico")
                        .HasColumnName("CURSO");

                    b.Property<string>("Nome")
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.HasIndex("Nome")
                        .IsUnique()
                        .HasFilter("[Nome] IS NOT NULL");

                    b.ToTable("TURMA", (string)null);
                });

            modelBuilder.Entity("Escola.API.Model.Boletim", b =>
                {
                    b.HasOne("Escola.API.Model.Aluno", "Aluno")
                        .WithMany("Boletins")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");
                });

            modelBuilder.Entity("Escola.API.Model.NotaMateria", b =>
                {
                    b.HasOne("Escola.API.Model.Boletim", "Boletim")
                        .WithMany("NotaMaterias")
                        .HasForeignKey("BoletimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Escola.API.Model.Materia", "Materia")
                        .WithMany("NotaMateria")
                        .HasForeignKey("MateriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Boletim");

                    b.Navigation("Materia");
                });

            modelBuilder.Entity("Escola.API.Model.Aluno", b =>
                {
                    b.Navigation("Boletins");
                });

            modelBuilder.Entity("Escola.API.Model.Boletim", b =>
                {
                    b.Navigation("NotaMaterias");
                });

            modelBuilder.Entity("Escola.API.Model.Materia", b =>
                {
                    b.Navigation("NotaMateria");
                });
#pragma warning restore 612, 618
        }
    }
}
