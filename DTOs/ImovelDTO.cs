namespace imobcrm.DTOs;
public class ImovelDTO
{
    public Guid ProprietarioId { get; set; } // Relacionamento com Cliente

    public string Finalidade { get; set; }

    public string TipoImovel { get; set; }

    public decimal Valor { get; set; }

    public int SiteCod { get; set; }

    public decimal? ValorCondominio { get; set; }

    public float? Area { get; set; }

    public string Observacoes { get; set; }

    public string Descricao { get; set; }

    public byte? Quartos { get; set; }
    public byte? Suites { get; set; }
    public byte? Banheiros { get; set; }
    public byte? SalasEstar { get; set; }
    public byte? SalasJantar { get; set; }
    public byte? Varanda { get; set; }
    public byte? Garagem { get; set; }

    public decimal? ValorAutorizacao { get; set; }

    public string TipoAutorizacao { get; set; }

    public DateTime? DataAutorizacao { get; set; }

    public Guid EnderecoId { get; set; } // Relacionamento com Localizacoes

    public string Rua { get; set; }

    public string Numero { get; set; }
}
