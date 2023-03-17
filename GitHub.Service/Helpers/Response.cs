namespace GitHub.Service.Helpers;
public class Response<T>
{
    public int Code { get; set; }
    public string Message { get; set; }
    public T Value { get; set; }
}
