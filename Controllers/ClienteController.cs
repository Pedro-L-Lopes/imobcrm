using imobcrm.DTOs;
using imobcrm.Errors;
using imobcrm.Pagination;
using imobcrm.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace imobcrm.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        /// <summary>
        /// Insere um novo cliente.
        /// </summary>
        /// <param name="clienteDTO">Dados do cliente a ser inserido.</param>
        /// <returns>Mensagem de sucesso.</returns>
        /// <response code="200">Cliente adicionado com sucesso.</response>
        /// <response code="400">Erro de validação nos dados do cliente.</response>
        [HttpPost]
        public async Task<IActionResult> InsertClient([FromBody] ClienteDTO clienteDTO)
        {
            await _clienteService.InsertClient(clienteDTO);
            return Ok(new { message = "Cliente adicionado com sucesso" });
        }

        /// <summary>
        /// Obtém uma lista paginada de clientes.
        /// </summary>
        /// <param name="clienteParameters">Parâmetros de paginação e filtragem.</param>
        /// <returns>Lista de clientes.</returns>
        /// <response code="200">Lista de clientes obtida com sucesso.</response>
        [HttpGet]
        public async Task<IActionResult> GetClients([FromQuery] ClienteParameters clienteParameters)
        {
            var clients = await _clienteService.GetClients(clienteParameters);
            return Ok(clients);
        }

        /// <summary>
        /// Obtém os detalhes de um cliente específico.
        /// </summary>
        /// <param name="id">ID do cliente.</param>
        /// <returns>Detalhes do cliente.</returns>
        /// <response code="200">Cliente encontrado.</response>
        /// <response code="404">Cliente não encontrado.</response>
        [HttpGet("{id}/detalhes")]
        public async Task<IActionResult> GetClientDetails(string id)
        {
            try
            {
                var clientDetails = await _clienteService.GetClientDetails(id);
                return Ok(clientDetails);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { status = "Error", message = $"Erro interno do servidor: {ex.Message}" });
            }
        }

        /// <summary>
        /// Pesquisa clientes por nome ou documento.
        /// </summary>
        /// <param name="term">Termo de busca (nome ou CPF/CNPJ).</param>
        /// <returns>Lista de clientes correspondentes.</returns>
        /// <response code="200">Clientes encontrados com sucesso.</response>
        /// <response code="400">Termo de busca inválido.</response>
        [HttpGet("search")]
        public async Task<IActionResult> GetClientsByNameAndDocument([FromQuery] string term)
        {
            if (string.IsNullOrWhiteSpace(term))
                throw new CustomException(HttpStatusCode.BadRequest, "O termo de busca não pode estar vazio.");

            var clients = await _clienteService.GetClientsByNameAndDocument(term);
            return Ok(clients);
        }
    }
}