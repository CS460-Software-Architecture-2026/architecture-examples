using System.Reflection;
using CommandContracts;

namespace Reflections.Exercise;

class Program
{
    private record CommandInfo(Type ClassType, MethodInfo Method, string Description);

    static void Main(string[] args)
    {
        string dllPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "UserCommands.dll");

        if (!File.Exists(dllPath))
        {
            dllPath = "UserCommands.dll";
        }

        if (!File.Exists(dllPath))
        {
            Console.WriteLine($"[Error] Could not find {dllPath}");
            return;
        }

        Assembly userCommandsAsm = Assembly.LoadFrom(dllPath);
        var commandRegistry = RegisterCommands(userCommandsAsm);

        Console.WriteLine($"Successfully loaded {commandRegistry.Count} commands.");
        Console.WriteLine("Type 'help' for available commands or 'exit' to quit.\n");

        while (true)
        {
            Console.Write("> ");
            string? input = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(input))
                continue;

            if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                break;

            if (input.Equals("help", StringComparison.OrdinalIgnoreCase))
            {
                ShowHelp(commandRegistry);
                continue;
            }

            ExecuteCommand(input, commandRegistry);
        }
    }

    private static Dictionary<string, CommandInfo> RegisterCommands(Assembly asm)
    {
        var registry = new Dictionary<string, CommandInfo>(StringComparer.OrdinalIgnoreCase);

        foreach (var type in asm.GetTypes())
        {
            var commandAttr = type.GetCustomAttribute<CommandAttribute>();
            if (commandAttr == null) continue;

            var executeMethod = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static)
                .FirstOrDefault(m => m.GetCustomAttribute<ExecuteAttribute>() != null);

            if (executeMethod != null)
            {
                string commandName = commandAttr.Name;
                registry[commandName] = new CommandInfo(type, executeMethod, $"Command: {commandName}");
            }
        }

        return registry;
    }

    private static void ExecuteCommand(string input, Dictionary<string, CommandInfo> registry)
    {

        string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string cmdName = parts[0];
        string[] rawArgs = parts.Skip(1).ToArray();

        if (!registry.TryGetValue(cmdName, out var cmdInfo))
        {
            Console.WriteLine($"Unknown command: '{cmdName}'. Type 'help' to see all commands.");
            return;
        }

        try
        {
            var parameters = cmdInfo.Method.GetParameters();

            if (parameters.Length != rawArgs.Length)
            {
                Console.WriteLine($"[Error] Command '{cmdName}' expects {parameters.Length} arguments, but got {rawArgs.Length}.");
                return;
            }

            object[] convertedArgs = new object[parameters.Length];
            for (int i = 0; i < parameters.Length; i++)
            {
                convertedArgs[i] = Convert.ChangeType(rawArgs[i], parameters[i].ParameterType);
            }

            object? instance = cmdInfo.Method.IsStatic ? null : Activator.CreateInstance(cmdInfo.ClassType);
            cmdInfo.Method.Invoke(instance, convertedArgs);
        }
        catch (Exception ex)
        {
            Exception inner = ex.InnerException ?? ex;
            Console.WriteLine($"[Execution Error] {inner.Message}");
        }
    }

    private static void ShowHelp(Dictionary<string, CommandInfo> registry)
    {
        Console.WriteLine("\n=== Available Commands ===");
        foreach (var (name, info) in registry)
        {
            var paramsList = string.Join(", ", info.Method.GetParameters().Select(p => $"{p.ParameterType.Name} {p.Name}"));
            Console.WriteLine($"  - {name} ({paramsList})");
        }
        Console.WriteLine();
    }
}