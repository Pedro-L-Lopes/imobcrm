using imobcrm.DTOs;
using imobcrm.Pagination;
using imobcrm.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public async Task<IActionResult> InsertClient([FromBody] ClienteDTO clienteDTO)
        {
            await _clienteService.InsertClient(clienteDTO);
            return StatusCode(StatusCodes.Status201Created, "Cliente adicionado com sucesso");
        }

        [HttpGet]
        public async Task<IActionResult> GetClients([FromQuery] ClienteParameters clienteParameters)
        {
            var clients = await _clienteService.GetClients(clienteParameters);
            return Ok(clients);
        }

        [HttpGet("{id}/detalhes")]
        public async Task<IActionResult> GetClientDetails(string id)
        {
            try
            {
                var clientDetails = await _clienteService.GetClientDetails(id);
                return Ok(clientDetails);
            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { status = "Error", message = $"Erro interno do servidor: {ex.Message}" });
            }
        }
    }
}
