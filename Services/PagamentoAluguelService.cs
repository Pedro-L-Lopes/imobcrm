using imobcrm.Errors;
using imobcrm.Models;
using imobcrm.Repository.Interfaces;
using imobcrm.Services.Interfaces;
using System.Net;

namespace imobcrm.Services;

public class PagamentoAluguelService : IPagamentoAluguelService
{
    private readonly IUnityOfWork _uof;

    public PagamentoAluguelService(IUnityOfWork uof)
    {
        _uof = uof;
    }

    public async Task<List<PagamentoAluguel>> GeneratePayments(Guid contractId, int extraMonths)
    {
        var contract = await _uof.ContratoAluguelRepository.GetContract(contractId);
        if (contract == null)
        {
            throw new CustomException(HttpStatusCode.NotFound, "Contrato não encontrado");
        }

        return await _uof.PagamentoAluguelRepository.GeneratePayments(contract, extraMonths);
    }

    public async Task<List<PagamentoAluguel>> GetPaymentsByContractId(Guid contractId)
    {
        return await _uof.PagamentoAluguelRepository.GetPaymentsByContractId(contractId);
    }
}
