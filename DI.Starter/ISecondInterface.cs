public interface ISecondInterface
{
    
}


public class SecondImplementation : ISecondInterface
{
    private readonly IFirstInterface firstInterface;
    
    public SecondImplementation(IFirstInterface firstInterface)
    {
        this.firstInterface = firstInterface;
    }

    public IFirstInterface FirstInterface => firstInterface;
    
    public override string ToString()
    {
        return $"Second_{GetHashCode()}";
    }
}