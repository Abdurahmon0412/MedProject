namespace MedApi.Models;

public class Result
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public object Data { get; set; }
    public string PaginationData { get; set; }
}