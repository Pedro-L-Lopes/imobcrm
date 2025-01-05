using imobcrm.DTOs;
using imobcrm.Models;
using imobcrm.Services;
using imobcrm.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace imobcrm.Controllers;

[Route("/[controller]")]
[ApiController]
public class ContaExtraController : ControllerBase
{
    private readonly IContaExtraService _contaExtraService;

    public ContaExtraController(IContaExtraService contaExtraService)
    {
        _contaExtraService = contaExtraService;
    }

    [HttpPost]
    public async Task<IActionResult> InsertExtraAccount([FromBody] ContaExtraDTO contaExtraDTO)
    {
        await _contaExtraService.InsertExtraAccount(contaExtraDTO);

        return Ok(contaExtraDTO);
        // Retornar o contrato atualizado com os valores gerados
        //return CreatedAtRoute(nameof(GetContract), new { id = contratoAluguelDTO.ContratoId }, contratoAluguelDTO);
    }
}
