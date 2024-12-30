using imobcrm.Context;
using imobcrm.DTOs;
using imobcrm.Models;
using imobcrm.Pagination;
using imobcrm.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace imobcrm.Repository;
public class ImovelRepository : IImovelRepository
{
    private readonly AppDbContext _context;
    private readonly IUnityOfWork _uof;

    public ImovelRepository(AppDbContext context, IUnityOfWork uof)
    {
        _context = context;
        _uof = uof;
    }

    public async Task<Imovel> InsertProperty(Imovel imovel)
    {
        // Busca o maior 'Codigo' existente e incrementa para o novo cliente
        var ultimoCodigo = await _context.Imoveis
            .MaxAsync(c => (int?)c.Codigo) ?? 0;  // Retorna 0 se não houver clientes ainda

        imovel.Codigo = ultimoCodigo + 1;  // Atribui o próximo código sequencial

        _context.Imoveis.Add(imovel);
        await _uof.Commit();

        return imovel;
    }

    public async Task<PagedList<ImovelDTO>> GetPropertys(ImovelParameters imovelParameters)
    {
        var query = _context.Imoveis
            .Include(i => i.Localizacao) // Incluir a navegação Localizacao
            .Include(i => i.Proprietario) // Incluir a navegação Proprietario
            .AsNoTracking();

        if (!string.IsNullOrEmpty(imovelParameters.Finalidade))
        {
            query = query.Where(i => i.Finalidade.ToLower() == imovelParameters.Finalidade.ToLower());
        }

        if (!string.IsNullOrEmpty(imovelParameters.TipoImovel))
        {
            query = query.Where(i => i.TipoImovel.ToLower() == imovelParameters.TipoImovel.ToLower());
        }

        if (!string.IsNullOrEmpty(imovelParameters.Situacao))
        {
            query = query.Where(i => i.Situacao.ToLower() == imovelParameters.Situacao.ToLower());
        }

        if (!string.IsNullOrEmpty(imovelParameters.Cidade))
        {
            query = query.Where(i => i.Localizacao.Cidade.ToLower() == imovelParameters.Cidade.ToLower());
        }
        
        if (!string.IsNullOrEmpty(imovelParameters.Bairro))
        {
            query = query.Where(i => i.Localizacao.Bairro.ToLower() == imovelParameters.Bairro.ToLower());
        }

        if (imovelParameters.Avaliacao.HasValue)
        {
            query = query.Where(i => i.Avaliacao == imovelParameters.Avaliacao.Value);
        }

        if (imovelParameters.ComPlaca.HasValue)
        {
            query = query.Where(i => i.ComPlaca == imovelParameters.ComPlaca.Value);
        }

        if (!string.IsNullOrEmpty(imovelParameters.TipoAutorizacao))
        {
            query = query.Where(i => i.TipoAutorizacao.ToLower() == imovelParameters.TipoAutorizacao.ToLower());
        }

        // Aplicando ordenação dinâmica
        query = imovelParameters.OrderBy.ToLower() switch
        {
            "ultimaedicao" => imovelParameters.SortDirection.ToLower() == "asc"
                        ? query.OrderBy(c => c.UltimaEdicao)
                        : query.OrderByDescending(c => c.UltimaEdicao),
            "cep" => imovelParameters.SortDirection.ToLower() == "asc"
                        ? query.OrderBy(c => c.Cep)
                        : query.OrderByDescending(c => c.Cep),
            "valor" => imovelParameters.SortDirection.ToLower() == "asc"
                        ? query.OrderBy(c => c.Valor)
                        : query.OrderByDescending(c => c.Valor),
            "area" => imovelParameters.SortDirection.ToLower() == "asc"
                        ? query.OrderBy(c => c.Area)
                        : query.OrderByDescending(c => c.Area),
            "bairro" => imovelParameters.SortDirection.ToLower() == "asc"
                        ? query.OrderBy(c => c.Localizacao.Bairro)
                        : query.OrderByDescending(c => c.Localizacao.Bairro),
            "cidade" => imovelParameters.SortDirection.ToLower() == "asc"
                        ? query.OrderBy(c => c.Localizacao.Cidade)
                        : query.OrderByDescending(c => c.Localizacao.Cidade),
            "proprietario" => imovelParameters.SortDirection.ToLower() == "asc"
                        ? query.OrderBy(c => c.Proprietario)
                        : query.OrderByDescending(c => c.Proprietario),

            "codigo" => imovelParameters.SortDirection.ToLower() == "asc"
                            ? query.OrderBy(c => c.Codigo)
                            : query.OrderByDescending(c => c.Codigo),
            _ => query.OrderBy(c => c.UltimaEdicao)
        };

        var totalCount = await query.CountAsync();

        var items = await query
            .Skip((imovelParameters.PageNumber - 1) * imovelParameters.PageSize)
            .Take(imovelParameters.PageSize)
            .ToListAsync();

        var imovelDTOs = items.Select(i => new ImovelDTO
        {
            ImovelId = i.ImovelId,
            Codigo = i.Codigo,
            ProprietarioId = i.ProprietarioId,
            Finalidade = i.Finalidade,
            Destinacao = i.Destinacao,
            TipoImovel = i.TipoImovel,
            Situacao = i.Situacao,
            Valor = i.Valor,
            SiteCod = i.SiteCod,
            ValorCondominio = i.ValorCondominio,
            Area = i.Area,
            Observacoes = i.Observacoes,
            Descricao = i.Descricao,
            Quartos = i.Quartos,
            Suites = i.Suites,
            Banheiros = i.Banheiros,
            SalasEstar = i.SalasEstar,
            SalasJantar = i.SalasJantar,
            Varanda = i.Varanda,
            Garagem = i.Garagem,
            Avaliacao = i.Avaliacao,
            AvaliacaoValor = i.AvaliacaoValor,
            DataAvaliacao = i.DataAvaliacao,
            ComPlaca = i.ComPlaca,
            ValorAutorizacao = i.ValorAutorizacao,
            TipoAutorizacao = i.TipoAutorizacao,
            DataAutorizacao = i.DataAutorizacao,
            Rua = i.Rua,
            Numero = i.Numero,
            Cep = i.Cep,
            DataCriacao = i.DataCriacao,
            LocalizacaoId = i.LocalizacaoId,
            Bairro = i.Localizacao?.Bairro,
            Cidade = i.Localizacao?.Cidade,
            Estado = i.Localizacao?.Estado,
            ProprietarioNome = i.Proprietario?.Nome,
            UltimaEdicao = i.UltimaEdicao
        }).ToList();

        return new PagedList<ImovelDTO>(imovelDTOs, totalCount, imovelParameters.PageNumber, imovelParameters.PageSize);
    }

