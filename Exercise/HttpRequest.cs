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
    private readonly HttpRequest _httpRequest =  new HttpRequest();

    public HttpRequestBuilder WithUrl(string url)
    {
        _httpRequest.Url = url;
        return this;
    }

    public HttpRequestBuilder WithMethod(string method)
    {
        _httpRequest.Method = method;
        return this;
    }

    public HttpRequestBuilder WithHeader(string key, string value)
    {
        _httpRequest.Headers.Add(key, value);
        return this;
    }

    public HttpRequestBuilder WithQueryParameter(string key, string value)
    {
        _httpRequest.QueryParameters.Add(key, value);
        return this;
    }

    public HttpRequestBuilder WithBody(string body)
    {
        _httpRequest.Body = body;
        return this;
    }

    public HttpRequest Build()
    {
        if (string.IsNullOrWhiteSpace(_httpRequest.Url)) throw new Exception("No url provided");
        if  (string.IsNullOrWhiteSpace(_httpRequest.Method)) throw new Exception("No method provided");
        if (_httpRequest.Headers.Count == 0) throw new Exception("No headers provided");
        if (_httpRequest.QueryParameters.Count == 0) throw new Exception("No query parameters provided");
        if (string.IsNullOrWhiteSpace(_httpRequest.Body)) throw new Exception("No body provided");
        return _httpRequest;
    }
}