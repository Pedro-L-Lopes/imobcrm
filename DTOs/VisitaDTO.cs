namespace imobcrm.DTOs;
public class VisitaDTO
{
    public Guid VisitaId { get; set; }
    public DateTime DataHora { get; set; }
    public string Situacao { get; set; } // Ex: "confirmada", "cancelada"
    public int Codigo { get; set; }
    public string? ClienteNome { get; set; }
    public Guid ClienteId { get; set; } // Chave estrangeira para Cliente
    public Guid ImovelId { get; set; } // Chave estrangeira para Imovel
    public string Observacao { get; set; }
    public DateTime? UltimaEdicao { get; set; }


    // Novos campos
    public string? CEP { get; set; }
    public string? Rua { get; set; }
    public string? Bairro { get; set; }
    public string? Cidade { get; set; } 
    public string? Estado { get; set; }
    public string? ClienteEmail { get; set; }
    public string? ClienteTelefone { get; set; }
    public string? ClienteDocumento { get; set; }
    public string? FinalidadeVisita { get; set; }
    public string? Destincao { get; set; }
    public decimal? ValorImovel { get; set; }
}

