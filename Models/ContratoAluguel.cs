namespace imobcrm.Models;
public class ContratoAluguel
{
    public Guid ContratoId { get; set; }
    public int Codigo { get; set; }

    public Guid ImovelId { get; set; }

    public Imovel Imovel { get; set; }

    public Guid LocadorId { get; set; }

    public Cliente Locador { get; set; }

    public Guid LocatarioId { get; set; }

    public Cliente Locatario { get; set; }

    public decimal ValorContrato { get; set; }

    public decimal ValorCondominio { get; set; }

    public decimal OutrosValores { get; set; }

    public DateTime InicioContrato { get; set; }

    public DateTime? FimContrato { get; set; }

    public byte VencimentoAluguel { get; set; }

    public string StatusContrato { get; set; } = "ativo";

    public DateTime? UltimaRenovacao { get; set; }

    public DateTime? UltimaEdicao { get; set; }

    public byte TempoContrato { get; set; }

    public DateTime DataCriacao { get; set; } = DateTime.Now;
}
