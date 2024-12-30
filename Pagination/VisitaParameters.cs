namespace imobcrm.Pagination;
public class VisitaParameters
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
    public string OrderBy { get; set; } = "DataHora";
    public string SortDirection { get; set; } = "asc";

    // Parâmetros de filtro
    public string? Situacao { get; set; }

    // Filtros de datas
    public DateTime? DataInicio { get; set; }
    public DateTime? DataFim { get; set; }
}
