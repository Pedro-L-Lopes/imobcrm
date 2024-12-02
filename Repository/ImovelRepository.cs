using imobcrm.Context;
using imobcrm.Models;
using imobcrm.Repository.Interfaces;

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
        _context.Imoveis.Add(imovel);
        await _uof.Commit();

        return imovel;
    }
}
