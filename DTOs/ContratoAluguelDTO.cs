using imobcrm.Models;
using System.Text.Json.Serialization;

namespace imobcrm.DTOs;
public class ContratoAluguelDTO
{
    public Guid ContratoId { get; set; }
    public int Codigo { get; set; }

    public Guid ImovelId { get; set; }

    public Guid LocadorId { get; set; }
    public string? LocadorNome { get; set; }
    public int? CodigoLocador { get; set; }

    public Guid LocatarioId { get; set; }
    public string? LocatarioNome { get; set; }
    public int? CodigoLocatario { get; set; }

    public decimal ValorContrato { get; set; }
    public DateTime? PrimeiroAluguel { get; set; }

    public decimal ValorCondominio { get; set; }

    public DateTime InicioContrato { get; set; }

    public DateTime? FimContrato { get; set; }

    public byte VencimentoAluguel { get; set; }


    public string StatusContrato { get; set; }
    public string DestinacaoContrato { get; set; }

    public byte TaxaAdm { get; set; }
    public byte TaxaIntermediacao { get; set; }

    public string Rescisao { get; set; } // ex: 3 meses de aluguel 
    public string SemMultaApos { get; set; }

    public string AnotacoesGerais { get; set; }

    public DateTime? DataRescisao { get; set; }


    public DateTime? UltimaRenovacao { get; set; }

    public byte TempoContrato { get; set; }
    public DateTime? UltimaEdicao { get; set; }
    public DateTime? DataCriacao { get; set; }


    // Imóvel
    public int? CodigoImovel { get; set; }
    public string? TipoImovel { get; set; }
    public string? Rua { get; set; }
    public string? Numero { get; set; }
    public string? Cep { get; set; }
    public string? Bairro { get; set; }
    public string? Cidade { get; set; }
    public string? Estado { get; set; }

    [JsonIgnore]
    public Cliente? Locatario { get; set; }
    [JsonIgnore]
    public Cliente? Locador { get; set; }
    [JsonIgnore]
    public Imovel? Imovel { get; set; }
}
