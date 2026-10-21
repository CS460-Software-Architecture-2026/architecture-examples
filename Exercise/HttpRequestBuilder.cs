namespace Exercise;

public class HttpRequestBuilder
{
    private readonly HttpRequest request = new HttpRequest();

    public HttpRequestBuilder Url(string value)
    {
        request.Url = value;
        return this;
    }

    public HttpRequestBuilder Method(string value)
    {
        request.Method = value;
        return this;
    }

    public HttpRequestBuilder Header(string key, string value)
    {
        request.Headers[key] = value;
        return this;
    }

    public HttpRequestBuilder QueryParameter(string key, string value)
    {
        request.QueryParameters[key] = value;
        return this;
    }

    public HttpRequestBuilder Body(string? value)
    {
        request.Body = value;
        return this;
    }

    public HttpRequest Build()
    {
        return request;
    }
}