using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Escola.API.Migrations
{
    /// <inheritdoc />
    public partial class criartabelaboletimnotamateriaemateria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "AlunoTB",
                newName: "ALUNO");

            migrationBuilder.RenameIndex(
                name: "IX_AlunoTB_EMAIL",
                table: "ALUNO",
                newName: "IX_ALUNO_EMAIL");

            migrationBuilder.CreateTable(
                name: "BOLETINS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlunoId = table.Column<int>(type: "INT", nullable: false),
                    order_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOLETINS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BOLETINS_ALUNO_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "ALUNO",
                        principalColumn: "PK_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MATERIAS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MATERIAS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NOTA_MATERIAS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOTA = table.Column<double>(type: "float", nullable: false),
                    BoletimId = table.Column<int>(type: "int", nullable: false),
                    MateriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NOTA_MATERIAS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NOTA_MATERIAS_BOLETINS_BoletimId",
                        column: x => x.BoletimId,
                        principalTable: "BOLETINS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NOTA_MATERIAS_MATERIAS_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "MATERIAS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BOLETINS_AlunoId",
                table: "BOLETINS",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_NOTA_MATERIAS_BoletimId",
                table: "NOTA_MATERIAS",
                column: "BoletimId");

            migrationBuilder.CreateIndex(
                name: "IX_NOTA_MATERIAS_MateriaId",
                table: "NOTA_MATERIAS",
                column: "MateriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NOTA_MATERIAS");

            migrationBuilder.DropTable(
                name: "BOLETINS");

            migrationBuilder.DropTable(
                name: "MATERIAS");

            migrationBuilder.RenameTable(
                name: "ALUNO",
                newName: "AlunoTB");

            migrationBuilder.RenameIndex(
                name: "IX_ALUNO_EMAIL",
                table: "AlunoTB",
                newName: "IX_AlunoTB_EMAIL");
        }
    }
}
