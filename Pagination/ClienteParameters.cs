namespace imobcrm.Pagination;
public class ClienteParameters
{
    const int maxPageSize = 30;
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
    public string OrderBy { get; set; } = "ultimaEdicao"; // Campo padrão para ordenação
    public string SortDirection { get; set; } = "asc"; // Direção padrão

    // Parâmetro de pesquisa
    public string? SearchTerm { get; set; }
}
