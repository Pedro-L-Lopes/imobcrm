﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using imobcrm.Context;

#nullable disable

namespace imobcrm.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("imobcrm.Models.Cliente", b =>
                {
                    b.Property<Guid>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CpfCnpj")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("varchar(1)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("imobcrm.Models.ContaExtra", b =>
                {
                    b.Property<Guid>("IdContaExtra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CodigoConta")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("ContratoId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("DataPagamento")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("StatusPagamento")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("TipoConta")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("IdContaExtra");

                    b.HasIndex("ContratoId");

                    b.ToTable("ContasExtras");
                });

            modelBuilder.Entity("imobcrm.Models.ContratoAluguel", b =>
                {
                    b.Property<Guid>("ContratoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("FimContrato")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("ImovelId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("InicioContrato")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("LocadorId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("LocatarioId")
                        .HasColumnType("char(36)");

                    b.Property<decimal>("OutrosValores")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("StatusContrato")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<byte>("TempoContrato")
                        .HasColumnType("tinyint unsigned");

                    b.Property<DateTime?>("UltimaRenovacao")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("ValorCondominio")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<decimal>("ValorContrato")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<byte>("VencimentoAluguel")
                        .HasColumnType("tinyint unsigned");

                    b.HasKey("ContratoId");

                    b.HasIndex("ImovelId");

                    b.HasIndex("LocadorId");

                    b.HasIndex("LocatarioId");

                    b.ToTable("ContratosAluguel");
                });

            modelBuilder.Entity("imobcrm.Models.Imovel", b =>
                {
                    b.Property<Guid>("ImovelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<float?>("Area")
                        .HasColumnType("float");

                    b.Property<byte?>("Banheiros")
                        .HasColumnType("tinyint unsigned");

                    b.Property<DateTime?>("DataAutorizacao")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("EnderecoId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Finalidade")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<byte?>("Garagem")
                        .HasColumnType("tinyint unsigned");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Observacoes")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("ProprietarioId")
                        .HasColumnType("char(36)");

                    b.Property<byte?>("Quartos")
                        .HasColumnType("tinyint unsigned");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<byte?>("SalasEstar")
                        .HasColumnType("tinyint unsigned");

                    b.Property<byte?>("SalasJantar")
                        .HasColumnType("tinyint unsigned");

                    b.Property<int>("SiteCod")
                        .HasColumnType("int");

                    b.Property<byte?>("Suites")
                        .HasColumnType("tinyint unsigned");

                    b.Property<string>("TipoAutorizacao")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("TipoImovel")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal?>("ValorAutorizacao")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal?>("ValorCondominio")
                        .HasColumnType("decimal(10,2)");

                    b.Property<byte?>("Varanda")
                        .HasColumnType("tinyint unsigned");

                    b.HasKey("ImovelId");

                    b.HasIndex("EnderecoId");

                    b.HasIndex("ProprietarioId");

                    b.ToTable("Imoveis");
                });

            modelBuilder.Entity("imobcrm.Models.Localizacao", b =>
                {
                    b.Property<Guid>("LocalizacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("LocalizacaoId");

                    b.ToTable("Localizacoes");
                });

            modelBuilder.Entity("imobcrm.Models.PagamentoAluguel", b =>
                {
                    b.Property<Guid>("PagamentoAluguelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ContratoId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("DataPagamento")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataVencimentoAluguel")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("PeriodoFim")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("PeriodoInicio")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("StatusPagamento")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<decimal?>("ValorPago")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("PagamentoAluguelId");

                    b.HasIndex("ContratoId");

                    b.ToTable("PagamentoAlugueis");
                });

            modelBuilder.Entity("imobcrm.Models.Visita", b =>
                {
                    b.Property<Guid>("VisitaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("ClienteId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Codigo")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("ImovelId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Observacao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Situacao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("VisitaId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ImovelId");

                    b.ToTable("Visitas");
                });

            modelBuilder.Entity("imobcrm.Models.ContaExtra", b =>
                {
                    b.HasOne("imobcrm.Models.ContratoAluguel", "Contrato")
                        .WithMany()
                        .HasForeignKey("ContratoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contrato");
                });

            modelBuilder.Entity("imobcrm.Models.ContratoAluguel", b =>
                {
                    b.HasOne("imobcrm.Models.Imovel", "Imovel")
                        .WithMany()
                        .HasForeignKey("ImovelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("imobcrm.Models.Cliente", "Locador")
                        .WithMany()
                        .HasForeignKey("LocadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("imobcrm.Models.Cliente", "Locatario")
                        .WithMany()
                        .HasForeignKey("LocatarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Imovel");

                    b.Navigation("Locador");

                    b.Navigation("Locatario");
                });

            modelBuilder.Entity("imobcrm.Models.Imovel", b =>
                {
                    b.HasOne("imobcrm.Models.Localizacao", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("imobcrm.Models.Cliente", "Proprietario")
                        .WithMany()
                        .HasForeignKey("ProprietarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");

                    b.Navigation("Proprietario");
                });

            modelBuilder.Entity("imobcrm.Models.PagamentoAluguel", b =>
                {
                    b.HasOne("imobcrm.Models.ContratoAluguel", "Contrato")
                        .WithMany()
                        .HasForeignKey("ContratoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contrato");
                });

            modelBuilder.Entity("imobcrm.Models.Visita", b =>
                {
                    b.HasOne("imobcrm.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.HasOne("imobcrm.Models.Imovel", "Imovel")
                        .WithMany()
                        .HasForeignKey("ImovelId");

                    b.Navigation("Cliente");

                    b.Navigation("Imovel");
                });
#pragma warning restore 612, 618
        }
    }
}
