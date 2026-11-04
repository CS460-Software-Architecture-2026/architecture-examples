using DI.Starter;

public interface IFirstInterface
{
    
}

public class FirstImplementation : IFirstInterface
{
    private ITestImplementation test_instance;

    public FirstImplementation(ITestImplementation test_instance)
    {
        this.test_instance = test_instance;
    }
    
    public override string ToString()
    {
        return $"First_{GetHashCode()}";
    }
}