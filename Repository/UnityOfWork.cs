using imobcrm.Context;
using imobcrm.Repository.Interfaces;

namespace imobcrm.Repository;
public class UnityOfWork : IUnityOfWork
{
    private IClienteRepository _clienteRepository;
    private ILocalizacaoRepository _localizacaoRepository;
    private IImovelRepository _imovelRepository;
    private IVisitaRepository _visitaRepository;
    private IContratoAluguelRepository _contratoAluguelRepository;
    private IContaExtraRepository _contaExtraRepository;
    private IContaFixaRepository _contaFixaRepository;
    private IPagamentoAluguelRepository _pagamentoAluguelRepository;
    private IControleAluguelRepository _controleAluguelRepository;

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

    public IContratoAluguelRepository ContratoAluguelRepository
    {
        get
        {
            return _contratoAluguelRepository ??= new ContratoAluguelRepository(_context, this);
        }
    }

    public IContaExtraRepository ContaExtraRepository
    {
        get
        {
            return _contaExtraRepository ??= new ContaExtraRepository(_context, this);
        }
    }

    public IContaFixaRepository ContaFixaRepository
    {
        get
        {
            return _contaFixaRepository ??= new ContaFixaRepository(_context, this);
        }
    }

    public IPagamentoAluguelRepository PagamentoAluguelRepository
    {
        get
        {
            return _pagamentoAluguelRepository ??= new PagamentoAluguelRepository(_context, this);
        }
    }
    
    public IControleAluguelRepository ControleAluguelRepository
    {
        get
        {
            return _controleAluguelRepository ??= new ControleAluguelRepository(_context, this);
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
