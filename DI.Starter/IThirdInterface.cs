public interface IThirdInterface
{
    
}


public class ThirdImplementation : IThirdInterface
{
    private IFirstInterface firstInterface;
    private ISecondInterface secondInterface;
    
    public ThirdImplementation(IFirstInterface firstInterface, ISecondInterface secondInterface)
    {
        this.firstInterface = firstInterface;
        this.secondInterface = secondInterface;
    }
    
    public override string ToString()
    {
        return $"Third{GetHashCode()}";
    }
}