using imobcrm.DTOs;
using imobcrm.Pagination;

namespace imobcrm.Services.Interfaces;
public interface IControleAluguelService
{
    Task<PagedList<ControleAluguelDTO>> GetControl(ControleAluguelParameters controleAluguelParameters);
}
