using imobcrm.Context;
using imobcrm.DTOs;
using imobcrm.Errors;
using imobcrm.Models;
using imobcrm.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace imobcrm.Repository;

public class PagamentoAluguelRepository : IPagamentoAluguelRepository
{
    private readonly AppDbContext _context;
    private readonly IUnityOfWork _uof;

    public PagamentoAluguelRepository(AppDbContext context, IUnityOfWork uof)
    {
        _context = context;
        _uof = uof;
    }

    public async Task<List<PagamentoAluguel>> GetPaymentsByContractId(Guid contractId)
    {
        return await _context.PagamentoAlugueis
            .Where(p => p.ContratoId == contractId)
            .OrderBy(p => p.PeriodoInicio)
            .ToListAsync();
    }

    public async Task<List<PagamentoAluguel>> GeneratePayments(ContratoAluguelDTO contract, int extraMonths)
    {
        var pagamentos = new List<PagamentoAluguel>();

        DateTime inicio = contract.PrimeiroAluguel ?? contract.InicioContrato;
        DateTime fim = contract.FimContrato ?? inicio.AddMonths(contract.TempoContrato + extraMonths);
        DateTime periodoInicio = inicio;
        DateTime periodoFim = inicio.AddMonths(1).AddDays(-1);

        // Busca o maior 'Codigo' existente e inicia o contador para o próximo
        var lastCode = await _context.PagamentoAlugueis
            .MaxAsync(c => (int?)c.Codigo) ?? 0;

        while (periodoInicio < fim)
        {
            lastCode++; // Incrementa o código para cada novo pagamento

            pagamentos.Add(new PagamentoAluguel
            {
                PagamentoAluguelId = Guid.NewGuid(),
                ContratoId = contract.ContratoId,
                Codigo = lastCode,
                PeriodoInicio = periodoInicio,
                PeriodoFim = periodoFim,
                ReferenciaPagamento = $"{periodoInicio:MMM/yyyy}",
                DataVencimentoAluguel = new DateTime(periodoFim.Year, periodoFim.Month, contract.VencimentoAluguel),
                StatusPagamento = "Pendente"
            });

            periodoInicio = periodoFim.AddDays(1);
            periodoFim = periodoInicio.AddMonths(1).AddDays(-1);
        }

        await _context.PagamentoAlugueis.AddRangeAsync(pagamentos);
        await _uof.Commit();

        return pagamentos;
    }

}
