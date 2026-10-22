namespace Exercise;

public class HttpRequestBuilder
{
    private HttpRequest current = new();
    private readonly Stack<HttpRequest> history = new();

    private HttpRequestBuilder Change(Action<HttpRequest> change)
    {
        history.Push(Copy(current));
        change(current);
        return this;
    }

    public HttpRequestBuilder Url(string url) => Change(r => r.Url = url);

    public HttpRequestBuilder Method(string method) => Change(r => r.Method = method);

    public HttpRequestBuilder Header(string name, string value) => Change(r => r.Headers[name] = value);

    public HttpRequestBuilder QueryParameter(string name, string value) => Change(r => r.QueryParameters[name] = value);

    public HttpRequestBuilder Body(string? body) => Change(r => r.Body = body);

    public HttpRequest Build()
    {
        Validate(current);
        return Save();
    }

    public HttpRequest Save() => Copy(current);

    public HttpRequestBuilder Restore(HttpRequest snapshot)
    {
        history.Push(Copy(current));
        current = Copy(snapshot);
        return this;
    }

    public HttpRequestBuilder Undo()
    {
        if (history.Count != 0) current = history.Pop();
        return this;
    }

    private static void Validate(HttpRequest request)
    {
        if (!Uri.TryCreate(request.Url, UriKind.Absolute, out var uri) || (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps)) 
            throw new InvalidOperationException($"URL '{request.Url}' must be an absolute http or https URL.");

        if (string.IsNullOrWhiteSpace(request.Method))
            throw new InvalidOperationException("Method must not be empty.");

        if (request.Body is not null && (request.Method.Equals("GET", StringComparison.OrdinalIgnoreCase) || request.Method.Equals("HEAD", StringComparison.OrdinalIgnoreCase)))
            throw new InvalidOperationException($"{request.Method} requests must not have a body.");

        if (request.Body is null && request.Headers.ContainsKey("Content-Type"))
            throw new InvalidOperationException("Header 'Content-Type' requires a body.");
    }

    private static HttpRequest Copy(HttpRequest request)
    {
        return new HttpRequest
        {
            Url = request.Url,
            Method = request.Method,
            Headers = new Dictionary<string, string>(request.Headers, StringComparer.OrdinalIgnoreCase),
            QueryParameters = new Dictionary<string, string>(request.QueryParameters),
            Body = request.Body
        };
    }
}
