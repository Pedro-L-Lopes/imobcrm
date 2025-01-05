namespace imobcrm.Repository.Interfaces;
public interface IUnityOfWork
{
    IClienteRepository ClienteRepository { get; }
    ILocalizacaoRepository LocalizacaoRepository { get; }
    IImovelRepository ImovelRepository { get; }
    IVisitaRepository VisitaRepository{ get; }
    IContratoAluguelRepository ContratoAluguelRepository { get; }
    IContaExtraRepository ContaExtraRepository { get; }
    IContaFixaRepository ContaFixaRepository { get; }
    IPagamentoAluguelRepository PagamentoAluguelRepository { get; }
    Task Commit();
}
