using Microsoft.EntityFrameworkCore;
using Escola.API.Model;

namespace Escola.API.DataBase
{
    public class EscolaDbContexto : DbContext
    {
        public virtual DbSet<Aluno> Alunos { get; set; }

        public virtual DbSet<Turma> Turmas { get; set; }

        public virtual DbSet<Boletim> Boletins { get; set; }
        public virtual DbSet<Materia> Materias { get; set; }
        public virtual DbSet<NotaMateria> NotaMaterias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Password=P@ssword;Persist Security Info=True;User ID=sa;Initial Catalog=EscolaDB-Audaces;Data Source=tcp:localhost,1433;encrypt=true;trustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>().ToTable("ALUNO");

            modelBuilder.Entity<Aluno>().HasKey(x => x.Id)
                                        .HasName("Pk_aluno_id");

            modelBuilder.Entity<Aluno>().Property(x => x.Id)
                                        .HasColumnName("PK_ID" )
                                        .HasColumnType("INT");

            modelBuilder.Entity<Aluno>().Property(x => x.Nome)
                                        .IsRequired()
                                        .HasColumnName("NOME")
                                        .HasColumnType("VARCHAR")
                                        .HasMaxLength(50);

            modelBuilder.Entity<Aluno>().Property(x => x.Sobrenome)
                                        .IsRequired()
                                        .HasColumnName("SOBRENOME")
                                        .HasColumnType("VARCHAR")
                                        .HasMaxLength(150);

            modelBuilder.Entity<Aluno>().Ignore(x => x.Idade);

            modelBuilder.Entity<Aluno>().Property(x => x.Email)
                                        .IsRequired()
                                        .HasColumnName("EMAIL")
                                        .HasColumnType("VARCHAR")
                                        .HasMaxLength(50);


            modelBuilder.Entity<Aluno>().HasIndex(x => x.Email)
                                        .IsUnique();

            modelBuilder.Entity<Aluno>().Property(x => x.Genero)
                                        .HasColumnName("GENERO")
                                        .HasColumnType("VARCHAR")
                                        .HasMaxLength(20);

            modelBuilder.Entity<Aluno>().Property(x => x.Telefone)
                                        .HasColumnName("TELEFONE")
                                        .HasColumnType("VARCHAR")
                                        .HasMaxLength(30);

            modelBuilder.Entity<Aluno>().Property(x => x.DataNascimento)
                                        .HasColumnName("DATA_NASCIMENTO")
                                        .HasColumnType("datetime2");


            modelBuilder.Entity<Turma>().ToTable("TURMA");

            modelBuilder.Entity<Turma>().Property(x => x.Id)
                                        .HasColumnType("int")
                                        .HasColumnName("ID");

            modelBuilder.Entity<Turma>().HasKey(x => x.Id);


            modelBuilder.Entity<Turma>().Property(x => x.Curso)
                            .HasColumnType("varchar")
                            .HasMaxLength(50)
                            .HasDefaultValue("Curso Basico")
                            .HasColumnName("CURSO");

            modelBuilder.Entity<Turma>().Property(x => x.Nome)
                            .HasColumnType("varchar")
                            .HasMaxLength(50)
                            .HasColumnName("Nome");

            modelBuilder.Entity<Turma>().HasIndex(x => x.Nome)
                                        .IsUnique();

            #region Materia
            modelBuilder.Entity<Materia>().ToTable("MATERIAS");

            modelBuilder.Entity<Materia>().HasKey(x => x.Id);

            modelBuilder.Entity<Materia>().Property(x => x.Nome)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .HasColumnName("Nome");

            modelBuilder.Entity<Materia>()
                .HasMany<NotaMateria>(x => x.NotaMateria)
                .WithOne(x => x.Materia)
                .HasForeignKey(x => x.MateriaId);
            #endregion

            #region Boletim
            modelBuilder.Entity<Boletim>().ToTable("BOLETINS");

            modelBuilder.Entity<Boletim>().HasKey(x => x.Id);

            modelBuilder.Entity<Boletim>()
                .Property(x => x.OrderDate)
                .HasColumnType("datetime2")
                .HasColumnName("order_date");

            modelBuilder.Entity<Boletim>()
                .HasOne<Aluno>(x => x.Aluno)
                .WithMany(x => x.Boletins)
                .HasForeignKey(x => x.AlunoId);
            #endregion

            #region NotaMateria
            modelBuilder.Entity<NotaMateria>().ToTable("NOTA_MATERIAS");

            modelBuilder.Entity<NotaMateria>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<NotaMateria>()
                .Property(x => x.Nota)
                .HasColumnName("NOTA")
                .HasColumnType("float");

            modelBuilder.Entity<NotaMateria>()
                .HasOne(x => x.Materia)
                .WithMany(x => x.NotaMateria)
                .HasForeignKey(x => x.MateriaId);

            modelBuilder.Entity<NotaMateria>()
                .HasOne(x => x.Boletim)
                .WithMany(x => x.NotaMaterias)
                .HasForeignKey(x => x.BoletimId);
            #endregion
        }
    }
}
