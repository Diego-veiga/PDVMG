using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class ativoforma : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PagamentoVenda_FormaPagamento_IdPagamento",
                table: "PagamentoVenda");

            migrationBuilder.DropForeignKey(
                name: "FK_PagamentoVenda_Vendas_IdVenda",
                table: "PagamentoVenda");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PagamentoVenda",
                table: "PagamentoVenda");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FormaPagamento",
                table: "FormaPagamento");

            migrationBuilder.RenameTable(
                name: "PagamentoVenda",
                newName: "PagamentoVendas");

            migrationBuilder.RenameTable(
                name: "FormaPagamento",
                newName: "FormaPagamentos");

            migrationBuilder.RenameIndex(
                name: "IX_PagamentoVenda_IdVenda",
                table: "PagamentoVendas",
                newName: "IX_PagamentoVendas_IdVenda");

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "FormaPagamentos",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PagamentoVendas",
                table: "PagamentoVendas",
                columns: new[] { "IdPagamento", "IdVenda" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_FormaPagamentos",
                table: "FormaPagamentos",
                column: "IdPagamento");

            migrationBuilder.AddForeignKey(
                name: "FK_PagamentoVendas_FormaPagamentos_IdPagamento",
                table: "PagamentoVendas",
                column: "IdPagamento",
                principalTable: "FormaPagamentos",
                principalColumn: "IdPagamento",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PagamentoVendas_Vendas_IdVenda",
                table: "PagamentoVendas",
                column: "IdVenda",
                principalTable: "Vendas",
                principalColumn: "IdVenda",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PagamentoVendas_FormaPagamentos_IdPagamento",
                table: "PagamentoVendas");

            migrationBuilder.DropForeignKey(
                name: "FK_PagamentoVendas_Vendas_IdVenda",
                table: "PagamentoVendas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PagamentoVendas",
                table: "PagamentoVendas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FormaPagamentos",
                table: "FormaPagamentos");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "FormaPagamentos");

            migrationBuilder.RenameTable(
                name: "PagamentoVendas",
                newName: "PagamentoVenda");

            migrationBuilder.RenameTable(
                name: "FormaPagamentos",
                newName: "FormaPagamento");

            migrationBuilder.RenameIndex(
                name: "IX_PagamentoVendas_IdVenda",
                table: "PagamentoVenda",
                newName: "IX_PagamentoVenda_IdVenda");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PagamentoVenda",
                table: "PagamentoVenda",
                columns: new[] { "IdPagamento", "IdVenda" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_FormaPagamento",
                table: "FormaPagamento",
                column: "IdPagamento");

            migrationBuilder.AddForeignKey(
                name: "FK_PagamentoVenda_FormaPagamento_IdPagamento",
                table: "PagamentoVenda",
                column: "IdPagamento",
                principalTable: "FormaPagamento",
                principalColumn: "IdPagamento",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PagamentoVenda_Vendas_IdVenda",
                table: "PagamentoVenda",
                column: "IdVenda",
                principalTable: "Vendas",
                principalColumn: "IdVenda",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
