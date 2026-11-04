public interface IFourthInterface
{
    
}


public class FourthImplementation : IFourthInterface
{
    private IThirdInterface thirdInterface;
    private ISecondInterface secondInterface;
    
    public FourthImplementation(IThirdInterface thirdInterface, ISecondInterface secondInterface)
    {
        this.thirdInterface = thirdInterface;
        this.secondInterface = secondInterface;
    }
    
    public override string ToString()
    {
        return $"Fourth_{GetHashCode()} (inside: {thirdInterface}, {secondInterface}) ";
    }
}