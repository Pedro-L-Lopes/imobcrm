using imobcrm.DTOs;
using imobcrm.Models;
using imobcrm.Pagination;

namespace imobcrm.Repository.Interfaces;
public interface IContratoAluguelRepository
{
    Task<ContratoAluguel> InsertContract(ContratoAluguel contratoAluguel);

    Task<PagedList<ContratoAluguelResumoDTO>> GetContracts(ContratoAluguelParameters contratoAluguelParameters);
}
