using imobcrm.DTOs;
using imobcrm.DTOs.PagamentoAluguelEditDTO;
using imobcrm.Models;

namespace imobcrm.Repository.Interfaces;
public interface IPagamentoAluguelRepository
{
    Task<List<PagamentoAluguel>> GetPaymentsByContractId(Guid contractId);
    Task<List<PagamentoAluguel>> GeneratePayments(ContratoAluguelDTO contract, int extraMonths);
    Task<PagamentoAluguelDTO> UpdatePayment(PagamentoAluguelEditDTO pagamentoAluguelEditDTO);
}
