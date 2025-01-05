using imobcrm.Models;
using System.Text.Json.Serialization;

namespace imobcrm.DTOs.ContaFixa;

public class ContaFixaDTO
{
    public Guid ContaFixaId { get; set; }
    public string TipoConta { get; set; }
    public int Codigo { get; set; }
    public string? CodigoConsulta { get; set; }
    public string Status { get; set; }
    public string? Descricao { get; set; }
    public DateTime? UltimaEdicao { get; set; }

    public DateTime? DataCriacao { get; set; } = DateTime.Now;

    public Guid? ImovelId { get; set; }

    [JsonIgnore]
    public Imovel? imovel { get; set; }
}
