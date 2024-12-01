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
            var clienteExistsWithDocument = await _context.Clientes
                .AnyAsync(c => c.CpfCnpj == cliente.CpfCnpj);

            if (clienteExistsWithDocument)
            {
                throw new CustomException(HttpStatusCode.BadRequest, "Já existe um cliente com este CPF ou CNPJ.");
            }

            _context.Clientes.Add(cliente);
            await _uof.Commit();

            return cliente;
        }

        public async Task<PagedList<Cliente>> GetClients(ClienteParameters clienteParameters)
        {
            var query = _context.Clientes.AsNoTracking();

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
