using System.Reflection;
using CommandContracts;

// 1. Load assembly
//    Option A: current assembly (if type is defined in same project)
// var asm = Assembly.GetExecutingAssembly();

//    Option B: by name
// Assembly asm = Assembly.Load("DemoDomain");

//    Option C: from file
Assembly asm = Assembly.LoadFrom("UserCommands.dll");

// 2. List all types
Console.WriteLine("=== Types in assembly ===");
var commands = new Dictionary<string, (Type Type, MethodInfo[] Methods)>(StringComparer.OrdinalIgnoreCase);

foreach (var t in asm.GetTypes())
{
    var command = t.GetCustomAttribute<CommandAttribute>();
    if (command is null)
        continue;

    Console.WriteLine($"Command '{command.Name}' -> {t.FullName}");

    MethodInfo[] methods = []; 
    foreach (var method in t.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
    {
        var paramList = string.Join(", ", method.GetParameters().Select(p => $"{p.ParameterType.Name} {p.Name}"));
        Console.WriteLine($"{method.ReturnType.Name} {method.Name}({paramList})");
        methods.Append(method);
    }
    
    commands[command.Name] = (t, methods);
}

Console.WriteLine($"Commands: {string.Join(", ", commands.Keys)}.");

// 3. Get specific type
// var userType = typeof(User);
// or: Type userType = asm.GetType("DemoDomain.User")!;

// 4. Inspect constructors
// Console.WriteLine("\n=== Constructors ===");
// foreach (var ctor in userType.GetConstructors())
// {
//     var paramList = string.Join(", ", ctor.GetParameters().Select(p => $"{p.ParameterType.Name} {p.Name}"));
//     Console.WriteLine($"{userType.Name}({paramList})");
// }
//
// // 5. Inspect properties
// Console.WriteLine("\n=== Properties ===");
// foreach (var prop in userType.GetProperties())
// {
//     Console.WriteLine($"{prop.PropertyType.Name} {prop.Name} (CanWrite: {prop.CanWrite})");
// }
//
// // 6. Inspect methods
// Console.WriteLine("\n=== Methods ===");
// foreach (var m in userType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
// {
//     var paramList = string.Join(", ", m.GetParameters().Select(p => $"{p.ParameterType.Name} {p.Name}"));
//     Console.WriteLine($"{m.ReturnType.Name} {m.Name}({paramList})");
// }
//
// // 7. Inspect attributes
// Console.WriteLine("\n=== Attributes ===");
// foreach (var attr in userType.GetCustomAttributes())
// {
//     Console.WriteLine(attr.GetType().Name);
// }