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
        /// Insere uma nova localização (bairro, cidade e estado).
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
            return Ok(new { message = "Localização adicionada com sucesso"});
        }

        /// <summary>
        /// Pesquisa localizações por termo em um unico campo .
        /// </summary>
        /// <param name="term">Termo de pesquisa em um unico campo (bairro ou cidade).</param>
        /// <response code="200">Resultados encontrados.</response>
        /// <response code="400">Termo de pesquisa não pode ser vazio.</response>
        [HttpGet("search1")]
        public async Task<IActionResult> SearchLocationsByOneTerm([FromQuery] string term)
        {
            if (string.IsNullOrWhiteSpace(term))
            {
                return BadRequest("O termo de pesquisa não pode ser vazio.");
            }

            var results = await _locationService.GetLocationsByOneTerm(term);
            return Ok(results);
        }

        /// <summary>
        /// Pesquisa localizações por termo em dois campos.
        /// </summary>
        /// <param name="term">Termo de pesquisa em dois campos (bairro ou cidade) separado por -
        /// Exemplo Centro-São Paulo
        /// 
        /// .</param>
        /// <response code="200">Resultados encontrados.</response>
        /// <response code="400">Termo de pesquisa não pode ser vazio.</response>
        [HttpGet("search2")]
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
