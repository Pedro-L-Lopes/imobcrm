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
            throw new CustomException(HttpStatusCode.BadRequest, "Este bairro-cidade já está cadastrado");
        }

        _context.Localizacoes.Add(localizacao);
        await _uof.Commit();

        return localizacao;
    }
}
