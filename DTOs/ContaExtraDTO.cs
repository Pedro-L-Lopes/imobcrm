using imobcrm.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace imobcrm.DTOs;
public class ContaExtraDTO
{
    public Guid ContratoId { get; set; } // Chave estrangeira para ContratoAluguel

    public string TipoConta { get; set; } // Ex: "luz", "água", "IPTU"

    public string CodigoConta { get; set; } // Código externo de consulta

    public DateTime DataVencimento { get; set; }

    public string StatusPagamento { get; set; } = "em atraso"; // "em dia", "em atraso"

    public decimal Valor { get; set; }

    public DateTime? DataPagamento { get; set; }
}
