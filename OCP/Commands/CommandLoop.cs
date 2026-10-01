namespace OCP.Commands;

public class CommandLoop
{
    public void Run()
    {
        while (true)
        {
            Console.Write("> ");
            var input = Console.ReadLine();
            if (input == null)
            {
                return;
            }

            var parts = input.Split((char[]?)null, 2,
                StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            if (parts.Length == 0)
            {
                continue;
            }

            var arguments = parts.Length > 1 ? parts[1] : "";
            // Every new command requires editing this loop.
            switch (parts[0].ToLowerInvariant())
            {
                case "/echo":
                    Console.WriteLine(arguments);
                    break;
                case "/time":
                    Console.WriteLine($"UTC: {DateTimeOffset.UtcNow:HH:mm:ss}");
                    break;
                case "/exit":
                    return;
                default:
                    Console.WriteLine("Unknown command.");
                    break;
            }
        }
    }
}
