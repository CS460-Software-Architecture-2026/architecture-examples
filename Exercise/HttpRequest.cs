namespace Exercise;
public class HttpRequest
{
    public string Url { get; set; } = "";
    public string Method { get; set; } = "GET";
    public Dictionary<string, string> Headers { get; set; } = new(StringComparer.OrdinalIgnoreCase);
    public Dictionary<string, string> QueryParameters { get; set; } = new();
    public string? Body { get; set; }
}

public interface IStart
{
    ISetMethod Url(string url);
}

public interface ISetMethod
{
    IOptional Method(string method);
}

public interface IOptional
{
    IOptional Headers(Dictionary<string, string> headers);
    IOptional QueryParameters(Dictionary<string, string> queryParameters );
    IOptional Body(string body);
    IHttpRequestBuilder Done();
}

public interface IHttpRequestBuilder
{
    HttpRequest Build();
}

