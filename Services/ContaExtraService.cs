using AutoMapper;
using imobcrm.DTOs;
using imobcrm.Models;
using imobcrm.Repository.Interfaces;
using imobcrm.Services.Interfaces;

namespace imobcrm.Services;
public class ContaExtraService : IContaExtraService
{
    private readonly IUnityOfWork _uof;
    private readonly IMapper _mapper;

    public ContaExtraService(IUnityOfWork uof, IMapper mapper)
    {
        _uof = uof;
        _mapper = mapper;
    }

    public async Task InsertExtraAccount(ContaExtraDTO contaExtraDTO)
    {
        var extraAccount = new ContaExtra
        {
            TipoConta = contaExtraDTO.TipoConta,
            CodigoConta = contaExtraDTO.CodigoConta,
            Valor = contaExtraDTO.Valor,
            DataVencimento = contaExtraDTO.DataVencimento,
            DataPagamento = contaExtraDTO.DataPagamento,
            Observacoes = contaExtraDTO.Observacoes,
            Recorrente = contaExtraDTO.Recorrente,
            StatusPagamento = contaExtraDTO.StatusPagamento,
            UltimaEdicao = DateTime.UtcNow,
            ContratoId = contaExtraDTO.ContratoId,
            
        };

        await _uof.ContaExtraRepository.InsertExtraAccount(extraAccount);
    }
}
