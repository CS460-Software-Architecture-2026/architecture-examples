namespace Exercise;

public class HttpRequest
{
    internal HttpRequest() { }
    public string Url { get; internal set; } = "";
    public string Method { get; internal set; } = "GET";
    public Dictionary<string, string> Headers { get; internal set; } = new(StringComparer.OrdinalIgnoreCase);
    public Dictionary<string, string> QueryParameters { get; internal set; } = new();
    public string? Body { get; internal set; }
}

public class RequestBuilder
{
    // Робочий запит: належить лише білдеру і ніколи не виходить за його межі.
    private readonly HttpRequest request = new();

    public RequestBuilder Url(string value)
    {
        request.Url = value;
        return this;
    }

    public RequestBuilder Method(string value)
    {
        request.Method = value;
        return this;
    }

    public RequestBuilder Header(string name, string value)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(value);
        request.Headers[name] = value; // повторний виклик перезаписує значення
        return this;
    }

    public RequestBuilder Query(string name, string value)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(value);
        request.QueryParameters[name] = value;
        return this;
    }

    public RequestBuilder Body(string? value)
    {
        request.Body = value;
        return this;
    }

    public HttpRequest Build()
    {
        Validate();

        return new HttpRequest
        {
            Url = request.Url,
            Method = request.Method,
            Body = request.Body,
            Headers = new Dictionary<string, string>(request.Headers, StringComparer.OrdinalIgnoreCase),
            QueryParameters = new Dictionary<string, string>(request.QueryParameters)
        };
    }

    private void Validate()
    {
        if (string.IsNullOrWhiteSpace(request.Url))
        {
            throw new InvalidOperationException("Url is required.");
        }

        // Перевірка схеми потрібна, бо на Unix "/some/path" теж парситься як абсолютний (file://) URI.
        if (!Uri.TryCreate(request.Url, UriKind.Absolute, out var uri)
            || (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps))
        {
            throw new InvalidOperationException($"Url '{request.Url}' must be an absolute http(s) URI.");
        }

        if (string.IsNullOrWhiteSpace(request.Method))
        {
            throw new InvalidOperationException("Method is required.");
        }
    }
}
