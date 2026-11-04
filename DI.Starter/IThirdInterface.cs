public interface IThirdInterface
{
    ISecondInterface Second { get; }
}

public class ThirdImplementation : IThirdInterface
{
    public ISecondInterface Second { get; }

    public ThirdImplementation(ISecondInterface second)
    {
        Second = second;
    }
}

public class ThirdConsumer
{
    public IThirdInterface Third { get; }

    public ThirdConsumer(IThirdInterface third)
    {
        Third = third;
    }
}
