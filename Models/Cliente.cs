namespace imobcrm.Models;
public class Cliente
{
    public Guid ClienteId { get; set; }
    public string TipoCliente { get; set; }
    public int Codigo { get; set; }

    public string Nome { get; set; }

    public string? Email { get; set; }

    public string? Telefone { get; set; }

    public string? CpfCnpj { get; set; } // Pode ser CPF (11 dígitos) ou CNPJ (14 dígitos)

    public char? Sexo { get; set; } // Use 'M' para Masculino, 'F' para Feminino, etc.

    public DateTime? DataNascimento { get; set; }

    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

    public DateTime? UltimaEdicao { get; set; }

    // Propriedade de Navegação - um cliente pode ter vários imóveis
    public ICollection<Imovel> Imoveis { get; set; }
}
