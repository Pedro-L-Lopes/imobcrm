using System.ComponentModel.DataAnnotations;

namespace imobcrm.Models;
public class Localizacao
{
    public Guid LocalizacaoId { get; set; } = Guid.NewGuid();

    public string Cep { get; set; }

    public string Bairro { get; set; }

    public string Cidade { get; set; }

    public string Estado { get; set; }
}
