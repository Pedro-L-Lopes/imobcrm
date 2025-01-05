using imobcrm.DTOs;
using imobcrm.Models;

namespace imobcrm.Services.Interfaces;

public interface IContaExtraService
{
    Task InsertExtraAccount(ContaExtraDTO contaExtraDTO);
}
