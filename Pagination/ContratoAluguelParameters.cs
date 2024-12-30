namespace imobcrm.Pagination;
public class ContratoAluguelParameters
{
    const int maxPageSize = 15;
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
    public string? StatusContrato { get; set; }
    public DateTime? InicioContrato { get; set; }
    public DateTime? FimContrato { get; set; }
    public string? SearchTerm { get; set; }
}
