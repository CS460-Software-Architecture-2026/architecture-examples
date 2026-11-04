using DI.Starter;

public interface ISecondInterface
{
    void RunSomething();
}


public class SecondImplementation : ISecondInterface
{
    private IFirstInterface firstInterface;
    private ISomeClass someClass;
    
    public SecondImplementation(IFirstInterface firstInterface, ISomeClass someClass)
    {
        this.firstInterface = firstInterface;
        this.someClass = someClass;
    }

    public void RunSomething()
    {
        someClass.Do();
    }

    public override string ToString()
    {
        return $"Second_{GetHashCode()} - First_{firstInterface}";
    }
}