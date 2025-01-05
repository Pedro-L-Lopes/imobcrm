using imobcrm.DTOs;
using imobcrm.Pagination;
using imobcrm.Services;
using imobcrm.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace imobcrm.Controllers;

[Route("/[controller]")]
[ApiController]
public class ContratoAluguelController : ControllerBase
{
    private readonly IContratoAluguelService _contratoAluguelService;

    public ContratoAluguelController(IContratoAluguelService contratoAluguelService)
    {
        _contratoAluguelService = contratoAluguelService;
    }


    /// <summary>
    /// Insere um novo contrato de aluguel no banco de dados. 
    /// O método gera automaticamente o próximo código sequencial com base no maior código existente na tabela.
    /// </summary>
    /// <param name="contratoAluguel">
    /// Objeto do tipo <see cref="ContratoAluguel"/> contendo os dados do contrato a ser inserido.
    /// </param>
    /// <returns>
    /// Retorna o contrato inserido, incluindo o código sequencial gerado.
    /// </returns>
    [HttpPost]
    public async Task<IActionResult> InsertContract([FromBody] ContratoAluguelDTO contratoAluguelDTO)
    {
        await _contratoAluguelService.InsertContract(contratoAluguelDTO);

        // Retornar o contrato atualizado com os valores gerados
        return CreatedAtRoute(nameof(GetContract), new { id = contratoAluguelDTO.ContratoId }, contratoAluguelDTO);
    }



    /// <summary>
    /// Recupera uma lista paginada de contratos de aluguel com base nos parâmetros de filtragem, ordenação e paginação fornecidos.
    /// O método aplica filtros por situação do contrato, intervalo de datas e ordena os resultados conforme o parâmetro de ordenação.
    /// </summary>
    /// <param name="contratoAluguelParameters">
    /// Objeto contendo os parâmetros de filtragem, ordenação e paginação para a consulta dos contratos de aluguel.
    /// </param>
    /// <returns>
    /// Retorna uma instância de <see cref="PagedList{ContratoAluguelDTO}"/>, que contém a lista de contratos de aluguel filtrados, ordenados e paginados.
    /// </returns>
    [HttpGet]
    public async Task<IActionResult> GetContracts([FromQuery] ContratoAluguelParameters contratoAluguelParameters)
    {
        var contracts = await _contratoAluguelService.GetContracts(contratoAluguelParameters);
        return Ok(contracts);
    }

    [HttpGet("{id}", Name = "GetContract")]
    public async Task<IActionResult> GetContract(string id)
    {
        var contract = await _contratoAluguelService.GetContract(id);
        return Ok(contract);
    }
}
