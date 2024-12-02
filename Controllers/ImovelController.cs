using imobcrm.DTOs;
using imobcrm.Pagination;
using imobcrm.Services;
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

        [HttpPost]
        public async Task<IActionResult> InsertProperty([FromBody] ImovelDTO imovelDTO)
        {
            await _imovelService.InsertProperty(imovelDTO);
            return StatusCode(StatusCodes.Status201Created, "Imóvel adicionado com sucesso");
        }

        [HttpGet]
        public async Task<IActionResult> GetPropertys([FromQuery] ImovelParameters imovelParameters)
        {
            var clients = await _imovelService.GetPropertys(imovelParameters);
            return Ok(clients);
        }
    }
}
