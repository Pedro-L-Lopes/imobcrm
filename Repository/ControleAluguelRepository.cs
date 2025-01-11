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
        var contasFixas = await _context.ContasFixas.AsNoTracking().ToListAsync();

        // Obter o pagamento correspondente ao período atual para cada contrato
        var pagamentosAgrupados = await _context.PagamentoAlugueis
            .AsNoTracking()
            .Where(p => p.PeriodoInicio <= today && p.PeriodoFim >= today)
            .GroupBy(p => p.ContratoId)
            .Select(g => g.FirstOrDefault())
            .ToListAsync();

        // Carregar dados relacionados de contratos e imóveis
        var contratos = await _context.ContratosAluguel
            .Include(c => c.Imovel)
                .ThenInclude(i => i.Localizacao)
            .Include(c => c.Locador)
            .Include(c => c.Locatario)
            .AsNoTracking()
            .ToDictionaryAsync(c => c.ContratoId);

        // Criar a lista de DTOs
        var controleAluguelDTOs = pagamentosAgrupados
            .Select(p =>
            {
                if (p == null || !contratos.TryGetValue(p.ContratoId, out var contrato))
                    return null;

                return MapToControleAluguelDTO(p, contrato, contasFixas);
            })
            .Where(dto => dto != null)
            .ToList();

        // Ordenação
        if (!string.IsNullOrEmpty(parameters.OrderBy))
        {
            controleAluguelDTOs = parameters.OrderBy.ToLower() switch
            {
                "vencimentoaluguel" => parameters.SortDirection?.ToLower() == "desc"
                    ? controleAluguelDTOs.OrderByDescending(dto => dto.DiaVencimento).ToList()
                    : controleAluguelDTOs.OrderBy(dto => dto.DiaVencimento).ToList(),
                "valorcontrato" => parameters.SortDirection?.ToLower() == "desc"
                    ? controleAluguelDTOs.OrderByDescending(dto => dto.ValorAluguel).ToList()
                    : controleAluguelDTOs.OrderBy(dto => dto.ValorAluguel).ToList(),
                _ => controleAluguelDTOs
            };
        }

        // Paginação
        var totalCount = controleAluguelDTOs.Count;
        var pagedItems = controleAluguelDTOs
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
            CodigoImovel = imovel.Codigo,
            EnderecoImovel = $"{imovel.Rua}, {imovel.Numero} - {localizacao.Bairro}, {localizacao.Cidade}-{localizacao.Estado}",
            CodigoLocador = contrato.Locador.Codigo,
            NomeLocador = contrato.Locador.Nome,
            CodigoLocatario = contrato.Locatario.Codigo,
            NomeLocatario = contrato.Locatario.Nome,
            Periodo = $"{pagamento.PeriodoInicio:dd/MM/yyyy} - {pagamento.PeriodoFim:dd/MM/yyyy}",
            DiaVencimento = contrato.VencimentoAluguel,
            ValorAluguel = contrato.ValorContrato,
            StatusPagamento = pagamento.StatusPagamento?.ToLower() ?? "pendente",

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
