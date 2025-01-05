using AutoMapper;
using imobcrm.DTOs;
using imobcrm.DTOs.ContaFixa;
using imobcrm.Models;
using imobcrm.Repository.Interfaces;
using imobcrm.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace imobcrm.Services;

public class ContaFixaService : IContaFixaService
{
    private readonly IUnityOfWork _uof;
    private readonly IMapper _mapper;

    public ContaFixaService(IUnityOfWork uof, IMapper mapper)
    {
        _uof = uof;
        _mapper = mapper;
    }

    public async Task<ContaFixa> InsertAccount(AddContaFixaDTO addContaFixaDTO)
    {
        var account = new ContaFixa
        {
            CodigoConsulta = addContaFixaDTO.CodigoConsulta, 
            Descricao = addContaFixaDTO.Descricao,
            ImovelId = addContaFixaDTO.ImovelId,
            Status = addContaFixaDTO.Status,
            TipoConta = addContaFixaDTO.TipoConta,
            UltimaEdicao = DateTime.UtcNow,
            DataCriacao = DateTime.UtcNow,
        };

        var createdAccount = await _uof.ContaFixaRepository.InsertAccount(account);
        return createdAccount;
    }

    public async Task<List<ContaFixa>> GetAccount(string imovelId)
    {
        Guid propertyId = Guid.Parse(imovelId);

        return await _uof.ContaFixaRepository.GetAccount(propertyId);
    }
}
