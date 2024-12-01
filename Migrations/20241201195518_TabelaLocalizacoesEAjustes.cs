using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace imobcrm.Migrations
{
    /// <inheritdoc />
    public partial class TabelaLocalizacoesEAjustes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imoveis_BairroCEPs_BairroCepId",
                table: "Imoveis");

            migrationBuilder.DropForeignKey(
                name: "FK_Imoveis_CidadeUFs_CidadeUFId",
                table: "Imoveis");

            migrationBuilder.DropIndex(
                name: "IX_Imoveis_BairroCepId",
                table: "Imoveis");

            migrationBuilder.DropColumn(
                name: "BairroCepId",
                table: "Imoveis");

            migrationBuilder.RenameColumn(
                name: "CidadeUFId",
                table: "Imoveis",
                newName: "LocalizacaoId");

            migrationBuilder.RenameIndex(
                name: "IX_Imoveis_CidadeUFId",
                table: "Imoveis",
                newName: "IX_Imoveis_LocalizacaoId");

            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "Imoveis",
                type: "varchar(15)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Localizacoes",
                columns: table => new
                {
                    LocalizacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Bairro = table.Column<string>(type: "varchar(50)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cidade = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<string>(type: "varchar(35)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localizacoes", x => x.LocalizacaoId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Imoveis_Localizacoes_LocalizacaoId",
                table: "Imoveis",
                column: "LocalizacaoId",
                principalTable: "Localizacoes",
                principalColumn: "LocalizacaoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imoveis_Localizacoes_LocalizacaoId",
                table: "Imoveis");

            migrationBuilder.DropTable(
                name: "Localizacoes");

            migrationBuilder.DropColumn(
                name: "Cep",
                table: "Imoveis");

            migrationBuilder.RenameColumn(
                name: "LocalizacaoId",
                table: "Imoveis",
                newName: "CidadeUFId");

            migrationBuilder.RenameIndex(
                name: "IX_Imoveis_LocalizacaoId",
                table: "Imoveis",
                newName: "IX_Imoveis_CidadeUFId");

            migrationBuilder.AddColumn<int>(
                name: "BairroCepId",
                table: "Imoveis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Imoveis_BairroCepId",
                table: "Imoveis",
                column: "BairroCepId");

            migrationBuilder.AddForeignKey(
                name: "FK_Imoveis_BairroCEPs_BairroCepId",
                table: "Imoveis",
                column: "BairroCepId",
                principalTable: "BairroCEPs",
                principalColumn: "BairroCEPId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Imoveis_CidadeUFs_CidadeUFId",
                table: "Imoveis",
                column: "CidadeUFId",
                principalTable: "CidadeUFs",
                principalColumn: "CidadeUFId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
