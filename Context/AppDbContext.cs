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
}
