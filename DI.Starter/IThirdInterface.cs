namespace DI.Starter;

public interface IThirdInterface
{
    IFirstInterface First { get; }
    void SomeMethod();

}

public class ThirdImplementation : IThirdInterface
{
    public IFirstInterface First { get; }


    public ThirdImplementation(IFirstInterface first)
    {
        this.First = first;
    }


    public void SomeMethod()
    {
        Console.WriteLine(First.ToString() + " this is third implementation");
    }
}