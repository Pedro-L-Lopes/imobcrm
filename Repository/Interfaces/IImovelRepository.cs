using imobcrm.DTOs;
using imobcrm.Models;
using imobcrm.Pagination;

namespace imobcrm.Repository.Interfaces;
public interface IImovelRepository
{
    Task<Imovel> InsertProperty(Imovel imovel);
    Task<PagedList<ImovelDTO>> GetPropertys(ImovelParameters imovelParameters);
    Task<List<ImovelDTO>> SearchProperties(SearcheImovelParameters searcheImovelParameters, string term);
}
