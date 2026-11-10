namespace Exercise;

public class HttpRequest
{
    public string Url { get; }
    public string Method { get; }
    public Dictionary<string, string> Headers { get; }
    public Dictionary<string, string> QueryParameters { get; }
    public string Body { get; }

    public HttpRequest(string url, string method, Dictionary<string, string> headers, Dictionary<string, string> queryParams, string body)
    {
        Url = url;
        Method = method;
        Headers = new Dictionary<string, string>(headers);
        QueryParameters = new Dictionary<string, string>(queryParams);
        Body = body;
    }
}

public class HttpRequestBuilder
{
    private string _url = "";
    private string _method = "GET";
    private readonly Dictionary<string, string> _headers = new();
    private readonly Dictionary<string, string> _queryParams = new();
    private string _body = "";

    public HttpRequestBuilder SetUrl(string url)
    {
        _url = url;
        return this;
    }

    public HttpRequestBuilder SetMethod(string method)
    {
        _method = method;
        return this;
    }

    public HttpRequestBuilder AddHeader(string key, string value)
    {
        _headers[key] = value;
        return this;
    }

    public HttpRequestBuilder AddQueryParam(string key, string value)
    {
        _queryParams[key] = value;
        return this;
    }

    public HttpRequestBuilder SetBody(string body)
    {
        _body = body;
        return this;
    }

    public HttpRequest Build()
    {
        if (string.IsNullOrWhiteSpace(_url))
        {
            throw new InvalidOperationException("URL cannot be empty.");
        }

        var allowedMethods = new[] { "GET", "POST", "PUT", "DELETE", "PATCH" };
        if (!allowedMethods.Contains(_method.ToUpper()))
        {
            throw new InvalidOperationException($"Invalid HTTP method: {_method}");
        }

        if (_method.ToUpper() == "GET" && !string.IsNullOrWhiteSpace(_body))
        {
            throw new InvalidOperationException("GET requests should not have a body.");
        }

        return new HttpRequest(_url, _method.ToUpper(), _headers, _queryParams, _body);
    }
}