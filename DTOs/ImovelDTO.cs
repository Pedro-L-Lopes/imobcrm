using imobcrm.Models;

namespace imobcrm.DTOs;
public class ImovelDTO
{
    public Guid ProprietarioId { get; set; } // Relacionamento com Cliente
    public int Codigo { get; set; }
    public Guid ImovelId { get; set; }

    public string Finalidade { get; set; }
    public string Destinação { get; set; }
    public string TipoImovel { get; set; }
    public string Situacao { get; set; }
    public decimal Valor { get; set; }
    public string? SiteCod { get; set; }
    public decimal? ValorCondominio { get; set; }
    public float? Area { get; set; }
    public string? Observacoes { get; set; }
    public string? Descricao { get; set; }

    public byte? Quartos { get; set; }
    public byte? Suites { get; set; }
    public byte? Banheiros { get; set; }
    public byte? SalasEstar { get; set; }
    public byte? SalasJantar { get; set; }
    public byte? Varanda { get; set; }
    public byte? Garagem { get; set; }

    public decimal? ValorAutorizacao { get; set; }
    public string? TipoAutorizacao { get; set; }
    public DateTime? DataAutorizacao { get; set; }

    public string? Rua { get; set; }
    public string? Numero { get; set; }
    public string? Cep { get; set; }

    public DateTime DataCricao {  get; set; }

    public int LocalizacaoId { get; set; }

    public string? Bairro { get; set; }
    public string? Cidade { get; set; }
    public string? Estado { get; set; }
    public string? ProprietarioNome { get; set; }
    public DateTime? UltimaEdicao { get; set; }

}
