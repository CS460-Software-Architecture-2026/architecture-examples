using System.Reflection;
using CommandContracts;

var asm = Assembly.LoadFrom("UserCommands.dll");

Console.WriteLine("=== Types in assembly ===");

foreach (var t in asm.GetTypes())
{
    var attribute = t.GetCustomAttribute<CommandAttribute>();

    if (attribute != null)
    {
        Console.WriteLine(attribute.Name);

        var executeMethods = t
            .GetMethods(BindingFlags.Public | BindingFlags.NonPublic
                | BindingFlags.Instance | BindingFlags.Static)
            .Where(m => m.GetCustomAttribute<ExecuteAttribute>() != null);

        foreach (var m in executeMethods)
        {
            Console.WriteLine($"Method: {m.Name}");
        }
    }
}