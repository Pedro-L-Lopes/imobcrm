using AutoMapper;
using imobcrm.Context;
using imobcrm.Errors;
using imobcrm.Models;
using imobcrm.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace imobcrm.Repository;

public class ContaFixaRepository : IContaFixaRepository
{
    private readonly AppDbContext _context;
    private readonly IUnityOfWork _uof;

    public ContaFixaRepository(AppDbContext context, IUnityOfWork uof)
    {
        _context = context;
        _uof = uof;
    }

    public async Task<ContaFixa> InsertAccount(ContaFixa contaFixa)
    { 
        var exists = await _context.ContasFixas.AnyAsync(c => c.TipoConta == contaFixa.TipoConta && c.imovel.ImovelId == contaFixa.ImovelId);

        if (exists)
        {
            throw new CustomException(HttpStatusCode.BadRequest, "Esta conta fixa já está cadastrada");
        }

        // Busca o maior 'Codigo' existente e incrementa para o novo cliente
        var lastCode = await _context.ContasFixas
            .MaxAsync(c => (int?)c.Codigo) ?? 0;  // Retorna 0 se não houver clientes ainda

        contaFixa.Codigo = lastCode + 1;  // Atribui o próximo código sequencial

        _context.ContasFixas.Add(contaFixa);
        await _uof.Commit();

        return contaFixa;
    }

    public async Task<List<ContaFixa>> GetAccount(Guid imovelId)
    {
        var exists = await _context.Imoveis.AnyAsync(i => i.ImovelId == imovelId);

        if (!exists)
        {
            throw new CustomException(HttpStatusCode.BadRequest, "Imóvel inválido!");
        }

        return await _context.ContasFixas
            .Where(c => c.ImovelId == imovelId).OrderBy(c => c.TipoConta).ToListAsync();
    }
}
