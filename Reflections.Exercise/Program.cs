using System.Reflection;
using CommandContracts;

Assembly asm = Assembly.LoadFrom(Path.Combine(AppContext.BaseDirectory, "UserCommands.dll"));

foreach (var type in asm.GetTypes())
{
    Console.WriteLine($"=== Type {type.FullName}===");
    var cmd = type.GetCustomAttribute<CommandAttribute>();   
    if (cmd is null) continue;                               

    var methods = type
        .GetMethods(BindingFlags.Public | BindingFlags.NonPublic |
                    BindingFlags.Instance | BindingFlags.Static)
        .Where(m => m.GetCustomAttribute<ExecuteAttribute>() != null)  
        .Where(m => m.GetParameters().Length == 0);                    

    foreach (var m in methods)
    {
        object? instance = m.IsStatic ? null : Activator.CreateInstance(type);
        object? result = m.Invoke(instance, null);   // null = масив аргументів порожній
        Console.WriteLine($"{cmd.Name}: {result}");
    }
}


