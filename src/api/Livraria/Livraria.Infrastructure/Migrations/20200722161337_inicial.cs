﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Livraria.Infrastructure.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IntituicoesEnsino",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Habilitado = table.Column<bool>(nullable: false),
                    DataCadastramento = table.Column<DateTime>(nullable: true, defaultValueSql: "getdate()"),
                    Nome = table.Column<string>(maxLength: 200, nullable: false),
                    Endereco = table.Column<string>(maxLength: 500, nullable: false),
                    CPNJ = table.Column<string>(maxLength: 15, nullable: false),
                    Telefone = table.Column<string>(maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntituicoesEnsino", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Livros",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Habilitado = table.Column<bool>(nullable: false),
                    DataCadastramento = table.Column<DateTime>(nullable: true, defaultValueSql: "getdate()"),
                    Titulo = table.Column<string>(maxLength: 200, nullable: false),
                    Genero = table.Column<string>(maxLength: 200, nullable: false),
                    Autor = table.Column<string>(maxLength: 200, nullable: false),
                    Sinopse = table.Column<string>(maxLength: 200, nullable: true),
                    Capa = table.Column<string>(maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Habilitado = table.Column<bool>(nullable: false),
                    DataCadastramento = table.Column<DateTime>(nullable: true, defaultValueSql: "getdate()"),
                    Nome = table.Column<string>(maxLength: 200, nullable: false),
                    Endereco = table.Column<string>(maxLength: 500, nullable: true),
                    CPF = table.Column<string>(maxLength: 11, nullable: false),
                    InstituicaoEnsinoId = table.Column<int>(nullable: false),
                    Telefone = table.Column<string>(maxLength: 11, nullable: true),
                    Email = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_IntituicoesEnsino_InstituicaoEnsinoId",
                        column: x => x.InstituicaoEnsinoId,
                        principalTable: "IntituicoesEnsino",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    DataDevolucao = table.Column<DateTime>(nullable: true),
                    Devolvido = table.Column<bool>(nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_InstituicaoEnsinoId",
                table: "Usuarios",
                column: "InstituicaoEnsinoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmprestimosLivros");

            migrationBuilder.DropTable(
                name: "ReservasLivros");

            migrationBuilder.DropTable(
                name: "Livros");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "IntituicoesEnsino");
        }
    }
}
