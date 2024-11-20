using imobcrm.Models;

namespace imobcrm.DTOs;
public class ContratoAluguelDTO
{
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

    public byte TempoContrato { get; set; }
}
