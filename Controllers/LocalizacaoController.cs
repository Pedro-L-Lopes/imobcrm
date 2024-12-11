using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using imobcrm.DTOs;
using imobcrm.DTOs.Locations;
using imobcrm.Services.Interfaces;
using System.Threading.Tasks;

namespace imobcrm.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class LocalizacaoController : ControllerBase
    {
        private readonly ILocalizacaoService _locationService;

        public LocalizacaoController(ILocalizacaoService locationService)
        {
            _locationService = locationService;
        }

        /// <summary>
        /// Insere uma nova localização (bairro e cidade).
        /// </summary>
        /// <param name="localizacaoDTO">Dados da localização.</param>
        /// <response code="201">Bairro-Cidade adicionado com sucesso.</response>
        /// <response code="400">Erro de validação nos dados fornecidos.</response>
        [HttpPost]
        public async Task<IActionResult> InsertLocation([FromBody] LocalizacaoDTO localizacaoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _locationService.InsertLocation(localizacaoDTO);
            return StatusCode(StatusCodes.Status201Created, "Bairro-Cidade adicionado com sucesso");
        }

        /// <summary>
        /// Pesquisa localizações por termo.
        /// </summary>
        /// <param name="term">Termo de pesquisa (bairro ou cidade).</param>
        /// <response code="200">Resultados encontrados.</response>
        /// <response code="400">Termo de pesquisa não pode ser vazio.</response>
        [HttpGet("search")]
        public async Task<IActionResult> SearchLocations([FromQuery] string term)
        {
            if (string.IsNullOrWhiteSpace(term))
            {
                return BadRequest("O termo de pesquisa não pode ser vazio.");
            }

            var results = await _locationService.GetLocations(term);
            return Ok(results);
        }
    }
}
