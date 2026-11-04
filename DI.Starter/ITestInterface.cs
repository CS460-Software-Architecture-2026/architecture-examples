namespace DI.Starter;

public interface ITestInterface
{
    
}

public class TestInterface : ITestInterface
{
    public override string ToString()
    {
        return $"Test_{GetHashCode()}";
    }
}