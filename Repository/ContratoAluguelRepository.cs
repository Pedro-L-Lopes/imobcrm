using imobcrm.Context;
using imobcrm.DTOs;
using imobcrm.Models;
using imobcrm.Pagination;
using imobcrm.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace imobcrm.Repository;
public class ContratoAluguelRepository : IContratoAluguelRepository
{
    private readonly AppDbContext _context;
    private readonly IUnityOfWork _uof;

    public ContratoAluguelRepository(AppDbContext context, IUnityOfWork uof)
    {
        _context = context;
        _uof = uof;
    }

    public async Task<ContratoAluguel> InsertContract(ContratoAluguel contratoAluguel)
    {
        // Busca o maior 'Codigo' existente e incrementa para o novo contrato
        var ultimoCodigo = await _context.ContratosAluguel
            .MaxAsync(c => (int?)c.Codigo) ?? 0;  // Retorna 0 se não houver contratos ainda

        contratoAluguel.Codigo = ultimoCodigo + 1;  // Atribui o próximo código sequencial

        _context.ContratosAluguel.Add(contratoAluguel);
        await _uof.Commit();

        return contratoAluguel;
    }

    public async Task<PagedList<ContratoAluguelResumoDTO>> GetContracts(ContratoAluguelParameters contratoAluguelParameters)
    {
        var query = _context.ContratosAluguel
             .Include(v => v.Imovel)
             .ThenInclude(i => i.Localizacao)
             .Include(l => l.Locador)
             .Include(l => l.Locatario)
             .AsNoTracking();

        // Filtro por situação
        if (!string.IsNullOrWhiteSpace(contratoAluguelParameters.StatusContrato))
        {
            query = query.Where(v => v.StatusContrato.Trim().ToLower() == contratoAluguelParameters.StatusContrato.Trim().ToLower());
        }

        // Filtro por intervalo de datas
        if (contratoAluguelParameters.InicioContrato.HasValue)
        {
            query = query.Where(v => v.InicioContrato >= contratoAluguelParameters.InicioContrato.Value);
        }

        if (contratoAluguelParameters.FimContrato.HasValue)
        {
            query = query.Where(v => v.FimContrato >= contratoAluguelParameters.FimContrato.Value);
        }

        // Ordenação dinâmica
        query = contratoAluguelParameters.OrderBy.ToLower() switch
        {
            "ultimaEdicao" => contratoAluguelParameters.SortDirection.ToLower() == "asc"
                ? query.OrderBy(v => v.UltimaEdicao)
                : query.OrderByDescending(v => v.UltimaEdicao),
            "inicioContrato" => contratoAluguelParameters.SortDirection.ToLower() == "asc"
                ? query.OrderBy(v => v.InicioContrato)
                : query.OrderByDescending(v => v.InicioContrato),
            "fimContrato" => contratoAluguelParameters.SortDirection.ToLower() == "asc"
                ? query.OrderBy(v => v.FimContrato)
                : query.OrderByDescending(v => v.FimContrato),
            "codigo" => contratoAluguelParameters.SortDirection.ToLower() == "desc"
                ? query.OrderBy(v => v.Codigo)
                : query.OrderByDescending(v => v.Codigo),
            "statusContrato" => contratoAluguelParameters.SortDirection.ToLower() == "asc"
                ? query.OrderBy(v => v.StatusContrato)
                : query.OrderByDescending(v => v.StatusContrato),
            "valorContrato" => contratoAluguelParameters.SortDirection.ToLower() == "asc"
                ? query.OrderBy(v => v.ValorContrato)
                : query.OrderByDescending(v => v.ValorContrato),
            "tempoContrato" => contratoAluguelParameters.SortDirection.ToLower() == "asc"
                ? query.OrderBy(v => v.TempoContrato)
                : query.OrderByDescending(v => v.TempoContrato),
            _ => query.OrderBy(v => v.UltimaEdicao)
        };

        var totalCount = await query.CountAsync();

        var items = await query
            .Skip((contratoAluguelParameters.PageNumber - 1) * contratoAluguelParameters.PageSize)
            .Take(contratoAluguelParameters.PageSize)
            .ToListAsync();

        var contratosAluguelDTO = items.Select(c => new ContratoAluguelResumoDTO
        {
            Codigo = c.Codigo,
            ImovelId = c.ImovelId,
            LocadorId = c.LocadorId,
            LocadorNome = c.Locador?.Nome,
            LocatarioId = c.LocatarioId,
            locatarioNome = c.Locatario?.Nome,
            ValorContrato = c.ValorContrato,
            InicioContrato = c.InicioContrato,
            FimContrato = c.FimContrato,
            StatusContrato = c.StatusContrato,
            TempoContrato = c.TempoContrato,
            UltimaEdicao = c.UltimaRenovacao,
            Cep = c.Imovel.Cep,
            Rua = c.Imovel.Rua,
            Numero = c.Imovel.Numero,
            Bairro = c.Imovel.Localizacao.Bairro,
            Cidade = c.Imovel.Localizacao.Cidade,
            Estado = c.Imovel.Localizacao.Estado,
            CodigoImovel = c.Imovel.Codigo,
            TipoImovel = c.Imovel.TipoImovel,
            DataCriacao = c.DataCriacao,

        });

        return new PagedList<ContratoAluguelResumoDTO>(contratosAluguelDTO, totalCount, contratoAluguelParameters.PageNumber, contratoAluguelParameters.PageSize);
    }
}
