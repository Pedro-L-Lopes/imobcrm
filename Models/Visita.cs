namespace imobcrm.Models;
public class Visita
{
    public Guid VisitaId { get; set; }

    public DateTime DataHora { get; set; }

    public string Situacao { get; set; } // Ex: "confirmada", "cancelada"

    public int Codigo { get; set; }

    public Guid ClienteId { get; set; } // Chave estrangeira para Cliente

    public Guid ImovelId { get; set; } // Chave estrangeira para Imovel

    public string Observacao { get; set; }

    // Propriedades de Navegação
    public Cliente Cliente { get; set; }

    public Imovel Imovel { get; set; }
}
