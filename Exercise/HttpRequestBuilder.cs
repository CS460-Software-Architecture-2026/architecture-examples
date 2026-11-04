namespace Exercise;

public class HttpRequestBuilder
{
    private string url = "";
    private string method = "GET";
    private readonly Dictionary<string, string> headers = new(StringComparer.OrdinalIgnoreCase);
    private readonly Dictionary<string, string> queryParameters = new();
    private string? body;

    public HttpRequestBuilder WithUrl(string value)
    {
        url = value;
        return this;
    }

    public HttpRequestBuilder WithMethod(string value)
    {
        method = value;
        return this;
    }

    public HttpRequestBuilder WithHeader(string name, string value)
    {
        headers[name] = value;
        return this;
    }

    public HttpRequestBuilder WithQueryParameter(string name, string value)
    {
        queryParameters[name] = value;
        return this;
    }

    public HttpRequestBuilder WithBody(string? value)
    {
        body = value;
        return this;
    }

    public HttpRequest Build()
    {
        if (!Uri.TryCreate(url, UriKind.Absolute, out var uri)
            || (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps)
            || string.IsNullOrEmpty(uri.Host))
        {
            throw new InvalidOperationException("URL must be an absolute HTTP or HTTPS address with a host.");
        }

        if (!IsToken(method))
        {
            throw new InvalidOperationException("HTTP method must be a non-empty HTTP token.");
        }

        foreach (var header in headers)
        {
            if (!IsToken(header.Key) || header.Value is null
                || header.Value.Any(character => char.IsControl(character) && character != '\t'))
            {
                throw new InvalidOperationException($"Invalid HTTP header: '{header.Key}'.");
            }

        }

        if (queryParameters.Any(parameter => parameter.Value is null))
        {
            throw new InvalidOperationException("Query parameter values cannot be null.");
        }

        return new HttpRequest
        {
            Url = url,
            Method = method,
            Headers = new Dictionary<string, string>(headers, headers.Comparer),
            QueryParameters = new Dictionary<string, string>(queryParameters),
            Body = body
        };
    }

    private static bool IsToken(string? value)
    {
        return !string.IsNullOrEmpty(value)
            && value.All(character => char.IsAsciiLetterOrDigit(character)
                || "!#$%&'*+-.^_`|~".Contains(character));
    }
}
