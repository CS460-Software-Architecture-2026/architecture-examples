using DI.Core;

VerifyLifetimes(Scope.Singleton, Scope.Singleton);
VerifyLifetimes(Scope.Singleton, Scope.Transient);
VerifyLifetimes(Scope.Transient, Scope.Singleton);
VerifyLifetimes(Scope.Transient, Scope.Transient);

IDiContainer di = new DiContainer();
var instance = new FirstImplementation();
di.Register<IFirstInterface>(instance);
di.Register<ISecondInterface, SecondImplementation>(Scope.Transient);
Check(ReferenceEquals(instance, di.Resolve<IFirstInterface>()), "Registered instance is resolved");
Check(ReferenceEquals(instance, di.Resolve<ISecondInterface>().First), "Registered instance is injected");

IDiContainer circular = new DiContainer();
circular.Register<IFirstInterface, CircularFirstImplementation>(Scope.Transient);
circular.Register<ISecondInterface, SecondImplementation>(Scope.Transient);
try
{
    circular.Resolve<IFirstInterface>();
    throw new Exception("Circular dependency was not detected");
}
catch (InvalidOperationException exception)
{
    Check(exception.Message == "Circular dependency: IFirstInterface -> ISecondInterface -> IFirstInterface",
        "Circular dependency chain is reported");
    Console.WriteLine(exception.Message);
}

static void VerifyLifetimes(Scope firstScope, Scope secondScope)
{
    Console.WriteLine($"First: {firstScope}, Second: {secondScope}");
    // Predict: singletons are shared; transients are new. A singleton keeps its injected dependency.
    IDiContainer container = new DiContainer();
    container.Register<IFirstInterface, AlternativeFirstImplementation>(firstScope);
    container.Register<ISecondInterface, SecondImplementation>(secondScope);

    var first = container.Resolve<IFirstInterface>();
    var anotherFirst = container.Resolve<IFirstInterface>();
    var second = container.Resolve<ISecondInterface>();
    var anotherSecond = container.Resolve<ISecondInterface>();

    Check(second.First is AlternativeFirstImplementation, "New implementation is injected");
    Check(ReferenceEquals(first, anotherFirst) == (firstScope == Scope.Singleton), "First lifetime");
    Check(ReferenceEquals(second, anotherSecond) == (secondScope == Scope.Singleton), "Second lifetime");
    Check(ReferenceEquals(first, second.First) == (firstScope == Scope.Singleton), "Direct and injected instances");
    Check(ReferenceEquals(second.First, anotherSecond.First) ==
        (firstScope == Scope.Singleton || secondScope == Scope.Singleton), "Dependencies shared as predicted");
}

static void Check(bool condition, string message)
{
    if (!condition)
    {
        throw new Exception(message);
    }

    Console.WriteLine($"OK: {message}");
}


