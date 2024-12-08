namespace imobcrm.Pagination;
public class ImovelParameters
{
    const int maxPageSize = 20;
    public int PageNumber { get; set; } = 1;
    private int _pageSize;

    public int PageSize
    {
        get
        {
            return _pageSize;
        }
        set
        {
            _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }
    }

    // Parâmetros de ordenação
    public string? OrderBy { get; set; } = "dataCriacao"; // Campo padrão para ordenação
    public string? SortDirection { get; set; } = "asc"; // Direção padrão

    // Parâmetros de filtro
    public string? Finalidade { get; set; }
    public string? TipoImovel { get; set; }
    public string? Situacao { get; set; }
    public string? Cidade { get; set; }
    public bool? Avaliacao { get; set; }
    public bool? ComPlaca { get; set; }
    public string? TipoAutorizacao { get; set; }
}
