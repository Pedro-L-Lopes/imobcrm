using imobcrm.Context;
using imobcrm.DTOs;
using imobcrm.Models;
using imobcrm.Pagination;
using imobcrm.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace imobcrm.Repository;
public class ControleAluguelRepository : IControleAluguelRepository
{
    private readonly AppDbContext _context;
    private readonly IUnityOfWork _uof;

    public ControleAluguelRepository(AppDbContext context, IUnityOfWork uof)
    {
        _context = context;
        _uof = uof;
    }

    public async Task<PagedList<ControleAluguelDTO>> GetControl(ControleAluguelParameters parameters)
    {
        var today = DateTime.Today;

        // Obter contas fixas fora do loop principal
        var fixedAccounts = await _context.ContasFixas.AsNoTracking().ToListAsync();

        // Obter contratos com pagamentos e incluir dados relacionados
        var contracts = await _context.ContratosAluguel
            .Include(c => c.Imovel)
                .ThenInclude(i => i.Localizacao)
            .Include(c => c.Locador)
            .Include(c => c.Locatario)
            .AsNoTracking()
            .ToListAsync();

        // Obter pagamentos do período atual
        var payments = await _context.PagamentoAlugueis
            .AsNoTracking()
            .Where(p => p.PeriodoInicio <= today && p.PeriodoFim >= today)
            .ToListAsync();

        // Criar a lista de DTOs
        var rentControlDTOs = contracts.Select(contract =>
        {
            var payment = payments.FirstOrDefault(p => p.ContratoId == contract.ContratoId);
            return MapToControleAluguelDTO(payment, contract, fixedAccounts);
        }).ToList();

        // Ordenação
        if (!string.IsNullOrEmpty(parameters.OrderBy))
        {
            rentControlDTOs = parameters.OrderBy.ToLower() switch
            {
                "vencimentoaluguel" => parameters.SortDirection?.ToLower() == "desc"
                    ? rentControlDTOs.OrderByDescending(dto => dto.DiaVencimento).ToList()
                    : rentControlDTOs.OrderBy(dto => dto.DiaVencimento).ToList(),
                "valorcontrato" => parameters.SortDirection?.ToLower() == "desc"
                    ? rentControlDTOs.OrderByDescending(dto => dto.ValorAluguel).ToList()
                    : rentControlDTOs.OrderBy(dto => dto.ValorAluguel).ToList(),
                _ => rentControlDTOs
            };
        }

        // Paginação
        var totalCount = rentControlDTOs.Count;
        var pagedItems = rentControlDTOs
            .Skip((parameters.PageNumber - 1) * parameters.PageSize)
            .Take(parameters.PageSize)
            .ToList();

        return new PagedList<ControleAluguelDTO>(pagedItems, totalCount, parameters.PageNumber, parameters.PageSize);
    }

    // Método auxiliar para mapear o DTO
    private ControleAluguelDTO MapToControleAluguelDTO(PagamentoAluguel pagamento, ContratoAluguel contrato, List<ContaFixa> contasFixas)
    {
        var imovel = contrato.Imovel;
        var localizacao = imovel.Localizacao;

        var luz = contasFixas.FirstOrDefault(cf => cf.ImovelId == imovel.ImovelId && cf.TipoConta.Contains("Energia"));
        var agua = contasFixas.FirstOrDefault(cf => cf.ImovelId == imovel.ImovelId && cf.TipoConta.Contains("Água"));
        var iptu = contasFixas.FirstOrDefault(cf => cf.ImovelId == imovel.ImovelId && cf.TipoConta.Contains("IPTU"));
        var condominio = contasFixas.FirstOrDefault(cf => cf.ImovelId == imovel.ImovelId && cf.TipoConta.Contains("Condomínio"));

        return new ControleAluguelDTO
        {
            ContratoAluguelId = contrato.ContratoId,
            ImovelId = contrato.ImovelId,
            CodigoImovel = imovel.Codigo,
            EnderecoImovel = string.Format("{0}, {1} - {2}, {3}-{4}", imovel.Rua, imovel.Numero, localizacao.Bairro, localizacao.Cidade, localizacao.Estado),
            CodigoLocador = contrato.Locador.Codigo,
            NomeLocador = contrato.Locador.Nome,
            CodigoLocatario = contrato.Locatario.Codigo,
            NomeLocatario = contrato.Locatario.Nome,
            Periodo = pagamento != null
                ? string.Format("{0:dd/MM/yyyy} - {1:dd/MM/yyyy}", pagamento.PeriodoInicio, pagamento.PeriodoFim)
                : "Não há pagamentos no período",
            DiaVencimento = contrato.VencimentoAluguel,
            ValorAluguel = contrato.ValorContrato,
            StatusPagamento = pagamento?.StatusPagamento ?? "pendente",

            // Dados de contas fixas
            CodigoLuz = luz?.Codigo,
            CodigoConsultaLuz = luz?.CodigoConsulta,
            StatusLuz = luz?.Status,

            CodigoAgua = agua?.Codigo,
            CodigoConsultaAgua = agua?.CodigoConsulta,
            StatusAgua = agua?.Status,

            CodigoIptu = iptu?.Codigo,
            CodigoConsultaIptu = iptu?.CodigoConsulta,
            StatusIptu = iptu?.Status,

            CodigoCondominio = condominio?.Codigo,
            StatusCondominio = condominio?.Status,
        };
    }
}
