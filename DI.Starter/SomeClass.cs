namespace DI.Starter;

public class SomeClass : ISomeClass
{
    public void Do()
    {
        Console.WriteLine("Something");
    }
}

public interface ISomeClass
{
    public void Do();
}