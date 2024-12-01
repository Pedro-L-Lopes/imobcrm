using imobcrm.DTOs;
using imobcrm.DTOs.Locations;
using imobcrm.Services;
using imobcrm.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace imobcrm.Controllers;

[Route("/[controller]")]
[ApiController]
public class LocalizacaoController : ControllerBase
{
    private readonly ILocalizacaoService _locationService;

    public LocalizacaoController(ILocalizacaoService locationService)
    {
        _locationService = locationService;
    }

    [HttpPost]
    public async Task<IActionResult> InsertLocation([FromBody] LocalizacaoDTO localizacaoDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _locationService.InsertLocation(localizacaoDTO);
        return StatusCode(StatusCodes.Status201Created, "Bairro-Cidade adicioado com sucesso");
    }

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
