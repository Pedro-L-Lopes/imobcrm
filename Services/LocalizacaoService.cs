using AutoMapper;
using imobcrm.DTOs;
using imobcrm.DTOs.Locations;
using imobcrm.Models;
using imobcrm.Repository.Interfaces;
using imobcrm.Services.Interfaces;

namespace imobcrm.Services;
public class LocalizacaoService : ILocalizacaoService
{
    private readonly IUnityOfWork _uof;
    private readonly IMapper _mapper;

    public LocalizacaoService(IUnityOfWork uof, IMapper mapper)
    {
        _uof = uof;
        _mapper = mapper;
    }

    public async Task InsertLocation(LocalizacaoDTO localizacaoDTO)
    {
        var location = new Localizacao
        {
            Bairro = localizacaoDTO.Bairro,
            Cidade = localizacaoDTO.Cidade,
            Estado = localizacaoDTO.Estado,
        };

        await _uof.LocalizacaoRepository.InsertLocation(location);
    }
}
