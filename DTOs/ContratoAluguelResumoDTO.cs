namespace imobcrm.DTOs;
public class ContratoAluguelResumoDTO
{
    public Guid ContratoId { get; set; }
    public int Codigo { get; set; }


    public Guid ImovelId { get; set; }


    public Guid LocadorId { get; set; }
    public string? LocadorNome { get; set; }


    public Guid LocatarioId { get; set; }
    public string? locatarioNome { get; set; }


    public decimal ValorContrato { get; set; }


    public DateTime InicioContrato { get; set; }

    public DateTime? FimContrato { get; set; }


    public string StatusContrato { get; set; } = "ativo";
    public DateTime DataRescisao { get; set; }

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
}
