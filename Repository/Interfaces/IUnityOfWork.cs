namespace imobcrm.Repository.Interfaces;
public interface IUnityOfWork
{
    IClienteRepository ClienteRepository { get; }
    ILocalizacaoRepository LocalizacaoRepository { get; }
    Task Commit();
}
