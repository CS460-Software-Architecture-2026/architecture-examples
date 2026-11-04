public interface ISecondInterface
{

}


public class SecondImplementation : ISecondInterface
{
    private IFirstInterface firstInterface;
    private IThirdInterface thirdInterface;

    public SecondImplementation(IFirstInterface firstInterface, IThirdInterface thirdInterface)
    {
        this.firstInterface = firstInterface;
        this.thirdInterface = thirdInterface;
    }

    public override string ToString()
    {
        return $"Second_{GetHashCode()}";
    }
}