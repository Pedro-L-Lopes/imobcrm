﻿namespace imobcrm.DTOs;
public class PagamentoAluguelDTO
{
    public Guid? PagamentoAluguelId { get; set; }
    public Guid ContratoId { get; set; } // Chave estrangeira para ContratoAluguel
    public int Codigo { get; set; }

    public DateTime PeriodoInicio { get; set; }

    public DateTime PeriodoFim { get; set; }

    public decimal? ValorPago { get; set; }
    public string? ReferenciaPagamento { get; set; } // Ex: "Jan/2025"

    public string StatusPagamento { get; set; } = "em dia"; // "em dia", "em atraso"

    public DateTime DataVencimentoAluguel { get; set; }

    public DateTime? DataPagamento { get; set; }
    public DateTime? UltimaEdicao { get; set; }

}
