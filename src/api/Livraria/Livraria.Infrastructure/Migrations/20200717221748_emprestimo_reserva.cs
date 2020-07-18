using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Livraria.Infrastructure.Migrations
{
    public partial class emprestimo_reserva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastramento",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastramento",
                table: "Livros",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastramento",
                table: "IntituicoesEnsino",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EmprestimosLivros",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Habilitado = table.Column<bool>(nullable: false),
                    DataCadastramento = table.Column<DateTime>(nullable: true),
                    UsuarioId = table.Column<int>(nullable: false),
                    LivroId = table.Column<int>(nullable: false),
                    DataDevolucao = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmprestimosLivros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmprestimosLivros_Livros_LivroId",
                        column: x => x.LivroId,
                        principalTable: "Livros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmprestimosLivros_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservasLivros",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Habilitado = table.Column<bool>(nullable: false),
                    DataCadastramento = table.Column<DateTime>(nullable: true),
                    UsuarioId = table.Column<int>(nullable: false),
                    LivroId = table.Column<int>(nullable: false),
                    DataResgate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservasLivros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservasLivros_Livros_LivroId",
                        column: x => x.LivroId,
                        principalTable: "Livros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservasLivros_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmprestimosLivros_LivroId",
                table: "EmprestimosLivros",
                column: "LivroId");

            migrationBuilder.CreateIndex(
                name: "IX_EmprestimosLivros_UsuarioId",
                table: "EmprestimosLivros",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservasLivros_LivroId",
                table: "ReservasLivros",
                column: "LivroId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservasLivros_UsuarioId",
                table: "ReservasLivros",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmprestimosLivros");

            migrationBuilder.DropTable(
                name: "ReservasLivros");

            migrationBuilder.DropColumn(
                name: "DataCadastramento",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "DataCadastramento",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "DataCadastramento",
                table: "IntituicoesEnsino");
        }
    }
}
