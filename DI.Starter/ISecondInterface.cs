public interface ISecondInterface
{
    
}


public class SecondImplementation : ISecondInterface
{
    public override string ToString()
    {
        return $"Second_{GetHashCode()}";
    }
}