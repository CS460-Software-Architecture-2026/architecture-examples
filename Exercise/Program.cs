using Exercise;

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
