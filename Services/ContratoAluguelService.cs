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
    private readonly IPagamentoAluguelService _pagamentoAluguelService;

    public ContratoAluguelService(IUnityOfWork uof, IMapper mapper, IPagamentoAluguelService pagamentoAluguelService)
    {
        _uof = uof;
        _mapper = mapper;
        _pagamentoAluguelService = pagamentoAluguelService;
    }

    public async Task InsertContract(ContratoAluguelDTO contratoAluguelDTO)
    {
        // Mapeia o DTO para o modelo de domínio
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
            AnotacoesGerais = contratoAluguelDTO.AnotacoesGerais,
            DestinacaoContrato = contratoAluguelDTO.DestinacaoContrato,
            PrimeiroAluguel = contratoAluguelDTO.PrimeiroAluguel,
            Rescisao = contratoAluguelDTO.Rescisao,
            SemMultaApos = contratoAluguelDTO.SemMultaApos,
            TaxaAdm = contratoAluguelDTO.TaxaAdm,
            TaxaIntermediacao = contratoAluguelDTO.TaxaIntermediacao,
        };

        // Persistir no banco
        var savedContract = await _uof.ContratoAluguelRepository.InsertContract(contract);

        // Gerar pagamentos automaticamente
        await _pagamentoAluguelService.GeneratePayments(savedContract.ContratoId, 0);

        // Atualiza os campos gerados no DTO para retorno
        contratoAluguelDTO.ContratoId = savedContract.ContratoId;
        contratoAluguelDTO.Codigo = savedContract.Codigo;
    }



    public async Task<PagedList<ContratoAluguelResumoDTO>> GetContracts(ContratoAluguelParameters contratoAluguelParameters)
    {
        var pagedContracts = await _uof.ContratoAluguelRepository.GetContracts(contratoAluguelParameters);

        var contratosDTO = pagedContracts.Items
            .Select(c => _mapper.Map<ContratoAluguelResumoDTO>(c))
            .ToList();

        return new PagedList<ContratoAluguelResumoDTO>(contratosDTO, pagedContracts.TotalCount, contratoAluguelParameters.PageNumber, contratoAluguelParameters.PageSize);
    }

    public async Task<ContratoAluguelDTO> GetContract(string contractId)
    {
        Guid contractIdGuid = Guid.Parse(contractId);

        var contract = await _uof.ContratoAluguelRepository.GetContract(contractIdGuid);
        return _mapper.Map<ContratoAluguelDTO>(contract);
    }
}
