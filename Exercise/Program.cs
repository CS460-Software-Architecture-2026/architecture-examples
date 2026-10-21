using Exercise;

if (args.Length == 0)
{
    Console.WriteLine("Usage: dotnet run --project Exercise/Exercise.csproj -- <URL>");
    return;
}

var request = HttpRequestWizardBuilder.Create()
    .Url(args[0])
    .Method("POST")
    .Header("Content-Type", "application/json")
    .QueryParameter("preview", "true")
    .Body("{\"product\":\"Keyboard\",\"quantity\":2}")
    .Done()
    .Build();

using var httpClient = new HttpClient(new HttpClientHandler { AllowAutoRedirect = false });
IClient client = new Client(httpClient);

using var response = await client.SendAsync(request);
Console.WriteLine($"Status: {(int)response.StatusCode} {response.StatusCode}");
Console.WriteLine(await response.Content.ReadAsStringAsync());