    public async Task<List<ImovelDTO>> SearchProperties(SearcheImovelParameters searcheImovelParameters, string term)
    {
        // Verifica se o termo de busca é numérico
        bool isNumeric = int.TryParse(term, out int termAsInt);

        // Base da consulta com relacionamentos incluídos
        var query = _context.Imoveis
            .Include(i => i.Localizacao) // Inclui a navegação Localizacao
            .Include(i => i.Proprietario) // Inclui a navegação Proprietario
            .AsNoTracking();

        // Filtra por Finalidade, se fornecida
        if (!string.IsNullOrEmpty(searcheImovelParameters.Finalidade))
        {
            string finalidadeLower = searcheImovelParameters.Finalidade.ToLower();
            query = query.Where(i => i.Finalidade.ToLower() == finalidadeLower);
        }
        
        if (!string.IsNullOrEmpty(searcheImovelParameters.Situacao))
        {
            string SituacaoLower = searcheImovelParameters.Situacao.ToLower();
            query = query.Where(i => i.Situacao.ToLower() == SituacaoLower);
        }

        // Filtra por termo de busca
        query = query.Where(i =>
            i.Rua.Contains(term) ||
            i.Cep.Contains(term) ||
            i.Localizacao.Bairro.Contains(term) ||
            i.Localizacao.Cidade.Contains(term) ||
            i.Proprietario.Nome.Contains(term) ||
            (isNumeric && i.Codigo == termAsInt)
        );

        // Ordena a consulta
        query = query.OrderBy(i => i.Codigo).ThenBy(i => i.Rua);

        // Projeta os resultados na estrutura ImovelDTO
        var properties = await query
            .Select(i => new ImovelDTO
            {
                Codigo = i.Codigo,
                ImovelId = i.ImovelId,
                ProprietarioId = i.ProprietarioId,
                ProprietarioNome  = i.Proprietario!.Nome,
                Numero = i.Numero,
                Rua = i.Rua,
                Bairro = i.Localizacao.Bairro,
                Cidade = i.Localizacao.Cidade,
                Estado = i.Localizacao.Estado,
                Cep = i.Cep,
                Destinacao = i.Destinacao,
                Finalidade = i.Finalidade,
                TipoImovel = i.TipoImovel,
                Valor = i.Valor,
                ValorCondominio = i.ValorCondominio,
            })
            .Take(50) // Limita o número de resultados
            .ToListAsync();

        return properties;
    }
}
