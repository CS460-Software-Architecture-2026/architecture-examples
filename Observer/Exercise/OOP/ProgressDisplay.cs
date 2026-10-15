namespace Observer.Exercise;

public class ProgressDisplay : IProgressObserver
{
    public void OnProgressChanged(int percentage)
    {
        Console.WriteLine($"Progress: {percentage}%");
    }
}