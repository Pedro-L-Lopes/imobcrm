using imobcrm.DTOs;
using imobcrm.Pagination;
using imobcrm.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace imobcrm.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ImovelController : ControllerBase
    {
        private readonly IImovelService _imovelService;

        public ImovelController(IImovelService imovelService)
        {
            _imovelService = imovelService;
        }

        /// <summary>
        /// Insere um novo imóvel no sistema.
        /// </summary>
        /// <param name="imovelDTO">Objeto que contém as informações do imóvel a ser inserido.</param>
        /// <returns>Status 201 se o imóvel for adicionado com sucesso.</returns>
        /// <response code="201">Imóvel adicionado com sucesso.</response>
        /// <response code="400">Dados inválidos fornecidos.</response>
        [HttpPost]
        public async Task<IActionResult> InsertProperty([FromBody] ImovelDTO imovelDTO)
        {
            await _imovelService.InsertProperty(imovelDTO);
            return StatusCode(StatusCodes.Status201Created, "Imóvel adicionado com sucesso");
        }

        /// <summary>
        /// Retorna uma lista de imóveis com suporte à paginação, ordenação e filtros.
        /// </summary>
        /// <param name="imovelParameters">Parâmetros de busca e paginação.</param>
        /// <returns>Uma lista de imóveis conforme os filtros aplicados.</returns>
        /// <response code="200">Lista de imóveis retornada com sucesso.</response>
        /// <response code="400">Parâmetros inválidos fornecidos.</response>
        [HttpGet]
        public async Task<IActionResult> GetPropertys([FromQuery] ImovelParameters imovelParameters)
        {
            var clients = await _imovelService.GetPropertys(imovelParameters);
            return Ok(clients);
        }
    }
}
