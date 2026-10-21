using Exercise;

var builder = new HttpRequestBuilder()
    .Url("http://localhost:5000/echo")
    .Method("POST")
    .Header("Content-Type", "application/json")
    .Body("{}");

var r1 = builder.Build();
builder.Header("X-Test", "1");
var r2 = builder.Build();

Console.WriteLine($"r1 headers: {r1.Headers.Count}");
Console.WriteLine($"r2 headers: {r2.Headers.Count}");

if (args.Length == 0)
{
    Console.WriteLine("Usage: dotnet run --project Exercise/Exercise.csproj -- <URL>");
    return;
}

var request = new HttpRequest
{
    Url = args[0],
    Method = "POST",
    Headers = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
    {
        ["Content-Type"] = "application/json"
    },
    QueryParameters = new Dictionary<string, string>
    {
        ["preview"] = "true"
    },
    Body = "{\"product\":\"Keyboard\",\"quantity\":2}"
};

using var httpClient = new HttpClient(new HttpClientHandler { AllowAutoRedirect = false });
IClient client = new Client(httpClient);

using var response = await client.SendAsync(request);
Console.WriteLine($"Status: {(int)response.StatusCode} {response.StatusCode}");
Console.WriteLine(await response.Content.ReadAsStringAsync());
