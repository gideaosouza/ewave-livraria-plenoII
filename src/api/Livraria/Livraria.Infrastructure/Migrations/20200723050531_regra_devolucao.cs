using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Livraria.Infrastructure.Migrations
{
    public partial class regra_devolucao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataDevolvido",
                table: "EmprestimosLivros",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataDevolvido",
                table: "EmprestimosLivros");
        }
    }
}
