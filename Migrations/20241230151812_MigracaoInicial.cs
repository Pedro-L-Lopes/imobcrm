using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace imobcrm.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TipoCliente = table.Column<string>(type: "varchar(25)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(100)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefone = table.Column<string>(type: "varchar(25)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CpfCnpj = table.Column<string>(type: "varchar(25)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Sexo = table.Column<string>(type: "varchar(1)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataNascimento = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UltimaEdicao = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Localizacoes",
                columns: table => new
                {
                    LocalizacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(100)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cidade = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UltimaEdicao = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localizacoes", x => x.LocalizacaoId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Imoveis",
                columns: table => new
                {
                    ImovelId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    ProprietarioId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Finalidade = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Destinacao = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoImovel = table.Column<string>(type: "varchar(30)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Situacao = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Valor = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    SiteCod = table.Column<string>(type: "varchar(20)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ValorCondominio = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Area = table.Column<float>(type: "float", nullable: true),
                    Observacoes = table.Column<string>(type: "varchar(1000)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "varchar(1000)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Quartos = table.Column<byte>(type: "tinyint unsigned", nullable: true),
                    Suites = table.Column<byte>(type: "tinyint unsigned", nullable: true),
                    Banheiros = table.Column<byte>(type: "tinyint unsigned", nullable: true),
                    SalasEstar = table.Column<byte>(type: "tinyint unsigned", nullable: true),
                    SalasJantar = table.Column<byte>(type: "tinyint unsigned", nullable: true),
                    Varanda = table.Column<byte>(type: "tinyint unsigned", nullable: true),
                    Garagem = table.Column<byte>(type: "tinyint unsigned", nullable: true),
                    Avaliacao = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    AvaliacaoValor = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    DataAvaliacao = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ComPlaca = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    ValorAutorizacao = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    TipoAutorizacao = table.Column<string>(type: "varchar(30)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataAutorizacao = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Rua = table.Column<string>(type: "varchar(100)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Numero = table.Column<string>(type: "varchar(50)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cep = table.Column<string>(type: "varchar(15)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UltimaEdicao = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LocalizacaoId = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UltimaPubliRedes = table.Column<DateTime>(type: "datetime(6)", nullable: true)

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imoveis", x => x.ImovelId);
                    table.ForeignKey(
                        name: "FK_Imoveis_Clientes_ProprietarioId",
                        column: x => x.ProprietarioId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Imoveis_Localizacoes_LocalizacaoId",
                        column: x => x.LocalizacaoId,
                        principalTable: "Localizacoes",
                        principalColumn: "LocalizacaoId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ContratosAluguel",
                columns: table => new
                {
                    ContratoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    ImovelId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    LocadorId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    LocatarioId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ValorContrato = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ValorCondominio = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    InicioContrato = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FimContrato = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PrimeiroAluguel = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    VencimentoAluguel = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    StatusContrato = table.Column<string>(type: "varchar(30)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DestinacaoContrato = table.Column<string>(type: "varchar(30)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TempoContrato = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    TaxaAdm = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    TaxaIntermediacao = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Rescisao = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SemMultaApos = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AnotacoesGerais = table.Column<string>(type: "varchar(1000)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataRescisao = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UltimaRenovacao = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UltimaEdicao = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratosAluguel", x => x.ContratoId);
                    table.ForeignKey(
                        name: "FK_ContratosAluguel_Clientes_LocadorId",
                        column: x => x.LocadorId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContratosAluguel_Clientes_LocatarioId",
                        column: x => x.LocatarioId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContratosAluguel_Imoveis_ImovelId",
                        column: x => x.ImovelId,
                        principalTable: "Imoveis",
                        principalColumn: "ImovelId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Visitas",
                columns: table => new
                {
                        VisitaId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                        DataHora = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                        Situacao = table.Column<string>(type: "varchar(25)", nullable: false)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        Codigo = table.Column<int>(type: "int", nullable: false),
                        ClienteId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                        ImovelId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                        Observacao = table.Column<string>(type: "varchar(500)", nullable: true)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        UltimaEdicao = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitas", x => x.VisitaId);
                    table.ForeignKey(
                        name: "FK_Visitas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Visitas_Imoveis_ImovelId",
                        column: x => x.ImovelId,
                        principalTable: "Imoveis",
                        principalColumn: "ImovelId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ContasExtras",
                columns: table => new
                {
                    IdContaExtra = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    ContratoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TipoConta = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoConta = table.Column<string>(type: "varchar(50)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataVencimento = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    StatusPagamento = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Valor = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    Observacoes = table.Column<string>(type: "varchar(500)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Recorrente = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    DataPagamento = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UltimaEdicao = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ContratoAluguelContratoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasExtras", x => x.IdContaExtra);
                    table.ForeignKey(
                        name: "FK_ContasExtras_ContratosAluguel_ContratoAluguelContratoId",
                        column: x => x.ContratoAluguelContratoId,
                        principalTable: "ContratosAluguel",
                        principalColumn: "ContratoId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PagamentoAlugueis",
                columns: table => new
                {
                    PagamentoAluguelId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    ContratoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PeriodoInicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PeriodoFim = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ValorPago = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    StatusPagamento = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataVencimentoAluguel = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UltimaEdicao = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagamentoAlugueis", x => x.PagamentoAluguelId);
                    table.ForeignKey(
                        name: "FK_PagamentoAlugueis_ContratosAluguel_ContratoId",
                        column: x => x.ContratoId,
                        principalTable: "ContratosAluguel",
                        principalColumn: "ContratoId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ContasExtras_ContratoAluguelContratoId",
                table: "ContasExtras",
                column: "ContratoAluguelContratoId");

            migrationBuilder.CreateIndex(
                name: "IX_ContratosAluguel_ImovelId",
                table: "ContratosAluguel",
                column: "ImovelId");

            migrationBuilder.CreateIndex(
                name: "IX_ContratosAluguel_LocadorId",
                table: "ContratosAluguel",
                column: "LocadorId");

            migrationBuilder.CreateIndex(
                name: "IX_ContratosAluguel_LocatarioId",
                table: "ContratosAluguel",
                column: "LocatarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Imoveis_LocalizacaoId",
                table: "Imoveis",
                column: "LocalizacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Imoveis_ProprietarioId",
                table: "Imoveis",
                column: "ProprietarioId");

            migrationBuilder.CreateIndex(
                name: "IX_PagamentoAlugueis_ContratoId",
                table: "PagamentoAlugueis",
                column: "ContratoId");

            migrationBuilder.CreateIndex(
                name: "IX_Visitas_ClienteId",
                table: "Visitas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Visitas_ImovelId",
                table: "Visitas",
                column: "ImovelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContasExtras");

            migrationBuilder.DropTable(
                name: "PagamentoAlugueis");

            migrationBuilder.DropTable(
                name: "Visitas");

            migrationBuilder.DropTable(
                name: "ContratosAluguel");

            migrationBuilder.DropTable(
                name: "Imoveis");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Localizacoes");
        }
    }
}
