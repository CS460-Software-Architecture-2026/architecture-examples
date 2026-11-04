namespace DI.Starter;

public interface ITestImplementation
{
    
}

public class TestImplementation : ITestImplementation
{
    public override string ToString()
    {
        return $"Test_{GetHashCode()}";
    }
}