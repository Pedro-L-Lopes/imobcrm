using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace imobcrm.Models;
public class Imovel
{
    public Guid ImovelId { get; set; }
    public int Codigo { get; set; }

    public Guid ProprietarioId { get; set; } // Relacionamento com Cliente

    public string Finalidade { get; set; }
    public string Destinacao { get; set; }
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

    public bool? Avaliacao { get; set; }
    public decimal AvaliacaoValor { get; set; }
    public DateTime? DataAvaliacao { get; set; }

    public bool? ComPlaca { get; set; }

    public decimal? ValorAutorizacao { get; set; }
    public string? TipoAutorizacao { get; set; }
    public DateTime? DataAutorizacao { get; set; }

    public DateTime UltimaPubliRedes { get; set; } // Data da ultima publicação nas redes sociais

    public string? Rua { get; set; }
    public string? Numero { get; set; }
    public string? Cep{ get; set; }

    public DateTime? UltimaEdicao { get; set; }

    public int LocalizacaoId { get; set; }
    public DateTime DataCriacao {  get; set; } = DateTime.UtcNow;

    public Localizacao Localizacao { get; set; }

    // Propriedade de Navegação
    public Cliente Proprietario { get; set; }
}
