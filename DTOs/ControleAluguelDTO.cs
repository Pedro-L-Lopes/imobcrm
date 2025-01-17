using imobcrm.Models;
using System.Text.Json.Serialization;

namespace imobcrm.DTOs;
public class ControleAluguelDTO
{
    public Guid ContratoAluguelId { get; set; }
    public Guid ImovelId { get; set; }

    public int CodigoImovel { get; set; }
    public string EnderecoImovel { get; set; }

    public int CodigoLocador { get; set; }
    public string NomeLocador { get; set; }

    public int CodigoLocatario { get; set; }
    public string NomeLocatario { get; set; }

    public string StatusPagamento { get; set; }
    public string Periodo { get; set; }

    public byte DiaVencimento { get; set; }

    public int? CodigoLuz { get; set; }
    public string? CodigoConsultaLuz { get; set; }
    public string? StatusLuz { get; set; }

    public int? CodigoAgua { get; set; }
    public string? CodigoConsultaAgua { get; set; }
    public string? StatusAgua { get; set; }

    public int? CodigoIptu { get; set; }
    public string? CodigoConsultaIptu { get; set; }
    public string? StatusIptu { get; set; }
    
    public int? CodigoCondominio { get; set; }
    public string? StatusCondominio { get; set; }

    public decimal ValorAluguel { get; set; }

    [JsonIgnore]
    public ContratoAluguel? ContratoAluguel { get; set; }
}
