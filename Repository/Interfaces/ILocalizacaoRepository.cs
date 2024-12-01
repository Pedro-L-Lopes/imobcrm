using imobcrm.Models;
using imobcrm.Pagination;

namespace imobcrm.Repository.Interfaces;
public interface ILocalizacaoRepository
{
    Task<Localizacao> InsertLocation(Localizacao localizacao);
    Task<List<Localizacao>> GetLocations(string bairroTerm, string cidadeTerm);
}
