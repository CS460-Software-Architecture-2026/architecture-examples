namespace Exercise;

public class HttpRequest
{
    public string Url { get; set; } = "";
    public string Method { get; set; } = "GET";
    public Dictionary<string, string> Headers { get; set; } = new(StringComparer.OrdinalIgnoreCase);
    public Dictionary<string, string> QueryParameters { get; set; } = new();
    public string? Body { get; set; }
}

public class HttpRequestBuilder
{
    private readonly HttpRequest httprequest = new HttpRequest();
    public HttpRequestBuilder Url(string value)
    {
        httprequest.Url = value;
        return this;
    }
    public HttpRequestBuilder Method(string value)
    {
        httprequest.Method = value;
        return this;
    }
    public HttpRequestBuilder Headers(Dictionary<string, string> value)
    {
        httprequest.Headers = value;
        return this;
    }
    public HttpRequestBuilder QueryParameters(Dictionary<string, string> value)
    {
        httprequest.QueryParameters = value;
        return this;
    }
    public HttpRequestBuilder Body(string value)
    {
        httprequest.Body = value;
        return this;
    }
    public HttpRequest Build()
    {
        if (!Uri.TryCreate(httprequest.Url, UriKind.Absolute, out var uri) ||
            (uri.Scheme != "http" && uri.Scheme != "https"))
        {
            throw new InvalidOperationException("Invalid URL");
        }
        if (string.IsNullOrWhiteSpace(httprequest.Url)) throw new InvalidOperationException("Url required");
        if (string.IsNullOrWhiteSpace(httprequest.Method)) throw new InvalidOperationException("Method required");
        return new HttpRequest{
            Url = httprequest.Url, 
            Method = httprequest.Method, 
            Headers = new(httprequest.Headers, StringComparer.OrdinalIgnoreCase), 
            QueryParameters = new (httprequest.QueryParameters), 
            Body = httprequest.Body
            
        };
    }
}
