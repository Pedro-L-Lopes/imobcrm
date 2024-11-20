using imobcrm.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace imobcrm.DTOs;
public class PagamentoAluguelDTO
{
    [Key]
    public Guid PagamentoAluguelId { get; set; } = Guid.NewGuid();

    [Required]
    public Guid ContratoId { get; set; } // Chave estrangeira para ContratoAluguel

    [Required]
    [DataType(DataType.Date)]
    public DateTime PeriodoInicio { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime PeriodoFim { get; set; }

    [DataType(DataType.Currency)]
    public decimal? ValorPago { get; set; }

    [Required]
    [MaxLength(20)]
    public string StatusPagamento { get; set; } = "em dia"; // "em dia", "em atraso"

    [Required]
    [DataType(DataType.Date)]
    public DateTime DataVencimentoAluguel { get; set; }

    [DataType(DataType.Date)]
    public DateTime? DataPagamento { get; set; }

    // Propriedade de Navegação
    [ForeignKey("ContratoId")]
    public ContratoAluguelDTO Contrato { get; set; }
}
