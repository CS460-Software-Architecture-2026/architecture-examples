namespace Exercise;

public interface IStart
{
    IMethod Url(string url);
}

public interface IMethod
{
    IHeaders Method(string method);
}

public interface IHeaders
{
    IQueryParameters Headers(Dictionary<string, string> headers);
}

public interface IQueryParameters
{
    IOptional QueryParameters(Dictionary<string, string>  queryParameters);
}

public interface IOptional
{
    IOptional Body(string body);
    IBuild Done();
}

public interface IBuild
{
    HttpRequest Build();
}

public class HttpRequestBuilder : IStart,  IMethod, IHeaders,  IQueryParameters, IOptional, IBuild
{
    private readonly HttpRequest request;
    
    private HttpRequestBuilder()
    {
        request = new HttpRequest();
        request.Url = "";
        request.Method = "GET";
        request.Headers = new(StringComparer.OrdinalIgnoreCase);
        request.QueryParameters = new();
        request.Body = null;
    }

    public static IStart Create()
    {
        return new HttpRequestBuilder();
    }

    public IMethod Url(string url)
    {
        request.Url = url;
        return this;
    }
    
    public IHeaders Method(string method)
    {
        if (method == "GET" || method == "HEAD" || method == "POST" || method == "PUT" || method == "DELETE")
        {
            request.Method = method;
        }
        else
        {
            throw new NotSupportedException($"Method {method} is not supported.");
        }

        return this;
    }
    
    public IQueryParameters Headers(Dictionary<string, string> headers)
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
    
    public IBuild Done()
    {
        return this;
    }

    public HttpRequest Build()
    {
        // validation
        return request;
    }
}