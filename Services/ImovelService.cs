using AutoMapper;
using imobcrm.DTOs;
using imobcrm.Errors;
using imobcrm.Models;
using imobcrm.Pagination;
using imobcrm.Repository.Interfaces;
using imobcrm.Services.Interfaces;
using System.Net;

namespace imobcrm.Services;
public class ImovelService : IImovelService
{
    private readonly IUnityOfWork _uof;
    private readonly IMapper _mapper;

    public ImovelService(IUnityOfWork uof, IMapper mapper)
    {
        _uof = uof;
        _mapper = mapper;
    }

    public async Task InsertProperty(ImovelDTO imovelDTO)
    {
        // Verifica se o cliente existe
        //var clientExists = await _uof.ClienteRepository
        //    .GetByIdAsync(imovelDTO.ProprietarioId);
        //if (clientExists == null)
        //{
        //    throw new CustomException(HttpStatusCode.NotFound, "Cliente não encontrado.");
        //}

        // Verifica se a localização existe
        //var locationExists = await _uof.LocalizacaoRepository
        //    .GetByIdAsync(imovelDTO.LocalizacaoId);
        //if (locationExists == null)
        //{
        //    throw new CustomException(HttpStatusCode.NotFound, "Localização não encontrada.");
        //}

        var property = new Imovel
        {
            ProprietarioId = imovelDTO.ProprietarioId,
            Finalidade = imovelDTO.Finalidade,
            TipoImovel = imovelDTO.TipoImovel,
            Destinacao = imovelDTO.Destinacao,
            Situacao = imovelDTO.Situacao,
            Valor = imovelDTO.Valor,
            SiteCod = imovelDTO.SiteCod,
            ValorCondominio = imovelDTO.ValorCondominio,
            Area = imovelDTO.Area,
            Observacoes = imovelDTO.Observacoes,
            Descricao = imovelDTO.Descricao,
            Quartos = imovelDTO.Quartos,
            Suites = imovelDTO.Suites,
            Banheiros = imovelDTO.Banheiros,
            SalasEstar = imovelDTO.SalasEstar,
            SalasJantar = imovelDTO.SalasJantar,
            Varanda = imovelDTO.Varanda,
            Garagem = imovelDTO.Garagem,
            Avaliacao = imovelDTO.Avaliacao,
            AvaliacaoValor = imovelDTO.AvaliacaoValor,
            DataAvaliacao = imovelDTO.DataAvaliacao,
            ComPlaca = imovelDTO.ComPlaca,
            ValorAutorizacao = imovelDTO.ValorAutorizacao,
            TipoAutorizacao = imovelDTO.TipoAutorizacao,
            DataAutorizacao = imovelDTO.DataAutorizacao,
            Rua = imovelDTO.Rua,
            Numero = imovelDTO.Numero,
            Cep = imovelDTO.Cep,
            LocalizacaoId = imovelDTO.LocalizacaoId,
            UltimaEdicao = DateTime.UtcNow
        };

        await _uof.ImovelRepository.InsertProperty(property);
    }

    public async Task<PagedList<ImovelDTO>> GetPropertys(ImovelParameters imovelParameters)
    {
        var pagedPropertys = await _uof.ImovelRepository.GetPropertys(imovelParameters);

        var clientDTOs = pagedPropertys.Items
            .Select(property => _mapper.Map<ImovelDTO>(property))
            .ToList();

        return new PagedList<ImovelDTO>(clientDTOs, pagedPropertys.TotalCount, imovelParameters.PageNumber, imovelParameters.PageSize);
    }

    public async Task<List<ImovelDTO>> SearchProperties(SearcheImovelParameters searcheImovelParameters, string term)
    {
        var propertys = await _uof.ImovelRepository.SearchProperties(searcheImovelParameters, term);
        return _mapper.Map<List<ImovelDTO>>(propertys);
    }

    public async Task ChangeStatus(string propertyId, string status)
    {
        Guid propertyIdGuid = Guid.Parse(propertyId);

        await _uof.ImovelRepository.ChangeStatus(propertyIdGuid, status);
    }

    public async Task<ImovelDTO> Getproperty(string propertyId)
    {
        Guid propertyIdGuid = Guid.Parse(propertyId);

        var property = await _uof.ImovelRepository.Getproperty(propertyIdGuid);
        return _mapper.Map<ImovelDTO>(property);
    }
}
