using System.Reflection;
using CommandContracts;

var asm = Assembly.LoadFrom(Path.Combine(AppContext.BaseDirectory, "UserCommands.dll"));

Console.WriteLine("=== Types in assembly ===");
foreach (var t in asm.GetTypes())
{
    Console.WriteLine(t.FullName);
}

Console.WriteLine("\n=== Commands ===");
foreach (var t in asm.GetTypes())
{
    var cmd = t.GetCustomAttribute<CommandAttribute>();
    Console.WriteLine($"{t.Name}: {(cmd is null ? "NOT a command" : $"command '{cmd.Name}'")}");

    var methods = t.GetMethods(BindingFlags.Public | BindingFlags.NonPublic
                             | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly);
    foreach (var m in methods)
    {
        var isExecute = m.GetCustomAttribute<ExecuteAttribute>() is not null;
        var parameters = string.Join(", ", m.GetParameters().Select(p => $"{p.ParameterType.Name} {p.Name}"));
        Console.WriteLine($"    {(isExecute ? "[Execute] " : "")}{(m.IsStatic ? "static " : "")}{(m.IsPublic ? "public" : "private")} {m.ReturnType.Name} {m.Name}({parameters})");
    }
}

Console.WriteLine("\n=== Invoke Method ===");
var type = asm.GetType("UserCommands.Commands.HeartbeatCommand")!;
var method = type.GetMethod("Check")!;

try
{
    var instance = Activator.CreateInstance(type);
    var result = method.Invoke(instance, null);
    Console.WriteLine(result);
}
catch (TargetInvocationException ex)
{
    Console.WriteLine($"Error: {ex.InnerException?.Message}");
}