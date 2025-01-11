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
        var payments = await _context.PagamentoAlugueis
            .Where(p => p.ContratoId == contractId)
            .OrderBy(p => p.PeriodoInicio)
            .ToListAsync();

        DateTime today = DateTime.Now;
        bool modifications = false;

        foreach (var payment in payments)
        {
            if (payment.DataVencimentoAluguel < today && payment.StatusPagamento == "Pendente")
            {
                payment.StatusPagamento = "Em atraso";
                modifications = true;
            }
        }

        if (modifications)
        {
            await _context.SaveChangesAsync();
        }

        return payments;
    }


    public async Task<List<PagamentoAluguel>> GeneratePayments(ContratoAluguelDTO contract, int extraMonths)
    {
        var payments = new List<PagamentoAluguel>();

        // Início do contrato
        DateTime contractStart = contract.InicioContrato;
        DateTime contractEnd = contract.FimContrato ?? contractStart.AddMonths(contract.TempoContrato + extraMonths);

        // Data do primeiro aluguel (caso definida), caso contrário, início do contrato
        DateTime firstPaymentDate = contract.PrimeiroAluguel ?? contractStart;

        // Define o primeiro período
        DateTime periodStart = contractStart;
        DateTime periodEnd = periodStart.AddMonths(1).AddDays(-1);

        // Código incremental
        var lastCode = await _context.PagamentoAlugueis
            .MaxAsync(c => (int?)c.Codigo) ?? 0;

        bool firstPaymentDone = false;
        DateTime today = DateTime.Now;

        while (periodStart < contractEnd)
        {
            lastCode++;

            // Ajusta o período fim para ser exatamente 1 mês a partir da data de início
            periodEnd = periodStart.AddMonths(1).AddDays(-1);
            if (periodEnd > contractEnd) periodEnd = contractEnd;

            // Calcula o vencimento do aluguel
            DateTime dueDate;
            if (!firstPaymentDone && contract.PrimeiroAluguel != null)
            {
                // Primeiro pagamento na data definida
                dueDate = firstPaymentDate;
                firstPaymentDone = true;
            }
            else
            {
                // Pagamentos subsequentes no dia do vencimento especificado
                int dueDay = Math.Min(contract.VencimentoAluguel, DateTime.DaysInMonth(periodStart.Year, periodStart.Month));
                dueDate = new DateTime(periodStart.Year, periodStart.Month, dueDay);
            }

            // Define o status do pagamento com base na data de vencimento
            string paymentStatus = dueDate < today ? "Em atraso" : "Pendente";

            payments.Add(new PagamentoAluguel
            {
                PagamentoAluguelId = Guid.NewGuid(),
                ContratoId = contract.ContratoId,
                Codigo = lastCode,
                PeriodoInicio = periodStart,
                PeriodoFim = periodEnd,
                ReferenciaPagamento = $"{periodStart:MMM/yyyy}",
                DataVencimentoAluguel = dueDate,
                StatusPagamento = paymentStatus
            });

            // Próximo período
            periodStart = periodEnd.AddDays(1);
        }

        await _context.PagamentoAlugueis.AddRangeAsync(payments);
        await _uof.Commit();

        return payments;
    }
}
