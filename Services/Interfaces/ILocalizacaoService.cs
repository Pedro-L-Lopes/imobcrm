using imobcrm.DTOs;
using imobcrm.Models;

namespace imobcrm.Services.Interfaces;
public interface ILocalizacaoService
{
    Task InsertLocation(LocalizacaoDTO localizacaoDTO);
    Task<List<Localizacao>> GetLocationsByOneTerm(string term);
    Task<List<Localizacao>> GetLocations(string term);
}
