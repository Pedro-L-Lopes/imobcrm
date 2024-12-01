using imobcrm.Context;
using imobcrm.Repository.Interfaces;

namespace imobcrm.Repository;
public class UnityOfWork : IUnityOfWork
{
    private IClienteRepository _clienteRepository;
    private ILocalizacaoRepository _localizacaoRepository;
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

    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
