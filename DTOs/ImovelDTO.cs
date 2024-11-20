using imobcrm.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace imobcrm.DTOs;
public class ImovelDTO
{
    [Key]
    public Guid ImovelId { get; set; } = Guid.NewGuid();

    [Required]
    public Guid ProprietarioId { get; set; } // Relacionamento com Cliente

    [MaxLength(20)]
    public string Finalidade { get; set; }

    [MaxLength(45)]
    public string TipoImovel { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal Valor { get; set; }

    public int SiteCod { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal? ValorCondominio { get; set; }

    public float? Area { get; set; }

    [MaxLength(255)]
    public string Observacoes { get; set; }

    [MaxLength(255)]
    public string Descricao { get; set; }

    public byte? Quartos { get; set; }
    public byte? Suites { get; set; }
    public byte? Banheiros { get; set; }
    public byte? SalasEstar { get; set; }
    public byte? SalasJantar { get; set; }
    public byte? Varanda { get; set; }
    public byte? Garagem { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal? ValorAutorizacao { get; set; }

    [MaxLength(20)]
    public string TipoAutorizacao { get; set; }

    public DateTime? DataAutorizacao { get; set; }

    public Guid EnderecoId { get; set; } // Relacionamento com Localizacoes

    [MaxLength(100)]
    public string Rua { get; set; }

    [MaxLength(50)]
    public string Numero { get; set; }

    // Propriedades de Navegação
    public ClienteDTO Proprietario { get; set; }
    public LocalizacaoDTO Endereco { get; set; }
}
