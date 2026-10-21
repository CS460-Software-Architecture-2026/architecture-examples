namespace Exercise;

public enum HttpMethodType
{
    Get,
    Post,
    Put,
    Update,
    Delete
}

public class HttpRequestBuilder : IStart, ISetMethod, ISetHeaders, ISetQueryParameters, ISetBody, IBuild
{
    private readonly HttpRequest request = new HttpRequest();
    public HttpRequestBuilder() {}
    public static IStart Create() { return new HttpRequestBuilder(); }

    
    
    public ISetMethod Url(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        request.Url = value;
        return this;
    }

    public ISetHeaders Method(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        if (!Enum.TryParse<HttpMethodType>(value, ignoreCase: true, out var method) || !Enum.IsDefined(method))
        {
            throw new ArgumentException($"There is no such method: {value}");
        }

        request.Method = method.ToString().ToUpperInvariant();
        return this;
    }

    public ISetQueryParameters Headers(Dictionary<string, string> value)
    {
        ArgumentNullException.ThrowIfNull(value);
        foreach (var (name, headerValue) in value)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            if (name.Any(char.IsWhiteSpace) || name.Contains(':'))
            {
                throw new ArgumentException($"Invalid header name: '{name}'");
            }
            if (headerValue is null || headerValue.Contains('\r') || headerValue.Contains('\n'))
            {
                throw new ArgumentException($"Invalid value for header '{name}'");
            }

            request.Headers[name] = headerValue;
        }

        return this;
    }

    public ISetBody QueryParameters(Dictionary<string, string> value)
    {
        ArgumentNullException.ThrowIfNull(value);
        foreach (var (name, paramValue) in value)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            if (paramValue is null)
            {
                throw new ArgumentException($"Query parameter '{name}' has no value");
            }

            request.QueryParameters[name] = paramValue;
        }

        return this;
    }

    public IBuild Body(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        request.Body = value;
        return this;
    }

    public IBuild Done()
    {
        return this;
    }

    public HttpRequest Build()
    {
        if (string.IsNullOrWhiteSpace(request.Url))
        {
            throw new InvalidOperationException("Url required");
        }

        bool hasBody = request.Body is not null;
        bool hasContentType = request.Headers.ContainsKey("Content-Type");

        if (hasContentType && !hasBody)
        {
            throw new InvalidOperationException("Content-Type header set but request has no body");
        }

        if (hasBody && (request.Method == "GET" || request.Method == "DELETE"))
        {
            throw new InvalidOperationException($"{request.Method} request must not have a body");
        }

        if (hasBody && !hasContentType)
        {
            throw new InvalidOperationException("Request with a body requires a Content-Type header");
        }

        return request;
    }
}