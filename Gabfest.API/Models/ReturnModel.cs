namespace Gabfest.API;

public class ReturnModel
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public int StatusCode { get; set; }
    public object Data { get; set; }
}
