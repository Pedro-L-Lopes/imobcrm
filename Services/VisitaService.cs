using AutoMapper;
using imobcrm.DTOs;
using imobcrm.Models;
using imobcrm.Pagination;
using imobcrm.Repository.Interfaces;
using imobcrm.Services.Interfaces;

namespace imobcrm.Services;
public class VisitaService : IVisitaService
{
    private readonly IUnityOfWork _uof;
    private readonly IMapper _mapper;

    public VisitaService(IUnityOfWork uof, IMapper mapper)
    {
        _uof = uof;
        _mapper = mapper;
    }

    public async Task InsertVisit(VisitaDTO visitaDTO)
    {
        var visit = new Visita
        {
            ClienteId = visitaDTO.ClienteId,
            Codigo = visitaDTO.Codigo,
            DataHora = visitaDTO.DataHora,
            ImovelId = visitaDTO.ImovelId,
            Observacao = visitaDTO.Observacao,
            Situacao = visitaDTO.Situacao,
        };

        await _uof.VisitaRepository.InsertVisit(visit);
    }

    public async Task<PagedList<VisitaDTO>> GetVisits(VisitaParameters visitaParameters)
    {
        var pagedVisits = await _uof.VisitaRepository.GetVisits(visitaParameters);

        var visitasDTO = pagedVisits.Items
            .Select(client => _mapper.Map<VisitaDTO>(client))
            .ToList();

        return new PagedList<VisitaDTO>(visitasDTO, pagedVisits.TotalCount, visitaParameters.PageNumber, visitaParameters.PageSize);
    }
}
