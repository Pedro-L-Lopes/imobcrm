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

        // Busca o maior 'Codigo' existente e incrementa para o novo cliente
        var ultimoCodigo = await _context.Visitas
            .MaxAsync(c => (int?)c.Codigo) ?? 0;  // Retorna 0 se não houver clientes ainda

        visita.Codigo = ultimoCodigo + 1;  // Atribui o próximo código sequencial

        _context.Visitas.Add(visita);
        await _uof.Commit();

        return visita;
    }

    public async Task<PagedList<VisitaDTO>> GetVisits(VisitaParameters visitaParameters)
    {
        var query = _context.Visitas
            .Include(v => v.Imovel)
            .ThenInclude(i => i.Localizacao)
            .Include(v => v.Cliente)
            .AsNoTracking();

        // Filtro por situação
        if (!string.IsNullOrWhiteSpace(visitaParameters.Situacao))
        {
            query = query.Where(v => v.Situacao.Trim().ToLower() == visitaParameters.Situacao.Trim().ToLower());
        }

        // Filtro por intervalo de datas
        if (visitaParameters.DataInicio.HasValue)
        {
            query = query.Where(v => v.DataHora >= visitaParameters.DataInicio.Value);
        }

        if (visitaParameters.DataFim.HasValue)
        {
            query = query.Where(v => v.DataHora <= visitaParameters.DataFim.Value);
        }

        // Ordenação dinâmica
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
            VisitaId = v.VisitaId,
            ClienteId = v.ClienteId,
            ClienteNome = v.Cliente.Nome,
            Codigo = v.Codigo,
            DataHora = v.DataHora,
            ImovelId = v.ImovelId,
            Observacao = v.Observacao,
            Situacao = v.Situacao,
            UltimaEdicao = v.UltimaEdicao,
            CEP = v.Imovel.Cep,
            Rua = v.Imovel.Rua,
            Bairro = v.Imovel.Localizacao.Bairro,
            Cidade = v.Imovel.Localizacao.Cidade,
            Estado = v.Imovel.Localizacao.Estado,
            ClienteEmail = v.Cliente.Email,
            ClienteTelefone = v.Cliente.Telefone,
            ClienteDocumento = v.Cliente.CpfCnpj,
            FinalidadeVisita = v.Imovel.Finalidade,
            Destincao = v.Imovel.Destinacao,
            ValorImovel = v.Imovel.Valor
        });

        return new PagedList<VisitaDTO>(visitasDTO, totalCount, visitaParameters.PageNumber, visitaParameters.PageSize);
    }



}
