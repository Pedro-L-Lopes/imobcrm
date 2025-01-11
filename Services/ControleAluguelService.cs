using AutoMapper;
using imobcrm.DTOs;
using imobcrm.Pagination;
using imobcrm.Repository.Interfaces;
using imobcrm.Services.Interfaces;

namespace imobcrm.Services;
public class ControleAluguelService : IControleAluguelService
{
    private readonly IUnityOfWork _uof;
    private readonly IMapper _mapper;

    public ControleAluguelService(IUnityOfWork uof, IMapper mapper)
    {
        _uof = uof;
        _mapper = mapper;
    }

    public async Task<PagedList<ControleAluguelDTO>> GetControl(ControleAluguelParameters controleAluguelParameters)
    {
        var pagedControl = await _uof.ControleAluguelRepository.GetControl(controleAluguelParameters);

        var contractDTOs = pagedControl.Items
            .Select(client => _mapper.Map<ControleAluguelDTO>(client))
            .ToList();

        return new PagedList<ControleAluguelDTO>(contractDTOs, pagedControl.TotalCount, controleAluguelParameters.PageNumber, controleAluguelParameters.PageSize);
    }
}
