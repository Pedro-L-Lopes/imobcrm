namespace imobcrm.Models;
public class ContratoAluguel
{
    public Guid ContratoId { get; set; }
    public int Codigo { get; set; }

    public Guid ImovelId { get; set; }

    public Guid LocadorId { get; set; }

    public Guid LocatarioId { get; set; }


    public decimal ValorContrato { get; set; }

    public decimal ValorCondominio { get; set; }


    public DateTime InicioContrato { get; set; }

    public DateTime? FimContrato { get; set; }
    public DateTime? PrimeiroAluguel { get; set; }


    public byte VencimentoAluguel { get; set; }

    public string StatusContrato { get; set; } = "ativo";
    public string DestinacaoContrato { get; set; } = "Residencial";
    public byte TempoContrato { get; set; }

    public byte TaxaAdm { get; set; }
    public byte TaxaIntermediacao { get; set; }

    public string Rescisao { get; set; } // ex: 3 meses de aluguel 
    public string SemMultaApos { get; set; }

    public string AnotacoesGerais { get; set; }

    public DateTime? DataRescisao { get; set; }


    public DateTime? UltimaRenovacao { get; set; }

    public DateTime? UltimaEdicao { get; set; }


    public DateTime DataCriacao { get; set; } = DateTime.Now;


    public Cliente Locatario { get; set; }
    public Cliente Locador { get; set; }
    public Imovel Imovel { get; set; }
    public PagamentoAluguel PagamentoAluguel { get; set; }
}
