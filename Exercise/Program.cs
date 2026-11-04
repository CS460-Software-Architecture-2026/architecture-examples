using Exercise;

if (args.Length == 0)
{
    Console.WriteLine("Usage: dotnet run --project Exercise/Exercise.csproj -- <URL>");
    return;
}

var request = new HttpRequestBuilder()
    .WithUrl(args[0])
    .WithMethod("POST")
    .WithHeader("Content-Type", "application/json")
    .WithQueryParameter("preview", "true")
    .WithBody("{\"product\":\"Keyboard\",\"quantity\":2}")
    .Build();

using var httpClient = new HttpClient(new HttpClientHandler { AllowAutoRedirect = false });
IClient client = new Client(httpClient);

using var response = await client.SendAsync(request);
Console.WriteLine($"Status: {(int)response.StatusCode} {response.StatusCode}");
Console.WriteLine(await response.Content.ReadAsStringAsync());
