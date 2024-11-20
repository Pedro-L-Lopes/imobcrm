namespace imobcrm.DTOs;
public class ClienteDTO
{
    public string Nome { get; set; }

    public string Email { get; set; }

    public string Telefone { get; set; }

    public string CpfCnpj { get; set; } // Pode ser CPF (11 dígitos) ou CNPJ (14 dígitos)

    public char Sexo { get; set; } // Use 'M' para Masculino, 'F' para Feminino, etc.

    public DateTime DataNascimento { get; set; }
}
