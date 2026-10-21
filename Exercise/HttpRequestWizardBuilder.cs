namespace Exercise;

public class HttpRequestWizardBuilder : IStart, ISetMethod, IOptional, IBuild
{
    private readonly HttpRequest request = new HttpRequest();
    private HttpRequestWizardBuilder() { }
    public static IStart Create() { return new HttpRequestWizardBuilder(); }

    public ISetMethod Url(string value)
    {
        request.Url = value;
        return this;
    }

    public IOptional Method(string value)
    {
        request.Method = value;
        return this;
    }

    public IOptional Header(string name, string value)
    {
        request.Headers[name] = value;
        return this;
    }

    public IOptional QueryParameter(string name, string value)
    {
        request.QueryParameters[name] = value;
        return this;
    }

    public IOptional Body(string? value)
    {
        request.Body = value;
        return this;
    }

    public IBuild Done() { return this; }

    public HttpRequest Build()
    {
        if (!Uri.TryCreate(request.Url, UriKind.Absolute, out var uri) ||
            (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps))
        {
            throw new InvalidOperationException("A valid HTTP or HTTPS URL is required");
        }
        if (string.IsNullOrWhiteSpace(request.Method))
        {
            throw new InvalidOperationException("Method required");
        }
        return request;
    }
}
