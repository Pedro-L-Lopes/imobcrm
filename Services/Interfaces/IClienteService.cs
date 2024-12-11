using imobcrm.DTOs;
using imobcrm.Models;
using imobcrm.Pagination;

namespace imobcrm.Services.Interfaces;
public interface IClienteService
{
    Task InsertClient(ClienteDTO clienteDTO);
    Task<PagedList<ClienteDTO>> GetClients(ClienteParameters clienteParameters);
    Task<ClienteDTO> GetClientDetails(string clientId);
    Task<List<ClienteDTO>> GetClientsByNameAndDocument(string term);
}
