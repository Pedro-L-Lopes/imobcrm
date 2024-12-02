using imobcrm.DTOs;
using imobcrm.Models;
using imobcrm.Pagination;

namespace imobcrm.Repository.Interfaces;
public interface IVisitaRepository
{
    Task<Visita> InsertVisit(Visita visita);
    Task<PagedList<VisitaDTO>> GetVisits(VisitaParameters visitaParameters);
}
