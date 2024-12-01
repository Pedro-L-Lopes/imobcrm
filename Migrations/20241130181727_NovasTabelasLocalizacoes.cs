using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace imobcrm.Migrations
{
    /// <inheritdoc />
    public partial class NovasTabelasLocalizacoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BairroCEPs",
                columns: table => new
                {
                    BairroCEPId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Cep = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Bairro = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BairroCEPs", x => x.BairroCEPId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CidadeUFs",
                columns: table => new
                {
                    CidadeUFId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Cidade = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CidadeUFs", x => x.CidadeUFId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Imoveis_BairroCepId",
                table: "Imoveis",
                column: "BairroCepId");

            migrationBuilder.CreateIndex(
                name: "IX_Imoveis_CidadeUFId",
                table: "Imoveis",
                column: "CidadeUFId");

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


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imoveis_BairroCEPs_BairroCepId",
                table: "Imoveis");

            migrationBuilder.DropForeignKey(
                name: "FK_Imoveis_CidadeUFs_CidadeUFId",
                table: "Imoveis");

            migrationBuilder.DropTable(
                name: "BairroCEPs");

            migrationBuilder.DropTable(
                name: "CidadeUFs");

            migrationBuilder.DropIndex(
                name: "IX_Imoveis_BairroCepId",
                table: "Imoveis");

            migrationBuilder.DropIndex(
                name: "IX_Imoveis_CidadeUFId",
                table: "Imoveis");

            migrationBuilder.DropColumn(
                name: "BairroCepId",
                table: "Imoveis");

            migrationBuilder.DropColumn(
                name: "CidadeUFId",
                table: "Imoveis");
        }
    }
}
