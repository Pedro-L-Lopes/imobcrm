using imobcrm.Models;
using System.ComponentModel.DataAnnotations;

namespace imobcrm.DTOs;
public class ClienteDTO
{
    [Key]
    public Guid ClienteId { get; set; } = Guid.NewGuid();

    [Required]
    [MaxLength(100)]
    public string Nome { get; set; }

    [EmailAddress]
    [MaxLength(100)]
    public string Email { get; set; }

    [Phone]
    [MaxLength(15)]
    public string Telefone { get; set; }

    [Required]
    [MaxLength(14)]
    public string CpfCnpj { get; set; } // Pode ser CPF (11 dígitos) ou CNPJ (14 dígitos)

    [Required]
    public char Sexo { get; set; } // Use 'M' para Masculino, 'F' para Feminino, etc.

    [Required]
    [DataType(DataType.Date)]
    public DateTime DataNascimento { get; set; }

    [Required]
    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

    // Propriedade de Navegação - um cliente pode ter vários imóveis
    public ICollection<ImovelDTO> Imoveis { get; set; }
}
