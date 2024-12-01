using imobcrm.DTOs;
using imobcrm.Models;
using imobcrm.Pagination;

namespace imobcrm.Repository.Interfaces;
public interface IClienteRepository
{
    Task<Cliente> InsertClient(Cliente cliente);
    Task<PagedList<Cliente>> GetClients(ClienteParameters clienteParameters);
    Task<ClienteDTO> GetClientDetails(Guid clientId);
}
