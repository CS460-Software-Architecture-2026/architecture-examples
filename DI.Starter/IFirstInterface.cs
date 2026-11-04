using DI.Starter;

public interface IFirstInterface
{
    
}

public class FirstImplementation : IFirstInterface
{
    private ITestInterface test_instance;

    public FirstImplementation(ITestInterface test_instance)
    {
        this.test_instance = test_instance;
    }
    
    public override string ToString()
    {
        return $"First_{GetHashCode()}";
    }
}