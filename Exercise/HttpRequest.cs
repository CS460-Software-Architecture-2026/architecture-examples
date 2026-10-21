namespace Exercise;

public class HttpRequest
{
    public string Url { get; set; } = "";
    public string Method { get; set; } = "GET";
    public Dictionary<string, string> Headers { get; set; } = new(StringComparer.OrdinalIgnoreCase);
    public Dictionary<string, string> QueryParameters { get; set; } = new();
    public string? Body { get; set; }
}

// Step interfaces
public interface IStart
{
    ISetMethod Url(string value);
}

public interface ISetMethod
{
    IOptional Method(string value);
}

public interface IOptional
{
    IOptional Header(string name, string value);
    IOptional QueryParameter(string name, string value);
    IOptional Body(string? value);
    IBuild Done();
}

public interface IBuild
{
    HttpRequest Build();
}
