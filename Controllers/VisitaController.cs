using imobcrm.DTOs;
using imobcrm.Pagination;
using imobcrm.Services;
using imobcrm.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace imobcrm.Controllers;

[Route("/[controller]")]
[ApiController]
public class VisitaController : ControllerBase
{
    private readonly IVisitaService _visitaService;

    public VisitaController(IVisitaService visitaService)
    {
        _visitaService = visitaService;
    }

    [HttpPost]
    public async Task<IActionResult> InsertVisit([FromBody] VisitaDTO visitaDTO)
    {
        await _visitaService.InsertVisit(visitaDTO);
        return Ok(new { message = "Visita adicionada com sucesso" });
    }

    [HttpGet]
    public async Task<IActionResult> GetVisits([FromQuery] VisitaParameters visitaParameters)
    {
        var visits = await _visitaService.GetVisits(visitaParameters);
        return Ok(visits);
    }
}
