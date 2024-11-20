using imobcrm.Context;
using imobcrm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imobcrm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClienteController(AppDbContext context)
        {
            _context = context;
        }

        // Método para obter apenas os nomes dos clientes
        [HttpGet("nomes")]
        public async Task<ActionResult<IEnumerable<string>>> GetClientNames()
        {
            try
            {
                var nomes = await _context.Clientes
                    .Select(c => c.Nome)
                    .ToListAsync();

                if (nomes == null || !nomes.Any())
                {
                    return NotFound("Nenhum cliente encontrado.");
                }

                return Ok(nomes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }
    }
}
