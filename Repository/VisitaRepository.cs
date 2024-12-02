using imobcrm.Context;
using imobcrm.DTOs;
using imobcrm.Errors;
using imobcrm.Models;
using imobcrm.Pagination;
using imobcrm.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace imobcrm.Repository;
public class VisitaRepository : IVisitaRepository
{
    private readonly AppDbContext _context;
    private readonly IUnityOfWork _uof;

    public VisitaRepository(AppDbContext context, IUnityOfWork uof)
    {
        _context = context;
        _uof = uof;
    }

    public async Task<Visita> InsertVisit(Visita visita)
    {
       

        var visitExists = await _context.Visitas.AnyAsync(v => v.DataHora == visita.DataHora);

        if (visitExists)
        {
            throw new CustomException(HttpStatusCode.BadRequest, "Já existe uma visita neste horario.");
        }

        _context.Visitas.Add(visita);
        await _uof.Commit();

        return visita;
    }

    public async Task<PagedList<VisitaDTO>> GetVisits(VisitaParameters visitaParameters)
    {
        var query = _context.Visitas
            .Include(i => i.Imovel)
            .Include(i => i.Cliente)
            .AsNoTracking();

          // Aplica o filtro de situação apenas se o parâmetro não for nulo ou vazio
        if (!string.IsNullOrWhiteSpace(visitaParameters.Situacao))
        {
            query = query.Where(i => i.Situacao.Trim().ToLower() == visitaParameters.Situacao.Trim().ToLower());
        }

        query = visitaParameters.OrderBy.ToLower() switch
        {
            "datahora" => visitaParameters.SortDirection.ToLower() == "asc"
                ? query.OrderBy(v => v.DataHora)
                : query.OrderByDescending(v => v.DataHora),
            _ => query.OrderBy(v => v.DataHora)
        };

        var totalCount = await query.CountAsync();

        var items = await query
            .Skip((visitaParameters.PageNumber - 1) * visitaParameters.PageSize)
            .Take(visitaParameters.PageSize)
            .ToListAsync();

        var visitasDTO = items.Select(v => new VisitaDTO
        {
            ClienteId = v.ClienteId,
            ClienteNome = v.Cliente.Nome,
            Codigo = v.Codigo,
            DataHora = v.DataHora,
            ImovelId = v.ImovelId,
            Observacao = v.Observacao,
            Situacao = v.Situacao
        });

        return new PagedList<VisitaDTO>(visitasDTO, totalCount, visitaParameters.PageNumber, visitaParameters.PageSize);
    }

}
