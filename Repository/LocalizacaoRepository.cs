using imobcrm.Context;
using imobcrm.Errors;
using imobcrm.Models;
using imobcrm.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace imobcrm.Repository;
public class LocalizacaoRepository : ILocalizacaoRepository
{

    private readonly AppDbContext _context;
    private readonly IUnityOfWork _uof;

    public LocalizacaoRepository(AppDbContext context, IUnityOfWork uof)
    {
        _context = context;
        _uof = uof;
    }

    public async Task<Localizacao> InsertLocation(Localizacao localizacao)
    {
        var exists = await _context.Localizacoes.AnyAsync(l => l.Cidade == localizacao.Cidade && l.Bairro == localizacao.Bairro);

        if (exists)
        {
            throw new CustomException(HttpStatusCode.BadRequest, "Esta localização já está cadastrada");
        }

        // Busca o maior 'Codigo' existente e incrementa para o novo cliente
        var lastCode = await _context.Localizacoes
            .MaxAsync(c => (int?)c.Codigo) ?? 0;  // Retorna 0 se não houver clientes ainda

        localizacao.Codigo = lastCode + 1;  // Atribui o próximo código sequencial

        _context.Localizacoes.Add(localizacao);
        await _uof.Commit();

        return localizacao;
    }

    public async Task<List<Localizacao>> GetLocationsByOneTerm(string term)
    {
        return await _context.Localizacoes
            .Where(l => l.Bairro.ToLower().Contains(term.ToLower()) || l.Cidade.ToLower().Contains(term.ToLower()))
            .OrderBy(l => l.Cidade)
            .ThenBy(l => l.Bairro)
            .Take(50)
            .ToListAsync();
    }

    public async Task<List<Localizacao>> GetLocations(string bairroTerm, string cidadeTerm)
    {
        return await _context.Localizacoes
            .Where(l =>
                (string.IsNullOrEmpty(bairroTerm) || l.Bairro.ToLower().Contains(bairroTerm)) &&
                (string.IsNullOrEmpty(cidadeTerm) || l.Cidade.ToLower().Contains(cidadeTerm)))
            .OrderBy(l => l.Cidade)
            .ThenBy(l => l.Bairro)
            .Take(50)
            .ToListAsync();
    }
}
