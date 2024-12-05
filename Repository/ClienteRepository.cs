using imobcrm.Context;
using imobcrm.DTOs;
using imobcrm.Errors;
using imobcrm.Models;
using imobcrm.Pagination;
using imobcrm.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace imobcrm.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;
        private readonly IUnityOfWork _uof;

        public ClienteRepository(AppDbContext context, IUnityOfWork uof)
        {
            _context = context;
            _uof = uof;
        }

        public async Task<Cliente> InsertClient(Cliente cliente)
        {
            // Verifica se já existe um cliente com o CPF ou CNPJ
            var clienteExistsWithDocument = await _context.Clientes
                .AnyAsync(c => c.CpfCnpj == cliente.CpfCnpj);

            if (clienteExistsWithDocument)
            {
                throw new CustomException(HttpStatusCode.BadRequest, "Já existe um cliente com este CPF ou CNPJ.");
            }

            // Busca o maior 'Codigo' existente e incrementa para o novo cliente
            var ultimoCodigo = await _context.Clientes
                .MaxAsync(c => (int?)c.Codigo) ?? 0;  // Retorna 0 se não houver clientes ainda

            cliente.Codigo = ultimoCodigo + 1;  // Atribui o próximo código sequencial

            _context.Clientes.Add(cliente);
            await _uof.Commit();  // Commit da transação

            return cliente;
        }


        public async Task<PagedList<Cliente>> GetClients(ClienteParameters clienteParameters)
        {
            var query = _context.Clientes.AsNoTracking();

            // Aplicando filtro de pesquisa
            if (!string.IsNullOrWhiteSpace(clienteParameters.SearchTerm))
            {
                string searchTerm = clienteParameters.SearchTerm.ToLower();
                query = query.Where(c =>
                    c.Nome.ToLower().Contains(searchTerm) ||
                    c.Email.ToLower().Contains(searchTerm) ||
                    c.CpfCnpj.ToLower().Contains(searchTerm));
            }

            // Aplicando ordenação dinâmica
            query = clienteParameters.OrderBy.ToLower() switch
            {
                "nome" => clienteParameters.SortDirection.ToLower() == "asc"
                            ? query.OrderBy(c => c.Nome)
                            : query.OrderByDescending(c => c.Nome),

                "tipocliente" => clienteParameters.SortDirection.ToLower() == "asc"
                            ? query.OrderBy(c => c.TipoCliente)
                            : query.OrderByDescending(c => c.TipoCliente),

                "sexo" => clienteParameters.SortDirection.ToLower() == "asc"
                            ? query.OrderBy(c => c.Sexo)
                            : query.OrderByDescending(c => c.Sexo),

                _ => query.OrderBy(c => c.Nome) // Ordenação padrão
            };

            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((clienteParameters.PageNumber - 1) * clienteParameters.PageSize)
                .Take(clienteParameters.PageSize)
                .ToListAsync();

            return new PagedList<Cliente>(items, totalCount, clienteParameters.PageNumber, clienteParameters.PageSize);
        }

        public async Task<ClienteDTO> GetClientDetails(Guid clientId)
        {
            var client = await _context.Clientes
                .Where(c => c.ClienteId == clientId)
                .Select(c => new ClienteDTO
                {
                    ClienteId = c.ClienteId,
                    Nome = c.Nome,
                    Email = c.Email,
                    Telefone = c.Telefone,
                    TipoCliente = c.TipoCliente,
                    CpfCnpj = c.CpfCnpj,
                    Sexo = c.Sexo,
                    DataNascimento = c.DataNascimento,
                }).FirstOrDefaultAsync();

            return client!;
        }
    }
}
