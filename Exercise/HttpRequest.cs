namespace Exercise;

public class HttpRequest
{
    public string Url { get; internal set; } = "";
    public string Method { get; internal set; } = "GET";
    public Dictionary<string, string> Headers { get; internal set; } = new(StringComparer.OrdinalIgnoreCase);
    public Dictionary<string, string> QueryParameters { get; internal set; } = new();
    public string? Body { get; internal set; }
}
