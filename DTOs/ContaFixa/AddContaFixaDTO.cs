namespace imobcrm.DTOs.ContaFixa;

public class AddContaFixaDTO
{
    public string TipoConta { get; set; }
    public string? CodigoConsulta { get; set; }
    public string Status { get; set; } = "Em dia";
    public string? Descricao { get; set; }
    public Guid ImovelId { get; set; }
}
