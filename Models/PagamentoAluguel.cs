using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace imobcrm.Models;
public class PagamentoAluguel
{
    public Guid PagamentoAluguelId { get; set; } = Guid.NewGuid();

    public Guid ContratoId { get; set; } // Chave estrangeira para ContratoAluguel

    public DateTime PeriodoInicio { get; set; }

    public DateTime PeriodoFim { get; set; }

    public decimal? ValorPago { get; set; }

    public string StatusPagamento { get; set; } = "em dia"; // "em dia", "em atraso"

    public DateTime DataVencimentoAluguel { get; set; }

    public DateTime? DataPagamento { get; set; }

    // Propriedade de Navegação
    public ContratoAluguel Contrato { get; set; }
}
