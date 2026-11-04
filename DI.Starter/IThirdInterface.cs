namespace DI.Starter;

public interface IThirdInterface
{
    
}

public class ThirdImplementation : IThirdInterface
{
    private IFirstInterface firstInterface;

    public ThirdImplementation(IFirstInterface firstInterface)
    {
        this.firstInterface = firstInterface;
    }
    
    public override string ToString()
    {
        return $"Third_{GetHashCode()}";
    }
}
