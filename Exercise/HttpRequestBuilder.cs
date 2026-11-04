namespace Exercise;

public class HttpRequestBuilder
{
    private readonly HttpRequest request = new();
    
    public HttpRequestBuilder WithUrl(string url)
    { 
        request.Url = url;
        return this; 
    }

    public HttpRequestBuilder WithMethod(string method)
    {
        request.Method = method;
        return this;
    }

    public HttpRequestBuilder WithHeader(string key, string value)
    {
        request.Headers[key] = value;
        return this;
    }

    public HttpRequestBuilder WithHeaders(Dictionary<string, string> headers)
    {
        foreach (var header in headers)
        {
            request.Headers[header.Key] = header.Value;
        }

        return this;
    }

    public HttpRequestBuilder WithQueryParameter(string key, string value)
    {
        request.QueryParameters[key] = value;
        return this;
    }

    public HttpRequestBuilder WithQueryParameters(Dictionary<string, string> queryParameters)
    {
        foreach (var queryParameter in queryParameters)
        {
            request.QueryParameters[queryParameter.Key] = queryParameter.Value;
        }

        return this;
    }

    public HttpRequestBuilder WithBody(string body)
    {
        request.Body = body;
        return this;
    }
    
    public HttpRequest Build()
    {
        if (string.IsNullOrWhiteSpace(request.Url))
        {
            throw new InvalidOperationException("Url is required");
        }

        string[] methods = ["POST", "GET", "PUT", "DELETE", "PATCH", "HEAD", "OPTIONS"];
        if (string.IsNullOrWhiteSpace(request.Method) || !methods.Contains(request.Method.ToUpper()) )
        {
            throw new InvalidOperationException("Method is required. Please use \"POST\", \"GET\", \"PUT\", \"DELETE\", \"PATCH\", \"HEAD\", \"OPTIONS\"");
        }

        foreach (var requestQueryParameter in request.QueryParameters)
        {
            if (string.IsNullOrWhiteSpace(requestQueryParameter.Key))
            {
                throw new InvalidOperationException($"Query parameter name is required");
            }
        }

        return new HttpRequest
        {
            Url = request.Url,
            Method = request.Method.ToUpperInvariant(),
            Headers = new Dictionary<string, string>(request.Headers, StringComparer.OrdinalIgnoreCase),
            QueryParameters = new Dictionary<string, string>(request.QueryParameters),
            Body = request.Body
        };
    }
}