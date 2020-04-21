using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class ajustevenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemVenda",
                table: "ItemVenda");

            migrationBuilder.DropIndex(
                name: "IX_ItemVenda_ProdutoCodigo",
                table: "ItemVenda");

            migrationBuilder.DropIndex(
                name: "IX_ItemVenda_VendaIdVenda",
                table: "ItemVenda");

            migrationBuilder.DropColumn(
                name: "IdItemVenda",
                table: "ItemVenda");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemVenda",
                table: "ItemVenda",
                columns: new[] { "VendaIdVenda", "ProdutoCodigo" });

            migrationBuilder.CreateIndex(
                name: "IX_ItemVenda_ProdutoCodigo",
                table: "ItemVenda",
                column: "ProdutoCodigo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemVenda",
                table: "ItemVenda");

            migrationBuilder.DropIndex(
                name: "IX_ItemVenda_ProdutoCodigo",
                table: "ItemVenda");

            migrationBuilder.AddColumn<int>(
                name: "IdItemVenda",
                table: "ItemVenda",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemVenda",
                table: "ItemVenda",
                column: "IdItemVenda");

            migrationBuilder.CreateIndex(
                name: "IX_ItemVenda_ProdutoCodigo",
                table: "ItemVenda",
                column: "ProdutoCodigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemVenda_VendaIdVenda",
                table: "ItemVenda",
                column: "VendaIdVenda");
        }
    }
}
