using AutoMapper;
using imobcrm.DTOs;
using imobcrm.Models;
using imobcrm.Pagination;
using imobcrm.Repository.Interfaces;
using imobcrm.Services.Interfaces;

namespace imobcrm.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IUnityOfWork _uof;
        private readonly IMapper _mapper;

        public ClienteService(IUnityOfWork uof, IMapper mapper)
        {
            _uof = uof;
            _mapper = mapper;
        }

        public async Task InsertClient(ClienteDTO clienteDTO)
        {
            var client = new Cliente
            {
                Nome = clienteDTO.Nome,
                TipoCliente = clienteDTO.TipoCliente,
                Email = clienteDTO.Email,
                Telefone = clienteDTO.Telefone,
                CpfCnpj = clienteDTO.CpfCnpj,
                Sexo = clienteDTO.Sexo,
                DataNascimento = clienteDTO.DataNascimento,
                UltimaEdicao = DateTime.UtcNow
            };

            await _uof.ClienteRepository.InsertClient(client);
        }

        public async Task<PagedList<ClienteDTO>> GetClients(ClienteParameters clienteParameters)
        {
            var pagedClients = await _uof.ClienteRepository.GetClients(clienteParameters);

            var clientDTOs = pagedClients.Items
                .Select(client => _mapper.Map<ClienteDTO>(client))
                .ToList();

            return new PagedList<ClienteDTO>(clientDTOs, pagedClients.TotalCount, clienteParameters.PageNumber, clienteParameters.PageSize);
        }

        public async Task<ClienteDTO> GetClientDetails(string clientId)
        {
            Guid clientIdGuid = Guid.Parse(clientId);

            var client = await _uof.ClienteRepository.GetClientDetails(clientIdGuid);
            return _mapper.Map<ClienteDTO>(client);
        }

        public async Task<List<ClienteDTO>> GetClientsByNameAndDocument(string term)
        {
            var clients = await _uof.ClienteRepository.GetClientsByNameAndDocument(term);
            return _mapper.Map<List<ClienteDTO>>(clients);
        }
    }
}
