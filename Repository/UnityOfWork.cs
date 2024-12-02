using imobcrm.Context;
using imobcrm.Repository.Interfaces;

namespace imobcrm.Repository;
public class UnityOfWork : IUnityOfWork
{
    private IClienteRepository _clienteRepository;
    private ILocalizacaoRepository _localizacaoRepository;
    private IImovelRepository _imovelRepository;
    private IVisitaRepository _visitaRepository;
    public AppDbContext _context;

    public UnityOfWork(AppDbContext context)
    {
        _context = context;
    }

    public IClienteRepository ClienteRepository
    {
        get
        {
            return _clienteRepository ??= new ClienteRepository(_context, this);
        }
    }

    public ILocalizacaoRepository LocalizacaoRepository
    {
        get
        {
            return _localizacaoRepository ??= new LocalizacaoRepository(_context, this);
        }
    }

    public IImovelRepository ImovelRepository
    {
        get
        {
            return _imovelRepository ??= new ImovelRepository(_context, this);
        }
    }

    public IVisitaRepository VisitaRepository
    {
        get
        {
            return _visitaRepository ??= new VisitaRepository(_context, this);
        }
    }

    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
