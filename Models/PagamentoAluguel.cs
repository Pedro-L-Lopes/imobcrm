using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace imobcrm.Models;
public class PagamentoAluguel
{
    public Guid PagamentoAluguelId { get; set; }
    public int Codigo { get; set; }

    public Guid ContratoId { get; set; } // Chave estrangeira para ContratoAluguel

    public DateTime PeriodoInicio { get; set; }

    public DateTime PeriodoFim { get; set; }

    public decimal? ValorPago { get; set; }
    public string? ReferenciaPagamento { get; set; } // Ex: "Jan/2025"

    public string StatusPagamento { get; set; } = "em dia"; // "em dia", "em atraso"

    public DateTime DataVencimentoAluguel { get; set; }

    public DateTime? DataPagamento { get; set; }

    public DateTime? UltimaEdicao { get; set; }

    // Propriedade de Navegação
    [JsonIgnore]
    public ContratoAluguel Contrato { get; set; }
}
