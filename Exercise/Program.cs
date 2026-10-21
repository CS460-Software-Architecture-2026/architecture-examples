using Exercise;

var composer = new HttpRequestComposer()
    .SetUrl("https://example.com/products")
    .SetMethod("POST")
    .AddHeader("Content-Type", "application/json")
    .AddQueryParameter("preview", "true")
    .SetBody("{\"product\":\"Keyboard\",\"quantity\":2}");

var request = composer.Build();

Console.WriteLine(request.Method);
Console.WriteLine(request.Url);
Console.WriteLine(request.Headers["Content-Type"]);
Console.WriteLine(request.QueryParameters["preview"]);
Console.WriteLine(request.Body);

try
{
    new HttpRequestComposer()
        .SetUrl("not-a-url")
        .SetMethod("GET")
        .Build();
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Validation error: {ex.Message}");
}