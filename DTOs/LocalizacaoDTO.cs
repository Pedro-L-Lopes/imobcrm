namespace imobcrm.DTOs;
public class LocalizacaoDTO
{
    public int LocalizacaoId { get; set; }
    public int Codigo { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }

    public string Estado { get; set; }
    public DateTime? UltimaEdicao { get; set; }
}
