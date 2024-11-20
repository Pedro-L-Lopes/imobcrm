using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace imobcrm.DTOs;
public class VisitaDTO
{
    [Key]
    public Guid VisitaId { get; set; } = Guid.NewGuid();

    [Required]
    public DateTime DataHora { get; set; }

    [MaxLength(50)]
    public string Situacao { get; set; } // Ex: "confirmada", "cancelada"

    public int Codigo { get; set; }

    public Guid? ClienteId { get; set; } // Chave estrangeira para Cliente

    public Guid? ImovelId { get; set; } // Chave estrangeira para Imovel

    [MaxLength(100)]
    public string Observacao { get; set; }

    // Propriedades de Navegação
    [ForeignKey("ClienteId")]
    public ClienteDTO Cliente { get; set; }

    [ForeignKey("ImovelId")]
    public ImovelDTO Imovel { get; set; }
}
