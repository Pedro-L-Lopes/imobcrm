using imobcrm.DTOs;
using imobcrm.Pagination;

namespace imobcrm.Services.Interfaces;

public interface IImovelService
{
    Task InsertProperty(ImovelDTO imovelDTO);
    Task<PagedList<ImovelDTO>> GetPropertys(ImovelParameters imovelParameters);
    Task<List<ImovelDTO>> SearchProperties(SearcheImovelParameters searcheImovelParameters, string term);
    Task ChangeStatus(string propertyId, string status);
    Task<ImovelDTO> Getproperty(string propertyId);
}
