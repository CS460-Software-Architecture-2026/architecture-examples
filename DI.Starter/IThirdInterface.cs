namespace DI.Starter;

public interface IThirdInterface
{
    ISecondInterface Dependency { get; }
}

public class ThirdImplementation : IThirdInterface
{
    public ISecondInterface Dependency { get; }
    
    public ThirdImplementation(ISecondInterface secondInterface)
    {
        Dependency = secondInterface;
    }
    public override string ToString()
    {
        return $"Third_{GetHashCode()}";
    }
}
