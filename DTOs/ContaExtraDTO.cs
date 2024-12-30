using imobcrm.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace imobcrm.DTOs;
public class ContaExtraDTO
{
    public Guid IdContaExtra { get; set; }

    public Guid ContratoId { get; set; } // Chave estrangeira para ContratoAluguel
    public int Codigo { get; set; }

    public string TipoConta { get; set; } // Ex: "luz", "água", "IPTU"
    public string? CodigoConta { get; set; } // Código externo de consulta
    public bool Recorrente { get; set; }
    public decimal Valor { get; set; }
    public DateTime? DataVencimento { get; set; }
    public string? StatusPagamento { get; set; } // "em dia", "em atraso"
    public string? Observacoes { get; set; }

    public DateTime? DataPagamento { get; set; }
    public DateTime? UltimaEdicao { get; set; }
}
