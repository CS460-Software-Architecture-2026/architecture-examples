namespace Exercise;


public class HttpRequestBuilderWizard : IStart, ISetMethod, IOptional, IHttpRequestBuilder
{
    private readonly HttpRequest request = new HttpRequest();

    private HttpRequestBuilderWizard() { }

    public static IStart Create() { return new HttpRequestBuilderWizard(); }


    public IOptional Headers(Dictionary<string, string> headers)
    {
        request.Headers = headers;
        return this;
    }

    public IOptional QueryParameters(Dictionary<string, string> queryParameters)
    {
        request.QueryParameters = queryParameters;
        return this;
    }

    public IOptional Body(string body)
    {
        request.Body = body;
        return this;
    }

    public IHttpRequestBuilder Done() { return this; }
    

    public ISetMethod Url(string url)
    {
        request.Url = url;
        return this;
    }

    public IOptional Method(string method)
    {
        request.Method = method;
        return this;
    }

    HttpRequest IHttpRequestBuilder.Build()
    {
        // no validation here??
        return new HttpRequest(){Url = request.Url,
            Method = request.Method,
            Headers = new Dictionary<string, string>(request.Headers, StringComparer.OrdinalIgnoreCase),
            QueryParameters = new Dictionary<string, string>(request.QueryParameters),
            Body = request.Body,
            
        };
    }
}