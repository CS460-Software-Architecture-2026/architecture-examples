namespace Exercise;
// Step interfaces
public interface ISetUrl
{
    ISetMethod Url(string value);
}

public interface ISetMethod
{
    IOptional Method(string value);
    IOptional Get();
}

public interface IOptional
{
    IOptional Header(string name, string value);
    IOptional Query(string name, string value);
    IOptional Body(string text);
    IBuild Done();
}

public interface IBuild
{
    HttpRequest Build();
}

public class HttpRequestBuilder : ISetUrl, ISetMethod, IOptional, IBuild
{
    private readonly HttpRequest request = new();

    private HttpRequestBuilder()
    {
    }

    public static ISetUrl Create()
    {
        return new HttpRequestBuilder();
    }

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

    public IOptional Get()
    {
        request.Method = "GET";
        return this;
    }

    public IOptional Header(string name, string value)
    {
        request.Headers[name] = value;
        return this;
    }

    public IOptional Query(string name, string value)
    {
        request.QueryParameters[name] = value;
        return this;
    }

    public IOptional Body(string text)
    {
        request.Body = text;
        return this;
    }

    public IBuild Done()
    {
        return this;
    }

    public HttpRequest Build()
    {
        return request;
    }
}