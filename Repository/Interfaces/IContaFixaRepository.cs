using imobcrm.Models;

namespace imobcrm.Repository.Interfaces;
public interface IContaFixaRepository
{
    Task<ContaFixa> InsertAccount(ContaFixa contaFixa);
    Task<List<ContaFixa>> GetAccount(Guid imovelId);
}
