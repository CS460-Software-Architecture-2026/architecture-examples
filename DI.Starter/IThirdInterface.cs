public interface IThirdInterface
{
    
}
public class ThirdImplementation : IThirdInterface
{
    public override string ToString()
    {
        return $"Third_{GetHashCode()}";
    }
}