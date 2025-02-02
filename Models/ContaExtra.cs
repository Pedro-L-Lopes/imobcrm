﻿
using System.ComponentModel.DataAnnotations;

namespace imobcrm.Models;
public class ContaExtra
{
    public Guid IdContaExtra { get; set; }
    public int Codigo { get; set; }

    public Guid ContratoId { get; set; } // Chave estrangeira para ContratoAluguel

    public string TipoConta { get; set; } // Ex: "luz", "água", "IPTU"

    public string? CodigoConta { get; set; } // Código externo de consulta

    public DateTime? DataVencimento { get; set; }
    
    public string StatusPagamento { get; set; } = "Em dia"; // "em dia", "em atraso"

    public string? Observacoes { get; set; }

    public decimal Valor { get; set; }
    public bool Recorrente { get; set; }

    public DateTime? DataPagamento { get; set; }

    public DateTime? UltimaEdicao { get; set; }

    public ContratoAluguel ContratoAluguel { get; set; }
}
