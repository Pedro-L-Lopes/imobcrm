namespace imobcrm.DTOs;
public class VisitaDTO
{
    public DateTime DataHora { get; set; }

    public string Situacao { get; set; } // Ex: "confirmada", "cancelada"

    public int Codigo { get; set; }
    public string? ClienteNome { get; set; }

    public Guid ClienteId { get; set; } // Chave estrangeira para Cliente

    public Guid ImovelId { get; set; } // Chave estrangeira para Imovel

    public string Observacao { get; set; }
}
