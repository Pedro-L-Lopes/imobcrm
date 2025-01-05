using imobcrm.DTOs;
using imobcrm.Models;
using imobcrm.Pagination;

namespace imobcrm.Services.Interfaces;
public interface IContratoAluguelService
{
    Task InsertContract(ContratoAluguelDTO contratoAluguelDTO);
    Task<PagedList<ContratoAluguelResumoDTO>> GetContracts(ContratoAluguelParameters contratoAluguelParameters);
    Task<ContratoAluguelDTO> GetContract(string contractId);
}
