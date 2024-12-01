namespace imobcrm.Errors;
public class ErrorResponse
{
    public string Type { get; set; }
    public string Title { get; set; }
    public int Status { get; set; }
    public string TraceId { get; set; }
    public IEnumerable<object> Errors { get; set; }
}
