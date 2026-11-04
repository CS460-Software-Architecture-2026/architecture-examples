using Exercise;

if (args.Length == 0)
{
    Console.WriteLine("Usage: dotnet run --project Exercise/Exercise.csproj -- <URL>");
    return;
}

try
{
    new HttpRequestBuilder().WithMethod("GET").Build();
}
catch (Exception e)
{
    Console.WriteLine($"Validation: {e.Message}");
}

var builder = new HttpRequestBuilder()
    .WithUrl(args[0])
    .WithMethod("POST")
    .WithHeader("Content-Type", "application/json")
    .WithQueryParameter("preview", "true")
    .WithBody("{\"product\":\"Keyboard\",\"quantity\":2}");

var req1 = builder.Build();

builder.WithHeader("Authorization", "Bearer secret");
var req2 = builder.Build();

Console.WriteLine($"req1 headers: {req1.Headers.Count}");
Console.WriteLine($"req2 headers: {req2.Headers.Count}");

var httpClient = new HttpClient(new HttpClientHandler { AllowAutoRedirect = false });
IClient client = new Client(httpClient);

var response = await client.SendAsync(req2);
Console.WriteLine($"Status: {(int)response.StatusCode} {response.StatusCode}");
Console.WriteLine(await response.Content.ReadAsStringAsync());
