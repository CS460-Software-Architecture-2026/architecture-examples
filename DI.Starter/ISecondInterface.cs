public interface ISecondInterface
{
    public IFirstInterface First { get; }
}


public class SecondImplementation : ISecondInterface
{
    public IFirstInterface First { get; }
    public SecondImplementation(IFirstInterface firstInterface)
    {
        this.First = firstInterface;
    }
    
    public override string ToString()
    {
        return $"Second_{GetHashCode()}";
    }
    
}