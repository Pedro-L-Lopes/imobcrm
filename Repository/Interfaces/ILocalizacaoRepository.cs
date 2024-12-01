using imobcrm.Models;
using imobcrm.Pagination;

namespace imobcrm.Repository.Interfaces;
public interface ILocalizacaoRepository
{
    Task<Localizacao> InsertLocation(Localizacao localizacao);
}
