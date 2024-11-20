using System.ComponentModel.DataAnnotations;

namespace imobcrm.DTOs;
public class LocalizacaoDTO
{
    [Key]
    public Guid LocalizacaoId { get; set; } = Guid.NewGuid();

    [MaxLength(10)]
    public string Cep { get; set; }

    [Required]
    [MaxLength(50)]
    public string Bairro { get; set; }

    [Required]
    [MaxLength(50)]
    public string Cidade { get; set; }

    [Required]
    [MaxLength(50)]
    public string Estado { get; set; }
}
