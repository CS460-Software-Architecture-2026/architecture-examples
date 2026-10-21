using Exercise;

public class HttpRequestBuilder
{
    private string _url  = "";
    private string _method  = "GET";
    private Dictionary<string, string> _headers  = new(StringComparer.OrdinalIgnoreCase);
    private Dictionary<string, string> _queryParameters = new();
    private string? _body;
    public HttpRequestBuilder Url(string url)
    {
        _url = url;
        return this;
    }
    public HttpRequestBuilder Method(string method)
    {
        _method = method;
        return this;
    }
    public HttpRequestBuilder Header(string key, string value)
    {
        _headers[key] = value;
        return this;
    }

    public HttpRequestBuilder Query(string key, string value)
    {
        _queryParameters[key] = value;
        return this;
    }
    public HttpRequestBuilder Body(string body)
    {
        _body = body;
        return this;
    }
    public HttpRequest Build()
    {
        if (string.IsNullOrWhiteSpace(_url)) throw new InvalidOperationException("URL is required");
        
        var allowedMethods = new[] { "GET", "POST", "PUT", "DELETE", "HEAD" };
        if (!allowedMethods.Contains(_method.ToUpper())) throw new InvalidOperationException($"Unsupported method: {_method}");
        
        if ((_method.ToUpper() == "GET" || _method.ToUpper() == "HEAD") && _body is not null) throw new InvalidOperationException($"{_method} request cannot have a body");
        
        if (_headers.ContainsKey("Content-Type") && _body is null) throw new InvalidOperationException("Content-Type header requires a body");
        var request = new HttpRequest
        {
            Url = _url,
            Headers = new Dictionary<string, string>(_headers, StringComparer.OrdinalIgnoreCase),
            Method = _method,
            QueryParameters = new Dictionary<string, string>(_queryParameters),
            Body = _body
        };

        return request;
    }
    
}