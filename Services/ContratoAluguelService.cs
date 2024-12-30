using AutoMapper;
using imobcrm.DTOs;
using imobcrm.Models;
using imobcrm.Pagination;
using imobcrm.Repository.Interfaces;
using imobcrm.Services.Interfaces;

namespace imobcrm.Services;
public class ContratoAluguelService : IContratoAluguelService
{
    private readonly IUnityOfWork _uof;
    private readonly IMapper _mapper;

    public ContratoAluguelService(IUnityOfWork uof, IMapper mapper)
    {
        _uof = uof;
        _mapper = mapper;
    }

    public async Task InsertContract(ContratoAluguelDTO contratoAluguelDTO)
    {
        var contract = new ContratoAluguel
        {
            ImovelId = contratoAluguelDTO.ImovelId,
            LocadorId = contratoAluguelDTO.LocadorId,
            LocatarioId = contratoAluguelDTO.LocatarioId,
            InicioContrato = contratoAluguelDTO.InicioContrato,
            FimContrato = contratoAluguelDTO.FimContrato,
            TempoContrato = contratoAluguelDTO.TempoContrato,
            StatusContrato = contratoAluguelDTO.StatusContrato,
            UltimaRenovacao = DateTime.UtcNow,
            ValorContrato = contratoAluguelDTO.ValorContrato,
            VencimentoAluguel = contratoAluguelDTO.VencimentoAluguel,
            ValorCondominio = contratoAluguelDTO.ValorCondominio,
            UltimaEdicao = DateTime.UtcNow,
        };

        await _uof.ContratoAluguelRepository.InsertContract(contract);
    }

    public async Task<PagedList<ContratoAluguelResumoDTO>> GetContracts(ContratoAluguelParameters contratoAluguelParameters)
    {
        var pagedContracts = await _uof.ContratoAluguelRepository.GetContracts(contratoAluguelParameters);

        var contratosDTO = pagedContracts.Items
            .Select(client => _mapper.Map<ContratoAluguelResumoDTO>(client))
            .ToList();

        return new PagedList<ContratoAluguelResumoDTO>(contratosDTO, pagedContracts.TotalCount, contratoAluguelParameters.PageNumber, contratoAluguelParameters.PageSize);
    }
}
