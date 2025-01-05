using imobcrm.Context;
using imobcrm.Errors;
using imobcrm.Models;
using imobcrm.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace imobcrm.Repository;
public class ContaExtraRepository : IContaExtraRepository
{
    private readonly AppDbContext _context;
    private readonly IUnityOfWork _uof;

    public ContaExtraRepository(AppDbContext context, IUnityOfWork uof)
    {
        _context = context;
        _uof = uof;
    }

    public async Task<ContaExtra> InsertExtraAccount(ContaExtra contaExtra)
    {
        var exists = await _context.ContasExtras.AnyAsync(c => c.TipoConta == contaExtra.TipoConta);

        if (exists)
        {
            throw new CustomException(HttpStatusCode.BadRequest, "Já existe uma conta com este nome");
        }

        // Busca o maior 'Codigo' existente e incrementa para o novo cliente
        var lastCode = await _context.Localizacoes
            .MaxAsync(c => (int?)c.Codigo) ?? 0;  // Retorna 0 se não houver clientes ainda

        contaExtra.Codigo = lastCode + 1;  // Atribui o próximo código sequencial

        _context.ContasExtras.Add(contaExtra);
        await _uof.Commit();

        return contaExtra;
    }
}
