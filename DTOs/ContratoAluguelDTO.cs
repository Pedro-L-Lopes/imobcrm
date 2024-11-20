using imobcrm.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace imobcrm.DTOs;
public class ContratoAluguelDTO
{
    [Key]
    public Guid ContratoId { get; set; } = Guid.NewGuid();

    [Required]
    public Guid ImovelId { get; set; }

    [ForeignKey("ImovelId")]
    public Imovel Imovel { get; set; }

    [Required]
    public Guid LocadorId { get; set; }

    [ForeignKey("LocadorId")]
    public Cliente Locador { get; set; }

    [Required]
    public Guid LocatarioId { get; set; }

    [ForeignKey("LocatarioId")]
    public Cliente Locatario { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal ValorContrato { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal ValorCondominio { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal OutrosValores { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime InicioContrato { get; set; }

    [DataType(DataType.Date)]
    public DateTime? FimContrato { get; set; }

    [Range(1, 31)]
    public byte VencimentoAluguel { get; set; }

    [Required]
    [MaxLength(20)]
    public string StatusContrato { get; set; } = "ativo";

    [DataType(DataType.Date)]
    public DateTime? UltimaRenovacao { get; set; }

    public byte TempoContrato { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime DataCriacao { get; set; } = DateTime.Now;
}
