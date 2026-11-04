public interface ISecondInterface
{
    IFirstInterface First { get; }
}


public class SecondImplementation : ISecondInterface
{
    public IFirstInterface First { get; }
    
    public SecondImplementation(IFirstInterface firstInterface)
    {
        First = firstInterface;
    }
    
    public override string ToString()
    {
        return $"Second_{GetHashCode()}";
    }
}
