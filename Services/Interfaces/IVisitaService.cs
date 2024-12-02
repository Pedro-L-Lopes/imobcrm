using imobcrm.DTOs;
using imobcrm.Pagination;

namespace imobcrm.Services.Interfaces;
public interface IVisitaService
{
    Task InsertVisit(VisitaDTO visitaDTO);
    Task<PagedList<VisitaDTO>> GetVisits(VisitaParameters visitaParameters);
}
