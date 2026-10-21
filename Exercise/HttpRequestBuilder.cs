using System.Text;

namespace Exercise;

public class HttpRequestBuilder
{
    private readonly HttpRequest httpRequest = new HttpRequest();
    
    public HttpRequestBuilder Url(string url)
    {
        httpRequest.Url = url;
        return this;
    }
    
    public HttpRequestBuilder Method(string method)
    {
        httpRequest.Method = method;
        return this;
    }
    
    public HttpRequestBuilder Headers( Dictionary<string, string> headers)
    {
        httpRequest.Headers = headers;
        return this;
    }
    
    public HttpRequestBuilder QueryParameters( Dictionary<string, string> parameters)
    {
        httpRequest.QueryParameters = parameters;
        return this;
    }

    
    public HttpRequestBuilder Body(string? body)
    {
        httpRequest.Body = body;
        return this;
    }

    public HttpRequest Build()
    {
        if (string.IsNullOrWhiteSpace(httpRequest.Url))
            throw new InvalidOperationException("Url is required.");

        if (string.IsNullOrWhiteSpace(httpRequest.Method))
            throw new InvalidOperationException("Method is required.");

        return httpRequest;
    }
}
