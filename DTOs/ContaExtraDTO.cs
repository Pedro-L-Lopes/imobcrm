using imobcrm.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace imobcrm.DTOs;
public class ContaExtraDTO
{
    [Key]
    public Guid IdContaExtra { get; set; } = Guid.NewGuid();

    [Required]
    public Guid ContratoId { get; set; } // Chave estrangeira para ContratoAluguel

    [MaxLength(50)]
    public string TipoConta { get; set; } // Ex: "luz", "água", "IPTU"

    [MaxLength(50)]
    public string CodigoConta { get; set; } // Código externo de consulta

    [Required]
    [DataType(DataType.Date)]
    public DateTime DataVencimento { get; set; }

    [Required]
    [MaxLength(20)]
    public string StatusPagamento { get; set; } = "em atraso"; // "em dia", "em atraso"

    [Required]
    [DataType(DataType.Currency)]
    public decimal Valor { get; set; }

    [DataType(DataType.Date)]
    public DateTime? DataPagamento { get; set; }

    // Propriedade de Navegação
    [ForeignKey("ContratoId")]
    public ContratoAluguelDTO Contrato { get; set; }
}
