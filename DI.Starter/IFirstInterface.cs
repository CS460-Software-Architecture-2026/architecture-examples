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