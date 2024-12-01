
using System.ComponentModel.DataAnnotations;

namespace imobcrm.Models;
public class ContaExtra
{
    public Guid IdContaExtra { get; set; }

    public Guid ContratoId { get; set; } // Chave estrangeira para ContratoAluguel

    public string TipoConta { get; set; } // Ex: "luz", "água", "IPTU"

    public string CodigoConta { get; set; } // Código externo de consulta

    public DateTime DataVencimento { get; set; }

    public string StatusPagamento { get; set; } = "em atraso"; // "em dia", "em atraso"

    public decimal Valor { get; set; }

    public DateTime? DataPagamento { get; set; }

    public ContratoAluguel ContratoAluguel { get; set; }
}
