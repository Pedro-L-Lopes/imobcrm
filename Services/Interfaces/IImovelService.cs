using imobcrm.DTOs;
using imobcrm.Pagination;

namespace imobcrm.Services.Interfaces;

public interface IImovelService
{
    Task InsertProperty(ImovelDTO imovelDTO);
    Task<PagedList<ImovelDTO>> GetPropertys(ImovelParameters imovelParameters);
}
