﻿using imobcrm.Context;
using imobcrm.DTOs;
using imobcrm.Models;
using imobcrm.Pagination;
using imobcrm.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        Console.WriteLine(imovel.Codigo);
        Console.WriteLine(ultimoCodigo + 1);

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
            Destinação = i.Destinacao,
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



}
