using imobcrm.Pagination;
using imobcrm.Services;
using imobcrm.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace imobcrm.Controllers;

[Route("/[controller]")]
[ApiController]
public class ControleAluguelController : ControllerBase
{
    private readonly IControleAluguelService _controleAluguelService;

    public ControleAluguelController(IControleAluguelService controleAluguelService)
    {
        _controleAluguelService = controleAluguelService;
    }

    /// <summary>
    /// Obtém uma lista paginada de dos alugueis para controle.
    /// </summary>
    /// <param name="controleAluguelParameters">Parâmetros de paginação e filtragem.</param>
    /// <returns>Lista de alugueis.</returns>
    /// <response code="200">Lista de alugueis obtida com sucesso.</response>
    [HttpGet]
    public async Task<IActionResult> GetClients([FromQuery] ControleAluguelParameters controleAluguelParameters)
    {
         var contracts = await _controleAluguelService.GetControl(controleAluguelParameters);
        return Ok(contracts);
    }
}
