using imobcrm.DTOs.PagamentoAluguelEditDTO;
using imobcrm.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace imobcrm.Controllers;

[Route("/[controller]")]
[ApiController]
public class PagamentoAluguelController : ControllerBase
{
    private readonly IPagamentoAluguelService _pagamentoService;

    public PagamentoAluguelController(IPagamentoAluguelService pagamentoService)
    {
        _pagamentoService = pagamentoService;
    }

    [HttpPost("gerar")]
    public async Task<IActionResult> GeneratePayments(Guid contractId, int extraMonths = 0)
    {
        var pagamentos = await _pagamentoService.GeneratePayments(contractId, extraMonths);
        return Created("Periodos gerados com sucesso!", pagamentos);
    }

    [HttpGet]
    public async Task<IActionResult> GetPaymentsByContractId(Guid contractId)
    {
        var pagamentos = await _pagamentoService.GetPaymentsByContractId(contractId);
        return Ok(pagamentos);
    }

    [HttpPatch("atualizar")]
    public async Task<IActionResult> UpdatePayments([FromBody] PagamentoAluguelEditDTO pagamentoAluguelEditDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var updatedPayment = await _pagamentoService.UpdatePayment(pagamentoAluguelEditDTO);

        return Ok(new
        {
            message = "Pagamento atualizado com sucesso",
            data = updatedPayment
        });
    }

}
