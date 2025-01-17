using imobcrm.DTOs;
using imobcrm.DTOs.PagamentoAluguelEditDTO;
using imobcrm.Models;

namespace imobcrm.Services.Interfaces;

public interface IPagamentoAluguelService
{
    Task<List<PagamentoAluguel>> GetPaymentsByContractId(Guid contractId);
    Task<List<PagamentoAluguel>> GeneratePayments(Guid contractId, int extraMonths);
    Task<PagamentoAluguelDTO> UpdatePayment(PagamentoAluguelEditDTO pagamentoAluguelEditDTO);
}
