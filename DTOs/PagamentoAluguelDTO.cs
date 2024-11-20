namespace imobcrm.DTOs;
public class PagamentoAluguelDTO
{
    public Guid ContratoId { get; set; } // Chave estrangeira para ContratoAluguel

    public DateTime PeriodoInicio { get; set; }

    public DateTime PeriodoFim { get; set; }

    public decimal? ValorPago { get; set; }

    public string StatusPagamento { get; set; } = "em dia"; // "em dia", "em atraso"

    public DateTime DataVencimentoAluguel { get; set; }

    public DateTime? DataPagamento { get; set; }
}
