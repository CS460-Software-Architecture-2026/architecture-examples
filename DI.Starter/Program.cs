using DI.Core;

var di = new DiContainer();
di.Register<IFirstInterface, FirstImplementation>(Scope.Transient);
di.Register<IPrinter, ConsolePrinter>(Scope.Singleton);
di.Register<ISecondInterface, SecondImplementation>(Scope.Singleton);

Console.WriteLine("Task 1: constructor injection");
var first = di.Resolve<IFirstInterface>();
first.Print("Resolved FirstImplementation is using its injected printer.");

Console.WriteLine();
Console.WriteLine("Task 2: transient and singleton lifetimes");

var transient1 = di.Resolve<IFirstInterface>();
var transient2 = di.Resolve<IFirstInterface>();
Console.WriteLine($"Two transient resolutions are different: {!ReferenceEquals(transient1, transient2)}");
Console.WriteLine($"Those transient instances share the singleton printer: " +
    $"{ReferenceEquals(((FirstImplementation)transient1).Printer, ((FirstImplementation)transient2).Printer)}");

var singleton1 = (SecondImplementation)di.Resolve<ISecondInterface>();
var singleton2 = (SecondImplementation)di.Resolve<ISecondInterface>();
Console.WriteLine($"Two singleton resolutions are the same: {ReferenceEquals(singleton1, singleton2)}");
Console.WriteLine($"The singleton keeps the same transient dependency: " +
    $"{ReferenceEquals(singleton1.FirstInterface, singleton2.FirstInterface)}");
