using Exercise;

static string Describe(HttpRequest r) =>
    $"{r.Method} {r.Url} | headers: [{string.Join(", ", r.Headers.Select(h => $"{h.Key}={h.Value}"))}]" +
    $" | query: [{string.Join(", ", r.QueryParameters.Select(q => $"{q.Key}={q.Value}"))}] | body: {r.Body ?? "<none>"}";

// 1. Happy path: лише обов'язкові параметри (Method має значення за замовчуванням GET)
var minimal = new RequestBuilder().Url("https://example.com/api").Build();
Console.WriteLine($"[happy path] {Describe(minimal)}");

// 2. Fail: бракує обов'язкового Url
try
{
    new RequestBuilder().Method("POST").Build();
}
catch (InvalidOperationException e)
{
    Console.WriteLine($"[fail] {e.Message}");
}

// 3. Незалежність: зберігаємо незакінчену конфігурацію й двічі викликаємо Build
var draft = new RequestBuilder()
    .Url("https://example.com/api")
    .Method("POST")
    .Header("Accept", "application/json");

var first = draft.Build();
draft.Header("X-Trace", "123").Query("page", "2").Body("{}");   // змінюємо конфігурацію ПІСЛЯ першого Build
var second = draft.Build();
first.Headers["Accept"] = "text/plain";                          // міняємо вже створений запит

Console.WriteLine($"[independence] first : {Describe(first)}");
Console.WriteLine($"[independence] second: {Describe(second)}");
Console.WriteLine($"[independence] same request object? {ReferenceEquals(first, second)}");
Console.WriteLine($"[independence] same Headers object? {ReferenceEquals(first.Headers, second.Headers)}");
Console.WriteLine();

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
