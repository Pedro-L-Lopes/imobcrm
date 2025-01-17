namespace imobcrm.DTOs.PagamentoAluguelEditDTO;
public class PagamentoAluguelEditDTO
{
    public Guid PagamentoAluguelId { get; set; }

    public decimal? ValorPago { get; set; }

    public string StatusPagamento { get; set; } = "em dia"; // "em dia", "em atraso"

    public DateTime? DataPagamento { get; set; }
    public DateTime? UltimaEdicao { get; set; }
}
