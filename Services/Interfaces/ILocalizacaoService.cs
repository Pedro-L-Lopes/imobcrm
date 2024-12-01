using imobcrm.DTOs;
using imobcrm.Models;

namespace imobcrm.Services.Interfaces;
public interface ILocalizacaoService
{
    Task InsertLocation(LocalizacaoDTO localizacaoDTO);
    Task<List<Localizacao>> GetLocations(string term);
}
