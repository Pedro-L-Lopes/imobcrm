using System.Text.Json.Serialization;

namespace imobcrm.Models;
public class ContaFixa
{
    public Guid ContaFixaId { get; set; }
    public string TipoConta { get; set; }
    public int Codigo { get; set; }
    public string? CodigoConsulta { get; set; }
    public string Status { get; set; } = "Em dia";
    public string? Descricao { get; set; }
    public DateTime? UltimaEdicao { get; set; }

    public DateTime? DataCriacao { get; set; }

    public Guid? ImovelId { get; set; }

    [JsonIgnore]
    public Imovel? imovel { get; set; }
}
