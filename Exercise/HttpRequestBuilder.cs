
namespace Exercise;

public class HttpRequestBuilder
{
    private HttpRequest _request = new();
    private HttpRequest? _saved;
    private Stack<HttpRequest> _history = new();

    private void Remember()
    {
        _history.Push(Copy(_request));
    }

    public HttpRequestBuilder WithUrl(string url)
    {
        Remember();
        _request.Url = url;
        return this;
    }

    public HttpRequestBuilder WithMethod(string method)
    {
        Remember();
        _request.Method = method;
        return this;
    }

    public HttpRequestBuilder WithHeader(string key, string value)
    {
        Remember();
        _request.Headers[key] = value;
        return this;
    }

    public HttpRequestBuilder WithQueryParameter(string key, string value)
    {
        Remember();
        _request.QueryParameters[key] = value;
        return this;
    }

    public HttpRequestBuilder WithBody(string? body)
    {
        Remember();
        _request.Body = body;
        return this;
    }

    
    public HttpRequest Build()
    {
        if (_request.Url == "")
        {
            throw new Exception("URL is empty");
        }

        if (_request.Method == "")
        {
            throw new Exception("Method is empty");
        }

        return Copy(_request);
    }


    public void Save()
    {
        _saved = Copy(_request);
    }

    public void Restore()
    {
        if (_saved == null)
            throw new InvalidOperationException("Nothing saved");

        Remember();
        _request = Copy(_saved);
    }

    public void Undo()
    {
        if (_history.Count == 0)
            throw new InvalidOperationException("Nothing to undo");

        _request = _history.Pop();
    }

    private static HttpRequest Copy(HttpRequest request)
    {
        return new HttpRequest
        {
            Url = request.Url,
            Method = request.Method,
            Headers = new Dictionary<string, string>(
                request.Headers, StringComparer.OrdinalIgnoreCase),
            QueryParameters = new Dictionary<string, string>(
                request.QueryParameters),
            Body = request.Body
        };
    }
}
