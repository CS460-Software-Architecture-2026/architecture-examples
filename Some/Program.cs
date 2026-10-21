using System.Reflection;
using CommandContracts;

Assembly asm = Assembly.LoadFrom("Command.Contracts.dll");


Console.WriteLine("=== Types in assembly ===");
foreach (var t in asm.GetTypes())
{
    Console.WriteLine(t.FullName);
}

// 3. Get specific type
var commandAType = typeof(CommandAttribute); 
var executeAType = typeof(ExecuteAttribute);
//
// // 4. Inspect constructors
Console.WriteLine("\n=== Constructors ===");
foreach (var ctor in commandAType.GetConstructors())
{
    var paramList = string.Join(", ", ctor.GetParameters().Select(p => $"{p.ParameterType.Name} {p.Name}"));
    Console.WriteLine($"{commandAType.Name}({paramList})");
}
foreach (var ctor in executeAType.GetConstructors())
{
    var paramList = string.Join(", ", ctor.GetParameters().Select(p => $"{p.ParameterType.Name} {p.Name}"));
    Console.WriteLine($"{executeAType.Name}({paramList})");
}

// 5. Inspect properties
Console.WriteLine("\n=== Properties ===");
foreach (var prop in commandAType.GetProperties())
{
    Console.WriteLine($"{prop.PropertyType.Name} {prop.Name} (CanWrite: {prop.CanWrite})");
}
foreach (var prop in executeAType.GetProperties())
{
    Console.WriteLine($"{prop.PropertyType.Name} {prop.Name} (CanWrite: {prop.CanWrite})");
}
//
// 6. Inspect methods
Console.WriteLine("\n=== Methods ===");
foreach (var m in commandAType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
{
    var paramList = string.Join(", ", m.GetParameters().Select(p => $"{p.ParameterType.Name} {p.Name}"));
    Console.WriteLine($"{m.ReturnType.Name} {m.Name}({paramList})");
}
foreach (var m in executeAType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
{
    var paramList = string.Join(", ", m.GetParameters().Select(p => $"{p.ParameterType.Name} {p.Name}"));
    Console.WriteLine($"{m.ReturnType.Name} {m.Name}({paramList})");
}
//
// 7. Inspect attributes
Console.WriteLine("\n=== Attributes ===");
foreach (var attr in commandAType.GetCustomAttributes())
{
    Console.WriteLine(attr.GetType().Name);
}
foreach (var attr in executeAType.GetCustomAttributes())
{
    Console.WriteLine(attr.GetType().Name);
}
//
// // 8. Create instance dynamically
Console.WriteLine("\n=== Create Instance ===");
var instance1 = Activator.CreateInstance(commandAType, "some")!;
Console.WriteLine(instance1);
// var instance2 = Activator.CreateInstance()!;
// Console.WriteLine(instance2);


// 9. Invoke method
Console.WriteLine("\n=== Invoke Method ===");
var greetMethod1 = commandAType.GetMethod("Greet");
greetMethod1!.Invoke(instance1, null);
// var greetMethod2 = executeAType.GetMethod("Greet");
// greetMethod2!.Invoke(instance2, null);
//
// 9. Check attributed methods
// Console.WriteLine("\n=== Methods with [ObsoleteMethodAttribute] ===");
// var executeMethods1 = commandAType               
//     .GetMethods(BindingFlags.Public | BindingFlags.NonPublic 
//         | BindingFlags.Instance | BindingFlags.Static)
//     .Where(m => m.GetCustomAttribute(typeof(ObsoleteMethodAttribute)) != null);
//
// foreach (var m in executeMethods1)
// {
//     Console.WriteLine($"Method: {m.Name}");
// }
//
// var executeMethods2 = executeAType               
//     .GetMethods(BindingFlags.Public | BindingFlags.NonPublic 
//                                     | BindingFlags.Instance | BindingFlags.Static)
//     .Where(m => m.GetCustomAttribute(typeof(ObsoleteMethodAttribute)) != null);
//
// foreach (var m in executeMethods2)
// {
//     Console.WriteLine($"Method: {m.Name}");
// }