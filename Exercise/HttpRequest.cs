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
    ISetMethod Url(string value);
}

public interface ISetMethod
{
    ISetHeaders Method(string value);
}

public interface ISetHeaders
{
    ISetQueryParameters Headers(Dictionary<string, string> value);
}

public interface ISetQueryParameters
{
    ISetBody QueryParameters(Dictionary<string, string> value);
}

public interface ISetBody
{
    IBuild Body(string value);
    IBuild Done();
}

public interface IBuild
{
    HttpRequest Build();
}
