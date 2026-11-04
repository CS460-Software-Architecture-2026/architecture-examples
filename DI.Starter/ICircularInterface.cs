public interface ICircularA
{

}

public interface ICircularB
{

}

public class CircularA : ICircularA
{
    public CircularA(ICircularB b) { }
}

public class CircularB : ICircularB
{
    public CircularB(ICircularA a) { }
}
