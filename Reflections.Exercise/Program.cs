using System.Reflection;
using CommandContracts;

// 1. Load assembly (С)
var asm = Assembly.LoadFrom("UserCommands.dll");

Console.WriteLine("=== Commands in assembly ===");
foreach (var t in asm.GetTypes())
{
    var command = t.GetCustomAttribute<CommandAttribute>();
    if (command == null)
    {
        continue;
    }
    Console.WriteLine($"Command: {command.Name}");
    
    // 9. Check attributed methods
    Console.WriteLine("\n=== Methods with [ExecuteAttribute] ===");
    var executeMethods = t
        .GetMethods(BindingFlags.Public | BindingFlags.NonPublic
            | BindingFlags.Instance | BindingFlags.Static)
        .Where(m => m.GetCustomAttribute(typeof(ExecuteAttribute)) != null);

    foreach (var m in executeMethods)
    {
        Console.WriteLine($"Method: {m.Name}");
        if (m.GetParameters().Length != 0)
        {
            continue;
        }
        
        // 8. Create instance dynamically
        Console.WriteLine("\n=== Create Instance ===");
        var instance = Activator.CreateInstance(t);
        Console.WriteLine(instance);
        
        // 9. Invoke method
        Console.WriteLine("\n=== Invoke Method ===");
        var result = m.Invoke(instance, null);
        Console.WriteLine(result);
    }
}
