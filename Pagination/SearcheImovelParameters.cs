namespace imobcrm.Pagination;
public class SearcheImovelParameters
{
    // Parâmetros de ordenação
    public string? OrderBy { get; set; } = "dataHora"; // Campo padrão para ordenação
    public string? SortDirection { get; set; } = "desc"; // Direção padrão

    // Parâmetros de filtro
    public string? Finalidade { get; set; }
    public string? Situacao { get; set; }
}
