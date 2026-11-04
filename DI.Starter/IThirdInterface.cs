namespace DI.Starter;

public interface IThirdInterface
{
    
}

public class ThirdImplementation(ISecondInterface secondInterface) : IThirdInterface
{
    private ISecondInterface secondInterface = secondInterface;

    public override string ToString()
    {
        return $"Third_{GetHashCode()}";
    }
}