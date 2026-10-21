using System.Reflection;

Assembly asm = Assembly.LoadFile("C:\\Users\\Misha\\RiderProjects\\architecture-examples\\Reflections.Exercise\\UserCommands.dll");

foreach (var t in asm.GetTypes())
{
    Console.WriteLine(t.FullName);
    var methods = t.GetMethods();
    foreach (var m in methods)
    {
        Console.WriteLine("     " + m.Name);
    }
    
    Console.WriteLine();
}

Console.WriteLine("Class: ");
var className = Console.ReadLine();

var classType = asm.GetType(className);
if (classType.IsClass)
{
    var instance = Activator.CreateInstance(classType);
    Console.WriteLine("Method: ");
    var methodName = Console.ReadLine();
    var method = instance.GetType().GetMethod(methodName);
    method.Invoke(instance, null);
}

// UserCommands.Commands.SumCommand
// Calculate