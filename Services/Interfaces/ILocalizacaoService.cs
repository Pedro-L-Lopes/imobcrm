using imobcrm.DTOs;
using imobcrm.DTOs.Locations;
using imobcrm.Models;

namespace imobcrm.Services.Interfaces;
public interface ILocalizacaoService
{
    Task InsertLocation(LocalizacaoDTO localizacaoDTO);
}
