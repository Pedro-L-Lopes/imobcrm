using imobcrm.DTOs;
using imobcrm.Pagination;

namespace imobcrm.Repository.Interfaces;
public interface IControleAluguelRepository
{
    Task<PagedList<ControleAluguelDTO>> GetControl(ControleAluguelParameters controleAluguelParameters);
}
