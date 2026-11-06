namespace DI.Starter;

public class ClassWithDependency
{
    public IFirstInterface Dependency { get; }

    public ClassWithDependency(IFirstInterface dependency)
    {
        Dependency = dependency;
        Console.WriteLine($"ClassWithDependency_{GetHashCode()} received {dependency}");
    }
}