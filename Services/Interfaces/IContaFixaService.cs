using imobcrm.DTOs;
using imobcrm.DTOs.ContaFixa;
using imobcrm.Models;

namespace imobcrm.Services.Interfaces;
public interface IContaFixaService
{
    Task<ContaFixa> InsertAccount(AddContaFixaDTO addContaFixaDTO);
    Task<List<ContaFixa>> GetAccount(string imovelId);
}
