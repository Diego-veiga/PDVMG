using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class adicionandoproduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProdutoCodigo",
                table: "ItemVenda",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomeProduto = table.Column<string>(maxLength: 60, nullable: false),
                    PrecoProduto = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Codigo);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemVenda_ProdutoCodigo",
                table: "ItemVenda",
                column: "ProdutoCodigo",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemVenda_Produtos_ProdutoCodigo",
                table: "ItemVenda",
                column: "ProdutoCodigo",
                principalTable: "Produtos",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemVenda_Produtos_ProdutoCodigo",
                table: "ItemVenda");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_ItemVenda_ProdutoCodigo",
                table: "ItemVenda");

            migrationBuilder.DropColumn(
                name: "ProdutoCodigo",
                table: "ItemVenda");
        }
    }
}
