namespace DI.Starter;

public interface ITestInterface
{
    
}

public class TestImplementation : ITestInterface
{
    public override string ToString()
    {
        return $"Test_{GetHashCode()}";
    }
}