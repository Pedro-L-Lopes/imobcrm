using imobcrm.DTOs;
using imobcrm.DTOs.ContaFixa;
using imobcrm.Models;
using imobcrm.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace imobcrm.Controllers;

[Route("/[controller]")]
[ApiController]
public class ContaFixaController : ControllerBase
{
    private readonly IContaFixaService _contaFixaService;

    public ContaFixaController(IContaFixaService contaFixaService)
    {
        _contaFixaService = contaFixaService;
    }

    [HttpPost]
    public async Task<IActionResult> InsertAccount([FromBody] AddContaFixaDTO addContaFixaDTO)
    {
        var createdAccount = await _contaFixaService.InsertAccount(addContaFixaDTO);
        return StatusCode(StatusCodes.Status201Created, createdAccount);
    }

    [HttpGet]
    public async Task<IActionResult> GetAccounts([FromQuery] string propertyId)
    {
        var results = await _contaFixaService.GetAccount(propertyId);
        return Ok(results);
    }
}
