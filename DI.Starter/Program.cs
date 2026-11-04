using DI.Core;

// ---------------------------------------------------------------
// Завдання 1: нова реалізація, інжектована через конструктор
// ---------------------------------------------------------------
Console.WriteLine("=== Task 1: constructor injection ===");
{
    var di = new DiContainer();
    di.Register<IFirstInterface, FirstImplementation>(Scope.Singleton);
    di.Register<ILogger, ConsoleLogger>(Scope.Singleton);
    di.Register<ISecondInterface, SecondImplementation>(Scope.Singleton);

    var second = di.Resolve<ISecondInterface>();
    second.Logger.Log("Hello from logger injected into Second");

    Console.WriteLine($"Logger is ConsoleLogger: {second.Logger is ConsoleLogger}");
    Console.WriteLine($"Same logger as Resolve<ILogger>(): {ReferenceEquals(second.Logger, di.Resolve<ILogger>())}");
}

// ---------------------------------------------------------------
// Завдання 2а: Transient залежить від Singleton
// Прогноз: два різні Second, але First усередині — один і той самий
// ---------------------------------------------------------------
Console.WriteLine();
Console.WriteLine("=== Task 2a: Transient (Second) -> Singleton (First) ===");
{
    var di = new DiContainer();
    di.Register<IFirstInterface, FirstImplementation>(Scope.Singleton);
    di.Register<ILogger, ConsoleLogger>(Scope.Singleton);
    di.Register<ISecondInterface, SecondImplementation>(Scope.Transient);

    var s1 = di.Resolve<ISecondInterface>();
    var s2 = di.Resolve<ISecondInterface>();

    Console.WriteLine($"s1 = {s1}, s1.First = {s1.First}");
    Console.WriteLine($"s2 = {s2}, s2.First = {s2.First}");
    Console.WriteLine($"s1 == s2:             {ReferenceEquals(s1, s2)}             (expected False)");
    Console.WriteLine($"s1.First == s2.First: {ReferenceEquals(s1.First, s2.First)}  (expected True)");
}

// ---------------------------------------------------------------
// Завдання 2б: Singleton залежить від Transient (captive dependency)
// Прогноз: s1 == s2, First усередині один, а новий Resolve<IFirst> — інший
// ---------------------------------------------------------------
Console.WriteLine();
Console.WriteLine("=== Task 2b: Singleton (Second) -> Transient (First) ===");
{
    var di = new DiContainer();
    di.Register<IFirstInterface, FirstImplementation>(Scope.Transient);
    di.Register<ILogger, ConsoleLogger>(Scope.Transient);
    di.Register<ISecondInterface, SecondImplementation>(Scope.Singleton);

    var s1 = di.Resolve<ISecondInterface>();
    var s2 = di.Resolve<ISecondInterface>();
    var f = di.Resolve<IFirstInterface>();

    Console.WriteLine($"s1 = {s1}, s1.First = {s1.First}");
    Console.WriteLine($"s2 = {s2}, s2.First = {s2.First}");
    Console.WriteLine($"f  = {f}");
    Console.WriteLine($"s1 == s2:             {ReferenceEquals(s1, s2)}   (expected True)");
    Console.WriteLine($"s1.First == s2.First: {ReferenceEquals(s1.First, s2.First)}   (expected True)");
    Console.WriteLine($"s1.First == f:        {ReferenceEquals(s1.First, f)}  (expected False -> captive dependency)");
}

// ---------------------------------------------------------------
// Завдання 3: реєстрація вже створеного об'єкта
// Прогноз: у Second буде інжектовано САМЕ myFirst
// ---------------------------------------------------------------
Console.WriteLine();
Console.WriteLine("=== Task 3: Register(instance) ===");
{
    var di = new DiContainer();
    var myFirst = new FirstImplementation();
    di.Register<IFirstInterface>(myFirst);
    di.Register<ILogger, ConsoleLogger>(Scope.Singleton);
    di.Register<ISecondInterface, SecondImplementation>(Scope.Transient);

    var second = di.Resolve<ISecondInterface>();

    Console.WriteLine($"myFirst = {myFirst}, second.First = {second.First}");
    Console.WriteLine($"second.First == myFirst:           {ReferenceEquals(second.First, myFirst)}  (expected True)");
    Console.WriteLine($"Resolve<IFirstInterface>() == myFirst: {ReferenceEquals(di.Resolve<IFirstInterface>(), myFirst)}  (expected True)");
}
