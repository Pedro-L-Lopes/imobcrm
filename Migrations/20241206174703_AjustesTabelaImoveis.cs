using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace imobcrm.Migrations
{
    /// <inheritdoc />
    public partial class AjustesTabelaImoveis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Avaliacao",
                table: "Imoveis",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AvaliacaoValor",
                table: "Imoveis",
                type: "decimal(10)",
                nullable: true,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "ComPlaca",
                table: "Imoveis",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAvaliacao",
                table: "Imoveis",
                type: "datetime(6)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avaliacao",
                table: "Imoveis");

            migrationBuilder.DropColumn(
                name: "AvaliacaoValor",
                table: "Imoveis");

            migrationBuilder.DropColumn(
                name: "ComPlaca",
                table: "Imoveis");

            migrationBuilder.DropColumn(
                name: "DataAvaliacao",
                table: "Imoveis");

            migrationBuilder.RenameColumn(
                name: "DataCriacao",
                table: "Imoveis",
                newName: "DataCricao");
        }
    }
}
