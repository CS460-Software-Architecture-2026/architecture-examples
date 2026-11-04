public interface IFirstInterface
{
    
}

public class FirstImplementation : IFirstInterface
{
    public override string ToString()
    {
        return $"First_{GetHashCode()}";
    }
}

public class AlternativeFirstImplementation : IFirstInterface
{
}

public class CircularFirstImplementation : IFirstInterface
{
    public ISecondInterface Second { get; }
    public CircularFirstImplementation(ISecondInterface secondInterface)
    {
        Second = secondInterface;
    }
}
