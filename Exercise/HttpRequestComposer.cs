
namespace Exercise;

public class HttpRequestComposer
{
    private string url = "";
    private string method = "GET";
    private readonly Dictionary<string, string> headers =
        new(StringComparer.OrdinalIgnoreCase);
    private readonly Dictionary<string, string> queryParameters = new();
    private string? body;

    public HttpRequestComposer SetUrl(string url)
    {
        this.url = url;
        return this;
    }

    public HttpRequestComposer SetMethod(string method)
    {
        this.method = method;
        return this;
    }

    public HttpRequestComposer AddHeader(string name, string value)
    {
        headers[name] = value;
        return this;
    }

    public HttpRequestComposer AddQueryParameter(string name, string value)
    {
        queryParameters[name] = value;
        return this;
    }

    public HttpRequestComposer SetBody(string? body)
    {
        this.body = body;
        return this;
    }

    public HttpRequest Build()
    {
        Validate();

        return new HttpRequest
        {
            Url = url,
            Method = method,
            Headers = new Dictionary<string, string>(
                headers, StringComparer.OrdinalIgnoreCase),
            QueryParameters = new Dictionary<string, string>(
                queryParameters),
            Body = body
        };
    }

    private void Validate()
    {
        if (!Uri.TryCreate(url, UriKind.Absolute, out var uri) ||
            (uri.Scheme != Uri.UriSchemeHttp &&
             uri.Scheme != Uri.UriSchemeHttps) ||
            string.IsNullOrWhiteSpace(uri.Host))
        {
            throw new ArgumentException(
                "URL must be an absolute HTTP or HTTPS URL.");
        }

        if (string.IsNullOrWhiteSpace(method) ||
            !IsHttpToken(method))
        {
            throw new ArgumentException("Invalid HTTP method.");
        }

        foreach (var (name, value) in headers)
        {
            if (string.IsNullOrEmpty(name) ||
                !IsHttpToken(name))
            {
                throw new ArgumentException(
                    $"Invalid header name: '{name}'.");
            }

            if (value.Contains('\r') || value.Contains('\n'))
            {
                throw new ArgumentException(
                    $"Invalid header value for '{name}'.");
            }
        }

        foreach (var (name, value) in queryParameters)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(
                    "Query parameter name cannot be empty.");
            }

            if (name.Contains('\r') || name.Contains('\n') ||
                value.Contains('\r') || value.Contains('\n'))
            {
                throw new ArgumentException(
                    "Query parameter contains invalid characters.");
            }
        }
    }

    private static bool IsHttpToken(string value)
    {
        const string separators = "()<>@,;:\\\"/[]?={} \t";

        foreach (char c in value)
        {
            if (c <= 32 || c >= 127 || separators.Contains(c))
            {
                return false;
            }
        }

        return true;
    }
}
