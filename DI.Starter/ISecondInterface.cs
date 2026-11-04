using DI.Starter;

public interface ISecondInterface
{
    
}


public class SecondImplementation : ISecondInterface
{
    private IThirdInterface thirdInterface;
    
    public SecondImplementation(IThirdInterface thirdInterface)
    {
        this.thirdInterface = thirdInterface;
    }
    
    public override string ToString()
    {
        return $"Second_{GetHashCode()}";
    }
}
