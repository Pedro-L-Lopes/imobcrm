using imobcrm.Models;
using Microsoft.EntityFrameworkCore;

namespace imobcrm.Context;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Imovel> Imoveis { get; set; }
    public DbSet<Localizacao> Localizacoes { get; set; }
    public DbSet<Visita> Visitas { get; set; }
    public DbSet<ContratoAluguel> ContratosAluguel { get; set; }
    public DbSet<PagamentoAluguel> PagamentoAlugueis { get; set; }
    public DbSet<ContaExtra> ContasExtras { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Cliente>()
               .HasKey(c => c.ClienteId);
        modelBuilder.Entity<Cliente>()
            .Property(c => c.ClienteId)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<ContaExtra>()
               .HasKey(ce => ce.IdContaExtra);
        modelBuilder.Entity<ContaExtra>()
            .Property(ce => ce.IdContaExtra)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<ContratoAluguel>()
               .HasKey(ca => ca.ContratoId);
        modelBuilder.Entity<ContratoAluguel>()
            .Property(ca => ca.ContratoId)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Imovel>()
               .HasKey(i => i.ImovelId);
        modelBuilder.Entity<Imovel>()
            .Property(i => i.ImovelId)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Localizacao>()
               .HasKey(l => l.LocalizacaoId);
        modelBuilder.Entity<Localizacao>()
            .Property(l => l.LocalizacaoId)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<PagamentoAluguel>()
               .HasKey(pa => pa.PagamentoAluguelId);
        modelBuilder.Entity<PagamentoAluguel>()
            .Property(pa => pa.PagamentoAluguelId)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Visita>()
               .HasKey(v => v.VisitaId);
        modelBuilder.Entity<Visita>()
            .Property(v => v.VisitaId)
            .ValueGeneratedOnAdd();
    }
}
