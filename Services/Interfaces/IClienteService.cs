using imobcrm.DTOs;
using imobcrm.Pagination;

namespace imobcrm.Services.Interfaces;
public interface IClienteService
{
    Task InsertClient(ClienteDTO clienteDTO);
    Task<PagedList<ClienteDTO>> GetClients(ClienteParameters clienteParameters);
    Task<ClienteDTO> GetClientDetails(string clientId);
}
