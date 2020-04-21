using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class pagamentovenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PagamentoVenda",
                columns: table => new
                {
                    IdVenda = table.Column<int>(nullable: false),
                    IdPagamento = table.Column<int>(nullable: false),
                    DataPagamento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagamentoVenda", x => new { x.IdPagamento, x.IdVenda });
                    table.ForeignKey(
                        name: "FK_PagamentoVenda_FormaPagamento_IdPagamento",
                        column: x => x.IdPagamento,
                        principalTable: "FormaPagamento",
                        principalColumn: "IdPagamento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PagamentoVenda_Vendas_IdVenda",
                        column: x => x.IdVenda,
                        principalTable: "Vendas",
                        principalColumn: "IdVenda",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PagamentoVenda_IdVenda",
                table: "PagamentoVenda",
                column: "IdVenda");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PagamentoVenda");
        }
    }
}
