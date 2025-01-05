using imobcrm.DTOs;
using imobcrm.Models;

namespace imobcrm.Repository.Interfaces;
public interface IContaExtraRepository
{
    Task<ContaExtra> InsertExtraAccount(ContaExtra contaExtra);
}
